CREATE TABLE [dbo].[CustomerAttribute] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [Name]                   NVARCHAR (400) NOT NULL,
    [IsRequired]             BIT            NOT NULL,
    [AttributeControlTypeId] INT            NOT NULL,
    [DisplayOrder]           INT            NOT NULL,
    [NeedRegex]              BIT            DEFAULT ((0)) NOT NULL,
    [Regex]                  NVARCHAR (400) NULL,
    [RegexMessage]           NVARCHAR (400) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

