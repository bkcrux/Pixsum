CREATE TABLE [dbo].[PL_FileType] (
    [Id]          INT            NOT NULL IDENTITY (1, 1),
    [Value]       NVARCHAR (255) NOT NULL,
    [Description] NVARCHAR (MAX) NULL,
    [SortOrder]   SMALLINT       NOT NULL,
    [IsActive]    BIT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

