CREATE TABLE [dbo].[Subjects] (
    [SubjectId]    INT            IDENTITY (1, 1) NOT NULL,
    [Abbreviation] NVARCHAR (10)  NOT NULL,
    [FullName]     NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Subjects] PRIMARY KEY CLUSTERED ([SubjectId] ASC)
);

