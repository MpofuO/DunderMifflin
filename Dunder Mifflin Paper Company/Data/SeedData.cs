using Dunder_Mifflin_Paper_Company.Models;
using Microsoft.EntityFrameworkCore;

namespace Dunder_Mifflin_Paper_Company.Data
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            AppDbContext context = app.ApplicationServices
                .CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }

            if (!context.ProductTypes.Any())
            {
                context.ProductTypes.AddRange(
                    new ProductType { ProductTypeID = 1, ProductTypeName = "Paper" },
                    new ProductType { ProductTypeID = 2, ProductTypeName = "Pens and Pencils" },
                    new ProductType { ProductTypeID = 3, ProductTypeName = "Books" },
                    new ProductType { ProductTypeID = 4, ProductTypeName = "Printers and Copiers" },
                    new ProductType { ProductTypeID = 5, ProductTypeName = "Other" }
                    );
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product { Name = "Typek A4 White Paper 5 Reams", Quantity = 3000, Price = 489.00M, ProductTypeID = 1 },
                    new Product { Name = "HP Papers, MultiPurpose 500 sheets", Quantity = 3000, Price = 347.26M, ProductTypeID = 1 },
                    new Product { Name = "Rotatrim 80gsm A4 Paper Ream White", Quantity = 3000, Price = 89.00M, ProductTypeID = 1 },
                    new Product { Name = "AC - Handmade Papers - Black & White", Quantity = 3000, Price = 230.00M, ProductTypeID = 1 },
                    new Product { Name = "Epson 17in x 100ft Roll Enhanced Matte Paper", Quantity = 3000, Price = 1229.05M, ProductTypeID = 1 },
                    new Product { Name = "Crayola Construction Paper Pad, 9\" x 12\" - 96 sheets", Quantity = 3000, Price = 75.89M, ProductTypeID = 1 },
                    new Product { Name = "A5 Dry / Wet Media Paper Samplers And Test Packs - Fabriano | Artsavingsclub", Quantity = 3000, Price = 15.00M, ProductTypeID = 1 },
                    new Product { Name = "Radial Ball Pen & Clutch Pencil Set", Quantity = 3000, Price = 38.73M, ProductTypeID = 2 },
                    new Product { Name = "Unity Bamboo Ball Pen & Pencil Set", Quantity = 3000, Price = 194.24M, ProductTypeID = 2 },
                    new Product { Name = "Metal pen and pencil set in a gift box.", Quantity = 3000, Price = 43.84M, ProductTypeID = 2 },
                    new Product { Name = "BIC Orange Fine Ballpoint Pen Blue - Box of 60", Quantity = 3000, Price = 285.00M, ProductTypeID = 2 },
                    new Product { Name = "BIC Crystal Xtra Life Ballpoint Pens Assorted Pack Of 3", Quantity = 3000, Price = 489.00M, ProductTypeID = 2 },
                    new Product { Name = "Adel Drawing Pencils - 2H (12 Pack)", Quantity = 3000, Price = 119.00M, ProductTypeID = 2 },
                    new Product { Name = "CROXLEY Pencils Pastel Hb Woodfree Pack 6", Quantity = 3000, Price = 17.00M, ProductTypeID = 2 },
                    new Product { Name = "Pencils HB Triangular Grip With Rubber(100 Pack)", Quantity = 3000, Price = 239.80M, ProductTypeID = 2 },
                    new Product { Name = "Freedom Stationery 48 Page A5 17mm Exercise Book", Quantity = 3000, Price = 2.95M, ProductTypeID = 3 },
                    new Product { Name = "Freedom Stationery - A4 Counter Book 1 Quire - 96 Pages", Quantity = 3000, Price = 22.99M, ProductTypeID = 3 },
                    new Product { Name = "Freedom Stationery 144 Page A6 Memo Book", Quantity = 3000, Price = 6.50M, ProductTypeID = 3 },
                    new Product { Name = "Stationery - Colour & Sticker Book (4 Sticker Pages & 16 Colouring Pages", Quantity = 3000, Price = 65.00M, ProductTypeID = 3 },
                    new Product { Name = "1Pcs Kraft Paper Notebook Cute Pirint Daily Book Pocket Portable Notebook", Quantity = 3000, Price = 32.46M, ProductTypeID = 3 },
                    new Product { Name = "Pocket Jotter Book by Bob Shop", Quantity = 3000, Price = 17.00M, ProductTypeID = 3 },
                    new Product { Name = "Freedom Stationery 192 Page A5 F&M Manuscript Book", Quantity = 3000, Price = 19.90M, ProductTypeID = 3 },
                    new Product { Name = "Canon Pixma Ink Printer 4in1 TR4540", Quantity = 300, Price = 999.00M, ProductTypeID = 4 },
                    new Product { Name = "Brother MFC-L8690CDW Colour Laser All-in-One", Quantity = 300, Price = 15589.00M, ProductTypeID = 4 },
                    new Product { Name = "CANON PIXMA G2420 Printer", Quantity = 300, Price = 2499.00M, ProductTypeID = 4 },
                    new Product { Name = "Sharp MX-4100N Color Enabled Copier 41 cpm", Quantity = 50, Price = 105000.00M, ProductTypeID = 4 },
                    new Product { Name = "Retractable Paper Cutter Utility Knives Stationery for School Office Home", Quantity = 3000, Price = 134.85M, ProductTypeID = 5 },
                    new Product { Name = "Metric and Imperial Cutting Mat | A4", Quantity = 3000, Price = 85.00M, ProductTypeID = 5 },
                    new Product { Name = "Genmes Full Metal Stapler", Quantity = 3000, Price = 79.00M, ProductTypeID = 5 },
                    new Product { Name = "Treeline Metal Stapler & Punch Combo + Box of Staples", Quantity = 3000, Price = 129.00M, ProductTypeID = 5 },
                    new Product { Name = "500ml Kraft Brown Paper Noodle Box", Quantity = 3000, Price = 3.36M, ProductTypeID = 5 }
                    );
            }

            context.SaveChanges();
        }
    }
}
