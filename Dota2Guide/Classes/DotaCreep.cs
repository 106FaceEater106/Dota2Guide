using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dota2Guide
{
    public class DotaCreep : DotaCharacter
    {
        static List<DotaCreep> creeps = null;

        public static List<DotaCreep> Creeps
        {
            get { return creeps ?? Load(); }
            set { creeps = value; }
        }

        public static List<DotaCreep> Load()
        {
            creeps = new List<DotaCreep>();

            return creeps;
        }
    }
}
