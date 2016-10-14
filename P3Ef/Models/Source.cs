using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Source
    {
        public int Id
        {
            get;
            set;
        }

        public string FileName
        {
            get;
            set;
        }

        public string Package
        {
            get;
            set;
        }

        [DataType(DataType.MultilineText)]
        public string Content
        {
            get;
            set;
        }

        public string PName
        {
            get;
            set;
        }
    }
}
