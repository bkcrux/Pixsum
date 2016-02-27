CREATE TABLE [dbo].[User] (
    [Id]             INT            NOT NULL,
    [FirstName]      NVARCHAR (255) NOT NULL,
    [LastName]       NVARCHAR (255) NOT NULL,
    [Email]          NVARCHAR (500) NOT NULL,
    [HashedPassword] NVARCHAR (500) NOT NULL,
    [Salt]           NVARCHAR (500) NOT NULL,
    [IsLocked]       BIT            NOT NULL,
    [LastLoginDate]  DATETIME       NOT NULL,
    [CreatedDate]    DATETIME       NOT NULL DEFAULT GETDATE(),
    [UpdatedDate]    DATETIME       NOT NULL DEFAULT GETDATE(),
    [CreatedUserId]  INT            NOT NULL,
    [UpdatedUserId]  INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

