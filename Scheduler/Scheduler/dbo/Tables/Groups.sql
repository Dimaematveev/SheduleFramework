CREATE TABLE [dbo].[Groups] (
    [GroupId]         INT           IDENTITY (1, 1) NOT NULL,
    [Abbreviation]    NVARCHAR (50) NOT NULL,
    [FullName]        NVARCHAR (50) NOT NULL,
    [NumberOfPersons] INT           NOT NULL,
    [Seminar]         NVARCHAR (20) NOT NULL,
    [Potok]           NVARCHAR (20) NOT NULL,
    CONSTRAINT [PK_Groups] PRIMARY KEY CLUSTERED ([GroupId] ASC)
);

