CREATE TABLE [dbo].[User] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]      NVARCHAR (255) NOT NULL,
    [LastName]       NVARCHAR (255) NOT NULL,
    [Email]          NVARCHAR (500) NOT NULL,
    [HashedPassword] NVARCHAR (500) NOT NULL,
    [Salt]           NVARCHAR (500) NOT NULL,
    [IsLocked]       BIT            NOT NULL,
    [LastLoginDate]  DATETIME2 (7)  NOT NULL,
    [CreatedDate]    DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [UpdatedDate]    DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [CreatedUserId]  INT            NOT NULL,
    [UpdatedUserId]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

