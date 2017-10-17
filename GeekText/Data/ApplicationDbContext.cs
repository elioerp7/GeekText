using GeekText.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace GeekText.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public string ConnectionString { get; set; }

        public ApplicationDbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>();
            //PopulateDatabase();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Books", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Book()
                        {
                            ISBN = reader["ISBN"].ToString(),
                            Title = reader["Title"].ToString(),
                            Description = reader["Description"].ToString(),
                            Price = Convert.ToDouble(reader["Price"]),
                            Author = reader["Author"].ToString(),
                            Genre = reader["genre"].ToString(),
                            Publisher = reader["Publisher"].ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            Image = reader["image"].ToString(),
                            IsFeatured = Convert.ToInt32(reader["isFeatured"])

                        });
                    }
                }
            }
            return list;
        }
        //not used yet
        public void PopulateDatabase(object sender, EventArgs e)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                //MySqlCommand cmd = new MySqlCommand();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO Books (`ISBN`, `Title`, `Description`, `Price`, `Author`,`Genre`, `Publisher`, `Quantity`, `image`, `isFeatured`) VALUES(N'111-0062315007', N'The Alchemist', N'Description7', 34.99, N'Paulo Coelho', N'Adventure', N'HarperOne', 60, N'http://t2.gstatic.com/images?q=tbn:ANd9GcTAyMeaePHdaWi1UppB8qvu2GtO4jfpufEsS3cR8Sp9Is-x3KXb', 1);", conn);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
//namespace GeekText.Data
//{
//    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
//            : base(options)
//        {
//        }

//        public DbSet<Book> Books { get; set; }

//        protected override void OnModelCreating(ModelBuilder builder)
//        {
//            //base.OnModelCreating(builder);
//            // Customize the ASP.NET Identity model and override the defaults if needed.
//            // For example, you can rename the ASP.NET Identity table names and more.
//            // Add your customizations after calling base.OnModelCreating(builder);
//            builder.Entity<Book>().ToTable("Books");
//        }
//    }
//}
