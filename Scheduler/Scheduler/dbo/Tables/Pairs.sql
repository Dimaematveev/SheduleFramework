CREATE TABLE [dbo].[Pairs] (
    [PairId]        INT           IDENTITY (1, 1) NOT NULL,
    [NameThePair]   NVARCHAR (20) NOT NULL,
    [NumberThePair] INT           NOT NULL,
    CONSTRAINT [PK_Pairs] PRIMARY KEY CLUSTERED ([PairId] ASC)
);

