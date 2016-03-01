CREATE TABLE [dbo].[BlogContent] (
    [Id]                    INT              IDENTITY (1, 1) NOT NULL,
    [AccountId]             INT              NOT NULL,
    [Caption]               NVARCHAR (255)   NULL,
    [Tags]                  NVARCHAR (255)   NULL,
    [FileGUID]              UNIQUEIDENTIFIER NOT NULL,
    [PL_FileType]           INT              NOT NULL,
    [FileName]              NVARCHAR (255)   NOT NULL,
    [FileExtension]         NVARCHAR (255)   NOT NULL,
    [FileSize]              INT              NOT NULL,
    [PL_FileStorageService] INT              NOT NULL,
    [CreatedDate]           DATETIME2 (7)    DEFAULT (getutcdate()) NOT NULL,
    [UpdatedDate]           DATETIME2 (7)    DEFAULT (getutcdate()) NOT NULL,
    [CreatedUserId]         INT              NOT NULL,
    [UpdatedUserId]         INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlogContent_To_PL_FileType] FOREIGN KEY ([PL_FileType]) REFERENCES [dbo].[PL_FileType] ([Id]),
    CONSTRAINT [FK_BlogContent_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_BlogContent_To_PL_FileStorageService] FOREIGN KEY ([PL_FileStorageService]) REFERENCES [dbo].[PL_FileStorageService] ([Id])
);

