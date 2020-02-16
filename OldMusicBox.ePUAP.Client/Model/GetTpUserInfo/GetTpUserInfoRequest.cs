﻿using OldMusicBox.ePUAP.Client.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace OldMusicBox.ePUAP.Client.Model.GetTpUserInfo
{
    /// <summary>
    /// GetTpUserInfo Request
    /// </summary>
    [XmlRoot("getTpUserInfo", Namespace = Namespaces.USERINFO)]
    public class GetTpUserInfoRequest
    {
        public const string SOAPACTION = "getTpUserInfo";

        public GetTpUserInfoRequest()
        {
            this.SystemOrganisationId = "0";
        }


        [XmlElement(ElementName = "tgsid", Namespace = "")]
        public string TgSid { get; set; }

        [XmlElement(ElementName = "systemOrganisationId", Namespace = "")]
        public string SystemOrganisationId { get; set; }
    }
}
