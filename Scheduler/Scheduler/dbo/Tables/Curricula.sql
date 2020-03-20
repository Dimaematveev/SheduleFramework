CREATE TABLE [dbo].[Curricula] (
    [CurriculumId]    INT IDENTITY (1, 1) NOT NULL,
    [GroupId]         INT NOT NULL,
    [SubjectId]       INT NOT NULL,
    [Number]          INT NOT NULL,
    [TypeOfClassesId] INT NOT NULL,
    CONSTRAINT [PK_Curricula] PRIMARY KEY CLUSTERED ([CurriculumId] ASC),
    CONSTRAINT [FK_Curricula_Groups] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([GroupId]),
    CONSTRAINT [FK_Curricula_Subjects] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subjects] ([SubjectId]),
    CONSTRAINT [FK_Curricula_TypeOfClasses] FOREIGN KEY ([TypeOfClassesId]) REFERENCES [dbo].[TypeOfClasses] ([TypeOfClassesId])
);

