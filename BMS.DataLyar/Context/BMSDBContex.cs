using BMS.DataLyar.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BMS.DataLyar.Context
{
    class BMSDBContex :DbContext
    {
        public BMSDBContex(DbContextOptions options):base(options)
        {

        }


        public  DbSet <Vehicle> Vehicles { get; set; }
    }

}
