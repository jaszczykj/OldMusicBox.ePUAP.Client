using Microsoft.VisualStudio.TestTools.UnitTesting;
using OldMusicBox.ePUAP.Client.Model.FileRepoService;
using OldMusicBox.ePUAP.Client.Request;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldMusicBox.ePUAP.Tests
{
    /// <summary>
    /// WS-FileRepoService tests
    /// </summary>
    [TestClass]
    public class FileRepoServiceTests
    {
        [TestMethod]
        public void UploadFileRequest_Valid()
        {
            // arrange
            var file = "test.pdf";

            var request = new UploadFileRequest()
            {
                File = Convert.ToBase64String(File.ReadAllBytes(file)),
                Filename = Path.GetFileNameWithoutExtension(file),
                MimeType = "application/pdf",
                Subject = "IDpodmiotu"
            };

            var requestFactory = new RequestFactory(new TestCertProvider().GetClientCertificate());

            // act
            string requestString = requestFactory.CreateRequest(request);

            // assert

            Assert.IsNotNull(requestString);
        }

        [TestMethod]
        public void DownloadFileRequest_Valid()
        {
            // arrange
            var file = @"https://epuap.gov.pl/file-download-servlet/DownloadServlet?fileId=123123123";

            var request = new DownloadFileRequest()
            {
                FileId = file,
                Subject = "IdPodmiotu"
            };

            var requestFactory = new RequestFactory(new TestCertProvider().GetClientCertificate());

            // act
            string requestString = requestFactory.CreateRequest(request);

            // assert

            Assert.IsNotNull(requestString);
        }
    }
}
