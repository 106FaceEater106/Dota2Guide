using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Dota2Guide
{
    public class DotaSkill : BizObject
    {
        static List<DotaSkill> skills = null;

        public DotaHero Hero { get; set; }
        public string ManaCost { get; set; }
        public string CoolDown { get; set; }
        public string Extra { get; set; }
        public string Video { get; set; }
        public string HeroName { get; set; }

        public string ImageSource
        {
            get 
            {
                var link = "/Dota2Guide;component/SkillImage/" + (Hero != null ? Hero.Name.Replace('\'',' ').Replace(' ','-') : HeroName) +"-"+ Link + ".png";
                return link; 
            }
        }

        public static List<DotaSkill> Skills
        {
            get { return skills ?? (skills=XmlToList("SkillXML/skills_"+Language.ActiveLanguage.Code+".xml")); }
            set { skills = value; }
        }

        public static List<DotaSkill> XmlToList(string path=null) 
        {
            var list = new List<DotaSkill>();
            XDocument loadedData = XDocument.Load("SkillXML/skills_" + Language.ActiveLanguage.Code + ".xml");
            var data = loadedData.Descendants("Skill")
            .Select(s => new DotaSkill()
            {
                HeroName = (string)s.Element("Owner"),
                Name = (string)s.Element("Name"),
                Title = (string)s.Element("Name"),
                Description = (string)s.Element("Description"),
                Image = new DotaImage() { Source = (string)s.Element("Image") },
                ManaCost = (string)s.Element("Mana"),
                CoolDown = (string)s.Element("Cooldown"),
                Video = (string)s.Element("Video"),
                Lore = (string)s.Element("Lore"),
                Hero = new DotaHero() { },
                Extra=null
            });

            list = data.ToList();
            return list;
        }
    }
}
