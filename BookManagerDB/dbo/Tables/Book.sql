CREATE TABLE [dbo].[Book] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [Name]       VARCHAR (300) NOT NULL,
    [AuthorId]   INT           NOT NULL,
    [CategoryId] INT           NOT NULL,
    [ISBN]       VARCHAR (13)  NOT NULL,
    CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Book_Author] FOREIGN KEY ([AuthorId]) REFERENCES [dbo].[Author] ([Id]),
    CONSTRAINT [FK_Book_Category] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[Category] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Book_CategoryId]
    ON [dbo].[Book]([CategoryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_Book_AuthorId]
    ON [dbo].[Book]([AuthorId] ASC);

