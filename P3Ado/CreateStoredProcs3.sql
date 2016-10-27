CREATE PROCEDURE [dbo].[InsertVehicule] 
@Vin nvarchar(225),
@Make nvarchar(225),
@Model nvarchar(225),
@EngName nvarchar(225)

AS
BEGIN
SET NOCOUNT ON;
insert into Vehicule (Vin)
values (@Vin)
END