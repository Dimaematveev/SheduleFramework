CREATE TABLE [dbo].[TypeUnionGroups] (
    [TypeUnionGroupId] INT           IDENTITY (1, 1) NOT NULL,
    [Abbreviation]     NVARCHAR (20) NOT NULL,
    [FullName]         NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TypeUnionGroups] PRIMARY KEY CLUSTERED ([TypeUnionGroupId] ASC)
);

