DROP PROCEDURE [dbo].[BuscarBoletos]
GO
CREATE PROCEDURE [dbo].[BuscarBoletos]
	@OrigenId int,
	@DestinoId int,
	@Fecha datetime
AS
	DECLARE @exists_origen_id int;
	DECLARE @exists_destino_id int;

	SET @exists_origen_id = (
		SELECT COUNT(*)
		FROM paradas
		WHERE id = @OrigenId
	);

	SET @exists_destino_id = (
		SELECT COUNT(*)
		FROM paradas
		WHERE id = @DestinoId
	);

	DECLARE @ReturnTable TABLE 
	(
		ViajeId INT,
		Empresa NVARCHAR(50),
		HorarioSalida VARCHAR(8),
		HorarioLlegada VARCHAR(8),
		AsientosDisponibles INT,
		Precio INT
	);

	IF @exists_origen_id = 1 AND @exists_destino_id = 1
	BEGIN

		DECLARE @FlagOrigen BIT;
		
		DECLARE @sumatoriaNodos INT;
		DECLARE @SumatoriaPrecio INT;
		DECLARE @SumatoriaAsientos INT;

		DECLARE @horarioSalida datetime;
		DECLARE @horarioLlegada datetime;

		DECLARE @asientosDisponibles INT;
		DECLARE @distribucionId INT;

		DECLARE @viaje_Id INT;

		DECLARE viajes_cursor CURSOR FOR   
		SELECT DISTINCT viajes.id FROM nodos
		INNER JOIN viajes ON nodos.viaje_id = viajes.id;

		OPEN viajes_cursor  
  
		FETCH NEXT FROM viajes_cursor INTO @viaje_Id
		WHILE @@FETCH_STATUS = 0  
		BEGIN  
			-- CURSOR MODO ORIGEN
			DECLARE @nodo_origen_id INT;
			DECLARE @nodo_origen_horario_id INT;
			DECLARE @resultados INT;

			SET @resultados = 0;

			EXEC BuscarNodos
				@FlagOrigen = 1,
				@ParadaId = @OrigenId,
				@Fecha = @Fecha,
				@ViajeId = @viaje_Id,
				@NodoId = @nodo_origen_id OUTPUT,
				@HorarioId = @nodo_origen_horario_id OUTPUT,
				@ReturnResult = @resultados OUTPUT;

			IF @resultados = 1
			BEGIN
				SELECT @horarioSalida = (CAST(CONVERT(DATE,@Fecha) AS datetime) + CAST(hora AS datetime))
				FROM horarios
				WHERE id = @nodo_origen_horario_id

				SET @SumatoriaNodos = 0;

				SELECT @SumatoriaNodos = (sum( DATEPART(SECOND, [demora]) + 60 * 
					DATEPART(MINUTE, [demora]) + 3600 * 
					DATEPART(HOUR, [demora] ))
				) from nodos where id < @nodo_origen_id and viaje_id = @viaje_Id group by viaje_id;

				SET @horarioSalida = @horarioSalida + CAST(CONVERT(TIME(0), DATEADD(SS,@SumatoriaNodos,0),108) AS DATETIME)

				-- CURSOR MODO DESTINO
				DECLARE @nodo_destino_id INT;
				DECLARE @nodo_destino_horario_id INT;

				EXEC BuscarNodos
					@FlagOrigen = 0,
					@ParadaId = @DestinoId,
					@Fecha = @Fecha,
					@ViajeId = @viaje_Id,
					@NodoId = @nodo_destino_id OUTPUT,
					@HorarioId = @nodo_destino_horario_id OUTPUT,
					@ReturnResult = @resultados OUTPUT;

				IF @resultados = 1 AND @nodo_origen_horario_id = @nodo_destino_horario_id
				BEGIN
					SELECT @horarioLlegada = (CAST(CONVERT(DATE,@Fecha) AS datetime) + CAST(hora AS datetime)), @distribucionId = (distribucion_id)
					FROM horarios
					WHERE id = @nodo_destino_horario_id

					SELECT @SumatoriaNodos = (sum( DATEPART(SECOND, [demora]) + 60 * 
						DATEPART(MINUTE, [demora]) + 3600 * 
						DATEPART(HOUR, [demora] ))
					) from nodos where id <= @nodo_destino_id and viaje_id = @viaje_Id group by viaje_id;

					SET @horarioLlegada = @horarioLlegada + CAST(CONVERT(TIME(0), DATEADD(SS,@SumatoriaNodos,0),108) AS DATETIME)

					SELECT @SumatoriaPrecio = (sum(precio))
					FROM nodos
					WHERE id BETWEEN @nodo_origen_id AND @nodo_destino_id and viaje_id = @viaje_Id group by viaje_id;

					SELECT @asientosDisponibles = (COUNT(*))
					FROM distribuciones
					INNER JOIN filas ON filas.distribucion_id = distribuciones.id
					INNER JOIN celdas ON celdas.fila_id = filas.id
					WHERE distribuciones.id = @distribucionId
					AND celdas.value IN (2,6,7)

					SELECT @SumatoriaAsientos = (count(*))
					FROM boletos
					WHERE
						(DATEPART(SECOND, [hora_salida]) + 60 * DATEPART(MINUTE, [hora_salida]) + 3600 * DATEPART(HOUR, [hora_salida] ))
						>
						(DATEPART(SECOND, @horarioSalida) + 60 * DATEPART(MINUTE, @horarioSalida) + 3600 * DATEPART(HOUR, @horarioSalida ))
						AND
						(DATEPART(SECOND, [hora_llegada]) + 60 * DATEPART(MINUTE, [hora_llegada]) + 3600 * DATEPART(HOUR, [hora_llegada] ))
						>=
						(DATEPART(SECOND, @horarioLlegada) + 60 * DATEPART(MINUTE, @horarioLlegada) + 3600 * DATEPART(HOUR, @horarioLlegada ))
						AND boletos.recorrido_id = @viaje_Id
						AND CAST(CONVERT(DATE,boletos.fecha) AS datetime) = CAST(CONVERT(DATE,@Fecha) AS datetime) 

					IF @SumatoriaPrecio > 0
						INSERT INTO @ReturnTable (ViajeId, Empresa, HorarioSalida, HorarioLlegada, AsientosDisponibles, Precio)
						VALUES (@viaje_Id, N'Boleteria Online', CONVERT(VARCHAR(8),@horarioSalida,108), CONVERT(VARCHAR(8),@horarioLlegada,108), @asientosDisponibles - @SumatoriaAsientos, @SumatoriaPrecio);
				END 
			END

			FETCH NEXT FROM viajes_cursor   
			INTO @viaje_Id

		END   
		CLOSE viajes_cursor;  
		DEALLOCATE viajes_cursor;  
		/*
		SELECT * FROM boletos
		WHERE recorrido_id = @nodo_viajeId
		AND (origen_id IN (SELECT id FROM nodos WHERE viaje_id = @nodo_viajeId );
		*/

	END
	SELECT * FROM @ReturnTable

RETURN


