CREATE TABLE [dbo].[CheckPointsFiles]
(
	[CheckPointId] BIGINT NOT NULL, 
    [MediaFileId] BIGINT NOT NULL,
	PRIMARY KEY(CheckPointId, MediaFileId),
	CONSTRAINT FK_CheckPointsFiles_MediaFiles FOREIGN KEY(CheckPointId) REFERENCES MediaFiles(Id),
	CONSTRAINT FK_CheckPointsFiles_CheckPoints FOREIGN KEY(MediaFileId) REFERENCES CheckPoints(Id)
)
