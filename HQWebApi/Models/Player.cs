using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HQWebApi.Models
{
    public class Player
    {
        // Basic info
        public String Name { get; set; }
        public long ID { get; set; }

        // Attributes
        public int Intelligence { get; set; }
        public int Strength { get; set; }
        public int Charisma { get; set; }
        public int Good { get; set; }
        public int Evil { get; set; }
    }
}