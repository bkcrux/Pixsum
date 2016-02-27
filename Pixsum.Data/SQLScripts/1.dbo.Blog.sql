CREATE TABLE [dbo].[Blog] (
    [Id]            INT             NOT NULL,
    [AccountId]     INT             NOT NULL,
    [Title]         NVARCHAR (255)  NOT NULL,
    [BlogDate]      DATETIME        NOT NULL DEFAULT GETDATE(),
    [Description]   NVARCHAR (2000) NULL,
    [Tags]          NVARCHAR (255)  NULL,
    [IsPublic]      BIT             NOT NULL,
    [CreatedDate]   DATETIME        NOT NULL DEFAULT GETDATE(),
    [UpdatedDate]   DATETIME        NOT NULL DEFAULT GETDATE(),
    [CreatedUserId] INT             NOT NULL,
    [UpdatedUserId] INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Blog_To_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id])
);

