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
VALUES (3, 'The Starting Line', 'US', '4', 'www.thestartingline.com', 'Punk/Emo', 'False', 'Ken Vasoli');


//Adding Albums

INSERT INTO "Album" ("Id", "Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES (1, 'August and Everything After', 'False', '1993', 1);

INSERT INTO "Album" ("Id", "Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES (2, 'Yourself or Someone Like You', 'False', '1996', 2);

INSERT INTO "Album" ("Id", "Title", "IsExplicit", "ReleaseDate", "BandId")
VALUES (3, 'Say It Like You Mean It', 'False', '2002', 3);


//Adding Songs
INSERT INTO "Song" ("Id", "TrackNumber", "Title", "Duration", "AlbumId")
VALUES (1, "2" "Omaha", "3:39", 1);

INSERT INTO "Song" ("Id", "TrackNumber", "Title", "Duration", "AlbumId")
VALUES (2, "3", "Mr. Jones", "4:33", 1 );

INSERT INTO "Song" ("Id", "TrackNumber", "Title", "Duration", "AlbumId")
VALUES (3, "5", "Anna Begins", "4:31", 1);


INSERT INTO "Song" ("Id", "TrackNumber", "Title", "Duration", "AlbumId")
VALUES (4, "3", "3 am", "3:47", 2);

INSERT INTO "Song" ("Id", "TrackNumber", "Title", "Duration", "AlbumId")
VALUES (5, "4", "Push", "3:59", 2);

INSERT INTO "Song" ("Id", "TrackNumber", "Title", "Duration", "AlbumId")
VALUES (6, "12", "Hang", "3:47", 2);

INSERT INTO "Song" ("Id", "TrackNumber", "Title", "Duration", "AlbumId")
VALUES (7, "4", "The Best of Me", "4:18", 3);

INSERT INTO "Song" ("Id", "TrackNumber", "Title", "Duration", "AlbumId")
VALUES (8, "5", "A Goodnight's Sleep", "4:23", 3);

INSERT INTO "Song" ("Id", "TrackNumber", "Title", "Duration", "AlbumId")
VALUES (9, "9", "Decisions, Decisions", "3:51", 3);

