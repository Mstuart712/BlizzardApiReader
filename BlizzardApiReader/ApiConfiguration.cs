﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlizzardApiReader
{
    public enum Region { EU, KR, SEA, TW, US }
    public enum Locale { en_GB, ko_KR, zh_TW, en_US }

    public class ApiConfiguration
    {
        public Region ApiRegion;
        public Locale ResultLocale;
        public string ApiKey;


        public static ApiConfiguration CreateEmpty()
        {
            return new ApiConfiguration();
        }

        public ApiConfiguration SetApiKey(string key)
        {
            ApiKey = key;
            return this;
        }

        public ApiConfiguration SetRegion(Region region)
        {
            ApiRegion = region;
            return this;
        }

        public ApiConfiguration SetLocale(Locale locale)
        {
            ResultLocale = locale;
            return this;
        }

        /// <summary>
        /// Will use the default locale for the configuration region, must be called only after setting the Region
        /// </summary>
        /// <returns></returns>
        public ApiConfiguration UseDefaultLocale()
        {
            ResultLocale = getDefaultLocaleForRegion(ApiRegion);
            return this;
        }


        /// <summary>
        /// Declare this Configuration as the global default configuration, it will be used when no configuration is provided to the api reader.
        /// </summary>  
        public ApiConfiguration DeclareAsDefault()
        {
            ApiReader.SetDefaultConfiguration(this);
            return this;
        }



        public string GetLocaleString()
        {
            return Enum.GetName(typeof(Locale), ResultLocale);
        }
        public string GetRegionString()
        {
            return Enum.GetName(typeof(Region), ApiRegion);
        }

        private Locale getDefaultLocaleForRegion(Region region)
        {
            // TODO: Finish this;
            return Locale.en_GB;
        }


    }
}
