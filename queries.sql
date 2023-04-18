namespace RhythmsGonnaGetYou


createdb RhythmsGonnaGetYouDb

pgcli RhythmsGonnaGetYouDb

//Creating Tables

CREATE TABLE "Bands" (
"Id"                   SERIAL PRIMARY KEY,
"Name"                 TEXT NOT NULL,
"CountryOfOrigin"      TEXT,
"NumberOfMembers"      INT,
"Website"              TEXT,
"Genre"                TEXT,
"IsSigned"             BOOLEAN,
"ContactName"          TEXT

);

CREATE TABLE "Albums" (
"Id"           SERIAL PRIMARY KEY,
"Title"        TEXT,
"IsExplicit"   BOOLEAN,
"ReleaseDate"  TEXT,
"BandsId" INT NULL REFERENCES "Bands" ("Id")
);


CREATE TABLE "Songs" (
"Id "          SERIAL PRIMARY KEY,
"TrackNumber"  INT,
"Title"        TEXT NOT NULL, 
"Duration"     TEXT,
"AlbumsId"     INT NULL REFERENCES "Albums" ("Id")
);

//Adding Bands

INSERT INTO "Bands" ("Id", "Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES (1, 'Counting Crows', 'US', '7', 'www.countingcrows.com', 'Alt Rock', 'True', 'Adam Duritz');

INSERT INTO "Bands" ("Id", "Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES (2, 'Matchbox 20', 'US', '4', 'www.mb20.com', 'Alt Rock', 'True', 'Rob Thomas');

INSERT INTO "Bands" ("Id", "Name", "CountryOfOrigin", "NumberOfMembers", "Website", "Genre", "IsSigned", "ContactName")
VALUES (3, 'The Starting Line', 'US', '4', 'www.thestartingline.com', 'Punk/Emo', 'False', 'Ken Vasoli');


//Adding Albums

INSERT INTO "Albums" ("Id", "Title", "IsExplicit", "ReleaseDate", "BandsId")
VALUES (1, 'August and Everything After', 'False', '1993', 1);

INSERT INTO "Albums" ("Id", "Title", "IsExplicit", "ReleaseDate", "BandsId")
VALUES (2, 'Yourself or Someone Like You', 'False', '1996', 2);

INSERT INTO "Albums" ("Id", "Title", "IsExplicit", "ReleaseDate", "BandsId")
VALUES (3, 'Say It Like You Mean It', 'False', '2002', 3);


//Adding Songs

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumsId")
VALUES ('2', 'Omaha', '3:39', 1);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumsId")
VALUES ('3', 'Mr. Jones', '4:33', 1 );

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumsId")
VALUES ('5', 'Anna Begin', '4:31', 1);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumsId")
VALUES ('3', '3 am', '3:47', 2);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumsId")
VALUES ('4', 'Push', '3:59', 2);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumsId")
VALUES ('12', 'Hang', '3:47', 2);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumsId")
VALUES ('4', 'The Best of Me', '4:18', 3);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumsId")
VALUES ('5', 'A Goodnights Sleep', '4:23', 3);

INSERT INTO "Songs" ("TrackNumber", "Title", "Duration", "AlbumsId")
VALUES ('9', 'Decisions, Decisions', '3:51', 3);

//View all Bands
SELECT * FROM "Bands";

//Let band go
UPDATE "Bands" SET "IsSigned" = false WHERE "Id" = 1;

//Resign a band
UPDATE "Bands" SET "IsSigned" = true WHERE "Id" = 1;

//Given a band name, view all Albums
SELECT * FROM "Albums" WHERE "BandsId" = 1;

*******//View all albums and associated songs ordered by ReleaseDate
SELECT * FROM "Albums" INNER JOIN "Songs" ORDER BY "ReleaseDate";

//View all bands that are IsSigned
SELECT * FROM "Bands" WHERE "IsSigned" = true;

//VIew all bands that are not IsSigned
SELECT * FROM "Bands" WHERE "IsSigned" = false;
