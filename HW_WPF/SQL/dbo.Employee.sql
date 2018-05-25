CREATE TABLE [dbo].[Employee] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (MAX) NULL,
    [Age]          TINYINT        DEFAULT ((0)) NULL,
    [Salary]       INT            DEFAULT ((0)) NULL,
    [DepartmentID] INT            NULL,
    [CompanyID]    INT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

