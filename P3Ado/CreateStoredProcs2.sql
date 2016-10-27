CREATE PROCEDURE [dbo].[GetVehiculeById]
@id int

AS
BEGIN
SET NOCOUNT ON;
select * from Vehicule where Id = @id 
END
