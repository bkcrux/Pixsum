CREATE TABLE [dbo].[User] (
    [Id]             INT            NOT NULL IDENTITY (1, 1),
    [FirstName]      NVARCHAR (255) NOT NULL,
    [LastName]       NVARCHAR (255) NOT NULL,
    [Email]          NVARCHAR (500) NOT NULL,
    [HashedPassword] NVARCHAR (500) NOT NULL,
    [Salt]           NVARCHAR (500) NOT NULL,
    [IsLocked]       BIT            NOT NULL,
    [LastLoginDate]  DATETIME       NOT NULL,
    [CreatedDate]    DATETIME       DEFAULT (getdate()) NOT NULL,
    [UpdatedDate]    DATETIME       DEFAULT (getdate()) NOT NULL,
    [CreatedUserId]  INT            NOT NULL,
    [UpdatedUserId]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

