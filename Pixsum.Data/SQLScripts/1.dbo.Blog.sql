CREATE TABLE [dbo].[Blog] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [AccountId]     INT             NOT NULL,
    [Title]         NVARCHAR (255)  NOT NULL,
    [BlogDate]      DATETIME2 (7)   DEFAULT (getutcdate()) NOT NULL,
    [Description]   NVARCHAR (2000) NULL,
    [Tags]          NVARCHAR (255)  NULL,
    [IsPublic]      BIT             NOT NULL,
    [CreatedDate]   DATETIME2 (7)   DEFAULT (getutcdate()) NOT NULL,
    [UpdatedDate]   DATETIME2 (7)   DEFAULT (getutcdate()) NOT NULL,
    [CreatedUserId] INT             NOT NULL,
    [UpdatedUserId] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Blog_To_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id])
);

