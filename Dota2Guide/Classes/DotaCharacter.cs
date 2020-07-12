using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Guide
{
    public abstract class DotaCharacter : BizObject
    {
        static List<DotaCharacter> characters = null;

        public string Intelligence { get; set; }
        public string Agility { get; set; }
        public string Strength { get; set; }
        public string Damage { get; set; }
        public string MovementSpeed { get; set; }
        public string Armor { get; set; }
        public string Bio { get; set; }

        public List<string> Roles = new List<string>();
        public List<DotaSkill> Skills = new List<DotaSkill>();

        public static List<DotaCharacter> Characters
        {
            get { return characters ?? LoadCharacters(); }
            set { characters = value; }
        }

        public static List<DotaCharacter> LoadCharacters()
        {
            characters = new List<DotaCharacter>();

            /*characters.Union(DotaHero.Heroes)
                        .Union(DotaCreep.Creeps);*/

            return characters;
        }

    }
}
