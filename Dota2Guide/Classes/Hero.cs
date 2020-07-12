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
using System.IO;
using System.Xml.Linq;

namespace Dota2Guide
{
    public class Hero
    {
        String name;
        String imageSource;
        String intelligence;
        String agility;
        String strength;
        String damage;
        String moveSpeed;
        String armor;
        String bio;
        String role;

        List<Skill> skillList=new List<Skill>();

        public List<Skill> SkillList 
        {
            set 
            {
                skillList = value;
            }

            get 
            {
                return skillList;
            }
        }

        public String Intelligence
        {
            set 
            {
                intelligence = value;
            }
            get 
            {
                return intelligence;
            }
        }

        public String Agility
        {
            set
            {
                agility = value;
            }
            get
            {
                return agility;
            }
        }

        public String Strength
        {
            set
            {
                strength = value;
            }
            get
            {
                return strength;
            }
        }
        public String Damage
        {
            set
            {
                damage = value;
            }
            get
            {
                return damage;
            }
        }
        public String MoveSpeed
        {
            set
            {
                moveSpeed = value;
            }
            get
            {
                return moveSpeed;
            }
        }

        public String Armor
        {
            set
            {
                armor = value;
            }
            get
            {
                return armor;
            }
        }

        public String ImageSource
        {
            get
            {
                return imageSource;
            }
            set
            {
                imageSource =  value;
            }
        }

        public String Bio 
        {
            set 
            {
                bio = "\t\t"+value;
            }
            get 
            {
                return bio;
            }
        }

        public String Role 
        {
            set 
            {
                role = value;
            }
            get 
            {
                return role;
            }
        }

        public enum heroClass
        {
            Strength,
            Agility,
            Intelligence
        }

        heroClass hClass;

        public String Name
        {
            set 
            {
                name = value;
            }
            get { return name; }
        }

        public Hero(String name, String heroClass, String imageSource, String intelligence, String agility, String strength, String damage, String moveSpeed, String armor,String bio,String role) 
        {
            Name = name;
            if (heroClass.ToLower() == "strength")
            {
                this.hClass = Hero.heroClass.Strength;
            }
            else if (heroClass.ToLower() == "agility")
            {
                this.hClass = Hero.heroClass.Agility;
            }
            else if (heroClass.ToLower() == "intelligence")
            {
                this.hClass = Hero.heroClass.Intelligence;
            }
            else this.hClass = Hero.heroClass.Strength;

            ImageSource = "/Dota2Guide;component/HeroImage/"+imageSource;

            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            Damage = damage;
            MoveSpeed = moveSpeed;
            Armor = armor;
            Bio = bio;
            Role = role;
        }

        public Hero() 
        {
            Name = "Hero";
            hClass= heroClass.Intelligence;
            ImageSource = "earthshaker.png";
            Intelligence = "0";
            Agility = "0";
            Strength = "0";
            Damage = "0";
            MoveSpeed = "0";
            Armor = "0";
            Bio = "Unknown";
            Role = "Unknown";
        }

        public void AddSkill(Skill skill)
        {
            SkillList.Add(skill);
        }

        public static IEnumerable<Hero> XMLReader()
        {
            XDocument loadedData = XDocument.Load("heroes.xml");
            var data = from query in loadedData.Descendants("HERO")
                       select new Hero((string)query.Element("NAME"),
                           (string)query.Element("CLASS"),
                           (string)query.Element("IMAGE"),
                           (string)query.Element("INTELLIGENCE"),
                           (string)query.Element("AGILITY"),
                           (string)query.Element("STRENGTH"),
                           (string)query.Element("DAMAGE"),
                           (string)query.Element("MOVESPEED"),
                           (string)query.Element("ARMOR"),
                           (string)query.Element("BIO"),
                           (string)query.Element("ROLE"));
            IEnumerable<Hero> heroesList = data;

            return heroesList;
        }


        public static List<Hero> FetchHeroes()
        {
            List<Hero> heroList = new List<Hero>();

            IEnumerable<Hero> list = XMLReader();

            heroList = list.ToList<Hero>();

            return heroList;
        }

        public static Hero GetHero(String name)
        {
            Hero h = new Hero();

            //IEnumerable<Hero> heroList = new List<Hero>();

            //heroList = Hero.XMLReader();

            /*foreach (var item in heroList)
            {
                if (item.Name.Equals(name))
                    h = item;
            }*/


            for (int i = 0; i < Globals.heroList.Count; i++)
            {
                if (Globals.heroList[i].Name.Equals(name))
                    h = Globals.heroList[i];
            }

            return h;
        }
       
    }
}
