CREATE TABLE [dbo].[Account] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [AccountName]   NVARCHAR (255) NOT NULL,
    [SubDomain]     NVARCHAR (255) NOT NULL,
    [CreatedDate]   DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [UpdatedDate]   DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [CreatedUserId] INT            NOT NULL,
    [UpdatedUserId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

