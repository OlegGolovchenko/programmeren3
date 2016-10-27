USE [vehicules]
GO

/****** Object: Table [dbo].[Engine] Script Date: 27.10.2016 15:15:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Engine];


GO
CREATE TABLE [dbo].[Engine] (
    [Id]           INT            NOT NULL,
    [Displacement] INT            NOT NULL,
    [CylCnt]       INT            NOT NULL,
    [EngName]      NVARCHAR (255) NOT NULL,
    [EngMake]      NVARCHAR (255) NOT NULL
);


