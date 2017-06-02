CREATE TABLE [dbo].[CustomerPassword] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [CustomerId]       INT            NOT NULL,
    [Password]         NVARCHAR (MAX) NULL,
    [PasswordFormatId] INT            NOT NULL,
    [PasswordSalt]     NVARCHAR (MAX) NULL,
    [CreatedOnUtc]     DATETIME       NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [CustomerPassword_Customer] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customer] ([Id]) ON DELETE CASCADE
);

