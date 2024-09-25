﻿Use master
Go
IF EXISTS (SELECT * FROM sys.databases WHERE name = N'Game_DB')
BEGIN
    DROP DATABASE Game_DB;
END
Go
Create Database Game_DB
Go
Use Game_DB
Go

-- יצירת טבלת סוגי משתמש
Create Table UserType (
TypeID Int Primary Key Identity, -- מספר סידורי 
TypeName nvarchar(20) -- שם הסוג
-- סוגי משתמש
-- שחקן 1
-- מנהל 2
);


-- יצירת טבלת משתמשים
Create Table Users (
Username nvarchar(16) Primary key, -- שם משתמש
Email nvarchar(60) unique, -- אימייל
Password nvarchar(16), -- סיסמה
FirstName nvarchar(30), -- שם פרטי
LastName nvarchar(30), -- שם משפחה
Score int, -- ניקוד
GamesPlayed int, -- מספר משחקים ששוחקו
Foreign Key (TypeID) References UserType(TypeID) -- סוג משתמש
);

-- יצירת טבלת משחקים
Create Table Games (
GameID int Primary Key Identity, -- מספר סידורי 
ActionsAmount int, -- כמות הפעולות ששוחקו במשחק
TurnsAmount int, -- כמות תורות במשחק
Date date, -- התאריך של המשחק
PointsGained int, -- כמות נקודות שהושגו מהמשחק
PointsLost int, -- כמות נקודות שאבדו מהמשחק
Foreign Key (Winner) References Users(Username), -- המנצח של המשחק
Foreign Key (Loser) References Users(Username) -- המפסיד של המשחק
);

--יצירת טבלת קלפים
Create Table Cards (
CardID int Primary Key Identity, -- מספר סידורי 
CardImage VarBinary(Max), -- תמונה של הקלף
Description nvarchar(300), -- תיאור הקלף
Rules nvarchar(300), -- חוקי קלף
)

-- צור הירשמות ללא גלוטן
CREATE LOGIN [TaskAdminLogin] WITH PASSWORD = 'DBGalPass';
Go

-- צור משתמש בדאטאבייס להירשמות
CREATE USER [TaskAdminUser] FOR LOGIN [TaskAdminLogin];
Go

-- Add the user to the db_owner role to grant admin privileges
-- הוסף את המשתמש לדאטאבייס לתפקיד מנהל על מנת להעניק גישות מנהל
ALTER ROLE db_owner ADD MEMBER [TaskAdminUser];
Go


insert into UserType values ('Player')
insert into UserType values ('Manager')

insert into Users values ('Lettuce4ever', 'galkluger@gmail.com', 'Gal031206', 'Gal', 'Klug', -1, -1, 2)
insert into Users values ('TAMUDA123', 'FreimanTami@gmail.com', 'Tami238', 'Tami', 'Freiman', 0, 1, 1)
insert into Users values ('Shalgon', 'shshalgi@gmail.com', 'shahar4532', 'Shahar', 'Shalgi', 10, 1, 1)

insert into Games values (20, 8, '09-25-2024', 10, 5, 'Shalgon', 'TAMUDA123')



