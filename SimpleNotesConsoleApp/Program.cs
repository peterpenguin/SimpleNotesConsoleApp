using System;
using System.IO;
using System.Text;

namespace SimpleNotesConsoleApp
{
    class Program
    {
        static void Main()
        {
            //user instructions
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            UserInst();
            
            //defining
            bool repeat = true;
            string path = @"data\notes.txt";
            string paragr = "\n";
            string tab = "\t";

            //responding to input
            while (repeat == true)
            {
                string input = Convert.ToString(Console.ReadLine());
                switch (input)
                {
                    case "Notes":
                        if (File.Exists(path) == true)  //checking if notes exist
                        {
                            //notes output
                            Console.WriteLine(File.ReadAllText(path, Encoding.Default));
                        }
                        else
                        {
                            Console.WriteLine("No notes available.");
                        }
                        break;

                    case "Delete":
                        //deleting notes file
                        File.Delete(path);
                        Console.WriteLine("Your notes got deleted.");
                        break;

                    case "Close":
                        //escaping while loop - application closes
                        repeat = false;
                        break;

                    case "Help":
                        //giving user instructions from beginning
                        UserInst();
                        break;

                    default:
                        //adding notes to .txt file
                        string date = Convert.ToString(DateTime.Now);
                        File.AppendAllText(path, paragr);
                        File.AppendAllText(path, date);
                        File.AppendAllText(path, tab);
                        File.AppendAllText(path, input);
                        break;
                }
            }

        }
        static void UserInst()
        {
            Console.WriteLine("This is a simple persistent notes application - created by peterpenguin");
            Console.WriteLine("\nType any text and press enter to create a new note.");
            Console.WriteLine("You can check your notes by typing >Notes<.");
            Console.WriteLine("In order to delete all notes type in >Delete<.");
            Console.WriteLine("To get this instructions again type in >Help<.");
            Console.WriteLine("To close the application type in >Close<.\n");
        }
    }
}
