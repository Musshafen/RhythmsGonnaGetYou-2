﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace RhythmsGonnaGetYou
{

    class RhythmsGonnaGetYouContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }
         public DbSet<Album> Albums { get; set; }
         public DbSet<Song> Songs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
            // optionsBuilder.UseLoggerFactory(loggerFactory);

            optionsBuilder.UseNpgsql("server=localhost;database=RhythmsGonnaGetYou");
        }
    }

     class MenuOptions
    {
        public void AddAlbum(string albumTitle, int bandId, string isExplicit)
        {
            var context = new RhythmsGonnaGetYouContext();
            var album = new Album
            {
                Title = albumTitle,
                ReleaseDate = DateTime.Now,
                BandId = bandId,
                IsExplicit = isExplicit
            };
            context.Albums.Add(album);
            context.SaveChanges();
        }

        public void AddSong(int trackNumber, string songTitle, decimal duration, int albumId)
        {
            var context = new RhythmsGonnaGetYouContext();
            var song = new Song
            {
                TrackNumber = trackNumber,
                Title = songTitle,
                Duration = duration,
                AlbumId = albumId

            };
            context.Songs.Add(song);
            context.SaveChanges();
        }
    }
    class Band
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryOfOrigin { get; set; }
        public int NumberOfMembers { get; set; }
        public string Website { get; set; }
        public string Style { get; set; }
        public string IsSigned { get; set; }
        public string ContactName { get; set; }
        public string ContactPhoneNumber { get; set; }
        public List<Album> Albums { get; set; }

    }


    class Program
    {

        static void Main(string[] args)
        {




            Console.WriteLine("Welcome");





        }
    }
}
