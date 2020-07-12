using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Linq;

namespace Dota2Guide
{
    public class Language
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string IsActive { get; set; }

        public static List<Language> Languages = new List<Language>()
        {
            new Language(){Name="Bulgarian",Code="bg"},
            new Language(){Name="Czech",Code="cs"},
            new Language(){Name="German",Code="de"},
            new Language(){Name="English",Code="en"},
            new Language(){Name="Spanish",Code="es"},
            new Language(){Name="French",Code="fr"},
            new Language(){Name="Italian",Code="it"},
            new Language(){Name="Georgian",Code="ka"},
            new Language(){Name="Korean",Code="ko"},
            new Language(){Name="Polish",Code="pl"},
            new Language(){Name="Portuguese",Code="pt"},
            new Language(){Name="Russian",Code="ru"},
            new Language(){Name="Serbian",Code="sr"},
            new Language(){Name="Turkish",Code="tr"},
            new Language(){Name="Ukrainian",Code="uk"},
            new Language(){Name="Chinese",Code="zh"}
        };

        public static Language ActiveLanguage = Languages.Where(l => l.Code == "en").FirstOrDefault();
    }
}
