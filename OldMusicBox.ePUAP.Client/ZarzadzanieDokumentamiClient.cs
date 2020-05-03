﻿using OldMusicBox.ePUAP.Client.Model.Common;
using OldMusicBox.ePUAP.Client.Model.ZarzadzanieDokumentami;
using System;
using System.Security.Cryptography.X509Certificates;

namespace OldMusicBox.ePUAP.Client
{
    /// <summary>
    /// WS-ZarzadzanieDokumentami client
    /// 
    /// Służy do wykonania podstawowych opreacji w skrzynce.
    /// </summary>
    /// <remarks>
    /// Production uri:  https://ws.epuap.gov.pl/fe_external_ws/services/ZarzadzanieDokumentami
    /// Integration uri: https://int.epuap.gov.pl/fe_external_ws/services/ZarzadzanieDokumentami
    /// WSDL:            https://ws.epuap.gov.pl/fe_external_ws/services/ZarzadzanieDokumentami/wsdl/ZarzadzanieDokumentami.wsdl
    /// </remarks>
    public class ZarzadzanieDokumentamiClient : BaseClient
    {
        public const string INTEGRATION_URI = "https://int.epuap.gov.pl/fe_external_ws/services/ZarzadzanieDokumentami";
        public const string PRODUCTION_URI  = "https://ws.epuap.gov.pl/fe_external_ws/services/ZarzadzanieDokumentami";

        public ZarzadzanieDokumentamiClient(string serviceUri, X509Certificate2 signingCertificate) : base(serviceUri, signingCertificate)
        {

        }

        #region DodajDokument

        /// <summary>
        /// Interfejs służy do umieszczenia dowolnego dokumentu w podanej skrzynce
        /// </summary>
        public virtual DodajDokumentResponse DodajDokument(
           Sklad    sklad,
           Dokument dokument,
           out FaultModel fault
           )
        {
            // validation
            if (sklad == null || string.IsNullOrEmpty( sklad.Nazwa ) || string.IsNullOrEmpty( sklad.Podmiot ) ) 
                throw new ArgumentNullException("sklad");
            if (dokument == null || dokument.Tresc == null )
                throw new ArgumentNullException("dokument");

            var request = new DodajDokumentRequest()
            {
                Sklad    = sklad,
                Dokument = dokument
            };

            // call ePUAP service and parse the response
            var response = WSSecurityRequest<DodajDokumentRequest, DodajDokumentResponse, DodajDokumentResponseHandler>(
                this.ServiceUri,
                request,
                out fault);

            // parsed response
            return response;
        }

        #endregion
    }
}
