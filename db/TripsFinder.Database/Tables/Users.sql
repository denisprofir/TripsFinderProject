CREATE TABLE [dbo].[Users](
	[Id] BIGINT NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[Name] NVARCHAR(32) NOT NULL, 
    [Surname] NVARCHAR(32) NOT NULL, 
    [BirthDate] DATE NOT NULL, 
    [Country] NVARCHAR(32) NULL,
    [Address] NVARCHAR(32) NULL, 
    [AvatarId] BIGINT NULL,
	[CurrentTripId] BIGINT NULL, 
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(

	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
CONSTRAINT FK_Users_MediaFiles FOREIGN KEY(AvatarId) REFERENCES MediaFiles(Id),
	CONSTRAINT FK_Users_Trips FOREIGN KEY(CurrentTripId) REFERENCES Trips(Id)
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO