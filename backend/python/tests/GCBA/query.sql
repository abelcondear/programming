-- 1 - Taxistas que tengan email pero no dominio (patente de vehículo)

SELECT 
	* 
FROM 
	taxistas 
WHERE 
	email IS NOT NULL 
	AND TRIM(email) = '' 
	AND dominio IS NULL
		
-- 2 - Clientes que ingresaron a la aplicación en las últimas 24hs
SELECT
	*
FROM 
	cliente c,
	pedido p
WHERE 
	c.idPedido = p.id
	AND p.fecha >= now() - INTERVAL 1 DAY
	
-- 3 - Recuento de todos los estados de viajes .	
SELECT 
	COUNT(1) AS recuento, 
	estado 
FROM 
	viaje
GROUP BY 
	estado

-- 4 - Viajes en los que el taxista con email X , llevó al pasajero con email Y.
SELECT 
	* 
FROM 
	viaje v,
	taxista t,
	cliente c
WHERE
	v.idTaxista = t.id
	AND v.idCliente = c.id
	AND t.email IS NOT NULL 
	AND c.email IS NOT NULL 
	AND t.email <> c.email	
	
