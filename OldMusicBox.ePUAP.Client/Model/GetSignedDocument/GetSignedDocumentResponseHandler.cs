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

namespace OldMusicBox.ePUAP.Client.Model.GetSignedDocument
{
    /// <summary>
    /// GetSignedDocument Response Handler
    /// </summary>
    public class GetSignedDocumentResponseHandler
        : IServiceResponseHandler<GetSignedDocumentResponse>
    {
        public GetSignedDocumentResponse FromSOAP(string soapResponse, out FaultModel fault)
        {
            fault = null;

            if (string.IsNullOrEmpty(soapResponse))
            {
                throw new ArgumentNullException();
            }

            try
            {
                var xd = new XmlDocument();
                xd.LoadXml(soapResponse);

                var serializer = new XmlSerializer(typeof(GetSignedDocumentResponse));
                var nsManager  = new XmlNamespaceManager(xd.NameTable);
                nsManager.AddNamespace("ns1", Namespaces.COMARCH_SIGN);

                var response = xd.SelectSingleNode("//ns1:getSignedDocumentResponse", nsManager) as XmlElement;
                if (response != null)
                {
                    using (var reader = new StringReader(response.OuterXml))
                    {
                        return serializer.Deserialize(reader) as GetSignedDocumentResponse;
                    }
                }

                return null;
            }
            catch ( Exception ex )
            {
                throw new ServiceClientException("Cannot deserialize GetSignedDocument", ex);
            }
        }

        public GetSignedDocumentResponse FromSOAP(byte[] soapResponse, string content_typeResponse, out FaultModel fault)
        {
            throw new NotImplementedException();
        }
    }
}
