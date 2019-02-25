using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BMS.DataLyar.Entities
{
   public class Vehicle
    {
        [Key]
        public int ID { get; set; }

        public string Code { get; set; }

        public string Model { get; set; }

        public DateTime Year { get; set; }

        public string Color { get; set; }

        public string PlateNumber { get; set; }

        public bool Active { get; set; }

        public string Note { get; set; }

        public string NotActiveRes { get; set; }
    }
}
