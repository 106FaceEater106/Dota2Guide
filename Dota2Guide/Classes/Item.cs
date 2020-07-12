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
using System.IO;
using System.Xml.Linq;
using System.Linq;

namespace Dota2Guide
{
    public class Item
    {
        String title;
        String price;
        String imageSource;
        String description;
        String role;
        String intelligence;
        String agility;
        String strength;
        String damage;
        String movementSpeed;
        String armor;
        String hpRegeneration;
        String manaRegeneration;
        String spellResistance;
        String evasion;
        String allAttributes;
        String mana;
        String health;
        String attackSpeed;
        String extra;
        String recipe;
        String manaCost;
        String coolDown;
        List<String> recipeList=new List<string>();


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

        public String Price
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    price = value;
                else price = null;
            }
            get
            {
                return price;
            }
        }

        public String ImageSource
        {
            set
            {
                imageSource = "/Dota2Guide;component/ItemImage/" + value;
            }
            get
            {
                return imageSource;
            }
        }

        public String Description
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    value = "\t\t" + value;
                    description = value;
                }
                else description = null;
            }
            get
            {
                return description;
            }
        }
        public String Role
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    role = "\t\t" + value;
                else role = null;
            }
            get
            {
                return role;
            }
        }

        public String Intelligence
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    intelligence = "+" + value;
                else intelligence = null;
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
                if (!String.IsNullOrWhiteSpace(value))
                    agility = "+" + value;
                else agility = null;
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
                if (!String.IsNullOrWhiteSpace(value))
                    strength = "+" + value;
                else strength = null;
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
                if (!String.IsNullOrWhiteSpace(value))
                    damage = "+" + value;
                else damage = null;
            }
            get
            {
                return damage;
            }
        }

        public String MovementSpeed
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    movementSpeed = "+" + value;
                else movementSpeed = null;
            }
            get
            {
                return movementSpeed;
            }
        }

        public String Armor
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    armor = "+" + value;
                else armor = null;
            }

            get
            {
                return armor;
            }
        }

        public String HpRegeneration
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    hpRegeneration = "+" + value;
                else hpRegeneration = null;
            }
            get
            {
                return hpRegeneration;
            }
        }

        public String ManaRegeneration
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    manaRegeneration = "+" + value + "%";
                else manaRegeneration = null;
            }

            get
            {
                return manaRegeneration;
            }
        }

        public String SpellResistance
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    spellResistance = "+" + value + "%";
                else spellResistance = null;
            }

            get
            {
                return spellResistance;
            }
        }

        public String Evasion
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    evasion = "+" + value + "%";
                else evasion = null;
            }

            get
            {
                return evasion;
            }
        }

        public String AllAttributes
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    allAttributes = "+" + value;
                else allAttributes = null;
            }

            get
            {
                return allAttributes;
            }
        }

        public String Mana
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    mana = "+" + value;
                else mana = null;
            }

            get
            {
                return mana;
            }
        }

        public String Health
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    health = "+" + value;
                else health = null;
            }

            get
            {
                return health;
            }
        }

        public String AttackSpeed
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    attackSpeed = "+" + value;
                else attackSpeed = null;
            }

            get
            {
                return attackSpeed;
            }
        }

        public String Extra
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                {
                    value = value.Replace(',', '\n');
                    extra = value;
                }
                else extra = null;
            }

            get
            {
                return extra;
            }
        }

        public String Recipe
        {
            set
            {
                recipe = value;
                String [] strList= recipe.Split(',');
                recipeList = strList.ToList<String>();
            }

            get
            {
                return recipe;
            }
        }

        public String ManaCost
        {
            set
            {
                if (!String.IsNullOrWhiteSpace(value))
                    manaCost = value;
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
                    coolDown = value;
                else coolDown = null;
            }

            get
            {
                return coolDown;
            }
        }

        public List<String> RecipeList 
        {
            set 
            {
                recipeList = value;
            }

            get 
            {
                return recipeList;
            }
        }

        public Item()
        {
            Title = "Item";
            Price = "0";
            ImageSource = "recipe.png";
            Description = "Undefined";
            Role = "Undefined";
            Intelligence = "0";
            Agility = "0";
            Strength = "0";
            Damage = "0";
            MovementSpeed = "0";
            Armor = "0";
            HpRegeneration = "0";
            ManaRegeneration = "0";
            SpellResistance = "0";
            Evasion = "0";
            AllAttributes = "0";
            Mana = "0";
            Health = "0";
            AttackSpeed = "0";
            Extra = "Undefined";
            Recipe = "Clarity,Tango,Healing Salve";
            ManaCost = "0";
            CoolDown = "0";
        }

        public Item(String title, String price, String imageSource, String description, String role,
            String intelligence, String agility, String strength, String damage, String movementSpeed, String armor,
            String hpRegeneration, String manaRegeneration, String spellResistance, String evasion, String allAttributes,
            String mana, String health, String attackSpeed, String extra, String recipe, String manaCost, String coolDown)
        {
            Title = title;
            Price = price;
            ImageSource = imageSource;
            Description = description;
            Role = role;
            Intelligence = intelligence;
            Agility = agility;
            Strength = strength;
            Damage = damage;
            MovementSpeed = movementSpeed;
            Armor = armor;
            HpRegeneration = hpRegeneration;
            ManaRegeneration = manaRegeneration;
            SpellResistance = spellResistance;
            Evasion = evasion;
            AllAttributes = allAttributes;
            Mana = mana;
            Health = health;
            AttackSpeed = attackSpeed;
            Extra = extra;
            Recipe = recipe;
            ManaCost = manaCost;
            CoolDown = coolDown;
        }

        public static List<Item> FetchItems()
        {

            List<Item> itemList = new List<Item>();


            itemList = Item.XMLReader().ToList<Item>();

            return itemList;
        }


        public static Item GetItem(String title)
        {
            Item item = new Item();

          

            IEnumerable<Item> List = new List<Item>();

            List = Item.XMLReader();

            foreach (var i in List)
            {
                if (i.Title.ToUpper().Equals(title.ToUpper()))
                {
                    item = i;
                }
            }


            return item;
        }

        public static IEnumerable<Item> XMLReader() 
        {
            XDocument loadedData = XDocument.Load("items.xml");
            var data = from query in loadedData.Descendants("ITEM")
                       select new Item((string)query.Element("TITLE"),
                           (string)query.Element("PRICE"),
                           (string)query.Element("IMG"),
                           (string)query.Element("DESCRIPTION"),
                           (string)query.Element("ROLE"),
                           (string)query.Element("INTELLIGENCE"),
                           (string)query.Element("AGILITY"),
                           (string)query.Element("STRENGTH"),
                           (string)query.Element("DAMAGE"),
                           (string)query.Element("MOVEMENTSPEED"),
                           (string)query.Element("ARMOR"),
                           (string)query.Element("HPREG"),
                           (string)query.Element("MANAREG"),
                           (string)query.Element("SPELLRESISTANCE"),
                           (string)query.Element("EVASION"),
                           (string)query.Element("ALLATTRIBUTES"),
                           (string)query.Element("MANA"),
                           (string)query.Element("HEALTH"),
                           (string)query.Element("ATTACKSPEED"),
                           (string)query.Element("EXTRA"),
                           (string)query.Element("RECIPE"),
                           (string)query.Element("MANACOST"),
                           (string)query.Element("COOLDOWN"));
            IEnumerable<Item> itemList = data;
            return itemList;
        }

    }
}
