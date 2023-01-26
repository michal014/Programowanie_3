SELECT content.id as 'id',
	   content.name AS 'name',
       contenttype.name AS 'type',
       content.numberofepisodes AS 'episodes',
       table1.producers AS 'producer',
       table2.genres AS 'genre',
       content.picture AS 'picture'
FROM content
JOIN contenttype
ON content.type = contenttype.id
JOIN (SELECT producerrelation.contentid, 
             STRING_AGG(producer.name, '; ') AS 'producers'
      FROM producerrelation
      JOIN producer
      ON producerrelation.producerid = producer.id
      GROUP BY producerrelation.contentid) AS table1
ON table1.contentID = content.id
JOIN (SELECT genrerelation.contentid,
             STRING_AGG(genres.name, '; ') AS 'genres'
      FROM genrerelation
      JOIN genres
      ON genrerelation.genreid = genres.id
      GROUP BY genrerelation.contentid) AS table2
ON table2.contentID = content.id
ORDER BY content.name ASC;
