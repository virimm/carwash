namespace avtomoika.Models
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class CarWashContext : DbContext
    {

        public CarWashContext()
            : base("name=CarWashModel")
        {
        }

        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

    }


    public class CarWashDbInitializer : DropCreateDatabaseAlways<CarWashContext>
    {
        protected override void Seed(CarWashContext db)
        {
            var client1 = new Client { Name = "Ivan", CarNumber = "AX458439" };
            var client2 = new Client { Name = "Alex", CarNumber = "BX783433" };
            var client3 = new Client { Name = "Dmitriy", CarNumber = "NM934924" };

            var order1 = new Order { Date = DateTime.Now, BoxName = "BOX-7", Client = client1, State = "Завершен" };
            var order2 = new Order { Date = DateTime.Now, BoxName = "BOX-17", Client = client3, State = "В процессе" };
            var order3 = new Order { Date = DateTime.Now, BoxName = "BOX-9", Client = client2, State = "Новый" };

            db.Clients.AddRange(new List<Client> { client1, client2, client3 });
            db.Orders.AddRange(new List<Order> { order1, order2, order3 });


            db.SaveChanges();

            base.Seed(db);
        }
    }
}