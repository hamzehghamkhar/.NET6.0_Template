using Microsoft.EntityFrameworkCore;

namespace app.DataLayer.Context
{
    public static class ModelBuilderExtensions
    {
        public static void Configuration(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Configuration>().HasData(new Configuration
            //{
            //    Id = 1,
            //    CreateDate = DateTime.Now,
            //});
        }
        public static void Category(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Category>().HasData(new Category
            //{
            //    Id = "0",
            //    title = "بدون والد",
            //    CreateDate = DateTime.Now
            //});
        }
    }
}
