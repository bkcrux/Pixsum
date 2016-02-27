CREATE TABLE [dbo].[PL_FileType]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Value] NVARCHAR(255) NOT NULL, 
    [Description] NVARCHAR(MAX) NULL, 
    [SortOrder] SMALLINT NOT NULL, 
    [IsActive] BIT NOT NULL
)
