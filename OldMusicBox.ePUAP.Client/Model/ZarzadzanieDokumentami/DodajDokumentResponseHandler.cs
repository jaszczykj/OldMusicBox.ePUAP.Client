using OldMusicBox.ePUAP.Client.Constants;
using OldMusicBox.ePUAP.Client.Model.Common;
using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace OldMusicBox.ePUAP.Client.Model.ZarzadzanieDokumentami
{
    /// <summary>
    /// DodajDokument response handler
    /// </summary>
    public class DodajDokumentResponseHandler :
        BaseServiceResponseHandler,
        IServiceResponseHandler<DodajDokumentResponse>
    {
        public DodajDokumentResponse FromSOAP(string soapResponse, out FaultModel fault)
        {
            return FromSOAP_Template<DodajDokumentResponse>(soapResponse, out fault);
        }

        public DodajDokumentResponse FromSOAP(byte[] soapResponse, string content_typeResponse, out FaultModel fault)
        {
            throw new NotImplementedException();
        }

        protected override void AddManagerNamespaces(XmlNamespaceManager manager)
        {
            manager.AddNamespace("soapenv", Namespaces.SOAPENVELOPE);
            manager.AddNamespace("p521", Namespaces.ZARZADZANIEDOKUMENTAMI);
        }

        protected override string GetResponseXPath()
        {
            return "//soapenv:Envelope/soapenv:Body/p521:dodajDokumentResponse";
        }
    }
}
