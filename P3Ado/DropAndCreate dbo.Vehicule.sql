USE [vehicules]
GO

/****** Object: Table [dbo].[Vehicule] Script Date: 27.10.2016 15:13:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[Vehicule];


GO
CREATE TABLE [dbo].[Vehicule] (
    [Id]      INT            IDENTITY (1, 1) NOT NULL,
    [Vin]     NVARCHAR (225) NOT NULL,
    [Make]    NVARCHAR (225) NOT NULL,
    [Model]   NVARCHAR (225) NOT NULL,
    [EngName] NVARCHAR (225) NOT NULL
);


