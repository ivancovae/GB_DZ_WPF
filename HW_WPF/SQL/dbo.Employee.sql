CREATE TABLE [dbo].[Employee] (
    [Id]           INT     NOT NULL,
    [Name]         NVARCHAR(MAX)    NULL,
    [Age]          TINYINT DEFAULT ((0)) NULL,
    [Salary]       INT     DEFAULT ((0)) NULL,
    [DepartmentID] INT     NULL,
    [CompanyID]    INT     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

