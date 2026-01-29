using System.Linq.Expressions;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace MusicApp
{
    public class MusicInternational
    {
        static void Main(string[] args)
        {

            string musicFile = "musicFile.txt";
            string dowloadMusicFile = "dowloadMusicFile.txt";
            List<string> musicList = new List<string>();
            AfroBeats afroSongs = new AfroBeats(string.Empty, string.Empty, long.MinValue, string.Empty, string.Empty);
            List<AfroBeats> addToLList = new List<AfroBeats>
            {
                new AfroBeats (afroSongs.SongName = string.Empty,
                                afroSongs.Artist = string.Empty,
                                afroSongs.Views = 200,
                                afroSongs.Type = string.Empty,
                                afroSongs.Origin = string.Empty)
            };

            int limit = 21;

            // Menue
            bool close = false;
            do
            {
                Console.WriteLine("WELLCOME TO THE M-PLAYER");

                System.Console.WriteLine("1) view my Music List");
                System.Console.WriteLine("2) Home Player");
                System.Console.WriteLine("3) Go to YouTube Music List to view all Music");
                System.Console.WriteLine("0) to Quit");
                string? option = Console.ReadLine();

                if (option == "0")
                {
                    close = true;
                }
                else if (option == "1")
                {

                    // Load file
                    int counter = 0;
                    string lines = "";

                    try
                    {


                        using (StreamReader loadFile = File.OpenText(musicFile))
                        {
                            if (counter > limit)
                            {
                                Console.WriteLine("Error: Out of bound.");
                            }
                            else
                            {

                                Console.WriteLine("");
                                Console.WriteLine("Here is the Play List!");
                                while ((lines = loadFile.ReadLine()) != null)
                                {
                                    Console.WriteLine(counter + " " + lines);
                                    string li = musicList.Count.ToString();
                                    li = lines;
                                    counter++;
                                    //return;
                                }
                                //return; // end of the loop.
                                continue;
                            }

                        }
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine("Errir: File is not found.");
                        //musicSection = true;
                    }

                }
                else if (option == "2")
                {
                    System.Console.WriteLine("HOME PLAYER");
                    bool musicSection = false;
                    do
                    {
                        System.Console.WriteLine("S - to shufle the play list");
                        System.Console.WriteLine("D - delete from the list");
                        System.Console.WriteLine("B - back to Home");
                        System.Console.WriteLine("A - Upload your song to Your Music List");
                        System.Console.WriteLine("U - update music title from Your Music List");
                        string? playList = Console.ReadLine().Trim().ToUpper();

                        if (playList == "S")
                        {
                            string[] lines = File.ReadAllLines(musicFile);
                            if (0 > limit)
                            {
                                Console.WriteLine("Error: Out of bound.");
                            }
                            else
                            {


                                Random rnd = new Random();
                                int index = rnd.Next(lines.Length);
                                System.Console.WriteLine("Shuffling the Play List...");
                                System.Console.WriteLine(" --------------------------------------");
                                System.Console.WriteLine($"| Genre: {lines[index].Substring(80, 20).Trim().PadRight(30)}|");
                                System.Console.WriteLine($"| Artist: {lines[index].Substring(20, 20).Trim().PadRight(29)}|");
                                System.Console.WriteLine($"| Title: {lines[index].Substring(0, 20).Trim().PadRight(30)}|");
                                System.Console.WriteLine($"| Views : {lines[index].Substring(40, 20).Trim().PadRight(29)}|");
                                System.Console.WriteLine($"|               -------                |");
                                System.Console.WriteLine($"|       NEX    |PLAYING|    REW        |");
                                System.Console.WriteLine($"|               -------                |");
                                System.Console.WriteLine(" --------------------------------------");
                            }
                        }


                        else if (playList == "A")
                        {

                            System.Console.WriteLine("Add song name");
                            afroSongs.SongName = Console.ReadLine()?.Trim();

                            while (!Regex.IsMatch(afroSongs.SongName, @"^[a-zA-Z]"))
                            {
                                System.Console.WriteLine("Error: only leters are allowed");
                                afroSongs.SongName = Console.ReadLine()?.Trim();
                            }
                            addToLList.Add(afroSongs);

                            System.Console.WriteLine("Add Artist name");
                            afroSongs.Artist = Console.ReadLine()?.Trim();
                            while (!Regex.IsMatch(afroSongs.Artist, @"^[a-zA-Z]"))
                            {
                                Console.WriteLine("Error: only letters are allowed.");
                                afroSongs.Artist = Console.ReadLine()?.Trim();
                            }
                            addToLList.Add(afroSongs);

                            // System.Console.WriteLine("Add Views");
                            // afroSongs.Views = Console.ReadLine()?.Trim().ToUpper();
                            // while (!Regex.IsMatch(afroSongs.Views, @"^[0-9]"))
                            // {
                            //     Console.WriteLine("Error: only numbers are allowed.");
                            //     afroSongs.Views = Console.ReadLine()?.Trim().ToUpper();
                            // }
                            // addToLList.Add(afroSongs);

                            System.Console.WriteLine("Add Type");
                            afroSongs.Type = Console.ReadLine()?.Trim();
                            while (!Regex.IsMatch(afroSongs.Type, @"^[a-zA-Z]"))
                            {
                                Console.WriteLine("Error: only letters are allowed.");
                                afroSongs.Type = Console.ReadLine()?.Trim();
                            }
                            addToLList.Add(afroSongs);

                            System.Console.WriteLine("Add Origin");
                            afroSongs.Origin = Console.ReadLine()?.Trim();
                            while (!Regex.IsMatch(afroSongs.Origin, @"^[a-zA-Z]"))
                            {
                                Console.WriteLine("Error: only letters are allowed.");
                                afroSongs.Origin = Console.ReadLine()?.Trim();
                            }
                            addToLList.Add(afroSongs);

                            // add to file
                            using (StreamWriter sw = File.AppendText(dowloadMusicFile))
                            {
                                // use padding to allign the text
                                sw.WriteLine(afroSongs.SongName.ToString().PadRight(20) +
                                             afroSongs.Artist.ToString().PadRight(20) +
                                             afroSongs.Views.ToString().PadRight(20) +
                                             afroSongs.Type.ToString().PadRight(20) +
                                             afroSongs.Origin.ToString().PadRight(20));
                            }

                            // B to go back to the menue
                            if (playList == "B")
                            {
                                musicSection = true;
                            }
                        }
                        else if (playList == "D")
                        {
                            System.Console.WriteLine("in the delete section");
                        }
                        else if (playList == "U")
                        {
                            System.Console.WriteLine("in the update section");
                        }
                        else if (playList == "B")
                        {
                            System.Console.WriteLine("in the back section");
                            musicSection = true;
                        }
                        else
                        {
                            System.Console.WriteLine("Error: Wrong choice");
                        }
                    } while (!musicSection);
                }
                else if (option == "3")
                {
                    System.Console.WriteLine("YOUTUBE MUSIC LIST");
                    System.Console.WriteLine("s) Search by song title");
                    System.Console.WriteLine("d) Download Music from YouTube");
                    string? youTubeOption = Console.ReadLine()?.Trim().ToLower();
                    // Load file
                    int counter = 0;
                    string lines = "";

                    try
                    {
                        string[] readText = File.ReadAllLines(dowloadMusicFile);
                        List<string> dowloadMusicList = new List<string>();

                        string content = "";
                        int songFound = 0;

                        if (youTubeOption == "s")
                        {
                            System.Console.WriteLine("Enter song title to search");
                            string? searchTitle = Console.ReadLine()?.Trim();

                            for (int j = 0; j < readText.Length; j++)
                            {
                                if (readText[j].Substring(0, searchTitle.Length).Contains(searchTitle, StringComparison.OrdinalIgnoreCase))
                                {
                                    System.Console.WriteLine(readText[j]);
                                    songFound = 1;
                                    content = readText[j];
                                }
                            }
                        }

                        if (songFound != 0)
                        {
                            System.Console.WriteLine("Press d to dowload the song");
                            string? dowloadOption = Console.ReadLine()?.Trim().ToLower();

                            while (!Regex.IsMatch(dowloadOption, @"^d$"))
                            {
                                System.Console.WriteLine("Error: only 'd' is allowed to dowload the song");
                                dowloadOption = Console.ReadLine()?.Trim().ToLower();
                            }

                            using (StreamWriter sw = File.AppendText(musicFile))
                            {

                                sw.WriteLine(content);
                                System.Console.WriteLine("Song dowloaded to your Music List");
                                content = "";
                            }
                        }
                        else if (content == "")
                        {
                            System.Console.WriteLine("Error: Song not found in YouTube Music List");
                        }
                    }
                    catch (Exception e)
                    {
                        System.Console.WriteLine("Error: " + e.Message);
                    }
                }
                else
                {
                    System.Console.WriteLine("Error: Invalid Menue option");
                }
            } while (!close);
        }
    }
}