﻿CREATE TABLE [dbo].[BlogComment] (
    [Id]            INT            IDENTITY (1, 1) NOT NULL,
    [AccountId]     INT            NOT NULL,
    [BlogId]        INT            NOT NULL,
    [Comment]       NVARCHAR (MAX) NOT NULL,
    [CreatedDate]   DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [UpdatedDate]   DATETIME2 (7)  DEFAULT (getutcdate()) NOT NULL,
    [CreatedUserId] INT            NOT NULL,
    [UpdatedUserId] INT            NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BlogComment_Account] FOREIGN KEY ([AccountId]) REFERENCES [dbo].[Account] ([Id]),
    CONSTRAINT [FK_BlogComment_Blog] FOREIGN KEY ([BlogId]) REFERENCES [dbo].[Blog] ([Id])
);

