CREATE TABLE [dbo].[BlogTag] (
    [BlogPostID] INT NOT NULL,
    [TagID]      INT NOT NULL,
    CONSTRAINT [PK_BlogTag] PRIMARY KEY CLUSTERED ([BlogPostID] ASC, [TagID] ASC),
    CONSTRAINT [FK_BlogTag_BlogPost] FOREIGN KEY ([BlogPostID]) REFERENCES [dbo].[BlogPost] ([BlogPostID]),
    CONSTRAINT [FK_BlogTag_Tag] FOREIGN KEY ([TagID]) REFERENCES [dbo].[Tag] ([TagID])
);









