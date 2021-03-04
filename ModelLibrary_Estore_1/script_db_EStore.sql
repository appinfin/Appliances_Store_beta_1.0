IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Brands] (
    [BrandId] int NOT NULL IDENTITY,
    [BrandName] nvarchar(32) NOT NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY ([BrandId])
);
GO

CREATE TABLE [Counterpartys] (
    [CounterpartyId] int NOT NULL IDENTITY,
    [CounterpartyName] nvarchar(64) NOT NULL,
    [InnOgrnKpp] bigint NULL,
    CONSTRAINT [PK_Counterpartys] PRIMARY KEY ([CounterpartyId])
);
GO

CREATE TABLE [Personnels] (
    [PersonnelId] int NOT NULL IDENTITY,
    [PersonnelName] nvarchar(64) NOT NULL,
    CONSTRAINT [PK_Personnels] PRIMARY KEY ([PersonnelId])
);
GO

CREATE TABLE [ProductsGroups] (
    [ProductGroupId] int NOT NULL IDENTITY,
    [ProductGroupName] nvarchar(32) NOT NULL,
    CONSTRAINT [PK_ProductsGroups] PRIMARY KEY ([ProductGroupId])
);
GO

CREATE TABLE [Storages] (
    [StorageId] int NOT NULL IDENTITY,
    [StorageName] nvarchar(32) NOT NULL,
    CONSTRAINT [PK_Storages] PRIMARY KEY ([StorageId])
);
GO

CREATE TABLE [Units] (
    [IdUnit] int NOT NULL IDENTITY,
    [UnitName] nvarchar(16) NOT NULL DEFAULT ((N'шт')),
    CONSTRAINT [PK_Units] PRIMARY KEY ([IdUnit])
);
GO

CREATE TABLE [PersonnelsInfo] (
    [PersonnelsPersonnelId] int NOT NULL,
    [Passport] bigint NULL,
    CONSTRAINT [FK_PersonnelsInfo_Personnels_PersonnelsPersonnelId] FOREIGN KEY ([PersonnelsPersonnelId]) REFERENCES [Personnels] ([PersonnelId]) ON DELETE CASCADE
);
GO

CREATE TABLE [ProductsGroupsSales] (
    [ProductsGroupsProductGroupId] int NOT NULL,
    [Sale] float NOT NULL,
    CONSTRAINT [FK_ProductsGroupsSales_ProductsGroups_ProductsGroupsProductGroupId] FOREIGN KEY ([ProductsGroupsProductGroupId]) REFERENCES [ProductsGroups] ([ProductGroupId]) ON DELETE CASCADE
);
GO

CREATE TABLE [Realizations] (
    [RealizationId] int NOT NULL IDENTITY,
    [Date] datetime2(0) NOT NULL DEFAULT ((getdate())),
    [CounterpartysCounterpartyId] int NOT NULL DEFAULT (((1))),
    [PersonnelsPersonnelId] int NOT NULL DEFAULT (((1))),
    [StoragesStorageId] int NOT NULL DEFAULT (((1))),
    CONSTRAINT [PK_Realizations] PRIMARY KEY ([RealizationId]),
    CONSTRAINT [FK_Realizations_Counterpartys_CounterpartysCounterpartyId] FOREIGN KEY ([CounterpartysCounterpartyId]) REFERENCES [Counterpartys] ([CounterpartyId]) ON DELETE SET DEFAULT,
    CONSTRAINT [FK_Realizations_Personnels_PersonnelsPersonnelId] FOREIGN KEY ([PersonnelsPersonnelId]) REFERENCES [Personnels] ([PersonnelId]) ON DELETE SET DEFAULT,
    CONSTRAINT [FK_Realizations_Storages_StoragesStorageId] FOREIGN KEY ([StoragesStorageId]) REFERENCES [Storages] ([StorageId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Supplies] (
    [SupplyId] int NOT NULL IDENTITY,
    [Date] datetime2(0) NOT NULL DEFAULT ((getdate())),
    [CounterpartysCounterpartyId] int NOT NULL DEFAULT (((2))),
    [StoragesStorageId] int NOT NULL DEFAULT (((1))),
    CONSTRAINT [PK_Supplies] PRIMARY KEY ([SupplyId]),
    CONSTRAINT [FK_Supplies_Counterpartys_CounterpartysCounterpartyId] FOREIGN KEY ([CounterpartysCounterpartyId]) REFERENCES [Counterpartys] ([CounterpartyId]) ON DELETE SET DEFAULT,
    CONSTRAINT [FK_Supplies_Storages_StoragesStorageId] FOREIGN KEY ([StoragesStorageId]) REFERENCES [Storages] ([StorageId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [Products] (
    [ProductId] int NOT NULL IDENTITY,
    [ProductName] nvarchar(32) NOT NULL,
    [ProductSale] float NULL,
    [BrandsBrandId] int NULL,
    [ProductsGroupsProductGroupId] int NULL,
    [UnitsIdUnit] int NULL,
    CONSTRAINT [PK_Products] PRIMARY KEY ([ProductId]),
    CONSTRAINT [FK_Products_Brands_BrandsBrandId] FOREIGN KEY ([BrandsBrandId]) REFERENCES [Brands] ([BrandId]) ON DELETE SET NULL,
    CONSTRAINT [FK_Products_ProductsGroups_ProductsGroupsProductGroupId] FOREIGN KEY ([ProductsGroupsProductGroupId]) REFERENCES [ProductsGroups] ([ProductGroupId]) ON DELETE SET NULL,
    CONSTRAINT [FK_Products_Units_UnitsIdUnit] FOREIGN KEY ([UnitsIdUnit]) REFERENCES [Units] ([IdUnit]) ON DELETE SET NULL
);
GO

CREATE TABLE [RealizationPriceQtys] (
    [RealizationId] int NOT NULL,
    [ProductId] int NOT NULL,
    [PriceSelling] decimal(18,2) NOT NULL DEFAULT (((0))),
    [Quantity] float NOT NULL DEFAULT (((0))),
    CONSTRAINT [PK_Realization_Products] PRIMARY KEY ([ProductId], [RealizationId]),
    CONSTRAINT [FK_RealizationPriceQtys_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_RealizationPriceQtys_Realizations_RealizationId] FOREIGN KEY ([RealizationId]) REFERENCES [Realizations] ([RealizationId]) ON DELETE CASCADE
);
GO

CREATE TABLE [SupplyPriceQtys] (
    [SupplyId] int NOT NULL,
    [ProductId] int NOT NULL,
    [PricePurchase] decimal(18,2) NOT NULL DEFAULT (((0))),
    [Quantity] float NOT NULL DEFAULT (((0))),
    CONSTRAINT [PK_SupplyId_Products] PRIMARY KEY ([ProductId], [SupplyId]),
    CONSTRAINT [FK_SupplyPriceQtys_Products_ProductId] FOREIGN KEY ([ProductId]) REFERENCES [Products] ([ProductId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_SupplyPriceQtys_Supplies_SupplyId] FOREIGN KEY ([SupplyId]) REFERENCES [Supplies] ([SupplyId]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [UK_BrandName] ON [Brands] ([BrandName]);
GO

CREATE INDEX [IX_PersonnelsInfo_PersonnelsPersonnelId] ON [PersonnelsInfo] ([PersonnelsPersonnelId]);
GO

CREATE UNIQUE INDEX [UK_Passport_PersonnelsPersonnelId] ON [PersonnelsInfo] ([PersonnelsPersonnelId], [Passport]) WHERE [Passport] IS NOT NULL;
GO

CREATE INDEX [IX_Products_BrandsBrandId] ON [Products] ([BrandsBrandId]);
GO

CREATE INDEX [IX_Products_ProductsGroupsProductGroupId] ON [Products] ([ProductsGroupsProductGroupId]);
GO

CREATE INDEX [IX_Products_UnitsIdUnit] ON [Products] ([UnitsIdUnit]);
GO

CREATE UNIQUE INDEX [UK_ProductGroupName] ON [ProductsGroups] ([ProductGroupName]);
GO

CREATE INDEX [IX_ProductsGroupsSales_ProductsGroupsProductGroupId] ON [ProductsGroupsSales] ([ProductsGroupsProductGroupId]);
GO

CREATE INDEX [IX_RealizationPriceQtys_ProductId] ON [RealizationPriceQtys] ([ProductId]);
GO

CREATE INDEX [IX_RealizationPriceQtys_RealizationId] ON [RealizationPriceQtys] ([RealizationId]);
GO

CREATE INDEX [IX_Realizations_CounterpartysCounterpartyId] ON [Realizations] ([CounterpartysCounterpartyId]);
GO

CREATE INDEX [IX_Realizations_PersonnelsPersonnelId] ON [Realizations] ([PersonnelsPersonnelId]);
GO

CREATE INDEX [IX_Realizations_StoragesStorageId] ON [Realizations] ([StoragesStorageId]);
GO

CREATE UNIQUE INDEX [UK_StorageName] ON [Storages] ([StorageName]);
GO

CREATE INDEX [IX_Supplies_CounterpartysCounterpartyId] ON [Supplies] ([CounterpartysCounterpartyId]);
GO

CREATE INDEX [IX_Supplies_StoragesStorageId] ON [Supplies] ([StoragesStorageId]);
GO

CREATE INDEX [IX_SupplyPriceQtys_ProductId] ON [SupplyPriceQtys] ([ProductId]);
GO

CREATE INDEX [IX_SupplyPriceQtys_SupplyId] ON [SupplyPriceQtys] ([SupplyId]);
GO

CREATE UNIQUE INDEX [UK_UnitName] ON [Units] ([UnitName]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210215072854_Create_db_Enetrprise_Store_1', N'5.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

INSERT INTO [Counterpartys]
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
                            (N'Магазин')
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20210215074805_INPUT_rows_with_defaulValue', N'5.0.3');
GO

COMMIT;
GO

