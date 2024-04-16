--- QUERY LAB:

-- GET ALL THE MOVIES WHICH TITLE OR GENRE OR FIRSTNAME OR LASTNAME OF THEIR ACTORS BEGIN WITH
-- "Com":

SELECT M.Title as Ttile,
       M.Genre as Genre,
       (RTRIM(LTRIM(C.FirstName))) + ' ' + (RTRIM(LTRIM(C.LastName))) AS Casting    
FROM Movie M
INNER JOIN MovieCast MC
ON M.id = MC.MovieId
INNER JOIN [Cast] C
ON C.Id = MC.CastId
WHERE CONTAINS(M.Title, '"Com*"') OR  CONTAINS(M.Genre,'"Com*"')
	OR CONTAINS(C.FirstName, '"Com*"') OR  CONTAINS(C.LastName,'"Com*"')