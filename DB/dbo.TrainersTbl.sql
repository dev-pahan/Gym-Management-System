CREATE TABLE [dbo].[TrainersTbl] (
    [TId]         INT           IDENTITY (1, 1) NOT NULL,
    [TName]       VARCHAR (50)  NOT NULL,
    [TDOB]        DATE          NOT NULL,
    [TPhone]      VARCHAR (15)  NOT NULL,
    [TExperience] INT           NOT NULL,
    [TAddress]    VARCHAR (150) NOT NULL,
    [TPass]       VARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([TId] ASC)
);

