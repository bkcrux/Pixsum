CREATE TABLE [dbo].[BlogUser] (
    [Id]            INT      NOT NULL,
    [AccountId]     INT      NOT NULL,
    [BlogId]        INT      NOT NULL,
    [UserId]        INT      NOT NULL,
    [CreatedDate]   DATETIME NOT NULL DEFAULT GETDATE(),
    [UpdatedDate]   DATETIME NOT NULL DEFAULT GETDATE(),
    [CreatedUserId] INT      NOT NULL,
    [UpdatedUserId] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_Ids] UNIQUE NONCLUSTERED ([AccountId] ASC, [BlogId] ASC, [UserId] ASC),
    CONSTRAINT [FK_BlogUser_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_BlogUser_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_BlogUser_Blog] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blog] ([Id])
);

