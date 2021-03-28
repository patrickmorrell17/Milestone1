CREATE OR REPLACE FUNCTION UpdateNumCheckins() RETURNS trigger as '
BEGIN
	UPDATE Business
	SET numOfCheckin = numOfCheckin + 1
	WHERE Business.businessid = NEW.businessid;
	RETURN NEW;
END
' LANGUAGE plpgsql;

CREATE TRIGGER numcheckins
AFTER INSERT ON checkins
FOR EACH ROW
WHEN (NEW.businessid IS NOT NULL)
EXECUTE PROCEDURE UpdateNumCheckins();

CREATE OR REPLACE FUNCTION UpdateNumTips() RETURNS trigger as '
BEGIN
	UPDATE Business
	SET numOfTips = numOfTips + 1
	WHERE Business.businessid = NEW.businessid;
	RETURN NEW;
END
' LANGUAGE plpgsql;

CREATE TRIGGER numTips
AFTER INSERT ON tip
FOR EACH ROW
WHEN (NEW.businessid IS NOT NULL)
EXECUTE PROCEDURE UpdateNumTips();


CREATE OR REPLACE FUNCTION UpdateTipCount() RETURNS trigger as '
BEGIN
	UPDATE UserTable
	SET tipCount = tipCount + 1
	WHERE UserTable.userid = NEW.userid;
	RETURN NEW;
END
' LANGUAGE plpgsql;

CREATE TRIGGER tipCount
AFTER INSERT ON tip
FOR EACH ROW
WHEN (NEW.userID IS NOT NULL)
EXECUTE PROCEDURE UpdateTipCount();


CREATE OR REPLACE FUNCTION UpdateTotalTipLikes() RETURNS trigger as '
BEGIN
	UPDATE UserTable
	SET totaltiplikes = totaltiplikes + 1
	WHERE UserTable.userid = NEW.userid;
	RETURN NEW;
END
' LANGUAGE plpgsql;

CREATE TRIGGER totaltiplikes
AFTER UPDATE ON tip
FOR EACH ROW
WHEN (OLD.likecount < NEW.likecount)
EXECUTE PROCEDURE UpdateTotalTipLikes();

-- Testing UpdateTipCount and UpdateNumTips
--SELECT businessid, userid, numoftips, tipcount, totaltiplikes FROM Business, UserTable  WHERE businessid = '2D3gx261cReZb-K1RZJA_g' and userid = '--5XzJ2pRsVVJiJUfzZlgQ';

--INSERT INTO tip VALUES('2000-01-01',0,'test','--5XzJ2pRsVVJiJUfzZlgQ','2D3gx261cReZb-K1RZJA_g');

--SELECT businessid, userid, numoftips, tipcount, totaltiplikes FROM Business, UserTable  WHERE businessid = '2D3gx261cReZb-K1RZJA_g' and userid = '--5XzJ2pRsVVJiJUfzZlgQ';


-- Testing UpdateNumCheckins
-- SELECT businessid, numofcheckin FROM Business WHERE businessid = 'Ik-vXB7HCwnC44KDf_nwdw';

-- INSERT INTO checkins VALUES ('2010-01-01 09:30:30','Ik-vXB7HCwnC44KDf_nwdw');

-- SELECT businessid, numofcheckin FROM Business WHERE businessid = 'Ik-vXB7HCwnC44KDf_nwdw';

-- Testing UpdateTotalTipLikes()


-- Testing UpdateTotalTipLikes

-- SELECT userid,totaltiplikes FROM usertable WHERE userid = '---1lKK3aKOuomHnwAkAow';

-- UPDATE tip SET likecount = likecount+1 WHERE userid = '---1lKK3aKOuomHnwAkAow' and textoftip = 'Phone number should be 1531';

-- SELECT userid,totaltiplikes FROM usertable WHERE userid = '---1lKK3aKOuomHnwAkAow';

