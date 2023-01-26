SELECT content.id AS 'id',
	content.name AS 'name',
	content.description AS 'description',
	table1.allscore AS 'allscore',
	content.numberofepisodes AS 'numberOfEpisodes',
	contentrelation.progress AS 'episodeProgress',
	contentrelation.rate AS 'score',
	table2.genres AS 'genre',
	table3.producers AS 'producer',
	contentrelation.status AS 'idAdded',
	content.picture AS 'picture'
FROM content
JOIN contentrelation
ON content.id = contentrelation.contentid
JOIN users
ON users.ID = contentrelation.userid
JOIN (SELECT contentrelation.contentid AS 'id', AVG(contentrelation.rate) AS 'allscore' 
		FROM contentrelation
		GROUP BY contentrelation.contentid) AS table1
ON table1.id = content.id
JOIN (SELECT genrerelation.contentid,
             STRING_AGG(genres.name, '; ') AS 'genres'
      FROM genrerelation
      JOIN genres
      ON genrerelation.genreid = genres.id
      GROUP BY genrerelation.contentid) AS table2
ON table2.contentID = content.id
JOIN (SELECT producerrelation.contentid, 
             STRING_AGG(producer.name, '; ') AS 'producers'
      FROM producerrelation
      JOIN producer
      ON producerrelation.producerid = producer.id
      GROUP BY producerrelation.contentid) AS table3
ON table3.contentID = content.id
ORDER BY content.name ASC;