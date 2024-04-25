using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public class DbInitializer
    {
        public static async Task Initializer(StoreContext context, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new User
                {
                    UserName = "bob",
                    Email = "bob@test.com"
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Member");

                var admin = new User
                {
                    UserName = "admin",
                    Email = "admin@test.com"
                };
                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] {"Member", "Admin"});
            }
            

            if (context.Products.Any()) return;

            var products = new List<Product>
            {
                new Product
            {
                Name = "The Great Gatsby",
                Description = "The Great Gatsby is a novel written by F. Scott Fitzgerald. It tells the story of the mysterious millionaire Jay Gatsby and his obsession with the beautiful Daisy Buchanan in the 1920s.",
                Price = 1545,
                PictureUrl = "https://images.unsplash.com/photo-1694454081401-cef6ac439445?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1932&q=80",
                Brand = "Penguin Books",
                Type = "Fiction",
                QuantityInStock = 100,
            },
            new Product
            {
                Name = "To Kill a Mockingbird",
                Description = "To Kill a Mockingbird is a classic novel by Harper Lee. It explores themes of racism and injustice in the American South during the 1930s, as seen through the eyes of a young girl named Scout Finch.",
                Price = 1200,
                PictureUrl = "https://plus.unsplash.com/premium_photo-1676047258590-8a8a2a583050?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1936&q=80",
                Brand = "HarperCollins",
                Type = "Fiction",
                QuantityInStock = 85,
            },
            new Product
            {
                Name = "The Catcher in the Rye",
                Description = "The Catcher in the Rye is a novel by J.D. Salinger. It follows the experiences of Holden Caulfield, a disenchanted teenager in New York City, as he grapples with the challenges of growing up.",
                Price = 1500,
                PictureUrl = "https://plus.unsplash.com/premium_photo-1676047258590-8a8a2a583050?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1936&q=80",
                Brand = "Little Brown and Company",
                Type = "Fiction",
                QuantityInStock = 75,
            },
            new Product
            {
                Name = "The Hobbit",
                Description = "The Hobbit is a fantasy novel by J.R.R. Tolkien. It tells the tale of Bilbo Baggins, a hobbit who embarks on an epic adventure with a group of dwarves to reclaim their homeland from the dragon Smaug.",
                Price = 1800,
                PictureUrl = "https://images.unsplash.com/photo-1694406129739-0851220bf8ab?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1871&q=80",
                Brand = "Houghton Mifflin",
                Type = "Fantasy",
                QuantityInStock = 110,
            },
            new Product
            {
                Name = "The Embarks",
                Description = "Hobbit who embarks on an epic adventure with a peers of dwarves to reclaim their country from the dragon Smaug.",
                Price = 1800,
                PictureUrl = "https://images.unsplash.com/photo-1694406129739-0851220bf8ab?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1871&q=80",
                Brand = "Rahab Light",
                Type = "Scientific Fiction",
                QuantityInStock = 11,
            },
            new Product
            {
                Name = "The Hallan diary",
                Description = "The Hobbit is a fantasy novel by J. Hallan witten with a group of immigrants from the USA.",
                Price = 1800,
                PictureUrl = "https://images.unsplash.com/photo-1694406129739-0851220bf8ab?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1871&q=80",
                Brand = "Adams Toke",
                Type = "Fantasy",
                QuantityInStock = 50,
            },
            new Product
            {
                Name = "Tickler Sower",
                Description = "This defines the attibutes of a group of young lads that are playing the deadly game of entering a zoo with unleashed Lions.",
                Price = 1800,
                PictureUrl = "https://images.unsplash.com/photo-1694406129739-0851220bf8ab?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1871&q=80",
                Brand = "Kendrick Hitler",
                Type = "Horror",
                QuantityInStock = 31,
            },
            new Product
            {
                Name = "1984 - The Return of Ikenga the American",
                Description = "1984 is a dystopian novel by George Orwell. It depicts a totalitarian society ruled by Big Brother, where independent thought and freedom are suppressed, and surveillance is omnipresent.",
                Price = 1375,
                PictureUrl = "https://plus.unsplash.com/premium_photo-1694412515981-f30c5beb7e62?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1887&q=80",
                Brand = "Penguin Books",
                Type = "Fiction",
                QuantityInStock = 95,
            },
            new Product
            {
                Name = "Harry Potter and the Philosopher's Stone",
                Description = "Harry Potter and the Philosopher's Stone is the first book in the Harry Potter series by J.K. Rowling. It introduces the young wizard Harry Potter and his adventures at Hogwarts School of Witchcraft and Wizardry.",
                Price = 1700,
                PictureUrl = "https://images.unsplash.com/photo-1694565586339-164e6bab5ce9?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1887&q=80",
                Brand = "Bloomsbury Publishing",
                Type = "Fantasy",
                QuantityInStock = 120,
            },
            new Product
            {
                Name = "The Lord of the Rings",
                Description = "The Lord of the Rings is a high-fantasy epic novel by J.R.R. Tolkien. It follows the journey of a hobbit named Frodo Baggins as he seeks to destroy a powerful ring and save Middle-earth from darkness.",
                Price = 2100,
                PictureUrl = "https://images.unsplash.com/photo-1694437435316-4776b59a77b3?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=2070&q=80",
                Brand = "Houghton Mifflin",
                Type = "Fantasy",
                QuantityInStock = 80,
            },
            new Product
            {
                Name = "Pride and Prejudice",
                Description = "Pride and Prejudice is a classic novel by Jane Austen. It explores themes of love, class, and societal expectations in early 19th-century England through the story of Elizabeth Bennet and Mr. Darcy.",
                Price = 1199,
                PictureUrl = "https://images.unsplash.com/photo-1694683464468-303b8f3160a7?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1932&q=80",
                Brand = "Vintage Books",
                Type = "Romance",
                QuantityInStock = 65,
            },
            new Product
            {
                Name = "The Hunger Games",
                Description = "The Hunger Games is a dystopian novel by Suzanne Collins. It takes place in a future where teenagers are forced to participate in a deadly televised competition. The story follows Katniss Everdeen's fight for survival.",
                Price = 1499,
                PictureUrl = "https://plus.unsplash.com/premium_photo-1692287214829-a36af38d7f49?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1887&q=80",
                Brand = "Scholastic",
                Type = "Science Fiction",
                QuantityInStock = 95,
            },
            new Product
            {
                Name = "The Da Vinci Code",
                Description = "The Da Vinci Code is a mystery thriller novel by Dan Brown. It follows the quest of Robert Langdon and Sophie Neveu to unravel a series of cryptic clues and uncover a secret that could change history.",
                Price = 1399,
                PictureUrl = "https://plus.unsplash.com/premium_photo-1692287214829-a36af38d7f49?ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D&auto=format&fit=crop&w=1887&q=80",
                Brand = "Doubleday",
                Type = "Mystery",
                QuantityInStock = 70,
            }
            };

            context.Products.AddRange(products);
            context.SaveChanges();
        }
    }
}