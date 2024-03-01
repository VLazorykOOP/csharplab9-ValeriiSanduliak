using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_10CharpT
{
    public class MusicCatalog
    {
        private Hashtable catalog = new Hashtable();

        public void AddDisk(string diskTitle)
        {
            if (!catalog.ContainsKey(diskTitle))
            {
                catalog[diskTitle] = new ArrayList();
                Console.WriteLine($"Disk '{diskTitle}' added to the catalog.");
            }
            else
            {
                Console.WriteLine($"Disk '{diskTitle}' already exists in the catalog.");
            }
        }

        public void RemoveDisk(string diskTitle)
        {
            if (catalog.ContainsKey(diskTitle))
            {
                catalog.Remove(diskTitle);
                Console.WriteLine($"Disk '{diskTitle}' removed from the catalog.");
            }
            else
            {
                Console.WriteLine($"Disk '{diskTitle}' not found in the catalog.");
            }
        }

        public void AddSong(string diskTitle, string artist, string songTitle)
        {
            if (catalog.ContainsKey(diskTitle))
            {
                ArrayList songs = (ArrayList)catalog[diskTitle];
                songs.Add($"{artist} - {songTitle}");
                Console.WriteLine($"Song '{songTitle}' by {artist} added to disk '{diskTitle}'.");
            }
            else
            {
                Console.WriteLine($"Disk '{diskTitle}' not found in the catalog.");
            }
        }

        public void RemoveSong(string diskTitle, string artist, string songTitle)
        {
            if (catalog.ContainsKey(diskTitle))
            {
                ArrayList songs = (ArrayList)catalog[diskTitle];
                string songToRemove = $"{artist} - {songTitle}";

                if (songs.Contains(songToRemove))
                {
                    songs.Remove(songToRemove);
                    Console.WriteLine(
                        $"Song '{songTitle}' by {artist} removed from disk '{diskTitle}'."
                    );
                }
                else
                {
                    Console.WriteLine(
                        $"Song '{songTitle}' by {artist} not found in disk '{diskTitle}'."
                    );
                }
            }
            else
            {
                Console.WriteLine($"Disk '{diskTitle}' not found in the catalog.");
            }
        }

        public void ShowCatalog()
        {
            Console.WriteLine("Music Catalog:");
            foreach (DictionaryEntry entry in catalog)
            {
                string diskTitle = (string)entry.Key;
                ArrayList songs = (ArrayList)entry.Value;

                Console.WriteLine($"Disk: {diskTitle}");
                Console.WriteLine("Songs:");
                foreach (string song in songs)
                {
                    Console.WriteLine($"  {song}");
                }
                Console.WriteLine();
            }
        }

        public void SearchByArtist(string artist)
        {
            Console.WriteLine($"Search results for artist '{artist}':");
            foreach (DictionaryEntry entry in catalog)
            {
                ArrayList songs = (ArrayList)entry.Value;

                foreach (string song in songs)
                {
                    if (song.Contains(artist))
                    {
                        Console.WriteLine($"Disk: {entry.Key}, Song: {song}");
                    }
                }
            }
        }
    }

    public class Task4
    {
        public static void Task4_()
        {
            MusicCatalog catalog = new MusicCatalog();

            // Add disks to the catalog
            Console.WriteLine("\n\nAdding disks to the catalog");
            catalog.AddDisk("Pop Hits");
            catalog.AddDisk("Rock Classics");

            // Add songs to the disks
            Console.WriteLine("\n\nAdding songs to disk");
            catalog.AddSong("Pop Hits", "Artist1", "Song1");
            catalog.AddSong("Pop Hits", "Artist2", "Song2");

            catalog.AddSong("Rock Classics", "Artist3", "Song3");
            catalog.AddSong("Rock Classics", "Artist1", "Song4");

            // Show the catalog
            Console.WriteLine("\n\nShowing the catalog");
            Console.WriteLine();
            catalog.ShowCatalog();

            // Search for songs by artist
            catalog.SearchByArtist("Artist1");

            Console.WriteLine("\n\nRemoving songs and disks");
            catalog.RemoveSong("Pop Hits", "Artist2", "Song2");
            catalog.RemoveDisk("Nonexistent Disk");

            Console.WriteLine("\n\nShowing the catalog after removing");
            catalog.ShowCatalog();
        }
    }
}
