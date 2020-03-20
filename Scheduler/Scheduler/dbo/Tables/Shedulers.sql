CREATE TABLE [dbo].[Shedulers] (
    [ShedulerId]  INT           IDENTITY (1, 1) NOT NULL,
    [NumberWeek]  INT           NOT NULL,
    [DayWeek]     NVARCHAR (20) NOT NULL,
    [NumberPair]  INT           NOT NULL,
    [ClassroomId] INT           NOT NULL,
    [SubjectId]   INT           NOT NULL,
    [GroupId]     INT           NOT NULL,
    CONSTRAINT [PK_Shedulers] PRIMARY KEY CLUSTERED ([ShedulerId] ASC),
    CONSTRAINT [FK_Shedulers_Classrooms] FOREIGN KEY ([ClassroomId]) REFERENCES [dbo].[Classrooms] ([ClassroomId]),
    CONSTRAINT [FK_Shedulers_Groups] FOREIGN KEY ([GroupId]) REFERENCES [dbo].[Groups] ([GroupId]),
    CONSTRAINT [FK_Shedulers_Subjects] FOREIGN KEY ([SubjectId]) REFERENCES [dbo].[Subjects] ([SubjectId])
);

