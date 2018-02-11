namespace DAL.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Context context)
        {
            context.Products.AddOrUpdate(
                new DataModels.Product { Id = 1, Name = "Irish Truffle" },
                new DataModels.Product { Id = 2, Name = "Rum and Coke Truffle" },
                new DataModels.Product { Id = 3, Name = "Prosecco Truffle" },
                new DataModels.Product { Id = 4, Name = "Gin and Tonic Truffle" },
                new DataModels.Product { Id = 5, Name = "Ginger Ale Truffle" },
                new DataModels.Product { Id = 6, Name = "Vodka and Lemonade Truffle" },
                new DataModels.Product { Id = 7, Name = "Fruit Cider Truffle" });

            context.Users.AddOrUpdate(
                new DataModels.User { Id = 1, EmailAddress = "admin@truffleshop.com", Password = "changeme" });
        }
    }
}