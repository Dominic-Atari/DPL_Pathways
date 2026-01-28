using System;
using System.ComponentModel.DataAnnotations;
namespace Stage_1.Week_4.InterfaceExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // Computer users who joined the meeting
            // Using parameterless constructor.
            Computer computers = new Computer();
            List<Computer> computersList = new List<Computer>();
            computersList.Add(new Computer("Jim", "Mac", "Lincoln", ""));
            System.Console.WriteLine("\nMetting ID: " + computers.DevaultMessage());

            // using to string to print values
            foreach (Computer list in computersList)
            {
                System.Console.WriteLine(list);
            }

            // Computer users who did not joined the meeting.
            // using parameter constructore
            Computer computer = new Computer(string.Empty, string.Empty, string.Empty, string.Empty);
            List<Computer> listUbsentComputers = new List<Computer>
            {
                new Computer( computer.UserName = "Val",
                                computer.DeviceType = "Windows",
                                computer.Location = "Omaha",
                                computer.Time)
            };
            // not using to string to print user who did not join the meeting.
            System.Console.WriteLine($"First name: {computer.UserName}\nDevice type: {computer.DeviceType}\nLocation: {computer.Location}\nJoined At: {computer.Joined()}");

            // Phome users
            Phone phone = new Phone(string.Empty, string.Empty, string.Empty, string.Empty);
            List<Phone> phoneLiata = new List<Phone>
            {
                new Phone(phone.UserName = "Cooper",
                            phone.DeviceType = "Iphone",
                            phone.Location = "Lincoln",
                            phone.Time)
            };

            foreach (Phone list in phoneLiata)
            {
                System.Console.WriteLine(list);
            }
        }
    }
}