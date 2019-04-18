-- Execute me on Sitecore reporting database 
CREATE TABLE [dbo].[Fact_OperatingSystemMetrics](
	[SegmentRecordId] [bigint] NOT NULL, -- Required
	[SegmentId] [uniqueidentifier] NOT NULL, -- Required
	[Date] [smalldatetime] NOT NULL, -- Required
	[SiteNameId] [int] NOT NULL, -- Required
	[DimensionKeyId] [bigint] NOT NULL, -- Required
	[Visits] [int] NOT NULL -- Props from OperatingSystemMetrics.cs
	
	CONSTRAINT [PK_Fact_OperatingSystemMetrics_1] PRIMARY KEY CLUSTERED ([SegmentRecordId] ASC)
	WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]