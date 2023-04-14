namespace RhythmsGonnaGetYou


createdb RhythmsGonnaGetYouDb

pgcli RhythmsGonnaGetYouDb

//Creating Tables

CREATE TABLE "Band" (
"Id"                   SERIAL PRIMARY KEY,
"Name"                 TEXT NOT NULL,
"CountryOfOrigin"      TEXT,
"NumberOfMembers"      INT,
"Website"              TEXT,
"Genre"                TEXT,
"IsSigned"             BOOLEAN,
"ContactName"          TEXT

);

CREATE TABLE "Album" (
"Id"           SERIAL PRIMARY KEY,
"Title"        TEXT,
"IsExplicit"   BOOLEAN,
"ReleaseDate"  TEXT,
"BandId" INT NULL REFERENCES "Band" ("Id")
);


CREATE TABLE "Song" (
"Id "          SERIAL PRIMARY KEY,
"TrackNumber"  INT,
"Title"        TEXT NOT NULL, 
"Duration"     TEXT,
"AlbumId"     INT NULL REFERENCES "Album" ("Id")
);

//Adding Bands

INSERT INTO "Band" ("Id", "Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES (1, 'Counting Crows', 'US', '7', 'www.countingcrows.com', 'Alt Rock', 'True', 'Adam Duritz');

INSERT INTO "Band" ("Id", "Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES (2, 'Matchbox 20', 'US', '4', 'www.mb20.com', 'Alt Rock', 'True', 'Rob Thomas');

INSERT INTO "Band" ("Id", "Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES (3, 'The Starting Line', 'US', '4', 'www.thestartingline.com', 'Punk/Emo', 'No', 'Ken Vasoli');


//Adding Albums

INSERT INTO "Album" ("Id", "Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES (1, 'August and Everything After', 'False', '1993', 1);

INSERT INTO "Album" ("Id", "Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES (2, 'Yourself or Someone Like You', 'False', '1996', 2);

INSERT INTO "Album" ("Id", "Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES (3, 'Say It Like You Mean It', 'False', '2002', 3);

