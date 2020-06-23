CREATE TABLE [dbo].[Author] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      VARCHAR (300) NOT NULL,
    [LastName]  VARCHAR (300) NULL,
    [BirthDate] DATE          NULL,
    CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED ([Id] ASC)
);

