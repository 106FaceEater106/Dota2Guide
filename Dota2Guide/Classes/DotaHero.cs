using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Dota2Guide
{
    public enum HeroClass
    {
        Intelligence,
        Agility,
        Strength
    }

    public class DotaHero : DotaCharacter
    {
        public string ImageSource 
        {
            get { return "/Dota2Guide;component/HeroImage/" + Link + ".png"; }
        }

        static List<DotaHero> heroes = null;
        public static bool skillsLoaded = false;

        public HeroClass HeroClass = new HeroClass();

        public static List<DotaHero> Heroes
        {
            get { return heroes ?? (heroes=XMLToList("HeroXML/heroes_" + Language.ActiveLanguage.Code + ".xml")); }
            set { heroes = value; }
        }


        public static List<DotaHero> XMLToList(string path=null) 
        {
            var list = new List<DotaHero>();
            XDocument loadedData = XDocument.Load(path ?? "HeroXML/HeroesHeroes_" + Language.ActiveLanguage.Code + ".xml");
            var data = loadedData.Descendants("Hero")
            .Select(h => new DotaHero()
            {
                Name = (string)h.Element("Name"),
                Title = (string)h.Element("Title"),
                Image = new DotaImage() { Source = (string)h.Element("Image") },
                Intelligence = (string)h.Element("Intelligence"),
                Agility = (string)h.Element("Agility"),
                Strength = (string)h.Element("Strength"),
                Damage = (string)h.Element("Damage"),
                MovementSpeed = (string)h.Element("MovementSpeed"),
                Armor = (string)h.Element("Armor"),
                Bio = (string)h.Element("BIO"),
                Lore = (string)h.Element("Lore"),
                Roles = ((string)h.Element("Role")).Split('-').ToList()
            }).ToList();

            list = data;
            return list;
        }



        public static void LoadSkills()
        {
            foreach (var hero in DotaHero.Heroes)
            {
                foreach (var skill in DotaSkill.Skills)
                {
                    if (skill.HeroName.Equals(hero.Name))
                    {
                        hero.Skills.Add(skill);
                        skill.Hero = hero;
                    }
                }
            }

            skillsLoaded = true;
        }



  


    }
}
