#CptS 451 - Spring 2021
# https://www.psycopg.org/docs/usage.html#query-parameters

#{"business_id": "gnKjwL_1w79qoiV3IC_xQQ", "name": "Musashi Japanese Restaurant", "address": "10110 Johnston Rd, Ste 15", "city": "Charlotte", "state": "NC", "postal_code": "28210", "latitude": 35.092564, "longitude": -80.859132, "stars": 4.0, "review_count": 170, "is_open": 1, "attributes": {"GoodForKids": "True", "NoiseLevel": "average", "RestaurantsDelivery": "False", "GoodForMeal": {"dessert": "False", "latenight": "False", "lunch": "True", "dinner": "True", "brunch": "False", "breakfast": "False"}, "Alcohol": "beer_and_wine", "Caters": "False", "WiFi": "no", "RestaurantsTakeOut": "True", "BusinessAcceptsCreditCards": "True", "Ambience": {"romantic": "False", "intimate": "False", "touristy": "False", "hipster": "False", "divey": "False", "classy": "False", "trendy": "False", "upscale": "False", "casual": "True"}, "BusinessParking": {"garage": "False", "street": "False", "validated": "False", "lot": "True", "valet": "False"}, "RestaurantsTableService": "True", "RestaurantsGoodForGroups": "True", "OutdoorSeating": "False", "HasTV": "True", "BikeParking": "True", "RestaurantsReservations": "True", "RestaurantsPriceRange2": "2", "RestaurantsAttire": "casual"}, "categories": "Sushi Bars, Restaurants, Japanese", "hours": {"Monday": "17:30-21:30", "Wednesday": "17:30-21:30", "Thursday": "17:30-21:30", "Friday": "17:30-22:0", "Saturday": "17:30-22:0", "Sunday": "17:30-21:0"}}


#  if psycopg2 is not installed, install it using pip installer :  pip install psycopg2  (or pip3 install psycopg2) 
import json
import psycopg2

def cleanStr4SQL(s):
    return s.replace("'","`").replace("\n"," ")

def int2BoolStr (value):
    if value == 0:
        return 'False'
    else:
        return 'True'

def insert2BusinessTable():
    #reading the JSON file
    with open('./yelp_business.JSON','r') as f:    #TODO: update path for the input file
        #outfile =  open('./yelp_business_out.SQL', 'w')  #uncomment this line if you are writing the INSERT statements to an output file.
        line = f.readline()
        count_line = 0

        #connect to yelpdb database on postgres server using psycopg2
        try:
            #TODO: update the database name, username, and password
            conn = psycopg2.connect("dbname='tempyelp' user='postgres' host='localhost' password='mustafa'")
        except:
            print('Unable to connect to the database!')
        cur = conn.cursor()

        while line:
            data = json.loads(line)
            # Generate the INSERT statement for the current business
            # TODO: The below INSERT statement is based on a simple (and incomplete) businesstable schema. Update the statement based on your own table schema and
            # include values for all businessTable attributes
            try:
                cur.execute("INSERT INTO businessTable (business_id, name, address, state, city, zipcode, latitude, longitude, stars, numCheckins, numTips, is_open, review_count)"
                       + " VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s, %s)", 
                         (data['business_id'],cleanStr4SQL(data["name"]), cleanStr4SQL(data["address"]), data["state"], data["city"], data["postal_code"], data["latitude"], data["longitude"], data["stars"], 0 , 0 , [False,True][data["is_open"]],data["review_count"]) )              
            except Exception as e:
                print("Insert to businessTABLE failed!",e)
            conn.commit()
            # optionally you might write the INSERT statement to a file.
            # sql_str = ("INSERT INTO businessTable (business_id, name, address, state, city, zipcode, latitude, longitude, stars, numCheckins, numTips, is_open)"
            #           + " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', {6}, {7}, {8}, {9}, {10}, {11})").format(data['business_id'],cleanStr4SQL(data["name"]), cleanStr4SQL(data["address"]), data["state"], data["city"], data["postal_code"], data["latitude"], data["longitude"], data["stars"], 0 , 0 , [False,True][data["is_open"]] )            
            # outfile.write(sql_str+'\n')

            line = f.readline()
            count_line +=1

        cur.close()
        conn.close()

    print(count_line)
    #outfile.close()  #uncomment this line if you are writing the INSERT statements to an output file.
    f.close()


insert2BusinessTable()