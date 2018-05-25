CREATE TABLE [dbo].[Department] (
    [Id]        INT            IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (MAX) NULL,
    [CompanyID] INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

