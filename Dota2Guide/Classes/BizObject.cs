using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Dota2Guide
{
    public abstract class BizObject
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Lore { get; set; }

        public DotaImage Image { get; set; }

        public string Link 
        {
            get 
            {
                return Name.IndexOf('\'') == -1 ?
                            Name.Replace(' ', '-') :
                            Name.Remove(Name.IndexOf('\''), 1).Replace(' ', '-');
            }
        }

        public static List<BizObject> Objects = null;

        public static void InitializeObjects()
        {
            Objects = new List<BizObject>();

            /*Objects.Union(DotaHero.Load())
                    .Union(BizItem.Load())
                    .Union(DotaSkill.Load())
                    .Union(DotaCreep.Load());*/
        }

    }
}
