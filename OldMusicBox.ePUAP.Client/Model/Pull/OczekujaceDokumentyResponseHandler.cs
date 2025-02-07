﻿using OldMusicBox.ePUAP.Client.Constants;
using OldMusicBox.ePUAP.Client.Model.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace OldMusicBox.ePUAP.Client.Model.Pull
{
    /// <summary>
    /// OczekujaceDokumenty response handler
    /// </summary>
    public class OczekujaceDokumentyResponseHandler : 
        BaseServiceResponseHandler,
        IServiceResponseHandler<OczekujaceDokumentyResponse>
    {
        public OczekujaceDokumentyResponse FromSOAP(string soapResponse, out FaultModel fault)
        {
            return this.FromSOAP_Template<OczekujaceDokumentyResponse>(soapResponse, out fault);
        }

        public OczekujaceDokumentyResponse FromSOAP(byte[] soapResponse, string content_typeResponse, out FaultModel fault)
        {
            throw new NotImplementedException();
        }

        protected override void AddManagerNamespaces(XmlNamespaceManager manager)
        {
            manager.AddNamespace("soapenv", Namespaces.SOAPENVELOPE);
            manager.AddNamespace("p140", Namespaces.OBI);
        }

        protected override string GetResponseXPath()
        {
            return "//soapenv:Envelope/soapenv:Body/p140:OdpowiedzPullOczekujace";
        }
    }
}
