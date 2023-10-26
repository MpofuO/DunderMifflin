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

            if (!context.Addresses.Any())
            {
                context.Addresses.Add(
                    new Address { CustomerUserName="Collection"});
            }

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Typek A4 White Paper 5 Reams",
                        Description = "Typek A4 White Paper comes in a pack of 5 reams, providing 2500 sheets of high-quality white paper suitable for printing, writing, and various office needs.",
                        Quantity = 3000,
                        Price = 489.00M,
                        ProductTypeID = 1
                    },
new Product
{
    Name = "HP Papers, MultiPurpose 500 sheets",
    Description = "HP Multipurpose Papers offer 500 sheets of versatile paper suitable for a wide range of printing tasks. The sheets ensure crisp and reliable results for your printing needs.",
    Quantity = 3000,
    Price = 347.26M,
    ProductTypeID = 1
},
new Product
{
    Name = "Rotatrim 80gsm A4 Paper Ream White",
    Description = "Rotatrim 80gsm A4 Paper Ream in White provides a ream of A4-sized paper with a weight of 80gsm. The high-quality paper is ideal for both printing and writing purposes.",
    Quantity = 3000,
    Price = 89.00M,
    ProductTypeID = 1
},
new Product
{
    Name = "AC - Handmade Papers - Black & White",
    Description = "AC Handmade Papers offer a set of black and white handmade papers. These unique papers are suitable for artistic and creative projects, adding a distinctive touch to your work.",
    Quantity = 3000,
    Price = 230.00M,
    ProductTypeID = 1
},
new Product
{
    Name = "Epson 17in x 100ft Roll Enhanced Matte Paper",
    Description = "Epson 17in x 100ft Roll Enhanced Matte Paper provides a large roll of high-quality matte paper designed for printing photographs and other visuals with enhanced color and detail.",
    Quantity = 3000,
    Price = 1229.05M,
    ProductTypeID = 1
},
new Product
{
    Name = "Crayola Construction Paper Pad, 9\" x 12\" - 96 sheets",
    Description = "Crayola Construction Paper Pad offers a collection of 96 sheets of colorful construction paper, sized 9\" x 12\". These sheets are great for art and craft projects.",
    Quantity = 3000,
    Price = 75.89M,
    ProductTypeID = 1
},
new Product
{
    Name = "A5 Dry / Wet Media Paper Samplers And Test Packs - Fabriano | Artsavingsclub",
    Description = "A5 Dry / Wet Media Paper Samplers and Test Packs by Fabriano | Artsavingsclub contain a variety of paper types for testing and experimenting with different art mediums.",
    Quantity = 3000,
    Price = 15.00M,
    ProductTypeID = 1
},
new Product
{
    Name = "Radial Ball Pen & Clutch Pencil Set",
    Description = "Radial Ball Pen & Clutch Pencil Set includes a stylish ball pen and clutch pencil, offering a comfortable and elegant writing experience for both professional and personal use.",
    Quantity = 3000,
    Price = 38.73M,
    ProductTypeID = 2
},
new Product
{
    Name = "Unity Bamboo Ball Pen & Pencil Set",
    Description = "Unity Bamboo Ball Pen & Pencil Set features a combination of a ball pen and pencil made from sustainable bamboo, offering an eco-friendly writing solution.",
    Quantity = 3000,
    Price = 194.24M,
    ProductTypeID = 2
},
new Product
{
    Name = "Metal pen and pencil set in a gift box.",
    Description = "Metal Pen and Pencil Set comes in an elegant gift box, containing a premium ball pen and mechanical pencil crafted from durable metal materials.",
    Quantity = 3000,
    Price = 43.84M,
    ProductTypeID = 2
},
                    new Product
                    {
                        Name = "BIC Orange Fine Ballpoint Pen Blue - Box of 60",
                        Description = "BIC Orange Fine Ballpoint Pen Blue comes in a box of 60 pens. These pens feature a fine point tip, offering smooth and consistent blue ink for your writing needs.",
                        Quantity = 3000,
                        Price = 285.00M,
                        ProductTypeID = 2
                    },
new Product
{
    Name = "BIC Crystal Xtra Life Ballpoint Pens Assorted Pack Of 3",
    Description = "BIC Crystal Xtra Life Ballpoint Pens Assorted Pack includes three pens with assorted ink colors. The pens feature a clear barrel, providing a comfortable grip and long-lasting ink.",
    Quantity = 3000,
    Price = 489.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Adel Drawing Pencils - 2H (12 Pack)",
    Description = "Adel Drawing Pencils - 2H (12 Pack) offers a set of 12 high-quality drawing pencils with a 2H hardness level. These pencils are perfect for creating precise and detailed drawings.",
    Quantity = 3000,
    Price = 119.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "CROXLEY Pencils Pastel Hb Woodfree Pack 6",
    Description = "CROXLEY Pencils Pastel Hb Woodfree Pack includes six pastel-colored HB pencils. These wood-free pencils offer smooth writing and are great for both office and creative use.",
    Quantity = 3000,
    Price = 17.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Pencils HB Triangular Grip With Rubber(100 Pack)",
    Description = "Pencils HB Triangular Grip With Rubber come in a pack of 100 pencils. These HB pencils feature a triangular grip design and an eraser, making them comfortable for extended writing.",
    Quantity = 3000,
    Price = 239.80M,
    ProductTypeID = 2
},
new Product
{
    Name = "Freedom Stationery 48 Page A5 17mm Exercise Book",
    Description = "Freedom Stationery 48 Page A5 17mm Exercise Book offers a 48-page A5-sized exercise book with 17mm ruling. This book is ideal for note-taking and keeping track of your thoughts.",
    Quantity = 3000,
    Price = 2.95M,
    ProductTypeID = 3
},
new Product
{
    Name = "Freedom Stationery - A4 Counter Book 1 Quire - 96 Pages",
    Description = "Freedom Stationery - A4 Counter Book 1 Quire provides a 96-page A4-sized counter book with 1 quire. The book is suitable for various writing tasks and is easy to carry.",
    Quantity = 3000,
    Price = 22.99M,
    ProductTypeID = 3
},
new Product
{
    Name = "Freedom Stationery 144 Page A6 Memo Book",
    Description = "Freedom Stationery 144 Page A6 Memo Book offers a compact A6-sized memo book with 144 pages. The book is perfect for jotting down quick notes and reminders on the go.",
    Quantity = 3000,
    Price = 6.50M,
    ProductTypeID = 3
},
new Product
{
    Name = "Stationery - Colour & Sticker Book (4 Sticker Pages & 16 Colouring Pages",
    Description = "Stationery - Colour & Sticker Book features a coloring book with 16 coloring pages and 4 sticker pages. This book provides creative entertainment and is suitable for all ages.",
    Quantity = 3000,
    Price = 65.00M,
    ProductTypeID = 3
},
new Product
{
    Name = "1Pcs Kraft Paper Notebook Cute Pirint Daily Book Pocket Portable Notebook",
    Description = "1Pcs Kraft Paper Notebook Cute Pirint Daily Book is a single kraft paper notebook with a cute print cover. This pocket-sized notebook is perfect for jotting down thoughts and ideas on the go.",
    Quantity = 3000,
    Price = 32.46M,
    ProductTypeID = 3
},
                    new Product
                    {
                        Name = "Pocket Jotter Book by Bob Shop",
                        Description = "The Pocket Jotter Book by Bob Shop is a compact and portable journal perfect for quick note-taking. With its durable cover and convenient size, this jotter book is ideal for keeping your thoughts organized on the go.",
                        Quantity = 3000,
                        Price = 17.00M,
                        ProductTypeID = 3
                    },
new Product
{
    Name = "Freedom Stationery 192 Page A5 F&M Manuscript Book",
    Description = "The Freedom Stationery 192 Page A5 F&M Manuscript Book offers plenty of space for writing and recording your ideas. Its A5 size and 192 pages make it a great choice for creative writing, journaling, and more.",
    Quantity = 3000,
    Price = 19.90M,
    ProductTypeID = 3
},
new Product
{
    Name = "Canon Pixma Ink Printer 4in1 TR4540",
    Description = "The Canon Pixma Ink Printer 4in1 TR4540 is a versatile all-in-one printer that supports printing, scanning, copying, and faxing. With its compact design and wireless connectivity, it's perfect for both home and office use.",
    Quantity = 300,
    Price = 999.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Brother MFC-L8690CDW Colour Laser All-in-One",
    Description = "The Brother MFC-L8690CDW Colour Laser All-in-One printer offers professional-quality color printing, scanning, copying, and faxing. Its advanced features and high-speed performance make it suitable for demanding office environments.",
    Quantity = 300,
    Price = 15589.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "CANON PIXMA G2420 Printer",
    Description = "The CANON PIXMA G2420 Printer features a built-in ink tank system that offers high-volume and cost-effective printing. With its efficient design and reliable performance, it's an excellent choice for both home and small office use.",
    Quantity = 300,
    Price = 2499.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Sharp MX-4100N Color Enabled Copier 41 cpm",
    Description = "The Sharp MX-4100N Color Enabled Copier offers high-quality color copying and printing at a fast speed of 41 copies per minute. Designed for heavy-duty office use, it's equipped with advanced features for enhanced productivity.",
    Quantity = 50,
    Price = 105000.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Retractable Paper Cutter Utility Knives Stationery for School Office Home",
    Description = "The Retractable Paper Cutter Utility Knife is a versatile tool suitable for various tasks at school, office, and home. Its retractable blade design ensures safety and convenience while cutting paper, cardboard, and more.",
    Quantity = 3000,
    Price = 134.85M,
    ProductTypeID = 5
},
new Product
{
    Name = "Metric and Imperial Cutting Mat | A4",
    Description = "The Metric and Imperial Cutting Mat in A4 size is an essential tool for precise cutting and crafting. It features both metric and imperial measurements, making it convenient for various projects.",
    Quantity = 3000,
    Price = 85.00M,
    ProductTypeID = 5
},
new Product
{
    Name = "Genmes Full Metal Stapler",
    Description = "The Genmes Full Metal Stapler offers durability and reliability for all your stapling needs. Its sturdy metal construction ensures long-lasting performance, making it a valuable addition to your office or workspace.",
    Quantity = 3000,
    Price = 79.00M,
    ProductTypeID = 5
},
new Product
{
    Name = "Treeline Metal Stapler & Punch Combo + Box of Staples",
    Description = "The Treeline Metal Stapler & Punch Combo is a versatile tool that combines stapling and hole punching functions in one device. This combo set also includes a box of staples, providing everything you need for efficient document management.",
    Quantity = 3000,
    Price = 129.00M,
    ProductTypeID = 5
},
                    new Product
                    {
                        Name = "500ml Kraft Brown Paper Noodle Box",
                        Description = "The 500ml Kraft Brown Paper Noodle Box is perfect for serving a variety of dishes, from noodles to rice and more. Its eco-friendly and durable construction makes it a sustainable choice for takeout and food service.",
                        Quantity = 3000,
                        Price = 3.36M,
                        ProductTypeID = 5
                    },
new Product
{
    Name = "Watercolor Paper Pad, 9\" x 12\", 140lb, 30 Sheets",
    Description = "The Watercolor Paper Pad offers high-quality paper designed for watercolor painting. With its heavy weight, textured surface, and 30 sheets, it's a great option for artists and hobbyists looking to create vibrant watercolor artworks.",
    Quantity = 3000,
    Price = 25.99M,
    ProductTypeID = 1
},
new Product
{
    Name = "Moleskine Classic Notebook, Large, Ruled, Black",
    Description = "The Moleskine Classic Notebook in Large size features ruled pages, making it ideal for jotting down notes, thoughts, and ideas. Its sleek black cover and high-quality paper make it a timeless choice for journaling and writing.",
    Quantity = 3000,
    Price = 19.95M,
    ProductTypeID = 3
},
new Product
{
    Name = "A4 Clear Binding Covers, 100 Pack",
    Description = "The A4 Clear Binding Covers provide a professional finish to your documents. With a pack of 100 covers, you can enhance the appearance and durability of your reports, presentations, and projects.",
    Quantity = 3000,
    Price = 12.50M,
    ProductTypeID = 5
},
new Product
{
    Name = "Canson Sketch Book, 8.5\" x 11\", 100 Sheets",
    Description = "The Canson Sketch Book offers high-quality paper suitable for sketching and drawing. With its 8.5\" x 11\" size and 100 sheets, it's a great companion for artists and sketching enthusiasts.",
    Quantity = 3000,
    Price = 14.75M,
    ProductTypeID = 1
},
new Product
{
    Name = "Sticky Notes Variety Pack, 500 Sheets",
    Description = "The Sticky Notes Variety Pack includes 500 sheets of adhesive notes in various sizes and colors. These versatile sticky notes are perfect for reminders, quick notes, and organization.",
    Quantity = 3000,
    Price = 8.99M,
    ProductTypeID = 5
},
new Product
{
    Name = "Origami Paper Pack, 6\" x 6\", Assorted Colors, 200 Sheets",
    Description = "The Origami Paper Pack features 200 sheets of colorful paper specifically designed for origami projects. With its assorted colors and 6\" x 6\" size, it's a must-have for both beginners and experienced origami enthusiasts.",
    Quantity = 3000,
    Price = 7.49M,
    ProductTypeID = 1
},
new Product
{
    Name = "A4 Plastic Document Wallets, Assorted Colors, 10 Pack",
    Description = "The A4 Plastic Document Wallets provide a convenient way to organize and store your documents. This pack includes 10 wallets in assorted colors, making it easy to categorize and retrieve important papers.",
    Quantity = 3000,
    Price = 6.25M,
    ProductTypeID = 5
},
new Product
{
    Name = "Tissue Paper Assortment, 20\" x 26\", 100 Sheets",
    Description = "The Tissue Paper Assortment offers 100 sheets of soft and colorful tissue paper in a generous size of 20\" x 26\". It's perfect for gift wrapping, crafting, and adding a decorative touch to your projects.",
    Quantity = 3000,
    Price = 9.99M,
    ProductTypeID = 1
},
new Product
{
    Name = "Printer Paper 11\" x 17\", 500 Sheets",
    Description = "The Printer Paper in 11\" x 17\" size comes in a pack of 500 sheets, making it suitable for large-scale printing and copying. Its standard weight and size ensure compatibility with various printers and copiers.",
    Quantity = 3000,
    Price = 21.50M,
    ProductTypeID = 1
},
new Product
{
    Name = "Felt Tip Pens, Set of 24, Assorted Colors",
    Description = "The Felt Tip Pens Set includes 24 pens in a variety of vibrant colors. These pens are perfect for drawing, coloring, and writing. With their smooth and consistent ink flow, they are ideal for creative projects and everyday use.",
    Quantity = 3000,
    Price = 10.95M,
    ProductTypeID = 2
},
new Product
{
    Name = "Premium Lined Writing Stationery Set, 50 Sheets with Envelopes",
    Description = "The Premium Lined Writing Stationery Set offers 50 sheets of high-quality writing paper along with matching envelopes. With its elegant design and smooth paper, this set is perfect for writing letters, invitations, and special messages.",
    Quantity = 3000,
    Price = 15.75M,
    ProductTypeID = 3
},
new Product
{
    Name = "Scrapbooking Paper Pack, 12\" x 12\", Assorted Designs, 50 Sheets",
    Description = "The Scrapbooking Paper Pack includes 50 sheets of 12\" x 12\" paper with assorted designs. These papers are designed for scrapbooking, cardmaking, and various craft projects. With a variety of patterns, they add a creative touch to your creations.",
    Quantity = 3000,
    Price = 18.99M,
    ProductTypeID = 1
},
new Product
{
    Name = "A4 Glossy Photo Paper, 50 Sheets",
    Description = "The A4 Glossy Photo Paper comes in a pack of 50 sheets. Designed for printing photos, this paper delivers vibrant and sharp images with a glossy finish. It's perfect for preserving memories and creating photo albums.",
    Quantity = 3000,
    Price = 14.49M,
    ProductTypeID = 1
},
new Product
{
    Name = "Graph Paper Notebook, 5\" x 5\" Grid, 100 Sheets",
    Description = "The Graph Paper Notebook features a 5\" x 5\" grid layout with 100 sheets. It's suitable for technical drawings, mathematical graphs, and various diagramming tasks. The grid helps maintain precision in your work.",
    Quantity = 3000,
    Price = 7.99M,
    ProductTypeID = 3
},
new Product
{
    Name = "Decorative Washi Tape Set, Assorted Patterns, 10 Rolls",
    Description = "The Decorative Washi Tape Set includes 10 rolls of washi tape with assorted patterns. Washi tape is a versatile crafting supply that can be used for decorating journals, cards, scrapbooks, and more. Its removable nature makes it easy to use and reposition.",
    Quantity = 3000,
    Price = 9.75M,
    ProductTypeID = 5
},
new Product
{
    Name = "Handmade Lokta Paper Sheets, Natural Fiber, 8.5\" x 11\", 25 Sheets",
    Description = "The Handmade Lokta Paper Sheets come in a pack of 25 sheets. Made from natural lokta fiber, these sheets have a unique texture and appearance. They are perfect for creating distinctive invitations, art projects, and crafts.",
    Quantity = 3000,
    Price = 19.99M,
    ProductTypeID = 1
},
new Product
{
    Name = "A4 Plastic Index Dividers, 5-Tab Set",
    Description = "The A4 Plastic Index Dividers come in a set of 5 tabs. These dividers are perfect for organizing documents in binders and folders. The plastic construction ensures durability and longevity.",
    Quantity = 3000,
    Price = 4.25M,
    ProductTypeID = 5
},
new Product
{
    Name = "Origami Kit with Instruction Book and Colored Paper",
    Description = "The Origami Kit includes an instruction book and colored paper for creating various origami projects. This kit is suitable for beginners and experienced origami enthusiasts alike. It's a fun and creative way to explore the art of paper folding.",
    Quantity = 3000,
    Price = 12.95M,
    ProductTypeID = 1
},
new Product
{
    Name = "Calligraphy Practice Paper Pad, 50 Sheets",
    Description = "The Calligraphy Practice Paper Pad contains 50 sheets of specially designed paper for calligraphy practice. With guidelines for lettering and ample space, this pad helps beginners learn and refine their calligraphy skills.",
    Quantity = 3000,
    Price = 8.49M,
    ProductTypeID = 1
},
new Product
{
    Name = "Staple Remover, Ergonomic Design",
    Description = "Effortlessly remove staples with this ergonomic staple remover. Its design ensures easy and precise staple extraction, minimizing paper damage. A handy tool for offices and home use.",
    Quantity = 3000,
    Price = 3.25M,
    ProductTypeID = 5
},
new Product
{
    Name = "Pastel Chalk Set, Assorted Colors, 24 Sticks",
    Description = "Unleash your creativity with this set of 24 pastel chalk sticks. These assorted colors provide a soft and blendable medium for various artistic projects. Ideal for drawing, shading, and highlighting.",
    Quantity = 3000,
    Price = 9.99M,
    ProductTypeID = 2
},
new Product
{
    Name = "Leather-Bound Journal, Handcrafted, 200 Pages",
    Description = "Experience the timeless charm of this handcrafted leather-bound journal. With 200 pages of high-quality paper, it's perfect for journaling, sketching, and capturing your thoughts in style.",
    Quantity = 3000,
    Price = 38.50M,
    ProductTypeID = 3
},
new Product
{
    Name = "Inkjet Photo Paper, 4\" x 6\", Glossy Finish, 100 Sheets",
    Description = "Print your cherished memories with this pack of 4\" x 6\" inkjet photo paper. The glossy finish enhances image vibrancy, making your photos come to life. Ideal for preserving your special moments.",
    Quantity = 3000,
    Price = 8.75M,
    ProductTypeID = 1
},
new Product
{
    Name = "Mechanical Pencil Set, 0.5mm, Pack of 6",
    Description = "Write and draw with precision using this pack of six 0.5mm mechanical pencils. The fine lead diameter ensures accurate lines, while the refillable design makes them a sustainable choice.",
    Quantity = 3000,
    Price = 5.49M,
    ProductTypeID = 2
},
new Product
{
    Name = "Interactive Children's Coloring Book, 20 Pages",
    Description = "Entertain and educate with this interactive coloring book for children. Featuring 20 engaging pages, it combines learning and creativity to keep young minds entertained for hours.",
    Quantity = 3000,
    Price = 12.99M,
    ProductTypeID = 3
},
new Product
{
    Name = "3D Printer Filament Spool, PLA Material, 1kg",
    Description = "Fuel your 3D printing projects with this 1kg spool of PLA filament. Known for its reliability and ease of use, PLA is a versatile choice for creating various objects with your 3D printer.",
    Quantity = 3000,
    Price = 28.50M,
    ProductTypeID = 4
},
new Product
{
    Name = "Craft Glue Stick, Washable, 0.7oz, Pack of 12",
    Description = "Stick with this pack of 12 washable craft glue sticks. Ideal for bonding paper, fabric, and other materials, these glue sticks are a versatile choice for school, crafts, and DIY projects.",
    Quantity = 3000,
    Price = 6.25M,
    ProductTypeID = 5
},
new Product
{
    Name = "Erasable Gel Pens, Set of 8, Assorted Colors",
    Description = "Write, erase, and rewrite with ease using this set of eight erasable gel pens. The assorted colors add vibrancy to your notes and drawings, making them perfect for both work and play.",
    Quantity = 3000,
    Price = 11.99M,
    ProductTypeID = 2
},
new Product
{
    Name = "Pocket Dictionary, English Language, Paperback",
    Description = "Expand your vocabulary with this pocket-sized English dictionary. With its convenient paperback format, it's a valuable reference for students, writers, and language enthusiasts on the go.",
    Quantity = 3000,
    Price = 5.75M,
    ProductTypeID = 3
},
new Product
{
    Name = "3D Printing Pen, Adjustable Speed and Temperature",
    Description = "Explore your creativity in three dimensions with this 3D printing pen. Its adjustable speed and temperature settings allow you to create intricate designs and models. Perfect for artists, designers, and hobbyists.",
    Quantity = 3000,
    Price = 34.95M,
    ProductTypeID = 4
},
new Product
{
    Name = "Colored Pencil Set, 36 Colors, Pre-Sharpened",
    Description = "Add a burst of color to your artwork with this set of 36 pre-sharpened colored pencils. These vibrant pencils are ideal for coloring, shading, and blending. Suitable for artists of all levels.",
    Quantity = 3000,
    Price = 16.50M,
    ProductTypeID = 2
},
new Product
{
    Name = "Spiral Bound Sketchbook, 9\" x 12\", 100 Sheets",
    Description = "Capture your ideas and sketches in this spiral-bound sketchbook. With 100 sheets of high-quality paper, it provides ample space for your artistic endeavors. The 9\" x 12\" size is great for both on-the-go and studio work.",
    Quantity = 3000,
    Price = 13.25M,
    ProductTypeID = 1
},
new Product
{
    Name = "Mechanical Drafting Pencil Set, 0.7mm, Pack of 3",
    Description = "Achieve precision in your technical drawings with this pack of three 0.7mm mechanical drafting pencils. The fine lead size is perfect for detailed work, making them a valuable tool for architects, engineers, and drafters.",
    Quantity = 3000,
    Price = 8.99M,
    ProductTypeID = 2
},
new Product
{
    Name = "Eco-Friendly Notebook, Recycled Paper, A5 Size",
    Description = "Make sustainable choices with this eco-friendly A5 notebook. Crafted from recycled paper, it's an ideal companion for jotting down notes, ideas, and sketches. A responsible option for conscious individuals.",
    Quantity = 3000,
    Price = 5.99M,
    ProductTypeID = 3
},
new Product
{
    Name = "Laser Printer Toner Cartridge, Black, Compatible with Model X",
    Description = "Ensure sharp and consistent prints with this black laser printer toner cartridge. Designed to be compatible with Model X printers, it delivers professional-quality results. Perfect for offices and businesses.",
    Quantity = 3000,
    Price = 42.50M,
    ProductTypeID = 4
},
new Product
{
    Name = "Whiteboard Markers, Set of 10, Assorted Colors",
    Description = "Enhance your presentations and brainstorming sessions with this set of ten assorted whiteboard markers. The vivid colors and fine tips allow for clear and bold writing on whiteboards and other smooth surfaces.",
    Quantity = 3000,
    Price = 15.49M,
    ProductTypeID = 5
},
new Product
{
    Name = "Chalkboard Easel Stand with Chalk and Eraser",
    Description = "Add a touch of vintage charm to your space with this chalkboard easel stand. Complete with chalk and eraser, it's perfect for displaying menus, notes, and messages. A versatile addition to cafes, events, and more.",
    Quantity = 3000,
    Price = 28.75M,
    ProductTypeID = 5
},
new Product
{
    Name = "Vintage Leather Journal with Lock, 120 Pages",
    Description = "Preserve your thoughts and reflections in this vintage-style leather journal. Featuring a lock for privacy and 120 pages of unlined paper, it's a beautiful keepsake for personal writings and musings.",
    Quantity = 3000,
    Price = 27.99M,
    ProductTypeID = 3
},
new Product
{
    Name = "3-Ring Binder, 1.5\" Capacity, Durable Construction",
    Description = "Keep your documents organized with this 1.5\" capacity 3-ring binder. Its durable construction ensures long-lasting use, making it an essential tool for school, work, and home organization.",
    Quantity = 3000,
    Price = 6.95M,
    ProductTypeID = 5
},
new Product
{
    Name = "Metallic Gel Pens, Set of 12, Glitter and Metallic Colors",
    Description = "Add a touch of shimmer to your artwork with this set of 12 metallic gel pens. Featuring both glitter and metallic colors, these pens are perfect for adding highlights, details, and a touch of elegance to your creative projects.",
    Quantity = 3000,
    Price = 9.75M,
    ProductTypeID = 2
},
new Product
{
    Name = "Archival Watercolor Paper Roll, 24\" x 10 Yards, 300lb",
    Description = "Elevate your watercolor creations with this archival watercolor paper roll. Measuring 24\" x 10 yards and weighing 300lb, it offers durability and exceptional quality. Perfect for artists seeking longevity in their masterpieces.",
    Quantity = 3000,
    Price = 149.99M,
    ProductTypeID = 1
},
new Product
{
    Name = "Montblanc Meisterstück Gold-Coated Fountain Pen",
    Description = "Experience timeless elegance with the Montblanc Meisterstück fountain pen. With a gold-coated finish and exceptional craftsmanship, this fountain pen is a symbol of sophistication and prestige. A perfect companion for your writing endeavors.",
    Quantity = 3000,
    Price = 689.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Limited Edition Leather-Bound Art Book Set, Signed by the Artist",
    Description = "Own a piece of art history with this limited edition art book set. Handcrafted and leather-bound, each book is signed by the artist. An exquisite collection that showcases the beauty and significance of the artworks within.",
    Quantity = 3000,
    Price = 599.99M,
    ProductTypeID = 3
},
new Product
{
    Name = "Professional-grade Photo Printer, Large Format",
    Description = "Unlock the true potential of your photography with this professional-grade large format photo printer. Designed to deliver stunning prints with exceptional detail and color accuracy, it's an essential tool for photographers and artists.",
    Quantity = 300,
    Price = 4599.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Premium Leather Notebook with Gold-Plated Trim",
    Description = "Indulge in luxury with this premium leather notebook. Adorned with gold-plated trim, it's a combination of exquisite craftsmanship and refined aesthetics. Whether for writing, sketching, or planning, it's a statement of sophistication.",
    Quantity = 3000,
    Price = 299.95M,
    ProductTypeID = 3
},
new Product
{
    Name = "Handcrafted Solid Gold Pen and Pencil Set",
    Description = "Experience opulence in writing with this handcrafted solid gold pen and pencil set. Meticulously designed and crafted from genuine gold, this set is a collector's dream and a testament to the artistry of fine writing instruments.",
    Quantity = 3000,
    Price = 2899.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Limited Edition Woodblock Print Book Collection",
    Description = "Immerse yourself in the beauty of woodblock prints with this limited edition book collection. Featuring a curated selection of exquisite prints, this collection is a tribute to the artistry and tradition of woodblock printing.",
    Quantity = 3000,
    Price = 999.00M,
    ProductTypeID = 3
},
new Product
{
    Name = "High-End 3D Printer with Multi-Material Support",
    Description = "Explore the possibilities of 3D printing with this high-end printer. With multi-material support and advanced features, it empowers you to bring your complex designs to life. Ideal for professionals and enthusiasts seeking precision.",
    Quantity = 300,
    Price = 7499.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Antique Calligraphy Pen Set in Ornate Wooden Case",
    Description = "Step into the world of classic calligraphy with this antique pen set. Presented in an ornate wooden case, the set includes a selection of beautifully crafted pens and nibs. A treasure for calligraphy enthusiasts and collectors alike.",
    Quantity = 3000,
    Price = 399.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Collector's Edition Leather-Bound Encyclopedia Set",
    Description = "Immerse yourself in a world of knowledge with this meticulously curated collector's edition encyclopedia set. Bound in finest leather and enriched with beautifully illustrated pages, it's a testament to the pursuit of learning and discovery.",
    Quantity = 3000,
    Price = 1499.00M,
    ProductTypeID = 3
},
new Product
{
    Name = "Industrial-grade Laser Engraving Machine",
    Description = "Unleash your creativity with this industrial-grade laser engraving machine. From intricate designs to personalized creations, its precision and power make it an essential tool for artisans, makers, and businesses seeking to leave a lasting mark.",
    Quantity = 50,
    Price = 12500.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Luxury Rollerball Pen with Precious Gemstone Inlay",
    Description = "Experience the art of writing with this exquisite luxury rollerball pen. Meticulously crafted and adorned with a precious gemstone inlay, it's a symbol of refinement and sophistication. A writing instrument that transcends time and trends.",
    Quantity = 3000,
    Price = 1250.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Handcrafted Art Journal with Gold Leaf Details",
    Description = "Capture your thoughts and inspirations in this handcrafted art journal. Each page is a canvas for your creativity, enhanced by delicate gold leaf details. Whether for sketches, writings, or reflections, it's a journey of self-expression.",
    Quantity = 3000,
    Price = 499.99M,
    ProductTypeID = 3
},
new Product
{
    Name = "High-Performance Wide-Format Printer for Professional Photography",
    Description = "Elevate your photography with this high-performance wide-format printer. Designed to reproduce your art with stunning accuracy and vibrancy, it's the choice of professionals who demand excellence in every print.",
    Quantity = 300,
    Price = 9999.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Limited Edition Fountain Pen Collection with Unique Nibs",
    Description = "Discover the pleasure of writing with this limited edition fountain pen collection. Each pen features a unique nib design, offering a personalized writing experience. Encased in a presentation box, it's a tribute to the art of penmanship.",
    Quantity = 3000,
    Price = 1699.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Rare Manuscript Reproduction Set, Leather-Bound",
    Description = "Hold history in your hands with this rare manuscript reproduction set. Bound in leather and meticulously replicated, these manuscripts bridge the past and present. A treasure trove for history enthusiasts and collectors.",
    Quantity = 3000,
    Price = 1299.00M,
    ProductTypeID = 3
},
new Product
{
    Name = "State-of-the-Art 3D Printing Workstation",
    Description = "Explore the frontiers of creation with this state-of-the-art 3D printing workstation. Equipped with cutting-edge technology, it's a powerhouse for bringing your ideas to life in three dimensions. A tool that empowers innovation.",
    Quantity = 300,
    Price = 17500.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Handmade Solid Silver Pencil with Engraved Details",
    Description = "Experience the luxury of writing with this handmade solid silver pencil. Its engraved details reflect artisanal craftsmanship, making it a statement piece for your desk. A blend of elegance and functionality.",
    Quantity = 3000,
    Price = 1899.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Collector's Edition Historical Documents Replica Set",
    Description = "Step into the past with this collector's edition replica set. Meticulously crafted replicas of historical documents offer insight into pivotal moments in time. A testament to the preservation of heritage and the thrill of discovery.",
    Quantity = 3000,
    Price = 2499.00M,
    ProductTypeID = 3
},
new Product
{
    Name = "Professional 3D Resin Printer with Ultra-High Resolution",
    Description = "Experience the pinnacle of 3D printing precision with this professional-grade resin printer. Its ultra-high resolution brings your designs to life with remarkable accuracy, making it a must-have tool for architects, designers, and creators seeking perfection.",
    Quantity = 300,
    Price = 6999.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Customizable Premium Leather Sketchbook with Gold Initials",
    Description = "Elevate your artistic journey with this premium leather sketchbook. Impeccably crafted and customizable with your gold initials, it's a timeless companion for your creative expressions. An embodiment of luxury and creativity.",
    Quantity = 3000,
    Price = 389.00M,
    ProductTypeID = 3
},
new Product
{
    Name = "Limited Edition Fountain Pen with Diamond-Encrusted Cap",
    Description = "Indulge in opulence with this limited edition fountain pen. Its exquisite diamond-encrusted cap transforms writing into an extraordinary experience. A symbol of prestige and refinement, it's a collector's dream.",
    Quantity = 3000,
    Price = 4999.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Handcrafted Leather-Bound Travel Journal with Lock",
    Description = "Capture your journeys and reflections in this handcrafted leather-bound travel journal. Its intricate design, complete with a lock, ensures your memories remain secure. An invitation to document your adventures in style.",
    Quantity = 3000,
    Price = 349.95M,
    ProductTypeID = 3
},
new Product
{
    Name = "Industrial 3D Metal Printer for High-Strength Prototypes",
    Description = "Forge innovation with this industrial 3D metal printer. Ideal for creating high-strength prototypes and functional parts, it's a game-changer for engineers and manufacturers pushing the boundaries of possibility.",
    Quantity = 50,
    Price = 25999.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Professional Art Markers Set, 200 Colors",
    Description = "Unleash your creativity with this professional art markers set. With 200 vibrant colors at your fingertips, it's a versatile tool for illustrators, designers, and artists. Elevate your artwork with precision and flair.",
    Quantity = 3000,
    Price = 349.99M,
    ProductTypeID = 2
},
new Product
{
    Name = "Collector's Edition Deluxe Hardcover Anthology Set",
    Description = "Immerse yourself in a world of literary treasures with this collector's edition anthology set. Presented in deluxe hardcover, it's a journey through literary masterpieces that spans genres and eras.",
    Quantity = 3000,
    Price = 799.00M,
    ProductTypeID = 3
},
new Product
{
    Name = "Large-Format Fine Art Printer with UltraHD Technology",
    Description = "Turn your artistic visions into reality with this large-format fine art printer. Equipped with UltraHD technology, it reproduces your work with astonishing detail and color accuracy. The choice of fine artists and galleries.",
    Quantity = 300,
    Price = 18999.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Luxury Rollerball Pen and Fountain Pen Set, Platinum Trim",
    Description = "Experience the epitome of writing elegance with this luxury rollerball pen and fountain pen set. Adorned with platinum trim, these pens redefine sophistication and offer an unparalleled writing experience.",
    Quantity = 3000,
    Price = 1999.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Unique Handmade Leather Journal with Metal Embellishments",
    Description = "Celebrate uniqueness with this handmade leather journal. Embellished with intricate metal details, it's a tactile masterpiece that holds your thoughts, sketches, and dreams. A reflection of individuality and artistry.",
    Quantity = 3000,
    Price = 449.00M,
    ProductTypeID = 3
},
new Product
{
    Name = "Precision CNC Engraving Machine with Automated Tool Changer",
    Description = "Elevate your engraving capabilities with this precision CNC machine. Featuring an automated tool changer, it streamlines your workflow and delivers unparalleled accuracy, making it a cornerstone for engineers and artisans.",
    Quantity = 50,
    Price = 48999.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Limited Edition Gold-Dipped Calligraphy Pen Set",
    Description = "Discover the art of calligraphy with this limited edition pen set. Dipped in gold and meticulously crafted, it marries timeless elegance with the fluidity of your strokes, allowing you to create masterful compositions.",
    Quantity = 3000,
    Price = 2999.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Artistic Printmaking Press for Traditional and Digital Plates",
    Description = "Unleash your creativity with this artistic printmaking press. Designed for both traditional and digital plates, it empowers artists to produce captivating prints. A versatile tool for printmakers and mixed media enthusiasts.",
    Quantity = 50,
    Price = 17999.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Premium Fountain Pen with Hand-Painted Enamel Finish",
    Description = "Compose your thoughts in style with this premium fountain pen. Its hand-painted enamel finish exemplifies luxury, while the smooth flow of ink ensures an unparalleled writing experience. A testament to sophistication and craftsmanship.",
    Quantity = 3000,
    Price = 1299.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Exquisite Leather Portfolio with Custom Monogramming",
    Description = "Make a statement of professionalism with this exquisite leather portfolio. Embellished with custom monogramming, it's a refined accessory that houses your important documents and notes. A fusion of elegance and utility.",
    Quantity = 3000,
    Price = 579.00M,
    ProductTypeID = 5
},
new Product
{
    Name = "High-End Digital Flatbed Scanner for Large Artwork",
    Description = "Preserve your artwork in pristine detail with this high-end flatbed scanner. Designed for large pieces, it captures every nuance and color with precision. A necessity for artists and photographers seeking digital accuracy.",
    Quantity = 300,
    Price = 14499.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Luxurious Gold Nib Fountain Pen with Solid Wood Case",
    Description = "Indulge in the art of writing with this luxurious gold nib fountain pen. Presented in a solid wood case, it's a tactile masterpiece that transforms every stroke into an experience of elegance and refinement.",
    Quantity = 3000,
    Price = 1599.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Deluxe Writing Set with Handcrafted Feather Quill",
    Description = "Step back in time with this deluxe writing set featuring a handcrafted feather quill. A nod to the past, it evokes the romance of timeless letters and musings, inviting you to create with elegance and nostalgia.",
    Quantity = 3000,
    Price = 699.00M,
    ProductTypeID = 2
},
new Product
{
    Name = "Precision Laser Cutter for Intricate Paper and Wood Designs",
    Description = "Turn intricate designs into reality with this precision laser cutter. Whether it's paper or wood, it crafts with accuracy and finesse. A tool that empowers artists, architects, and designers to push boundaries.",
    Quantity = 50,
    Price = 32999.00M,
    ProductTypeID = 4
},
new Product
{
    Name = "Bespoke Handmade Leather-Bound Art Journal with Embossing",
    Description = "Elevate your journaling experience with this bespoke leather-bound art journal. With intricate embossing and handcraftsmanship, it's a canvas for your thoughts and creations, a tactile masterpiece that sparks inspiration.",
    Quantity = 3000,
    Price = 529.00M,
    ProductTypeID = 3
},
new Product
{
    Name = "Museum-Quality Fine Art Printer for Gallery Exhibitions",
    Description = "Bring your art to life with this museum-quality fine art printer. Perfect for gallery exhibitions, it reproduces your work with museum-level detail and color accuracy. The choice of artists aiming for perfection.",
    Quantity = 300,
    Price = 37999.00M,
    ProductTypeID = 4
}
                    );
            }

            context.SaveChanges();
        }
    }
}
