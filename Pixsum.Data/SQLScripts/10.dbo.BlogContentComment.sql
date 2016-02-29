CREATE TABLE [dbo].[BlogContentComment] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]     INT            NOT NULL,
    [BlogId]        INT            NOT NULL,
    [BlogContentId] INT            NOT NULL,
    [Comment]       NVARCHAR (MAX) NOT NULL,
    [CreatedDate]   DATETIME2       DEFAULT (getdate()) NOT NULL,
    [UpdatedDate]   DATETIME2       DEFAULT (getdate()) NOT NULL,
    [CreatedUserId] INT            NOT NULL,
    [UpdatedUserId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlogContentComment_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_BlogContentComment_Blog] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blog] ([Id]),
    CONSTRAINT [FK_BlogContentComment_BlogContent] FOREIGN KEY ([BlogContentId]) REFERENCES [dbo].[BlogContent] ([Id])
);

