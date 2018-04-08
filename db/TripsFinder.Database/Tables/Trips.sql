CREATE TABLE [dbo].[Trips]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Title] NVARCHAR(64) NOT NULL, 
    [Description] NVARCHAR(256) NULL, 
    [StartDate] DATE NOT NULL, 
    [EndDate] DATE NULL,
	[PosterImageId] BIGINT NULL,
    [StartingPointId] BIGINT NOT NULL UNIQUE, 
    [ArrivalPointId] BIGINT NULL, 
    [CreatedBy] BIGINT NOT NULL,
	CONSTRAINT FK_Trips_Users FOREIGN KEY(CreatedBy) REFERENCES Users(Id),
	CONSTRAINT FK_TripsStart_CheckPoints FOREIGN KEY(StartingPointId) REFERENCES CheckPoints(Id),
	CONSTRAINT FK_TripsEnd_CheckPoints FOREIGN KEY(ArrivalPointId) REFERENCES CheckPoints(Id),
	CONSTRAINT FK_Trips_MediaFiles FOREIGN KEY(PosterImageId) REFERENCES MediaFiles(Id)
)
