CREATE TABLE [dbo].[AccountUser] (
    [Id]              INT              NOT NULL IDENTITY (1, 1),
    [AccountId]       INT              NOT NULL,
    [UserId]          INT              NOT NULL,
    [IsAdmin]         BIT              NOT NULL,
    [AvatarPhotoGUID] UNIQUEIDENTIFIER NULL,
    [CreatedDate]     DATETIME         DEFAULT (getdate()) NOT NULL,
    [UpdatedDate]     DATETIME         DEFAULT (getdate()) NOT NULL,
    [CreatedUserId]   INT              NOT NULL,
    [UpdatedUserId]   INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [UQ_AU_Ids] UNIQUE NONCLUSTERED ([AccountId] ASC, [UserId] ASC),
    CONSTRAINT [FK_AccountUser_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_AccountUser_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id])
);

