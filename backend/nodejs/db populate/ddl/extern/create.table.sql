USE shift;

CREATE TABLE extern
(
		id INT PRIMARY KEY AUTO_INCREMENT NOT NULL
,		name VARCHAR(100) NOT NULL
,		surname VARCHAR(100) NOT NULL
,		cardid INT NOT NULL
,		email VARCHAR(100) NOT NULL
,		phone VARCHAR(50) NOT NULL
,		active SMALLINT DEFAULT 1 NOT NULL
);
