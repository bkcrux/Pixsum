CREATE TABLE [dbo].[BlogContent] (
    [Id]                    INT              NOT NULL IDENTITY (1, 1),
    [AccountId]             INT              NOT NULL,
    [Caption]               NVARCHAR (255)   NULL,
    [Tags]                  NVARCHAR (255)   NULL,
    [FileGUID]              UNIQUEIDENTIFIER NOT NULL,
    [PL_FileType]           INT              NOT NULL,
    [FileName]              NVARCHAR (255)   NOT NULL,
    [FileExtension]         NVARCHAR (255)   NOT NULL,
    [FileSize]              INT              NOT NULL,
    [PL_FileStorageService] INT              NOT NULL,
    [CreatedDate]           DATETIME         DEFAULT (getdate()) NOT NULL,
    [UpdatedDate]           DATETIME         DEFAULT (getdate()) NOT NULL,
    [CreatedUserId]         INT              NOT NULL,
    [UpdatedUserId]         INT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlogContent_To_PL_FileType] FOREIGN KEY ([PL_FileType]) REFERENCES [dbo].[PL_FileType] ([Id]),
    CONSTRAINT [FK_BlogContent_To_PL_FileStorageService] FOREIGN KEY ([PL_FileStorageService]) REFERENCES [dbo].[PL_FileStorageService] ([Id]),
    CONSTRAINT [FK_BlogContent_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id])
);

