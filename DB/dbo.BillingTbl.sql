CREATE TABLE [dbo].[BillingTbl] (
    [BillId] INT NOT NULL PRIMARY KEY IDENTITY,
    [Member] INT NOT NULL, 
    [BPeriod] VARCHAR(50) NOT NULL, 
    [BDate] DATE NOT NULL, 
    [BAmount] INT NOT NULL, 
    CONSTRAINT [FK3] FOREIGN KEY ([Member]) REFERENCES [MembersTbl]([MId]) 
);

