CREATE TABLE [dbo].[TypeOfClasses] (
    [TypeOfClassesId] INT            IDENTITY (1, 1) NOT NULL,
    [Abbreviation]    NVARCHAR (20)  NOT NULL,
    [FullName]        NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_TypeOfClasses] PRIMARY KEY CLUSTERED ([TypeOfClassesId] ASC)
);

