using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Project
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        public string UId
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int LangId
        {
            get;
            set;
        }

        [ForeignKey("LangId")]
        public Language Lang
        {
            get;
            set;
        }
    }
}
