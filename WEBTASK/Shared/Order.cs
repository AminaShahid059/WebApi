using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEBTASK.Shared
{
    public class Order
    {

        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int phone { get; set; }
        public string order { get; set; }
        public string additional { get; set; }
        public string address { get; set; }

    }
}
