CREATE TABLE usertable (
    userID VARCHAR,
    cool Integer,
    tipCount Integer default 0,
    username VARCHAR,
    averageStars REAL,
    latitude REAL,
    longitude REAL,
    yelping_Since TIMESTAMP,
    totalTipLikes INTEGER default 0,
    fans Integer,
    useful integer,
    funny integer,

    PRIMARY KEY(userID)
);

CREATE TABLE friendship(
    firstUserID VARCHAR,
    secondUserID VARCHAR,
    PRIMARY KEY(firstUserID, secondUserID),
    FOREIGN KEY(firstUserID) REFERENCES usertable(userID),
    FOREIGN KEY(secondUserID) REFERENCES usertable(userID)
);

CREATE TABLE business(
    --what to do about derived values
    businessID VARCHAR,
    city VARCHAR,
    businessState VARCHAR,
    latitude REAL,
    longitude REAL,
    stars INTEGER,
    businessName VARCHAR,
    numOfCheckin INTEGER default 0,
    numOfTips INTEGER default 0,
    --distanceBetweenUser shoulld it be in search or in business
    businessAddress VARCHAR,
    postalCode VARCHAR,
    is_open boolean,

    PRIMARY KEY(businessID)
);

CREATE TABLE categories(
    businessID VARCHAR,
    categoryName VARCHAR,
    PRIMARY KEY(categoryName, businessID),
    FOREIGN KEY(businessID) REFERENCES business(businessID)
);

CREATE TABLE tip(
    dateOfTip DATE,
    likeCount INTEGER,
    textOfTip VARCHAR,
    userID VARCHAR,
    businessID VARCHAR,
    PRIMARY KEY (dateOfTip, likeCount, textOfTip,businessID,userID),
    FOREIGN KEY(userID) REFERENCES usertable(userID),
    FOREIGN KEY(businessID) REFERENCES business(businessID)
);

--not sure if user should be in checkin defaulted to having it
CREATE TABLE checkins(
    checkintimestamp TIMESTAMP,
    businessID VARCHAR,
    PRIMARY KEY(checkintimestamp,businessID),
    FOREIGN KEY(businessID) REFERENCES business(businessID)
);

CREATE TABLE attributes(
    businessID VARCHAR,
    nameOfAttribute VARCHAR,
    valueOfAttribute VARCHAR,
    PRIMARY KEY(nameOfAttribute,businessID),
    FOREIGN KEY(businessID) REFERENCES business(businessID)
);

CREATE TABLE businessHours(
    businessID VARCHAR,
    dayOfWeek VARCHAR,
    -- these could also be time instead of varchar I'm not sure
    closeTime VARCHAR,
    openTime VARCHAR,
    PRIMARY KEY(dayOfWeek,businessID),
    FOREIGN KEY(businessID) REFERENCES business(businessID)
);


--not sure about search
