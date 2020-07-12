using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace Dota2Guide
{
    public class DotaItem : BizObject
    {
        static List<DotaItem> items = null;

        public static bool itemsAssociated = false;

        public string Price { get; set; }

        public string ManaCost { get; set; }
        public string Cooldown { get; set; }

        public string ImageSource
        {
            get { return "/Dota2Guide;component/ItemImage/" + Link + ".png"; }
        }


        string movementSpeed;
        public string MovementSpeed 
        {
            get { return !string.IsNullOrWhiteSpace(movementSpeed) ? "+" + movementSpeed : null; }
            set { movementSpeed = value; }
        }

        string selectedAttribute;
        public string SelectedAttribute 
        {
            get { return !string.IsNullOrWhiteSpace(selectedAttribute) ? "+" + selectedAttribute : null; }
            set { selectedAttribute = value; }
        }

        string attackSpeed;
        public string AttackSpeed 
        {
            get { return !string.IsNullOrWhiteSpace(attackSpeed) ?  "+" + attackSpeed : null; }
            set { attackSpeed = value; }
        }

        string allAttributes;
        public string AllAttributes 
        {
            get { return !string.IsNullOrWhiteSpace(allAttributes) ? "+" + allAttributes : null; }
            set { allAttributes = value; }
        }

        string health;
        public string Health 
        {
            get { return !string.IsNullOrWhiteSpace(health) ?  "+" + health : null; }
            set { health = value; }
        }

        string mana;
        public string Mana 
        {
            get { return !string.IsNullOrWhiteSpace(mana) ? "+" + mana : null; }
            set { mana = value; } 
        }

        string damage;
        public string Damage 
        {
            get { return !string.IsNullOrWhiteSpace(damage) ? "+" + damage : null; }
            set { damage = value; }
        }

        string strength;
        public string Strength 
        {
            get { return !string.IsNullOrWhiteSpace(strength) ? "+" + strength : null; }
            set { strength = value; }
        }

        string armor;
        public string Armor 
        {
            get { return !string.IsNullOrWhiteSpace(armor) ?  "+" + armor : null; }
            set { armor = value; }
        }

        string intelligence;
        public string Intelligence 
        {
            get { return !string.IsNullOrWhiteSpace(intelligence) ? "+" + intelligence : null; }
            set { intelligence = value; } 
        }

        string hpRegeneration;
        public string HPRegeneration 
        {
            get { return !string.IsNullOrWhiteSpace(hpRegeneration) ? "+" + hpRegeneration : null; }
            set { hpRegeneration = value; }
        }

        string manaRegeneration;
        public string ManaRegeneration 
        {
            get { return !string.IsNullOrWhiteSpace(manaRegeneration)?  "+" + manaRegeneration : null; }
            set { manaRegeneration = value; }
        }

        string agility;
        public string Agility 
        {
            get { return !string.IsNullOrWhiteSpace(agility) ? "+"+agility : null; }
            set { agility = value; } 
        }

        string castRange;
        public string CastRange 
        {
            get { return !string.IsNullOrWhiteSpace(castRange) ? "+" + castRange : null; }
            set { castRange = value; }
        }

        string evasion;
        public string Evasion 
        {
            get { return !string.IsNullOrWhiteSpace(evasion) ? "+"+evasion : null; }
            set { evasion = value; }
        }

        string attackRange;
        public string AttackRange 
        {
            get { return !string.IsNullOrWhiteSpace(attackRange) ?  "+"+attackRange : null; }
            set { attackRange = value; }
        }

        string spellResistance;
        public string SpellResistance 
        {
            get { return !string.IsNullOrWhiteSpace(spellResistance) ? "+" + spellResistance : null; }
            set { spellResistance = value; }
        }

        public List<string> RecipeList = new List<string>();
        public List<DotaItem> Recipes = new List<DotaItem>();

        public static List<DotaItem> Items
        {
            get { return items ?? (items=XmlToList("ItemXML/items_"+Language.ActiveLanguage.Code+".xml")); }
            set { items = value; }
        }

        public string EffectList
        {
            get
            {
                return Effects != null ? string.Join(",", Effects.Select(e => string.Format("{0}:{1}", e.Key, e.Value))) : null;
            }
        }

        public void FetchAttributes()
        {
            if (Attributes != null)
                Attributes.Clear();

            if (!string.IsNullOrWhiteSpace(MovementSpeed))
                Attributes.Add("Movement Speed", MovementSpeed);

            if (!string.IsNullOrWhiteSpace(SelectedAttribute))
                Attributes.Add("Selected Attribute", SelectedAttribute);

            if (!string.IsNullOrWhiteSpace(AttackSpeed))
                Attributes.Add("Attack Speed", AttackSpeed);

            if (!string.IsNullOrWhiteSpace(AllAttributes))
                Attributes.Add("All Attributes", AllAttributes);

            if (!string.IsNullOrWhiteSpace(Health))
                Attributes.Add("Health", Health);

            if (!string.IsNullOrWhiteSpace(Mana))
                Attributes.Add("Mana", Mana);

            if (!string.IsNullOrWhiteSpace(Damage))
                Attributes.Add("Damage", Damage);

            if (!string.IsNullOrWhiteSpace(Strength))
                Attributes.Add("Strength", Strength);

            if (!string.IsNullOrWhiteSpace(Armor))
                Attributes.Add("Armor", Armor);

            if (!string.IsNullOrWhiteSpace(Intelligence))
                Attributes.Add("Intelligence", Intelligence);

            if (!string.IsNullOrWhiteSpace(HPRegeneration))
                Attributes.Add("HP Regeneration", HPRegeneration);

            if (!string.IsNullOrWhiteSpace(ManaRegeneration))
                Attributes.Add("Mana Regeneration", ManaRegeneration);

            if (!string.IsNullOrWhiteSpace(Agility))
                Attributes.Add("Agility", Agility);

            if (!string.IsNullOrWhiteSpace(CastRange))
                Attributes.Add("Cast Range", CastRange);

            if (!string.IsNullOrWhiteSpace(Evasion))
                Attributes.Add("Evasion", Evasion);

            if (!string.IsNullOrWhiteSpace(AttackRange))
                Attributes.Add("Attack Range", AttackRange);

            if (!string.IsNullOrWhiteSpace(SpellResistance))
                Attributes.Add("Spell Resistance", SpellResistance);

        }

        public static Dictionary<string, string> FetchEffects(List<string> effectList)
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            foreach (var effect in effectList)
            {
                dic.Add(effect.Remove(effect.IndexOf(':')), effect.Remove(0, effect.IndexOf(':') + 1));
            }
            return dic;
        }

        public Dictionary<string, string> Attributes = new Dictionary<string, string>();
        public Dictionary<string, string> Effects = new Dictionary<string, string>();

        public static List<DotaItem> XmlToList(string path = null)
        {
            XDocument loadedData = XDocument.Load(path ?? "ItemXML/Items_" + Language.ActiveLanguage.Code + ".xml");

            items = loadedData.Descendants("Item")
                       .Select(i =>
                       {
                           var result = new DotaItem()
                           {
                               Name = (string)i.Element("Name"),
                               Title = (string)i.Element("Title"),
                               Price = (string)i.Element("Price"),
                               Image = new DotaImage() { Source = (string)i.Element("Image") },
                               Description = (string)i.Element("Description"),
                               Lore = (string)i.Element("Lore"),
                               ManaCost = (string)i.Element("ManaCost"),
                               Cooldown = (string)i.Element("CoolDown"),
                               RecipeList = i.Element("Recipe") != null ? ((string)i.Element("Recipe")).Split(',').ToList() : null,
                               MovementSpeed = i.Element("MovementSpeed") != null ? (string)i.Element("MovementSpeed") : null,
                               SelectedAttribute = i.Element("SelectedAttribute") != null ? (string)i.Element("SelectedAttribute") : null,
                               AttackSpeed = i.Element("AttackSpeed") != null ? (string)i.Element("AttackSpeed") : null,
                               AllAttributes = i.Element("AllAttributes") != null ? (string)i.Element("AllAttributes") : null,
                               Health = i.Element("Health") != null ? (string)i.Element("Health") : null,
                               Mana = i.Element("Mana") != null ? (string)i.Element("Mana") : null,
                               Damage = i.Element("Damage") != null ? (string)i.Element("Damage") : null,
                               Strength = i.Element("Strength") != null ? (string)i.Element("Strength") : null,
                               Armor = i.Element("Armor") != null ? (string)i.Element("Armor") : null,
                               Intelligence = i.Element("Intelligence") != null ? (string)i.Element("Intelligence") : null,
                               HPRegeneration = i.Element("HPRegeneration") != null ? (string)i.Element("HPRegeneration") : null,
                               ManaRegeneration = i.Element("ManaRegeneration") != null ? (string)i.Element("ManaRegeneration") : null,
                               Agility = i.Element("Agility") != null ? (string)i.Element("Agility") : null,
                               CastRange = i.Element("CastRange") != null ? (string)i.Element("CastRange") : null,
                               Evasion = i.Element("Evasion") != null ? (string)i.Element("Evasion") : null,
                               AttackRange = i.Element("AttackRange") != null ? (string)i.Element("AttackRange") : null,
                               SpellResistance = i.Element("SpellResistance") != null ? (string)i.Element("SpellResistance") : null,
                               Effects = !string.IsNullOrWhiteSpace((string)i.Element("Effects")) ? DotaItem.FetchEffects(((string)i.Element("Effects")).Split(',').ToList()) : null
                           };
                           result.FetchAttributes();
                           return result;
                       }).ToList();

            return items;
        }

        public static void AssociateRecipes()
        {
            foreach (var item in Items)
            {
                if (item.RecipeList != null)
                    foreach (var recipeName in item.RecipeList)
                    {
                        if (recipeName.Contains("Recipe"))
                            item.Recipes.Add(new DotaItem() { Name="Recipe"});
                        else 
                            item.Recipes.Add(Items.FirstOrDefault(i => i.Title.Equals(recipeName)));
                    }
            }

            itemsAssociated = true;
        }
    }
}
