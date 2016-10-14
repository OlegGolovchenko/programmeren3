using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Engine
    {
        public int DbId { get; set; }
        public int Displacement { get; set; }
        public int CylinderCount { get; set; }
        public string Name { get; set; }
        public string Make { get; set; }
    }
}
