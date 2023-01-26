SELECT	content.id AS 'id',
		content.name AS 'name',
		contenttype.name AS 'type',
		table1.progress AS 'progress',
		contentrelation.rate AS 'score',
		content.picture AS 'picture'
FROM content
JOIN contenttype
ON content.type = contenttype.id
JOIN contentrelation
ON content.id = contentrelation.contentid
JOIN users
ON contentrelation.userid=users.id
JOIN(SELECT content.id AS 'id',users.id AS 'uid',CONCAT(contentrelation.progress,'/',content.numberofepisodes) AS 'progress'
		FROM content
		JOIN contentrelation
		ON content.id = contentrelation.contentid
		JOIN users
		ON users.ID = contentrelation.userid) AS table1
ON table1.id = contentrelation.contentid AND table1.uid = contentrelation.userid
WHERE users.ID=x;