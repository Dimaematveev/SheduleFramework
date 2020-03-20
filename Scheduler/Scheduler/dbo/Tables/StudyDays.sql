CREATE TABLE [dbo].[StudyDays] (
    [StudyDayId]            INT           IDENTITY (1, 1) NOT NULL,
    [AbbreviationDayOfWeek] NVARCHAR (20) NOT NULL,
    [FullNameDayOfWeek]     NVARCHAR (20) NOT NULL,
    [NumberDayOfWeek]       INT           NULL,
    [NumberOfWeek]          INT           NOT NULL,
    CONSTRAINT [PK_StudyDays] PRIMARY KEY CLUSTERED ([StudyDayId] ASC)
);

