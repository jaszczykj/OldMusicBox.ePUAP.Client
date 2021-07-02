using Microsoft.VisualStudio.TestTools.UnitTesting;
using OldMusicBox.ePUAP.Client.Model.FileRepoService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml;

namespace OldMusicBox.ePUAP.Tests
{
    /// <summary>
    /// MTOM tests
    /// </summary>
    [TestClass]
    public class MTOMTest
    {
        [TestMethod]
        public void MTOM()
        {
            var file = @"test.pdf";
            Envelope myEnvelope = new Envelope() { Body = new Body() { DownloadFileResponse = new DownloadFileResponse() { File = File.ReadAllBytes(file), Filename = Path.GetFileName(file), MimeType = MimeMapping.GetMimeMapping(file) } } };

            MemoryStream MTOMInMemory = new MemoryStream();
            XmlDictionaryWriter TW = XmlDictionaryWriter.CreateMtomWriter(MTOMInMemory, Encoding.UTF8, Int32.MaxValue, "");
            DataContractSerializer DCS = new DataContractSerializer(myEnvelope.GetType());
            DCS.WriteObject(TW, myEnvelope);
            TW.Flush();
            //write MIME
            var mime = MTOMInMemory.ToArray();
            var mimeFile = Path.Combine(Path.GetTempPath(), $"{Path.GetFileNameWithoutExtension(file)}.mime");
            File.WriteAllBytes(mimeFile, mime);
            var mimeString = Encoding.UTF8.GetString(mime);
            //Console.WriteLine(mimeString);

            //deserialize
            MTOMInMemory = new MemoryStream(File.ReadAllBytes(mimeFile));
            XmlDictionaryReader TR = XmlDictionaryReader.CreateMtomReader(MTOMInMemory, Encoding.UTF8, XmlDictionaryReaderQuotas.Max);
            Envelope myEnvelope2 = new Envelope();
            myEnvelope2 = (Envelope)DCS.ReadObject(TR);
            File.WriteAllBytes(Path.Combine(Path.GetTempPath(), myEnvelope2.Body.DownloadFileResponse.Filename), myEnvelope2.Body.DownloadFileResponse.File);
            Assert.IsTrue(StructuralComparisons.StructuralEqualityComparer.Equals(myEnvelope.Body.DownloadFileResponse.File, myEnvelope2.Body.DownloadFileResponse.File));
        }
    }
}
