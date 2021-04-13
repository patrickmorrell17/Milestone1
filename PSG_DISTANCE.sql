CREATE OR REPLACE FUNCTION haversine (lat1 float,lon1 float,lat2 float,lon2 float) RETURNS float as $$
	DECLARE
		dlatitude float:= (lat2-lat1)*pi()/180.0;
		dlongitude float:= (lon2-lon1)*pi()/180.0;
		tempvalue float;
		radiusofearth float := 6371;
	BEGIN
		-- computing distances
		-- converting to radians
		lat1:=(lat1)*pi()/180.0;
		lat2:=(lat2)*pi()/180.0;
		
		-- applying formula
		tempvalue :=(power(sin(dlatitude/2),2)+power(sin(dlongitude/2),2)*cos(lat1)*cos(lat2));
		tempvalue:=2*asin(sqrt(tempvalue));
		RETURN tempvalue*radiusofearth;
	END;
$$ LANGUAGE plpgsql;


CREATE OR REPLACE FUNCTION haversine (useid VARCHAR,busid VARCHAR) RETURNS float as $$
	DECLARE
		businesslat float:=(SELECT latitude FROM Business WHERE businessid = busid);
		businesslong float:=(SELECT longitude FROM Business WHERE businessid = busid);
		userlat float:=(SELECT latitude FROM UserTable WHERE userid = useid);
		userlong float:=(SELECT longitude FROM UserTable WHERE userid = useid);
	BEGIN
		RETURN haversine(userlat,userlong,businesslat,businesslong);
	END;
$$ LANGUAGE plpgsql;