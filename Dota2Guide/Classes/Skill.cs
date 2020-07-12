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
using System.Linq;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Dota2Guide
{
    public class Skill
    {
        Hero owner;
        String title;
        String description;
        String imageSource;
        String manaCost;
        String coolDown;
        String extra;

        public Hero Owner
        {
            set
            {
                owner = value;
            }
            get
            {
                return owner;
            }
        }

        public String Title
        {
            set
            {
                title = value;
            }
            get
            {
                return title;
            }
        }

        public String Description
        {
            set
            {
                description = value;
            }
            get
            {
                return description;
            }
        }

        public String ImageSource
        {
            set
            {
                if(Owner is Neutral)
                    imageSource = "/Dota2Guide;component/NeutralSkillImage/" + value;
                else 
                    imageSource = "/Dota2Guide;component/SkillImage/" + value;
            }

            get
            {
                return imageSource;
            }
        }

        public String ManaCost
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    manaCost = "MANA COST:" + value;
                else manaCost = null;
            }

            get
            {
                return manaCost;
            }
        }

        public String CoolDown
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    coolDown = "COOLDOWN:" + value;
                else coolDown = null;
            }

            get
            {
                return coolDown;
            }
        }

        public String Extra 
        {
            set 
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    value = value.Replace(',', '\n');
                    extra = value.ToUpper();
                }
                else extra = null;
            }

            get 
            {
                return extra;
            }
        
        }

        public Skill(String owner, String title, String description, String imageSource, String manaCost, String coolDown,String extra)
        {
            for (int i = 0; i < Globals.heroList.Count; i++)
            {
                if (Globals.heroList[i].Name.Equals(owner))
                {
                    Owner = Globals.heroList[i];
                    Globals.heroList[i].SkillList.Add(this);
                    break;
                }
            }

            for (int i = 0; i < Globals.neutralList.Count; i++)
            {
                if(Globals.neutralList[i].Name.Equals(owner))
                {
                    Owner = Globals.neutralList[i];
                    Globals.neutralList[i].SkillList.Add(this);
                    break;
                }
            }

            if (Owner == null) 
            {
                Owner = new Hero();
            }

            Title = title;
            Description = description;
            ImageSource = imageSource;
            ManaCost = manaCost;
            CoolDown = coolDown;
            Extra = extra;
        }

        public Skill()
        {
            Owner = new Hero();
            Title = "Skill";
            Description = "Unknown";
            ImageSource = "earthshaker_aftershock.png";
            ManaCost = "0";
            CoolDown = "0";
            Extra = "Undefined";
        }

        public static List<Skill> FetchSkills()
        {
            IEnumerable<Skill> List = XMLReader();
            return List.ToList<Skill>();
        }

        public static List<Skill> FetchNeutralSkills()
        {
            IEnumerable<Skill> List = XMLReaderForNeutrals();
            return List.ToList<Skill>();
        }

        public static Skill GetSkill(String title)
        {
            Skill s = new Skill();

            IEnumerable<Skill> List = XMLReader();

            foreach (var skill in List)
            {
                if (skill.Title.Equals(title))
                {
                    s = skill;
                    break;
                }
            }

            return s;
        }

        public static IEnumerable<Skill> XMLReader()
        {

            XDocument loadedData = XDocument.Load("skills.xml");
            var data = from query in loadedData.Descendants("SKILL")
                       select new Skill((string)query.Element("OWNER"),
                           (string)query.Element("TITLE"),
                           (string)query.Element("DESCRIPTION"),
                           (string)query.Element("IMAGE"),
                           (string)query.Element("MANA"),
                           (string)query.Element("COOLDOWN"),
                           (string)query.Element("EXTRA"));
            IEnumerable<Skill> List = new List<Skill>();

            List = data;

            return List;
        }

        public static IEnumerable<Skill> XMLReaderForNeutrals() 
        {
            XDocument loadedData = XDocument.Load("neutralSkills.xml");
            var data = from query in loadedData.Descendants("SKILL")
                       select new Skill((string)query.Element("OWNER"),
                           (string)query.Element("TITLE"),
                           (string)query.Element("DESCRIPTION"),
                           (string)query.Element("IMAGE"),
                           (string)query.Element("MANA"),
                           (string)query.Element("COOLDOWN"),
                           (string)query.Element("EXTRA"));
            IEnumerable<Skill> List = new List<Skill>();

            List = data;

            return List;        
        }
    }
}