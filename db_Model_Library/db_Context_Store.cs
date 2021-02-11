using Microsoft.EntityFrameworkCore;

namespace db_Model_Library
{
    public class db_Context_Store : DbContext
    {
        #region
        public db_Context_Store()
        {
            //Database.EnsureCreated();
        }

        public db_Context_Store(DbContextOptions<db_Context_Store> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Counterparty> Counterpartys { get; set; }
        public virtual DbSet<Storage> Storages { get; set; }
        public virtual DbSet<ProductGroup> ProductsGroups { get; set; }
        public virtual DbSet<ProductGroupSale> ProductsGroupsSales { get; set; }
        public virtual DbSet<Personnel> Personnels { get; set; }
        public virtual DbSet<PersonnelInfo> PersonnelsInfo { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<Supply> Supplies { get; set; }
        public virtual DbSet<SupplyPriceQty> SupplyPriceQtys { get; set; }
        public virtual DbSet<Realization> Realizations { get; set; }
        public virtual DbSet<RealizationPriceQty> RealizationPriceQtys { get; set; }
        
        
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // Директива #warning
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                //optionsBuilder.UseMySql("server=localhost;database=db_test;user=root", Microsoft.EntityFrameworkCore.ServerVersion.FromString("5.7.16-mysql"));
                //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=db_test_Store;Trusted_Connection=True;Integrated Security = True");
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=db_Enterprise_Store_test5;Trusted_Connection=True;Integrated Security=True;");
                #region Подключение в текущем каталоге приложения
                //optionsBuilder.UseSqlServer(@"Data Source = (localdb)\mssqllocaldb;" +
                //    @"AttachDbFilename =" +
                //    Directory.GetCurrentDirectory() + @"\northwnd.mdf;" +
                //    "Integrated Security = True");
                #endregion

                #region Подключение к тестовой БД Northwnd.mdf в указаном каталоге
                //optionsBuilder.UseSqlServer(@"Data Source = (localdb)\mssqllocaldb;" +
                //    @"AttachDbFilename = F:\source\repos\AppliancesStore\WindowsFormsApp1\bin\Debug\netcoreapp3.1\northwnd.mdf;" +
                //    "Integrated Security = True");
                #endregion

#pragma warning restore CS1030 // Директива #warning
            }
        }
        #endregion

        #region Строки подключения примеры

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        //string current_catalog = Directory.GetCurrentDirectory() + "\\Northwind";
        //        //optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True");
        //        //optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True");
        //        //optionsBuilder.UseSqlServer(@"Data Source = (localdb)\mssqllocaldb;" +
        //        //    @"AttachDbFilename = F:\source\repos\AppliancesStore\WindowsFormsApp1\bin\Debug\netcoreapp3.1\northwnd.mdf;" +
        //        //    "Integrated Security = True");
        //        //optionsBuilder.UseSqlServer(@"Data Source = (localdb)\mssqllocaldb;" +
        //        //    @"AttachDbFilename =" +
        //        //    Directory.GetCurrentDirectory() + @"\northwnd.mdf;" +
        //        //    "Integrated Security = True");
        //        //AttachDbFilename = F:\source\repos\AppliancesStore\northwnd.mdf
        //        //AttachDbFilename = F:\source\repos\AppliancesStore\WindowsFormsApp1\bin\Debug\netcoreapp3.1\northwnd.mdf
        //    }
        //}
        #endregion

    }
}
