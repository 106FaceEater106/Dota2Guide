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
    public class Neutral:Hero
    {
        /*String name;
        String imageSource;
        String damage;
        String moveSpeed;
        String armor;
        String bio;

        List<Skill> skillList = new List<Skill>();

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
                imageSource = value;
            }
        }

        public String Bio
        {
            set
            {
                bio = "\t\t" + value;
            }
            get
            {
                return bio;
            }
        }


        public String Name
        {
            set
            {
                name = value;
            }
            get { return name; }
        }*/


        public Neutral(String name, String imageSource, String damage, String moveSpeed, String armor, String bio) 
        {
            Name = name;
            ImageSource = "/Dota2Guide;component/NeutralImage/" + imageSource;
            Damage = damage;
            MoveSpeed = moveSpeed;
            Armor = armor;
            Bio = bio;
        }

        public Neutral() 
        {
            Name = "Hero";            
            ImageSource = "earthshaker.png";
            Damage = "0";
            MoveSpeed = "0";
            Armor = "0";
            Bio = "Unknown";
        }


        public static List<Neutral> FetchSkills()
        {
            List<Neutral> neutralList = new List<Neutral>();

            IEnumerable<Neutral> list = XMLReaderForNeutrals();

            neutralList = list.ToList<Neutral>();

            return neutralList;
        }

        public static IEnumerable<Neutral> XMLReaderForNeutrals()
        {
            XDocument loadedData = XDocument.Load("neutrals.xml");
            var data = from query in loadedData.Descendants("NEUTRAL")
                       select new Neutral((string)query.Element("NAME"),
                           (string)query.Element("IMAGE"),
                           (string)query.Element("DAMAGE"),
                           (string)query.Element("MOVESPEED"),
                           (string)query.Element("ARMOR"),
                           (string)query.Element("BIO"));
            IEnumerable<Neutral> neutralList = data;

            return neutralList;
        }

    }
}
