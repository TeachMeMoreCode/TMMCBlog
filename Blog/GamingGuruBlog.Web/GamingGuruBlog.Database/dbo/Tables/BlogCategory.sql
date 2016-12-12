CREATE TABLE [dbo].[BlogCategory] (
    [CategoryID] INT NOT NULL,
    [BlogPostID] INT NOT NULL,
    CONSTRAINT [PK_BlogCategory] PRIMARY KEY CLUSTERED ([CategoryID] ASC, [BlogPostID] ASC),
    CONSTRAINT [FK_BlogCategory_BlogPost] FOREIGN KEY ([BlogPostID]) REFERENCES [dbo].[BlogPost] ([BlogPostID]),
    CONSTRAINT [FK_BlogCategory_Category] FOREIGN KEY ([CategoryID]) REFERENCES [dbo].[Category] ([CategoryID])
);









