UPDATE business
SET numoftips = numtips.count
FROM (
	SELECT T1.businessID, Count(T2.businessID)
	FROM tip as T1, tip as T2
	WHERE T1.businessID = T2.businessID
	GROUP BY T1.businessID 
) as numtips
WHERE numtips.businessid = business.businessid;

UPDATE business
SET numofcheckin= numcheckins.count
FROM (
	SELECT C1.businessID, Count(C2.businessID)
	FROM checkins as C1, checkins as C2
	WHERE C1.businessID = C2.businessID
	GROUP BY C1.businessID 
) as numcheckins
WHERE numcheckins.businessid = business.businessid;

UPDATE usertable
SET totaltiplikes = tipcount.sum
FROM (
	SELECT distinct userid, SUM(likecount)
	FROM tip
	GROUP BY userid
	) as tipcount
WHERE tipcount.userid = usertable.userid;

UPDATE usertable
SET tipcount = tipct.count
FROM (
	SELECT T1.userid, COUNT(T2.userid)
	FROM tip as T1, tip as T2
	WHERE T1.userid = T2.userid
	GROUP BY T1.userid
	) as tipct
WHERE tipct.userid = usertable.userid;