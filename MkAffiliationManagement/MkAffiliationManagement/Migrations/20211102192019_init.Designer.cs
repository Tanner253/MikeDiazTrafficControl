// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MkAffiliationManagement.data;

namespace MkAffiliationManagement.Migrations
{
    [DbContext(typeof(AdvertismentDbContext))]
    [Migration("20211102192019_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MkAffiliationManagement.Models.Advertisment", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Engagements")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductEndorsment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductLink")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductPromotionalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Ad");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Engagements = 0,
                            Image = "https://www.victoriassecret.com/p/760x1013/tif/0b/3d/0b3d5a483b5c4b9bab0815e5f1336309/111712650UNC_OM_F.jpg",
                            ProductEndorsment = "I love, love, love the rainbow leaves! I only wear VS leggings to run or just relax in. They are super comfy and never roll during workouts. This is the second pair of these leggings I have purchased.  They fit and feel great!",
                            ProductLink = "https://www.victoriassecret.com/us/vs/apparel-catalog/victoria-s-secret-total-knockout-by-victoria-s-secret-high-rise-tight-5000007478?genericId=11171265&choice=0UNC&size1=16&size1=16&cm_mmc=PLA-_-GOOGLE-_-VSD_GS+-+VS-+Top+Products+-+Apparel+Bottoms+-+P1-_-Type_Legging&gclid=CjwKCAjwvuGJBhB1EiwACU1AiVWV81AYw3dhwSknrq3s3oxU5OWSYmMBX0nkSI6OncF8nRwOPOSiqBoCQ50QAvD_BwE&gclsrc=aw.ds",
                            ProductName = "Victorias Secret Leggings TYPE=AC32",
                            ProductPromotionalCode = "DIAZDEALS"
                        },
                        new
                        {
                            ID = 2,
                            Engagements = 0,
                            Image = "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/c368aa69-428f-421f-a59a-cc6d1c83460d/af-1-1-mens-shoes-kcdPxn.png",
                            ProductEndorsment = "This is my endorsment for this product its absolutley amazing in almost every way",
                            ProductLink = "https://www.nike.com/t/af-1-1-mens-shoes-kcdPxn/DB2576-001",
                            ProductName = "Nike AF 1/1 (F)",
                            ProductPromotionalCode = "NikePr0M0"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
