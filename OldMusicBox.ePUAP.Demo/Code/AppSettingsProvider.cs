using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace OldMusicBox.ePUAP.Demo
{
    public class AppSettingsProvider
    {
        private static string _p12location;
        private static string _p12password;
        private static string _podmiot;
        private static string _nazwaSkrytki;
        private static string _adresSkrytki;
        private static string _adresOdpowiedzi;


        public string GetP12location()
        {
            if (string.IsNullOrEmpty(_p12location))
            {
                _p12location = ConfigurationManager.AppSettings["p12location"];
            }
            return _p12location;
        }

        public string GetP12password()
        {
            if (string.IsNullOrEmpty(_p12password))
            {
                _p12password = ConfigurationManager.AppSettings["p12password"];
            }
            return _p12password;
        }
        
        public string GetPodmiot()
        {
            if (string.IsNullOrEmpty(_podmiot))
            {
                _podmiot = ConfigurationManager.AppSettings["podmiot"];
            }
            return _podmiot;
        }

        public string GetNazwaSkrytki()
        {
            if (string.IsNullOrEmpty(_nazwaSkrytki))
            {
                _nazwaSkrytki = ConfigurationManager.AppSettings["nazwaSkrytki"];
            }
            return _nazwaSkrytki;
        }


        public string GetAdresSkrytki()
        {
            if (string.IsNullOrEmpty(_adresSkrytki))
            {
                _adresSkrytki = ConfigurationManager.AppSettings["adresSkrytki"];
            }
            return _adresSkrytki;
        }


        public string GetAdresOdpowiedzi()
        {
            if (string.IsNullOrEmpty(_adresOdpowiedzi))
            {
                _adresOdpowiedzi = ConfigurationManager.AppSettings["adresOdpowiedzi"];
            }
            return _adresOdpowiedzi;
        }

    }
}