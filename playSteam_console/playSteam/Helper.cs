﻿using System;
using System.Xml.Linq;

namespace playSteam
{
    class Helper
    {
        public const string DEFAULT_LAST_SETTINGS_XML = "lastSettings.xml";

        /*
         * load XML
         */
        public static XElement xRead(string url)
        {
            XElement xelement;
            try
            {
                xelement = XElement.Load(url);
                return xelement;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wyjatek przy xRead (czytanie XML): " + ex.Message);
                return null;
            }
        }

        /*
         * save last UID and APIKey to XML
         */
        public static bool xSettingsSave(string uid, string apiKey, string url = DEFAULT_LAST_SETTINGS_XML)
        {
            XElement settingsFile = new XElement("settings", 
                                                    new XElement("uid", uid), 
                                                    new XElement("api", apiKey));
            settingsFile.Save(url);
            
            return false;
        }
    }
}
