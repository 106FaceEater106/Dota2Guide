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
    public class Globals
    {
        public static List<Item> itemList=new List<Item>();
        public static List<Hero> heroList = new List<Hero>();
        public static List<Skill> skillList = new List<Skill>();
        public static List<Neutral> neutralList = new List<Neutral>();
        public static List<Skill> neutralSkillList = new List<Skill>();

        public static void LoadAllInfo()
        {
            itemList = Item.FetchItems();
            heroList = Hero.FetchHeroes();
            skillList=Skill.FetchSkills();
            neutralList = Neutral.FetchSkills();
            neutralSkillList = Skill.FetchNeutralSkills();
        }

        public static Item GetItem(String title) 
        {
            Item item=new Item();
            for (int i = 0; i < itemList.Count; i++)
            {
                if (itemList[i].Title.Equals(title))
                    item = itemList[i];
            }
            return item;
        }

        public static Hero GetHero(String name) 
        {
            Hero hero = new Hero();

            for (int i = 0; i < heroList.Count; i++)
            {
                if(heroList[i].Name.Equals(name))
                    hero=heroList[i];
            }

            return hero;
        }

        public static Skill GetSkill(String title) 
        {
            Skill skill = new Skill();

            for (int i = 0; i < skillList.Count; i++)
            {
                if(skillList[i].Title.Equals(title))
                    skill=skillList[i];
            }

            return skill;
        }

        public static Neutral GetNeutral(String name) 
        {
            Neutral neutral = new Neutral();

            for (int i = 0; i < neutralList.Count; i++)
            {
                if(neutralList[i].Name.Equals(name))
                    neutral=neutralList[i];
            }
            return neutral;
        }

        public static Skill GetNeutralSkill(String title) 
        {
             Skill skill = new Skill();

            for (int i = 0; i < neutralSkillList.Count; i++)
            {
                if (neutralSkillList[i].Title.Equals(title))
                    skill = neutralSkillList[i];
            }

            return skill;
        }

      
    }
}
