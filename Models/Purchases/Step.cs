using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreVer4.Models.Purchases
{
    public class Step
    {
        [Key]
        public int stepid { get; set; }

        public string nameStep { get; set; }
    }
}
