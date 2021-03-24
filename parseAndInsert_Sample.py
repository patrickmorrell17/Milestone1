# CptS 451 - Spring 2021
# https://www.psycopg.org/docs/usage.html#query-parameters

#{"businessID": "gnKjwL_1w79qoiV3IC_xQQ", "name": "Musashi Japanese Restaurant", "address": "10110 Johnston Rd, Ste 15", "city": "Charlotte", "state": "NC", "postal_code": "28210", "latitude": 35.092564, "longitude": -80.859132, "stars": 4.0, "review_count": 170, "is_open": 1, "attributes": {"GoodForKids": "True", "NoiseLevel": "average", "RestaurantsDelivery": "False", "GoodForMeal": {"dessert": "False", "latenight": "False", "lunch": "True", "dinner": "True", "brunch": "False", "breakfast": "False"}, "Alcohol": "beer_and_wine", "Caters": "False", "WiFi": "no", "RestaurantsTakeOut": "True", "BusinessAcceptsCreditCards": "True", "Ambience": {"romantic": "False", "intimate": "False", "touristy": "False", "hipster": "False", "divey": "False", "classy": "False", "trendy": "False", "upscale": "False", "casual": "True"}, "BusinessParking": {"garage": "False", "street": "False", "validated": "False", "lot": "True", "valet": "False"}, "RestaurantsTableService": "True", "RestaurantsGoodForGroups": "True", "OutdoorSeating": "False", "HasTV": "True", "BikeParking": "True", "RestaurantsReservations": "True", "RestaurantsPriceRange2": "2", "RestaurantsAttire": "casual"}, "categories": "Sushi Bars, Restaurants, Japanese", "hours": {"Monday": "17:30-21:30", "Wednesday": "17:30-21:30", "Thursday": "17:30-21:30", "Friday": "17:30-22:0", "Saturday": "17:30-22:0", "Sunday": "17:30-21:0"}}

# username to connect to the databse
import psycopg2
import json
USERNAME = 'postgres'
# database name
DB_NAME = 'milestone2'
# password
PASS = 'Sciencetem20'


#  if psycopg2 is not installed, install it using pip installer :  pip install psycopg2  (or pip3 install psycopg2)


def cleanStr4SQL(s):
    return s.replace("'", "`").replace("\n", " ")


def int2BoolStr(value):
    if value == 0:
        return 'False'
    else:
        return 'True'


def insert2CheckInTable():
    with open('./yelp_checkin.JSON', 'r') as f:
        line = f.readline()
        count_line = 0
        try:
            conn = psycopg2.connect(
                "dbname="+DB_NAME+" user='" + USERNAME + "' host='localhost' password='" + PASS + "'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()
        while line:
            data = json.loads(line)
            dates = str(data["date"]).split(",")
            for val in dates:
                try:
                    cur.execute("INSERT INTO checkins (businessID,dateOfCheckIn)"
                                + " VALUES (%s, %s)",
                                (data['businessID'],val))
                except Exception as e:
                    print("Insert to checkin failed!", e)
                conn.commit()
            count_line += 1
        f.close()
        conn.close()

def insert2TipTable():
    with open('./yelp_tip.JSON', 'r') as f:
        line = f.readline()
        count_line = 0
        try:
            conn = psycopg2.connect(
                "dbname="+DB_NAME+" user='" + USERNAME + "' host='localhost' password='" + PASS + "'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()
        while line:
            data = json.loads(line)
            try:
                cur.execute("INSERT INTO tipTable (userID,businessID,dateOfTip,textOfTip,likeCount)"
                            + " VALUES (%s, %s, %s, %s, %s)",
                            (data['user_id'], data["businessID"], data["date"], data["text"], data["likes"]))
            except Exception as e:
                print("Insert to tipTable failed!", e)
            conn.commit()
            count_line += 1
        f.close()
        conn.close()

def insert2UserTable():
    with open('./yelp_user.JSON', 'r') as f:
        frienddict = dict()
        line = f.readline()
        count_line = 0
        try:
            conn = psycopg2.connect(
                "dbname="+DB_NAME+" user='" + USERNAME + "' host='localhost' password='" + PASS + "'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()
        while line:
            data = json.loads(line)
            try:
                # may need to change names in future
                cur.execute("INSERT INTO usertable (userID,username,averageStars,fans,cool,tipCount,funny,totalTipLikes,useful,latitude,longitude,yelping_Since)"
                            + " VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)",
                            (data['user_id'], data["name"], data["average_stars"], data["fans"], data["cool"], 0, data["funny"], 0, 0, 0, 0, data["yelping_since"]))
            except Exception as e:
                print("Insert to usertable failed!", e)
            conn.commit()
            count_line += 1
            # keeping track of each user's friends (have to insert last)
            frienddict[str(data['user_id'])] = data['friends']
        print(count_line)
        for val in frienddict.keys():
            try:
                cur.execute("INSERT INTO friendship (firstUserID,secondUserID)"
                            + " VALUES (%s, %s)", (val, frienddict[val]))
            except Exception as e:
                print("Insert to friendship failed!", e)
        f.close()
        conn.close()


def insert2BusinessTable():
    # reading the JSON file
    with open('./yelp_business.JSON', 'r') as f:  # TODO: update path for the input file
        line = f.readline()
        count_line = 0
        #data = json.loads(line)
        #attributes = data["attributes"]
        #meals = attributes["GoodForMeal"]
        # connect to yelpdb database on postgres server using psycopg2
        try:
            # TODO: update the database name, username, and password
            conn = psycopg2.connect(
                "dbname="+DB_NAME+" user='" + USERNAME + "' host='localhost' password='" + PASS + "'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            # Generate the INSERT statement for the current business
            try:
                cur.execute("INSERT INTO business (businessID, businessName, businessaddress, businessstate, city, postalCode, latitude, longitude, stars, numOfCheckin, numOfTips, is_open)"
                            + " VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)",
                            (data['businessID'], cleanStr4SQL(data["name"]), cleanStr4SQL(data["address"]), data["state"], data["city"], data["postal_code"], data["latitude"], data["longitude"], data["stars"], 0, 0, int2BoolStr(data["is_open"])))
            except Exception as e:
                print("Insert to business failed!", e)
            conn.commit()
            # getting the attributes
            attributes = data["attributes"]
            # storing the businessID for insertion since it is accessed very often (used as a FK for all the weak relations)
            bus_id = data['businessID']
            for value in attributes:
                # if nested value, run through all the vals contained in it
                if value is dict:
                    for nestedval in value:
                        try:
                            # will have to change w/ attribute table names
                            cur.execute("INSERT INTO attributes (nameOfAttribute, valueOfAttribute, businessID)" +
                                        " VALUES (%s, %s, %s)", (nestedval, value[nestedval], bus_id))
                        except Exception as e:
                            print("Insert to attributeTable failed!", e)
                        conn.commit()
                else:
                    try:
                        cur.execute("INSERT INTO attributes (nameOfAttribute, valueOfAttribute, businessID)" +
                                    " VALUES (%s, %s, %s)", (value, attributes[value], bus_id))
                    except Exception as e:
                        print("Insert to attributes failed!", e)
                    conn.commit()
            # inserting the hours
            hours = data["hours"]
            for value in hours:
                # have to split the hours before insertion, since the way we did it the hours are a single string
                open_close = str(hours[value]).split("-")
                try:
                    # will have to change hoursTable names
                    cur.execute("INSERT INTO businessHours (dayOfWeek, closeTime, openTime, businessID)" +
                                " VALUES (%s, %s, %s, %s)", (value, open_close[0], open_close[1], bus_id))
                except Exception as e:
                    print("Insert to businessHours failed!", e)
                conn.commit()
            categories = str(data["categories"]).split(",")
            # inserting the categories
            for value in categories:
                try:
                    cur.execute("INSERT INTO categories (categoryName, businessID)" +
                                " VALUES (%s, %s)", (value, bus_id))
                except Exception as e:
                    print("Insert to categories failed!", e)
                conn.commit()

            line = f.readline()
            count_line += 1

        cur.close()
        conn.close()

    print(count_line)
    f.close()


insert2BusinessTable()
insert2UserTable()
insert2TipTable()
insert2CheckInTable()
