using Microsoft.EntityFrameworkCore.Migrations;

namespace MkAffiliationManagement.Migrations.AdvertismentDb
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ad",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: false),
                    ProductEndorsment = table.Column<string>(nullable: false),
                    ProductPromotionalCode = table.Column<string>(nullable: false),
                    ProductLink = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ad", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "ID", "Image", "ProductEndorsment", "ProductLink", "ProductName", "ProductPromotionalCode" },
                values: new object[] { 1, "https://www.victoriassecret.com/p/760x1013/tif/0b/3d/0b3d5a483b5c4b9bab0815e5f1336309/111712650UNC_OM_F.jpg", "I love, love, love the rainbow leaves! I only wear VS leggings to run or just relax in. They are super comfy and never roll during workouts. This is the second pair of these leggings I have purchased.  They fit and feel great!", "https://www.victoriassecret.com/us/vs/apparel-catalog/victoria-s-secret-total-knockout-by-victoria-s-secret-high-rise-tight-5000007478?genericId=11171265&choice=0UNC&size1=16&size1=16&cm_mmc=PLA-_-GOOGLE-_-VSD_GS+-+VS-+Top+Products+-+Apparel+Bottoms+-+P1-_-Type_Legging&gclid=CjwKCAjwvuGJBhB1EiwACU1AiVWV81AYw3dhwSknrq3s3oxU5OWSYmMBX0nkSI6OncF8nRwOPOSiqBoCQ50QAvD_BwE&gclsrc=aw.ds", "Victorias Secret Leggings TYPE=AC32", "DIAZDEALS" });

            migrationBuilder.InsertData(
                table: "Ad",
                columns: new[] { "ID", "Image", "ProductEndorsment", "ProductLink", "ProductName", "ProductPromotionalCode" },
                values: new object[] { 2, "https://static.nike.com/a/images/t_PDP_864_v1/f_auto,b_rgb:f5f5f5/c368aa69-428f-421f-a59a-cc6d1c83460d/af-1-1-mens-shoes-kcdPxn.png", "This is my endorsment for this product its absolutley amazing in almost every way", "https://www.nike.com/t/af-1-1-mens-shoes-kcdPxn/DB2576-001", "Nike AF 1/1 (F)", "NikePr0M0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ad");
        }
    }
}
