using Microsoft.EntityFrameworkCore;
using MkAffiliationManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MkAffiliationManagement.data
{
    public class AdvertismentDbContext : DbContext
    {

        public AdvertismentDbContext(DbContextOptions<AdvertismentDbContext> options) : base(options)
        {

        }
        /*       ID = 2
         *       Snakeskin Print Chiseled Shoulder Bag
                 The purse is beautiful! It’s little bigger than a clutch but it’s the perfect size. The leather quality is so nice and it’s well worth the price.
                 https://n.io.nordstrommedia.com/id/sr3/da0ec208-e35c-43cb-a490-3eb71d3bd7d8.jpeg?crop=pad&pad_color=FFF&format=jpeg&trim=color&trimcolor=FFF&w=60&h=90&dpr=2
                 BAGGAGECLAIM
                 https://www.nordstromrack.com/s/bruno-magli-snakeskin-print-chiseled-shoulder-bag/6115191?origin=category-personalizedsort&breadcrumb=Home%2FBags%20%26%20Accessories%2FHandbags%2FDesigner%20Bags&color=650#product-page-reviews
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertisment>().HasData(
                new Advertisment
                {
                    ID = 1,
                    ProductName = "Victorias Secret Leggings TYPE=AC32",
                    ProductEndorsment = "I love, love, love the rainbow leaves! I only wear VS leggings to run or just relax in. They are super comfy and never roll during workouts. " +
                    "This is the second pair of these leggings I have purchased.  They fit and feel great!",
                    Image = "https://www.victoriassecret.com/p/760x1013/tif/0b/3d/0b3d5a483b5c4b9bab0815e5f1336309/111712650UNC_OM_F.jpg",
                    ProductPromotionalCode = "DIAZDEALS",
                    ProductLink = "https://www.victoriassecret.com/us/vs/apparel-catalog/victoria-s-secret-total-knockout-by-victoria-s-secret-high-rise-tight-5000007478?genericId=11171265&choice=0UNC&size1=16&size1=16&cm_mmc=PLA-_-GOOGLE-_-VSD_GS+-+VS-+Top+Products+-+Apparel+Bottoms+-+P1-_-Type_Legging&gclid=CjwKCAjwvuGJBhB1EiwACU1AiVWV81AYw3dhwSknrq3s3oxU5OWSYmMBX0nkSI6OncF8nRwOPOSiqBoCQ50QAvD_BwE&gclsrc=aw.ds"

                },
                new Advertisment
                {
                    ID = 2,
                    ProductName = "example product # 2",
                    ProductEndorsment= "This is my endorsment for this product its absolutley amazing in almost every way",
                    Image = "IMAGE_URI_",
                    ProductPromotionalCode = "SOMENUMBERSANDLETTERS",
                    ProductLink = "This is the link to the product.... "


                }


            );
        }
        public DbSet<Advertisment> Ad { get; set; }

    }
}
