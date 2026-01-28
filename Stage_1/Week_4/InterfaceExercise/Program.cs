using System;
using System.ComponentModel.DataAnnotations;
namespace Stage_1.Week_4.InterfaceExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            // Computer users who joined the meeting
            Computer computer = new Computer(string.Empty, string.Empty, string.Empty, string.Empty);
            List<Computer> listComputers = new List<Computer>
            {

                new Computer( computer.UserName = "Jim",
                                computer.DeviceType = "Mac",
                                computer.Location = "Lincoln",
                                computer.Time),
            };
            System.Console.WriteLine("\nMetting ID: " + computer.DevaultMessage());

            foreach (Computer list in listComputers)
            {
                System.Console.WriteLine(list);
            }

            // Computer users who did not joined the meeting.
            List<Computer> listUbsentComputers = new List<Computer>
            {
                new Computer( computer.UserName = "Val",
                                computer.DeviceType = "Windows",
                                computer.Location = "Omaha",
                                computer.Time)
            };
            // not using to string to print user who did not join the meeting.
            System.Console.WriteLine($"\nFirst name: {computer.UserName}\nDevice type: {computer.DeviceType}\nLocation: {computer.Location}");
            System.Console.WriteLine("Has Joined: " + computer.Joined());

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