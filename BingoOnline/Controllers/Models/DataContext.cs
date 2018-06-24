using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BingoOnline.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
   
        public DbSet<Bingo> Bingos { get; set; }

        public DbSet<Award> Awards { get; set; }

        public DbSet<Card> Cards { get; set; }

        public System.Data.Entity.DbSet<BingoOnline.Models.BingoSorted> BingoSorteds { get; set; }
    }
}