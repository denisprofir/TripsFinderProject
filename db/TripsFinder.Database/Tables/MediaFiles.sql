﻿CREATE TABLE [dbo].[MediaFiles]
(
	[Id] BIGINT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Name] NVARCHAR(64) NOT NULL, 
    [Type] VARCHAR(16) NOT NULL, 
    [Path] NVARCHAR(128) NOT NULL,
)
