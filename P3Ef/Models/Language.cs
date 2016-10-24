using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Language
    {
        public int Id
        {
            get;
            set;
        }

        [DisplayName("Programming language")]
        public string Name
        {
            get;
            set;
        }
    }
}
