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
Foreign Key (TypeId) References UserType(TypeID) -- סוג משתמש
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
)