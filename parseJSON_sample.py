import json
def main():
    parseBusinessData()
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
            outfile.write('\n')
            attributes = data["attributes"]
            
            outfile.write('[')
            for key in attributes:
                if(type(attributes[key]) == dict):
                    for key2 in attributes[key]:
                        outfile.write('(' + cleanStr4SQL(key2) + ', ' + cleanStr4SQL(attributes[key][key2]) + ')')
                        outfile.write(', ')
                else:        
                    outfile.write('(' + cleanStr4SQL(key) + ', ' + cleanStr4SQL(attributes[key]) + ')')
                    outfile.write(', ')
            outfile.write(']\t')
            outfile.write('\n')
            # TO-DO : write your own code to process hours data
            outfile.write('[')
            hours = data["hours"]
            for day in hours:
                outfile.write('[' + cleanStr4SQL(day) + ': (' + cleanStr4SQL(hours[day])+')]')
            outfile.write(']\t') 

            outfile.write('\n')

            line = f.readline()
            count_line +=1
    print(count_line)
    outfile.close()
    f.close()

def parseUserData():
    # TO-DO : write code to parse yelp_user.JSON
    pass

def parseCheckinData():
    # TO-DO : write code to parse yelp_checkin.JSON
    pass


def parseTipData():
    # TO-DO : write code to parse yelp_tip.JSON
    pass

if __name__ == "__main__":
    parseBusinessData()
    parseUserData()
    parseCheckinData()
    parseTipData()
