CREATE TABLE [dbo].[BlogPost] (
    [BlogPostID]     INT            IDENTITY (1, 1) NOT NULL,
    [Title]          VARCHAR (100)  NOT NULL,
    [Body]           VARCHAR (MAX)  NOT NULL,
    [Summary]        VARCHAR (500)  NOT NULL,
    [UserID]         NVARCHAR (128) NOT NULL,
    [DateCreatedUTC] DATETIME       NOT NULL,
    [EditDate]       DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([BlogPostID] ASC),
    CONSTRAINT [FK_BlogPost_AspNetUsers] FOREIGN KEY ([UserID]) REFERENCES [dbo].[AspNetUsers] ([Id])
);





