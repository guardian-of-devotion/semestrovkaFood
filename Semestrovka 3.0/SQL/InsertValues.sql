use TestDb

SELECT * FROM Users

INSERT INTO Users (user_id, password, email, name, surname)
VALUES (NEWID(), 'qwerty', 'guardian-of-devotion@yandex.ru', 'Sarkis', 'Katvalyan')