DELETE  FROM Customer;

INSERT INTO Customer (CustomerID, firstname, lastname, title, age, notes)
VALUES (1, 'Hannah', 'Müller', 'Dr.', 35, 'Kindersitz für 4-jährige');

INSERT INTO Customer (CustomerID, firstname, lastname, title, age, notes)
VALUES (2, 'Otto', 'Bauer', 'Dipl. Ing.', 53,'kein Duftbaum');

INSERT INTO Customer(CustomerID, firstname, lastname, title, age)
VALUES (3, 'Alexander', 'Huber', 'Herr', 18);

SELECT*FROM Customer;
