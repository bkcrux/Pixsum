CREATE TABLE [dbo].[BlogComment] (
    [Id]            INT            NOT NULL,
    [AccountId]     INT            NOT NULL,
    [BlogId]        INT            NOT NULL,
    [Comment]       NVARCHAR (MAX) NOT NULL,
    [CreatedDate]   DATETIME       NOT NULL DEFAULT GETDATE(),
    [UpdatedDate]   DATETIME       NOT NULL DEFAULT GETDATE(),
    [CreatedUserId] INT            NOT NULL,
    [UpdatedUserId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlogComment_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_BlogComment_Blog] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blog] ([Id])
);

