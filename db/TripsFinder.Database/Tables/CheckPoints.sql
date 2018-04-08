﻿CREATE TABLE [dbo].[CheckPoints]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Title] NVARCHAR(64) NOT NULL, 
    [Description] NVARCHAR(256) NULL, 
    [Date] DATETIME NOT NULL DEFAULT GETDATE(), 
    [Latitude] FLOAT NOT NULL, 
    [Longitude] FLOAT NOT NULL,
	[TripId] BIGINT NOT NULL, 
    CONSTRAINT FK_CheckPoints_Trips FOREIGN KEY(TripId) REFERENCES Trips(Id),
)
