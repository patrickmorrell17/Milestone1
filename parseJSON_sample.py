import json

def cleanStr4SQL(s):
    return s.replace("'","`").replace("\n"," ")

def parseBusinessData():
    #read the JSON file
    # We assume that the Yelp data files are available in the current directory. If not, you should specify the path when you "open" the function. 
    with open('.//yelp_business.JSON','r') as f:  
        outfile =  open('.//business.txt', 'w')
        line = f.readline()
        count_line = 0
        #read each JSON abject and extract data
        while line:
            data = json.loads(line)
            outfile.write(cleanStr4SQL(data['business_id'])+'\t') #business id
            outfile.write(cleanStr4SQL(data['name'])+'\t') #name
            outfile.write(cleanStr4SQL(data['address'])+'\t') #full_address
            outfile.write(cleanStr4SQL(data['state'])+'\t') #state
            outfile.write(cleanStr4SQL(data['city'])+'\t') #city
            outfile.write(cleanStr4SQL(data['postal_code']) + '\t')  #zipcode
            outfile.write(str(data['latitude'])+'\t') #latitude
            outfile.write(str(data['longitude'])+'\t') #longitude
            outfile.write(str(data['stars'])+'\t') #stars
            outfile.write(str(data['review_count'])+'\t') #reviewcount
            outfile.write(str(data['is_open'])+'\t') #openstatus

            categories = data["categories"].split(', ')
            outfile.write(str(categories)+'\t')  #category list
            
            # TO-DO : write your own code to process attributes
            outfile.write(str([]) + "\t")
            attributes = data['attributes']
            # TO-DO : write your own code to process hours data
            outfile.write('[')
            hours = data["hours"]
            for day in hours:
                outfile.write('\'Hours' + cleanStr4SQL(day) + '\':\'' + cleanStr4SQL(hours[day])+'\',')
            outfile.write(']\t') 

            outfile.write('\n')

            line = f.readline()
            count_line +=1
    print(count_line)
    outfile.close()
    f.close()

# parses the user data into a .txt file to be read into the db
def parseUserData():
    # TO-DO : write code to parse yelp_user.JSON
    with open('.//yelp_user.JSON','r') as f:  
        outfile =  open('.//user.txt', 'w')
        line = f.readline()
        count_line = 0
        #read each JSON abject and extract data
        while line:
            data = json.loads(line)
            # getting all the attributes
            outfile.write(str(data['user_id'])+"\t")
            outfile.write(str(data['name'])+"\t")
            outfile.write(str(data["average_stars"])+"\t")
            outfile.write(str(data["cool"])+"\t")
            outfile.write(str(data["fans"])+"\t")
            # might have to change the format of the output for this depending on implementation of application
            outfile.write(str(data['friends']) + '\t')
            outfile.write(str(data['funny']) + '\t')
            outfile.write(str(data['tipcount'])+'\t')
            outfile.write(str(data['useful']) + '\t')
            outfile.write(str(data['yelping_since'])+'\t')
            outfile.write('\n')
            line = f.readline()
            count_line+=1
        print(count_line)

# parses the checkin data and outputs it to the .txt file
def parseCheckinData():
    with open('.//yelp_checkin.JSON','r') as f:  
        outfile =  open('.//checkin.txt', 'w')
        line = f.readline()
        count_line = 0
        #read each JSON abject and extract data
        while line:
            data = json.loads(line)
            outfile.write(str(data['business_id'])+'\t')
            outfile.write('[' + str(data['date']) + ']')
            outfile.write('\n')
            line = f.readline()
            count_line+=1
        print(count_line)

def parseTipData():
    with open('.//yelp_tip.JSON','r') as f:  
        outfile =  open('.//tip.txt', 'w')
        line = f.readline()
        count_line = 0
        #read each JSON abject and extract data
        while line:
            data = json.loads(line)
            outfile.write(str(data['business_id'])+'\t')
            outfile.write(str(data['date'])+'\t')
            outfile.write(str(data['likes'])+'\t')
            outfile.write(str(data['text']) + '\t')
            outfile.write(str(data['user_id']))
            outfile.write('\n')
            line = f.readline()
            count_line+=1
        print(count_line)

if __name__ == "__main__":
    parseBusinessData()
    parseUserData()
    parseCheckinData()
    parseTipData()
