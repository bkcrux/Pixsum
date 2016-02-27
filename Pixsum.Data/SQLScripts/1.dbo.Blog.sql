CREATE TABLE [dbo].[Blog] (
    [Id]            INT             NOT NULL IDENTITY (1, 1),
    [AccountId]     INT             NOT NULL,
    [Title]         NVARCHAR (255)  NOT NULL,
    [BlogDate]      DATETIME        DEFAULT (getdate()) NOT NULL,
    [Description]   NVARCHAR (2000) NULL,
    [Tags]          NVARCHAR (255)  NULL,
    [IsPublic]      BIT             NOT NULL,
    [CreatedDate]   DATETIME        DEFAULT (getdate()) NOT NULL,
    [UpdatedDate]   DATETIME        DEFAULT (getdate()) NOT NULL,
    [CreatedUserId] INT             NOT NULL,
    [UpdatedUserId] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Blog_To_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id])
);

