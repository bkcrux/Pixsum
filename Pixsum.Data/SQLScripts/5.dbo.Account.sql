CREATE TABLE [dbo].[Account] (
    [Id]            INT            NOT NULL IDENTITY(1,1),
    [AccountName]   NVARCHAR (255) NOT NULL,
    [SubDomain]     NVARCHAR (255) NOT NULL,
    [CreatedDate]   DATETIME       DEFAULT (getdate()) NOT NULL,
    [UpdatedDate]   DATETIME       DEFAULT (getdate()) NOT NULL,
    [CreatedUserId] INT            NOT NULL,
    [UpdatedUserId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

