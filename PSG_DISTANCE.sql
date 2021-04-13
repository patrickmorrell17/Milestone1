CREATE OR REPLACE FUNCTION haversine (lat1 float,lon1 float,lat2 float,lon2 float) RETURNS float as $$
	DECLARE
		-- getting the distance between the 2 latitudes and converting to radians
		dlatitude float:= (lat2-lat1)*pi()/180.0;
		-- getting the distance between the 2 longitudes and converting to radians
		dlongitude float:= (lon2-lon1)*pi()/180.0;
		-- user to make formula smaller
		tempvalue float;
		-- radius of earth in meters
		radiusofearth float := 6371;
	BEGIN
		-- converting to radians
		lat1:=(lat1)*pi()/180.0;
		lat2:=(lat2)*pi()/180.0;
		
		-- applying formula
		tempvalue :=(power(sin(dlatitude/2),2)+power(sin(dlongitude/2),2)*cos(lat1)*cos(lat2));
		tempvalue:=2*asin(sqrt(tempvalue));
		RETURN tempvalue*radiusofearth;
	END;
$$ LANGUAGE plpgsql;

-- overloaded function, takes only the userid and the businessid and computes the distance between them
CREATE OR REPLACE FUNCTION haversine (useid VARCHAR,busid VARCHAR) RETURNS float as $$
	DECLARE
		-- getting all the values
		businesslat float:=(SELECT latitude FROM Business WHERE businessid = busid);
		businesslong float:=(SELECT longitude FROM Business WHERE businessid = busid);
		userlat float:=(SELECT latitude FROM UserTable WHERE userid = useid);
		userlong float:=(SELECT longitude FROM UserTable WHERE userid = useid);
	BEGIN
		-- calling original function
		RETURN haversine(userlat,userlong,businesslat,businesslong);
	END;
$$ LANGUAGE plpgsql;