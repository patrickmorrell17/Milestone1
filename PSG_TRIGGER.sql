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

