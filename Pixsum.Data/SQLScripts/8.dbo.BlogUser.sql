CREATE TABLE [dbo].[BlogUser] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [AccountId]     INT           NOT NULL,
    [BlogId]        INT           NOT NULL,
    [UserId]        INT           NOT NULL,
    [CreatedDate]   DATETIME2 (7) DEFAULT (getutcdate()) NOT NULL,
    [UpdatedDate]   DATETIME2 (7) DEFAULT (getutcdate()) NOT NULL,
    [CreatedUserId] INT           NOT NULL,
    [UpdatedUserId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Ids] UNIQUE NONCLUSTERED ([AccountId] ASC, [BlogId] ASC, [UserId] ASC),
    CONSTRAINT [FK_BlogUser_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_BlogUser_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_BlogUser_Blog] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blog] ([Id])
);

