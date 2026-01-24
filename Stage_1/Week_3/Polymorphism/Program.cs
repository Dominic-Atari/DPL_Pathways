using System;

namespace MusicApp
{
    public class MusicInternational
    {
        static void Main(string[] args)
        {
            // Creating instances of AfroBeats and CountryMusic
            MusicBase[] afro = new AfroBeats[3];
            afro[0] = new AfroBeats("Twerk", "Wiskid", "3.7M", "Afro Music", "West Africa");
            afro[1] = new AfroBeats("Tshwala Bam", "Burna Boy", "12.4M", "Afro Music", "West Africa");
            afro[2] = new AfroBeats("Dumebi", "Rema", "9.2M", "Afro Music", "West Africa");

            // Creating instances of CountryMusic
            MusicBase[] country = new CountryMusic[3];
            country[0] = new CountryMusic("Country Roads", "John Denver", "5.6M", "Country Music", "USA");
            country[1] = new CountryMusic("Jolene", "Dolly Parton", "8.3M", "Country Music", "USA");
            country[2] = new CountryMusic("Take Me Home, Country Roads", "John Denver", "7.1M", "Country Music", "USA");

            // Displaying details and descriptions
            foreach (var afroSongs in afro)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine(afroSongs);
                Console.WriteLine(afroSongs.Description());
            }
            // Displaying details and descriptions
            foreach (var countrySongs in country)
            {
                Console.WriteLine("=====================================");
                Console.WriteLine(countrySongs);
                Console.WriteLine(countrySongs.Description());
            }
        }
    }
}