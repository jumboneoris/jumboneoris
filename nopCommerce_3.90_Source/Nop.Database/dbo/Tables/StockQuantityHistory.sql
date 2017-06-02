CREATE TABLE [dbo].[StockQuantityHistory] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [QuantityAdjustment] INT            NOT NULL,
    [StockQuantity]      INT            NOT NULL,
    [Message]            NVARCHAR (MAX) NULL,
    [CreatedOnUtc]       DATETIME       NOT NULL,
    [ProductId]          INT            NOT NULL,
    [CombinationId]      INT            NULL,
    [WarehouseId]        INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [StockQuantityHistory_Product] FOREIGN KEY ([ProductId]) REFERENCES [dbo].[Product] ([Id]) ON DELETE CASCADE
);

