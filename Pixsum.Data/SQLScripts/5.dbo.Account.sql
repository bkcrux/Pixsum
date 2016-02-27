CREATE TABLE [dbo].[Account] (
    [Id]            INT            NOT NULL,
    [AccountName]   NVARCHAR (255) NOT NULL,
    [SubDomain]     NVARCHAR (255) NOT NULL,
    [CreatedDate]   DATETIME       NOT NULL DEFAULT GETDATE(),
    [UpdatedDate]   DATETIME       NOT NULL DEFAULT GETDATE(),
    [CreatedUserId] INT            NOT NULL,
    [UpdatedUserId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

