DROP PROCEDURE [dbo].[BuscarNodos]
GO
CREATE PROCEDURE [dbo].[BuscarNodos]
	@FlagOrigen bit = 0,
	@ParadaId int, 
	@Fecha datetime,
	@ViajeId int,
	@NodoId int output,
	@HorarioId int output,
	@ReturnResult int output
AS
	SELECT 
		@NodoId = (nodos.id),
		@HorarioId = (horarios.id),
		@ReturnResult = 1
	FROM nodos
	INNER JOIN viajes ON nodos.viaje_id = viajes.id and viajes.estado = 1
	INNER JOIN horarios on viajes.id = horarios.viaje_id
	WHERE 
	viajes.id = @ViajeId
	AND horarios.dias LIKE '%' + CAST((datepart(dw,@Fecha) -1) AS VARCHAR)  + '%' 
	AND (@FlagOrigen = 1 AND nodos.origen_id = @ParadaId) OR (@FlagOrigen = 0 AND nodos.destino_id = @ParadaId)
	;

RETURN 0
