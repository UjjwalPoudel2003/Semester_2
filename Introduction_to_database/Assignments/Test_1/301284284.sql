--Creating Table HOTEL
CREATE TABLE HOTEL(
    --Hotel Number
    hno number CONSTRAINT Cons_Hotel_hno PRIMARY KEY,
    
    --Hotel Name
    hname VARCHAR2(30) CONSTRAINT Cons_Hotel_hname NOT NULL,
    
    --Hotel Location
    hlocation VARCHAR2(30) DEFAULT 'downtown',
    
    --Hotel City
    hcity VARCHAR2(30) CONSTRAINT Cons_Hotel_hcity CHECK (hcity IN('Toronto', 'Markham', 'Brampton', 'Vaughan', 'Kitchener')),
    
    --Hotel Contact Information
    hcontact_no NUMBER CONSTRAINT Cons_Hotel_hcontact_no UNIQUE
); 

--Creating Table CUSTOMER
CREATE TABLE CUSTOMER(
    --Customer Number
    cust_no NUMBER,
    
    --Customer Name
    cust_name VARCHAR2(30),
    
    --Hotel Number
    hno number,
    
    --Adding Constraint
    CONSTRAINT Cons_Customer_hno FOREIGN KEY (hno) REFERENCES HOTEL(hno),
    
    --Number of days to stay
    no_of_days_tostay NUMBER,
    
    --Customer Address
    cust_address VARCHAR2(40),
    
    --Customer City
    cust_city VARCHAR2(30),
    
    --Adding Constraint for Number of Days
    CONSTRAINT Cons_no_of_days_tostay CHECK (no_of_days_tostay BETWEEN 5 AND 20),
    
    --Adding Constraint for Customer Name
    CONSTRAINT Cons_Customer_cust_name CHECK(cust_name = LOWER(cust_name))
);

-- Inserting values into HOTEL table
INSERT INTO HOTEL (hno, hname, hlocation, hcity, hcontact_no)
VALUES (1, 'Hotel A', 'Downtown', 'Toronto', 123456789);

INSERT INTO HOTEL (hno, hname, hlocation, hcity, hcontact_no)
VALUES (2, 'Hotel B', 'Suburb', 'Markham', 987654321);

INSERT INTO HOTEL (hno, hname, hlocation, hcity, hcontact_no)
VALUES (3, 'Hotel C', 'City Center', 'Brampton', 456789123);

INSERT INTO HOTEL (hno, hname, hlocation, hcity, hcontact_no)
VALUES (4, 'Hotel D', 'Central', 'Vaughan', 789123456);

INSERT INTO HOTEL (hno, hname, hlocation, hcity, hcontact_no)
VALUES (5, 'Hotel E', 'Downtown', 'Toronto', 159357852);

INSERT INTO HOTEL (hno, hname, hlocation, hcity, hcontact_no)
VALUES (6, 'Hotel F', 'Suburb', 'Markham', 753951456);

INSERT INTO HOTEL (hno, hname, hlocation, hcity, hcontact_no)
VALUES (7, 'Hotel G', 'City Center', 'Brampton', 852963741);

INSERT INTO HOTEL (hno, hname, hlocation, hcity, hcontact_no)
VALUES (8, 'Hotel H', 'Central', 'Vaughan', 369258147);

-- Inserting values into CUSTOMER table
INSERT INTO CUSTOMER (cust_no, cust_name, hno, no_of_days_tostay, cust_address, cust_city)
VALUES (1, 'john smith', 1, 10, '123 Main St', 'Toronto');

INSERT INTO CUSTOMER (cust_no, cust_name, hno, no_of_days_tostay, cust_address, cust_city)
VALUES (2, 'emma jones', 2, 7, '456 Elm St', 'Markham');

INSERT INTO CUSTOMER (cust_no, cust_name, hno, no_of_days_tostay, cust_address, cust_city)
VALUES (3, 'michael brown', 3, 15, '789 Oak St', 'Brampton');

INSERT INTO CUSTOMER (cust_no, cust_name, hno, no_of_days_tostay, cust_address, cust_city)
VALUES (4, 'sophia wilson', 4, 8, '321 Maple Ave', 'Vaughan');

INSERT INTO CUSTOMER (cust_no, cust_name, hno, no_of_days_tostay, cust_address, cust_city)
VALUES (5, 'daniel thomas', 5, 12, '654 Pine Rd', 'Toronto');

INSERT INTO CUSTOMER (cust_no, cust_name, hno, no_of_days_tostay, cust_address, cust_city)
VALUES (6, 'olivia martin', 6, 18, '987 Cedar Ln', 'Markham');

INSERT INTO CUSTOMER (cust_no, cust_name, hno, no_of_days_tostay, cust_address, cust_city)
VALUES (7, 'james anderson', 7, 6, '159 Walnut Blvd', 'Brampton');

INSERT INTO CUSTOMER (cust_no, cust_name, hno, no_of_days_tostay, cust_address, cust_city)
VALUES (8, 'ava wilson', 8, 10, '753 Birch St', 'Vaughan');

--Query 1
--Displaying total number of hotels in Kitchener
SELECT COUNT(*) AS total_hotels
FROM HOTEL
WHERE hcity = 'Kitchener';

--Query 2
SELECT *
FROM CUSTOMER, HOTEL
WHERE CUSTOMER.hno = HOTEL.hno
  AND HOTEL.hcity = 'Toronto'
  AND CUSTOMER.no_of_days_tostay > 5;

--Query 3
ALTER TABLE HOTEL
ADD room_type VARCHAR2(20);

-- Updating the room_type for the existing rows in the HOTEL table
UPDATE HOTEL
SET room_type = 'Standard'
WHERE hno = 1;

UPDATE HOTEL
SET room_type = 'Deluxe'
WHERE hno = 2;

UPDATE HOTEL
SET room_type = 'Economy'
WHERE hno = 3;

UPDATE HOTEL
SET room_type = 'Suite'
WHERE hno = 4;

UPDATE HOTEL
SET room_type = 'Standard'
WHERE hno = 5;

UPDATE HOTEL
SET room_type = 'Deluxe'
WHERE hno = 6;

UPDATE HOTEL
SET room_type = 'Standard'
WHERE hno = 7;

ALTER TABLE CUSTOMER
ADD Price_Perday number;

UPDATE CUSTOMER
SET Price_Perday = 80;

--Query 4
ACCEPT city_name PROMPT 'Enter the city name: '

SELECT hcity AS City, AVG(Price_Perday) AS Average_Price
FROM HOTEL
JOIN CUSTOMER ON HOTEL.hno = CUSTOMER.hno
WHERE hcity = '&city_name'
GROUP BY hcity;

--Query 5
UPDATE CUSTOMER
SET Price_Perday = Price_Perday * 1.1;

SELECT cust_name AS Customer_Name, (Price_Perday * no_of_days_tostay) AS Total_Stay_Price
FROM CUSTOMER;

--Query 6
SELECT * FROM USER_CONSTRAINTS
WHERE TABLE_NAME = 'CUSTOMER';

--Query 7
DROP TABLE CUSTOMER;
ALTER SESSION SET RECYCLEBIN = 'ON';

FLASHBACK TABLE CUSTOMER TO BEFORE DROP;


















SELECT * FROM HOTEL;
SELECT * FROM CUSTOMER;
