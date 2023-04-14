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
"Style"                TEXT,
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
