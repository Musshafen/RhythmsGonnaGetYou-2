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
        public string Genre { get; set; }
        public string IsSigned { get; set; }
        public string ContactName { get; set; }
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
                Console.Write("(AB): Add Band\n(AA): Add Album\n(VB): View Bands\n(VA): View Albums\n(VBA): View Band Albums\n(SB): Un/Sign a Band\n(VSB): View Signed Bands\n(NSB): View Not Signed Bands\n(Q): Quit ");
                Console.WriteLine();

                var choice = Console.ReadLine().ToUpper();
                if (choice == "AB")
                {
                    var newAlbum = new Album();
                    var band = new Band();

                    // Add Band
                    Console.WriteLine("Adding a Band");
                    band.Name = PromptForString("Band name: ");
                    band.CountryOfOrigin = PromptForString("From: ");
                    band.NumberOfMembers = PromptForInteger("How many members: ");
                    band.Website = PromptForString("Website: ");
                    band.Genre = PromptForString("Music Genre: ");
                    band.IsSigned = PromptForString("Signed: ");
                    band.ContactName = PromptForString("Contact Name: ");
                    context.Bands.Add(band);
                    context.SaveChanges();

                }
                else if (choice == "AA")
                {
                    var viewBands = context.Bands.OrderBy(b => b.Name);
                    Console.WriteLine("Which Band #: ");

                    foreach (var band in viewBands)
                    {
                        Console.WriteLine($"{band.Name} - {band.Id}");
                    }
                    var bandById = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Adding an Album to {bandById}");
                    var albumToAdd = context.Bands.First(alb => alb.Id == bandById);
                    var newAlbumTitle = PromptForString("Album Title: ");
                    var newAlbumIsExplicit = PromptForString("Is it Explicit?: ");
                    menuOptions.AddAlbum(newAlbumTitle, bandById, newAlbumIsExplicit);
                    context.SaveChanges();
                }
                else if (choice == "AS")
                {
                    var viewAlbums = context.Albums.OrderBy(a => a.Title);
                    Console.WriteLine("Which Album #: ");
                    foreach (var album in viewAlbums)
                    {
                        Console.WriteLine($"{album.Title} - {album.Id}");
                    }
                    var albumById = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Adding songs to {albumById}");
                    var songToAdd = context.Albums.First(alb => alb.Id == albumById);
                    var newTrackNumber = PromptForInteger("What's the track number?: ");
                    var newSongTitle = PromptForString("Song Title: ");
                    var newDuration = PromptForInteger("How long is it?: ");
                    menuOptions.AddSong(newTrackNumber, newSongTitle, newDuration, albumById);
                    context.SaveChanges();
                }

                else if (choice == "VB")
                {
                    var viewBands = context.Bands.OrderBy(b => b.Name);
                    Console.WriteLine("View All Bands");

                    foreach (var band in viewBands)
                    {
                        Console.WriteLine($"{band.Name} - {band.Id} -{band.IsSigned}");
                    }
                }

                else if (choice == "VSB")
                {
                    var viewBands = context.Bands.OrderBy(b => b.Name);
                    var signedBands = context.Bands.Where(sb => sb.IsSigned == "yes");
                    Console.WriteLine("View Signed Bands");
                    foreach (var band in signedBands)
                    {
                        Console.WriteLine($"{band.Name} - {band.Id} -{band.IsSigned}");
                    }
                }
                else if (choice == "NSB")
                {
                    var viewBands = context.Bands.OrderBy(b => b.Name);
                    var notSignedBands = context.Bands.Where(sb => sb.IsSigned != "yes");
                    Console.WriteLine("View Signed Bands");
                    foreach (var band in notSignedBands)
                    {
                        Console.WriteLine($"{band.Name} - {band.Id} -{band.IsSigned}");
                    }
                }
                else if (choice == "VA")
                {
                    var viewAlbums = context.Albums.OrderBy(alb => alb.ReleaseDate);
                    Console.WriteLine("View all Albums by Release Date");

                    foreach (var album in viewAlbums)
                    {
                        Console.WriteLine($"{album.Title} - {album.ReleaseDate}");
                    }
                }
                else if (choice == "VBA")
                {
                    var viewBands = context.Bands.OrderBy(b => b.Name);
                    Console.WriteLine("Which Band #: ");

                    foreach (var band in viewBands)
                    {
                        Console.WriteLine($"{band.Name} - {band.Id}");
                    }
                    var bandById = int.Parse(Console.ReadLine());
                    var albums = context.Albums.Where(alb => bandById == alb.BandId);
                    foreach (var album in albums)
                    {
                        Console.WriteLine($"{album.Title}");
                    }
                }
                else if (choice == "SB")
                {
                    var bands = context.Bands.OrderBy(b => b.Name);
                    foreach (var band in bands)
                    {
                        Console.WriteLine($"{band.Id} - {band.Name}");
                    }
                    var bandById = int.Parse(Console.ReadLine());
                    var signBand = context.Bands.First(s => s.Id == bandById);
                    var isSigned = "";
                    if (isSigned == "yes")
                    {
                        signBand.IsSigned = "no";
                    }
                    else
                    {
                        signBand.IsSigned = "yes";
                    }
                    context.SaveChanges();
                }
                else
                {
                    isRunning = false;
                }

            }
        }
    }
}

