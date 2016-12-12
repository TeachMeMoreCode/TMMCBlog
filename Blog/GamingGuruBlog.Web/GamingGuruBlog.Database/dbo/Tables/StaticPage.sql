CREATE TABLE [dbo].[StaticPage] (
    [StaticPageID] INT            IDENTITY (1, 1) NOT NULL,
    [UserID]       NVARCHAR (128) NOT NULL,
    [Title]        VARCHAR (100)  NOT NULL,
    [Body]         VARCHAR (MAX)  NOT NULL,
    PRIMARY KEY CLUSTERED ([StaticPageID] ASC),
    CONSTRAINT [FK_StaticPage_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])
);

