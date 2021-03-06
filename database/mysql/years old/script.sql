SELECT 
	DIFF_DAYS + DIFF_YEARS AS YEARS_OLD
FROM
(
	SELECT
		CASE
			WHEN DATEDIFF(TODAY_YMD,BIRTHDAY_YMD) < 0 THEN 0
			WHEN DATEDIFF(TODAY_YMD,BIRTHDAY_YMD) = 0 THEN 1
			WHEN DATEDIFF(TODAY_YMD,BIRTHDAY_YMD) > 0 THEN 1
		END AS DIFF_DAYS,
		
		CASE
			WHEN PERIOD_DIFF(TODAY_YM, BIRTHDAY_YM) % 12 = 0 THEN 
				CONVERT
				(
					 PERIOD_DIFF(TODAY_YM, BIRTHDAY_YM) / 12
					, UNSIGNED
				) - 1
			ELSE
				CONVERT
				(
					FLOOR(PERIOD_DIFF(TODAY_YM, BIRTHDAY_YM) / 12)
					, UNSIGNED
				)
		END AS DIFF_YEARS
	FROM  
	(
		SELECT
			CONVERT
			(
				CONCAT
				(
					CONVERT(YEAR(TODAY), CHAR(4)), 
					DATE_FORMAT(TODAY, '%m') 
				)
				, UNSIGNED
			) AS TODAY_YM,

			CONVERT
			(
				CONCAT
				(
					CONVERT(YEAR(BIRTHDAY), CHAR(4)), 
					DATE_FORMAT(BIRTHDAY, '%m') 
				)
				, UNSIGNED
			) AS BIRTHDAY_YM,

			CONVERT
			(
				CONCAT
				(
					CONVERT(YEAR(TODAY), CHAR(4)), 
					DATE_FORMAT(TODAY, '%m'), 
					DATE_FORMAT(TODAY, '%d') 
				)
				, UNSIGNED
			) AS TODAY_YMD,

			CONVERT
			(
				CONCAT
				(
					CONVERT(YEAR(TODAY), CHAR(4)), 
					DATE_FORMAT(BIRTHDAY, '%m'), 
					DATE_FORMAT(BIRTHDAY, '%d') 
				)
				, UNSIGNED
			) AS BIRTHDAY_YMD 
		FROM
		(
			SELECT 
				STR_TO_DATE('19800501', '%Y%m%d') AS BIRTHDAY,
				CURRENT_DATE() AS TODAY
		) AS T1
	) AS T2
) AS T3
