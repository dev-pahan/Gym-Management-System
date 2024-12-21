CREATE TABLE [dbo].[MembersTbl] (
    [MId]         INT          IDENTITY (1, 1) NOT NULL,
    [MName]       VARCHAR (50) NOT NULL,
    [MGen]        VARCHAR (10) NOT NULL,
    [MDOB]        DATE         NOT NULL,
    [MDate]       DATE         NOT NULL,
    [MMembership] INT          NOT NULL,
    [MTrainer]    INT          NOT NULL,
    [MPhone]      NCHAR (15)   NOT NULL,
    [MTiming]     NCHAR (50)   NOT NULL,
    [MStatus]     VARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([MId] ASC),
    CONSTRAINT [FK1] FOREIGN KEY ([MMembership]) REFERENCES [dbo].[MembershipsTbl] ([MShipId]),
    CONSTRAINT [FK2] FOREIGN KEY ([MTrainer]) REFERENCES [dbo].[TrainersTbl] ([TId])
);

