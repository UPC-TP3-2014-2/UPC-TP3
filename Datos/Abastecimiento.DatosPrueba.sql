use CSUR
go


declare
	@contador int = 1, 
	@totalContador int = 10, 
	@contadorString varchar(10) = ''

-- Datos de prueba del módulo de Abastecimiento.


-- Borramos información
delete from TA_INSUMO
delete from TA_REFRIGERIO





-- insertamos información de prueba.
while @contador <= @totalContador
begin
	
	select @contadorString = convert(varchar, @contador)

	insert TA_INSUMO(VCH_DESCRIPCION, VCH_TIPO_UNIDAD, DTE_FECHA_VENCIMIENTO) 
	values('Insumo ' + @contadorString, 'Tipo Unidad ' + @contadorString, dateadd(day, @contador * -1, getdate()))
	
	insert into TA_REFRIGERIO(VCH_DESCRIPCION, VCH_TIPO_UNIDAD)
	values('Refrigerio ' + @contadorString, 'Tipo Unidad ' + @contadorString)
	
	insert into TA_UBIGEO(VCH_NOMBRE)
	values('Ubigeo ' + @contadorString)
	
	insert into TA_AGENCIA(VCH_NOMBRE, VCH_DIRECCION, INT_UBIGEO_DIRECCION)
	values('Agencia ' + @contadorString, 'Dirección ' + @contadorString, @contador)
	
	insert into TA_RUTA(VCH_ORIGEN, VCH_DESTINO, INT_CODIGO_AGENCIAORIGEN, INT_CODIGO_AGENCIADESTINO, BLN_ESTADO)
	values('Origen ' + @contadorString, 'Destino ' + @contadorString, @contador, @contador, 1)
	
	insert into TA_TIPO_TRANSPORTE(VCH_NOMBRE)
	values('Tipo Transporte ' + @contadorString)
	
	insert into TA_VEHICULO(VCH_PLACA, VCH_MARCA, VCH_MODELO, VCH_COLOR, INT_TIPO_TRANSPORTE)
	values('Placa ' + @contadorString, 'Marca ' + @contadorString, 'Modelo ' + @contadorString, 'Color ' + @contadorString, @contador)
	
	insert into TA_PERSONA(INT_CODIGOPERSONA, VCH_NUMERODOCUMENTO, VCH_APEPATPERSONA, VCH_APEMATPERSONA, VCH_NOMBREPERSONA, DTE_FECHANACIMIENTO, VCH_DIRECCION, CHR_SEXOPERSONA, BLN_ACTIVO)
	values(@contador, @contadorString, 'Ape. Paterno ' + @contadorString, 'Ape. Materno ' + @contadorString, 'Nombres ' + @contadorString, dateadd(year, @contador * -1, getdate()), 'Dirección ' + @contadorString, 'M', 1)
	
	insert into TA_PROGRAMACION_RUTA(INT_CODIGO_RUTA, DTM_FECHA_ORIGEN, DTM_FECHA_DESTINO, INT_CODIGOVEHICULO, INT_CODIGOPERSONA, BLN_ESTADO)
	values(@contador, dateadd(day, @contador * -1, getdate()), dateadd(day, @contador, getdate()), @contador, @contador, 1)
	
	insert into TA_SOLICITUDCOCINA(INT_CODIGO_REFRIGERIO, INT_CODIGO_PROGRAMACION_RUTA, INT_CANTIDAD, DTE_FECHA_SOLICITUD, BLN_ESTADO)
	values(@contador, @contador, @contador, dateadd(day, @contador * -1, getdate()),  1)
	
	insert into TA_SOLICITUDINSUMO(INT_CODIGO_SOLICITUDCOCINA, INT_CODIGO_INSUMO, DTE_FECHA_SOLICITUD, INT_CANTIDAD, VCH_UNIDAD, BLN_ESTADO)
	values(@contador, @contador, dateadd(day, @contador * -1, getdate()), @contador, 'Unidad ' + @contadorString, 1)
	
	select @contador += 1
end



--select * from TA_INSUMO
--select * from TA_SOLICITUDINSUMO
--select * from TA_SOLICITUDCOCINA
--select * from TA_PROGRAMACION_RUTA
--select * from TA_PERSONA
--select * from TA_VEHICULO
--select * from TA_RUTA
--select * from TA_AGENCIA
--select * from TA_UBIGEO

--select * from TA_PROGRAMACION_RUTA

--select a.int_codigo_solicitudcocina, a.int_codigo_refrigerio, a.int_codigo_programacion_ruta, a.int_cantidad, a.bln_estado, d.int_vehiculo, d.vch_placa, c.int_codigo_ruta, c.vch_origen, c.vch_destino from ta_solicitudcocina a left outer join ta_programacion_ruta b on(a.int_codigo_programacion_ruta = b.int_codigo_programacion_ruta) left outer join ta_ruta c on(b.int_codigo_ruta = c.int_codigo_ruta) left outer join ta_vehiculo d on(b.int_codigovehiculo = d.int_vehiculo) 
--select * from ta_programacion_ruta


select int_codigo_refrigerio, vch_descripcion, vch_tipo_unidad from ta_refrigerio

select
	a.int_codigo_programacion_ruta, 
	a.int_codigo_ruta, 
	a.dtm_fecha_origen, 
	a.dtm_fecha_destino, 
	a.tim_hora_salida, 
	a.tim_hora_llegada, 
	a.int_tipo_servicio, 
	a.int_codigovehiculo, 
	a.int_codigopersona, 
	a.bln_estado, 
	b.vch_placa, 
	c.vch_origen, 
	c.vch_destino
from ta_programacion_ruta a
left outer join ta_vehiculo b on(a.int_codigovehiculo = b.int_vehiculo)
left outer join ta_ruta c on(a.int_codigo_ruta = c.int_codigo_ruta)


select a.int_codigo_programacion_ruta, a.int_codigo_ruta, a.dtm_fecha_origen, a.dtm_fecha_destino, a.tim_hora_salida, a.tim_hora_llegada, a.int_tipo_servicio, a.int_codigovehiculo, a.int_codigopersona, a.bln_estado, b.vch_placa, c.vch_origen, c.vch_destino from ta_programacion_ruta a left outer join ta_vehiculo b on(a.int_codigovehiculo = b.int_vehiculo) left outer join ta_ruta c on(a.int_codigo_ruta = c.int_codigo_ruta)