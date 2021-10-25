USE [dmaa0920_1086219]
GO

/****** Object:  Table [dbo].[Event]    Script Date: 25-10-2021 15:49:44 ******/


CREATE TABLE [dbo].[Profile](
	[Email] [varchar](100) NOT NULL,
	[PhoneNo] [varchar](50) NOT NULL,
	[Password] [varchar](50) NOT NULL,
	[IsBanned] [bit] NOT NULL,
	[Description] [varchar](50) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,

	primary key (ID),
);


CREATE TABLE [dbo].[Event](
	[EventName] [varchar](50) NOT NULL,
	[EventCapacity] [int] NOT NULL,
	[Amount] [int] NOT NULL,
	[StartDateTime] [datetime] NOT NULL,
	[EndDateTime] [datetime] NOT NULL,
	[Description] [varchar](500) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ProfileID] [int] NOT NULL,
	
	primary key (ID),
	foreign key (ProfileID)	references	Profile(ID)
);

CREATE TABLE [dbo].[Match](
	[EventID] [int] NOT NULL,
	[ProfileID] [int] NOT NULL,
	[Match] [bit] NOT NULL
	
	primary key (EventID, ProfileID),
	foreign key (EventID)	references	Event(ID) ON DELETE CASCADE,
	foreign key (ProfileID)	references	Profile(ID) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[Location](
	[ZIP] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Address] [varchar](250) NOT NULL,
	[EventID] [int] NOT NULL,

	primary key (EventID),
	foreign key (EventID)	references	Event(ID) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[Person](
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Gender] [varchar](50) NOT NULL,
	[ProfileID] [int] NOT NULL,

	primary key (ProfileID),
	foreign key (ProfileID)	references	Profile(ID) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[Business](
	[Name] [varchar](50) NOT NULL,
	[CVR] [varchar](50) NOT NULL,
	[Subscription] [bit] NULL,
	[ProfileID] [int] NOT NULL,

	primary key (ProfileID),
	foreign key (ProfileID)	references	Profile(ID) ON DELETE CASCADE,
);

CREATE TABLE [dbo].[ReportUser](
	[AccuserID] [int] NOT NULL,
	[OffenderID] [int] NOT NULL,
	[Description] [varchar](400) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,

	primary key (ID),
	foreign key (AccuserID)	references	Profile(ID),
	foreign key (OffenderID)	references	Profile(ID)ON DELETE CASCADE,
);

CREATE TABLE [dbo].[Chat](
	[DestinationID] [int] NOT NULL,
	[SourceID] [int] NOT NULL,
	[TimeSent] [date] NOT NULL,
	[Body] [varchar](250) NULL,
	[ID] [int] IDENTITY(1,1) NOT NULL,

	primary key (ID),
	foreign key (DestinationID)	references	Event(ID) ON DELETE CASCADE,
	foreign key (SourceID)	references	Profile(ID) ON DELETE CASCADE,
);


