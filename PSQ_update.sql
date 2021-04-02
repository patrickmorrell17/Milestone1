UPDATE business
SET numoftips = numtips.count
FROM (
	SELECT T1.businessID, COUNT(t1.businessid)
	FROM tip as T1
	GROUP BY T1.businessid
) as numtips
WHERE numtips.businessid = business.businessid;

UPDATE business
SET numofcheckin= numcheckins.count
FROM (
	SELECT C1.businessID, Count(C1.businessID)
	FROM checkins as C1
	GROUP BY C1.businessid
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
	SELECT T1.userid, COUNT(T1.userid)
	FROM tip as T1
	GROUP BY T1.userid
	) as tipct
WHERE tipct.userid = usertable.userid;