CREATE TABLE [dbo].[Entities] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [EntityName] NVARCHAR (200) DEFAULT ('') NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

