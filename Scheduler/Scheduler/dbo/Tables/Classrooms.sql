CREATE TABLE [dbo].[Classrooms] (
    [ClassroomId]   INT           IDENTITY (1, 1) NOT NULL,
    [Abbreviation]  NVARCHAR (20) NOT NULL,
    [FullName]      NVARCHAR (20) NOT NULL,
    [NumberOfSeats] INT           NOT NULL,
    CONSTRAINT [PK_Classrooms] PRIMARY KEY CLUSTERED ([ClassroomId] ASC)
);

