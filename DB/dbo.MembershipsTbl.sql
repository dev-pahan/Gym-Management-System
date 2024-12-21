CREATE TABLE [dbo].[MembershipsTbl] (
    [MShipId]    INT          IDENTITY (1, 1) NOT NULL,
    [MSName]     VARCHAR (50) NOT NULL,
    [MSDuration] INT          NOT NULL,
    [MSCost]     INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([MShipId] ASC)
);

