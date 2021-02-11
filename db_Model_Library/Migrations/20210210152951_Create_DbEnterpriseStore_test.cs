using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace db_Model_Library.Migrations
{
    public partial class Create_DbEnterpriseStore_test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                    table.UniqueConstraint("UK_BrandName", x => x.BrandName);
                });

            migrationBuilder.CreateTable(
                name: "Counterpartys",
                columns: table => new
                {
                    CounterpartyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CounterpartyName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    InnOgrnKpp = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Counterpartys", x => x.CounterpartyId);
                    //table.UniqueConstraint("UK_InnOgrnKpp", x => x.InnOgrnKpp);
                });

            migrationBuilder.CreateTable(
                name: "Personnels",
                columns: table => new
                {
                    PersonnelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonnelName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personnels", x => x.PersonnelId);
                });

            migrationBuilder.CreateTable(
                name: "ProductsGroups",
                columns: table => new
                {
                    ProductGroupId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductGroupName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductsGroups", x => x.ProductGroupId);
                    table.UniqueConstraint("UK_ProductGroupName", x => x.ProductGroupName);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    StorageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.StorageId);
                    table.UniqueConstraint("UK_StorageName", x => x.StorageName);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    IdUnit = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UnitName = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false, defaultValue: "шт")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.IdUnit);
                    table.UniqueConstraint("UK_UnitName", x => x.UnitName);
                });

            migrationBuilder.CreateTable(
                name: "PersonnelsInfo",
                columns: table => new
                {
                    PersonnelsPersonnelId = table.Column<int>(type: "int", nullable: false),
                    Passport = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_PersonnelsInfo_Personnels_PersonnelsPersonnelId",
                        column: x => x.PersonnelsPersonnelId,
                        principalTable: "Personnels",
                        principalColumn: "PersonnelId",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);

                    table.UniqueConstraint("UK_Passport_PersonnelsPersonnelId", x => new { x.PersonnelsPersonnelId, x.Passport });
                });

            migrationBuilder.CreateTable(
                name: "ProductsGroupsSales",
                columns: table => new
                {
                    ProductsGroupsProductGroupId = table.Column<int>(type: "int", nullable: false),
                    Sale = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ProductsGroupsSales_ProductsGroups_ProductsGroupsProductGroupId",
                        column: x => x.ProductsGroupsProductGroupId,
                        principalTable: "ProductsGroups",
                        principalColumn: "ProductGroupId",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Realizations",
                columns: table => new
                {
                    RealizationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    CounterpartysCounterpartyId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    PersonnelsPersonnelId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    StoragesStorageId = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realizations", x => x.RealizationId);
                    table.ForeignKey(
                        name: "FK_Realizations_Counterpartys_CounterpartysCounterpartyId",
                        column: x => x.CounterpartysCounterpartyId,
                        principalTable: "Counterpartys",
                        principalColumn: "CounterpartyId",
                        onUpdate: ReferentialAction.Restrict,
                        onDelete: ReferentialAction.SetDefault);
                    table.ForeignKey(
                        name: "FK_Realizations_Personnels_PersonnelsPersonnelId",
                        column: x => x.PersonnelsPersonnelId,
                        principalTable: "Personnels",
                        principalColumn: "PersonnelId",
                        onUpdate: ReferentialAction.Restrict,
                        onDelete: ReferentialAction.SetDefault);
                    table.ForeignKey(
                        name: "FK_Realizations_Storages_StoragesStorageId",
                        column: x => x.StoragesStorageId,
                        principalTable: "Storages",
                        principalColumn: "StorageId",
                        onUpdate: ReferentialAction.Restrict,
                        onDelete: ReferentialAction.SetDefault);
                });

            migrationBuilder.CreateTable(
                name: "Supplies",
                columns: table => new
                {
                    SupplyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2(0)", nullable: false),
                    CounterpartysCounterpartyId = table.Column<int>(type: "int", nullable: false, defaultValue: 2),
                    StoragesStorageId = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplies", x => x.SupplyId);
                    table.ForeignKey(
                        name: "FK_Supplies_Counterpartys_CounterpartysCounterpartyId",
                        column: x => x.CounterpartysCounterpartyId,
                        principalTable: "Counterpartys",
                        principalColumn: "CounterpartyId",
                        onUpdate: ReferentialAction.Restrict,
                        onDelete: ReferentialAction.SetDefault);
                    table.ForeignKey(
                        name: "FK_Supplies_Storages_StoragesStorageId",
                        column: x => x.StoragesStorageId,
                        principalTable: "Storages",
                        principalColumn: "StorageId",
                        onUpdate: ReferentialAction.Restrict,
                        onDelete: ReferentialAction.SetDefault);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false),
                    ProductSale = table.Column<float>(type: "float", nullable: true),
                    BrandsBrandId = table.Column<int>(type: "int", nullable: true),
                    ProductsGroupsProductGroupId = table.Column<int>(type: "int", nullable: true),
                    UnitsIdUnit = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandsBrandId",
                        column: x => x.BrandsBrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onUpdate: ReferentialAction.Restrict,
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_ProductsGroups_ProductsGroupsProductGroupId",
                        column: x => x.ProductsGroupsProductGroupId,
                        principalTable: "ProductsGroups",
                        principalColumn: "ProductGroupId",
                        onUpdate: ReferentialAction.Restrict,
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Products_Units_UnitsIdUnit",
                        column: x => x.UnitsIdUnit,
                        principalTable: "Units",
                        principalColumn: "IdUnit",
                        onUpdate: ReferentialAction.Restrict,
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "RealizationPriceQtys",
                columns: table => new
                {
                    RealizationId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PriceSelling = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0),
                    Quantity = table.Column<float>(type: "float", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Realization_Products", x => new { x.ProductId, x.RealizationId });
                    table.ForeignKey(
                        name: "FK_RealizationPriceQtys_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onUpdate: ReferentialAction.Restrict,
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RealizationPriceQtys_Realizations_RealizationId",
                        column: x => x.RealizationId,
                        principalTable: "Realizations",
                        principalColumn: "RealizationId",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplyPriceQtys",
                columns: table => new
                {
                    SupplyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PricePurchase = table.Column<decimal>(type: "decimal(18,2)", nullable: false, defaultValue: 0),
                    Quantity = table.Column<float>(type: "float", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplyId_Products", x => new { x.ProductId, x.SupplyId });
                    table.ForeignKey(
                        name: "FK_SupplyPriceQtys_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onUpdate: ReferentialAction.Restrict,
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SupplyPriceQtys_Supplies_SupplyId",
                        column: x => x.SupplyId,
                        principalTable: "Supplies",
                        principalColumn: "SupplyId",
                        onUpdate: ReferentialAction.Cascade,
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonnelsInfo_PersonnelsPersonnelId",
                table: "PersonnelsInfo",
                column: "PersonnelsPersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandsBrandId",
                table: "Products",
                column: "BrandsBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductsGroupsProductGroupId",
                table: "Products",
                column: "ProductsGroupsProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_UnitsIdUnit",
                table: "Products",
                column: "UnitsIdUnit");

            migrationBuilder.CreateIndex(
                name: "IX_ProductsGroupsSales_ProductsGroupsProductGroupId",
                table: "ProductsGroupsSales",
                column: "ProductsGroupsProductGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_RealizationPriceQtys_ProductId",
                table: "RealizationPriceQtys",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_RealizationPriceQtys_RealizationId",
                table: "RealizationPriceQtys",
                column: "RealizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Realizations_CounterpartysCounterpartyId",
                table: "Realizations",
                column: "CounterpartysCounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Realizations_PersonnelsPersonnelId",
                table: "Realizations",
                column: "PersonnelsPersonnelId");

            migrationBuilder.CreateIndex(
                name: "IX_Realizations_StoragesStorageId",
                table: "Realizations",
                column: "StoragesStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_CounterpartysCounterpartyId",
                table: "Supplies",
                column: "CounterpartysCounterpartyId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplies_StoragesStorageId",
                table: "Supplies",
                column: "StoragesStorageId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyPriceQtys_ProductId",
                table: "SupplyPriceQtys",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplyPriceQtys_SupplyId",
                table: "SupplyPriceQtys",
                column: "SupplyId");

            migrationBuilder.Sql(
                @"ALTER TABLE dbo.Realizations
                  ADD CONSTRAINT DF_Date_Realization
                  DEFAULT (getdate()) FOR [Date]");
            migrationBuilder.Sql(
                @"ALTER TABLE dbo.Supplies
                  ADD CONSTRAINT DF_Date_Supplies
                  DEFAULT (getdate()) FOR [Date]");

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
                            (N'шт')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonnelsInfo");

            migrationBuilder.DropTable(
                name: "ProductsGroupsSales");

            migrationBuilder.DropTable(
                name: "RealizationPriceQtys");

            migrationBuilder.DropTable(
                name: "SupplyPriceQtys");

            migrationBuilder.DropTable(
                name: "Realizations");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Supplies");

            migrationBuilder.DropTable(
                name: "Personnels");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "ProductsGroups");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Counterpartys");

            migrationBuilder.DropTable(
                name: "Storages");
        }
    }
}
