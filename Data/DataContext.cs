using APICrawlDataThongTinDoanhNghiep.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICrawlDataThongTinDoanhNghiep.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Tax> Taxs { get; set; }
        public DbSet<LtsMap> LtsMaps { get; set; }
        public DbSet<LtsFacet> LtsFacets { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Root> Roots { get; set; }
    }
}
