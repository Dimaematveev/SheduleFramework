CREATE TABLE [dbo].[PlanToTwoWeek] (
    [PlanID]    INT IDENTITY (1, 1) NOT NULL,
    [GroupID]   INT NOT NULL,
    [SubjectID] INT NOT NULL,
    [NumPract]  INT NULL,
    [NumLec]    INT NULL,
    [NumLab]    INT NULL,
    CONSTRAINT [PK_Plan] PRIMARY KEY CLUSTERED ([PlanID] ASC)
);

