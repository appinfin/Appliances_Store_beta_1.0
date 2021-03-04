using Microsoft.EntityFrameworkCore.Migrations;

namespace ModelLibrary_Estore_1.Migrations
{
    public partial class INPUT_rows_with_defaulValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"INSERT INTO [Counterpartys]
           		                ([CounterpartyName]
           		                ,[InnOgrnKpp])
     		    VALUES
           		            (N'Покупатель'
           		            ,100000000000)
		        GO
		        INSERT INTO [Counterpartys]
           		            ([CounterpartyName]
           		            ,[InnOgrnKpp])
     		    VALUES
           		            (N'Поставщик'
           		            ,200000000000)
		        GO
                INSERT INTO [Brands]
			                ([BrandName])
		        VALUES
                            (N'неизв.')
		        GO
		        INSERT INTO [Storages]
			               ([StorageName])
		        VALUES
  		                   (N'Склад')
		        GO
		        INSERT INTO [Units]
			                ([UnitName])
		        VALUES
                            (N'шт')
			GO
		        INSERT INTO [Personnels]
			                ([PersonnelName])
		        VALUES
                            (N'Магазин')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.Sql(
            //    @"TRUNCATE TABLE Counterpartys;
            //      TRUNCATE TABLE Brands;
            //      TRUNCATE TABLE Storages;
            //      TRUNCATE TABLE Units;
            //      TRUNCATE TABLE Personnels;"
            //);
        }
    }
}
