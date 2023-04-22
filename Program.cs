using System;
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
    class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string IsExplicit { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Song> Songs { get; set; }
        // public List<Band> Bands { get; set; }
        public int BandId { get; set; }
        public Band Band { get; set; }
    }
    class Song
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public decimal Duration { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
    }


    class Program
    {

        static void Main(string[] args)
        {
            static string PromptForString(string prompt)
            {
                Console.Write(prompt);
                var userInput = Console.ReadLine();
                return userInput;
            }
            static int PromptForInteger(string prompt)
            {
                Console.Write(prompt);
                int userInput;
                var intUserInput = Int32.TryParse(Console.ReadLine(), out userInput);
                if (intUserInput)
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Invalid");
                    return 0;
                }
            }
            var menuOptions = new MenuOptions();
            var context = new RhythmsGonnaGetYouContext();
            var bandCollection = context.Albums.Include(album => album.Songs).Include(album => album.Band);

            var isRunning = true;
            while (isRunning)
            {
                Console.WriteLine();
                Console.WriteLine("Welcome to our Record Label");
                Console.WriteLine();
                Console.WriteLine("What would you like to do?");
                Console.Write("(AB): Add Band (AA): Add Album (VB): View Bands (VA): View Albums (VBA): View Band Albums (SB): Un/Sign a Band (VSB): View Signed Bands (NSB): View Not Signed Bands (Q): Quit ");




            }
        }
    }
}

