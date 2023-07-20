using System;
using System.Collections.Generic;
using System.IO;

namespace tasks_sem
{

   
    public class CandidateManagement
    {

       

        private List<Candidate> data = new List<Candidate>();

       

        public  void start()
        {

            LoadDataFromFile();
            bool ok = true;

            while (ok)
            {
                Console.WriteLine("\nHangi sayi:\n1)Create\n2)Delete\n3)Update\n4)Read All Candidates\n5)Read Specific Candidate\n6)Close the app");
                


                switch (Console.ReadLine())
                {
                    //1)CREATE
                    case "1":

                        Create();

                        break;
                    //2)DELETE
                    case "2":
                        Delete();
                        break;

                    //3)UPDATE 
                    case "3":

                        Update();
                        break; ;


                    //4)READ ALL CANDIDATES
                    case "4":

                        ReadAllCandidates();
                        break;


                    //5)READ
                    
                    case "5":

                        Read();
                        break;


                    //6)CLOSE THE APP
                    case "6":

                        SaveCandidatesToFile(data);
                        ok = false;
                        break;

                    default:
                        Console.WriteLine("Choose between 1-6");
                        break;



                }
            }

        }

        private  void Create()

        {
            Candidate candidate = new Candidate();
            Console.WriteLine("\nCREATE\n---------------\nUsername:");
            candidate.username = Console.ReadLine();
            Console.WriteLine("\nEmail:");

            candidate.email = Console.ReadLine();
            Console.WriteLine("\nPhone:");
            candidate.phone = Console.ReadLine();
            data.Add(candidate);


            SaveCandidatesToFile(data);
        }

        public  void Delete()
        {
            Candidate candidate = new Candidate();
            Console.WriteLine("DELETE\n---------------\nWhat is the name of the username you want to delete?");
            string usernametodelete = Console.ReadLine();


            candidate = data.Find(candidate => candidate.username == usernametodelete);
            if (candidate != null)
            {
                data.Remove(candidate);
                Console.WriteLine($"Candidate with username '{usernametodelete}' deleted successfully.");
            }
            else
            {
                Console.WriteLine($"Candidate with username '{usernametodelete}' not found.");
            }
            SaveCandidatesToFile(data);


        }

        public  void Update()
        {
            Candidate candidate = new Candidate();
            Console.WriteLine("\nUPDATE\n---------------\nUsername to update:\n");
            string usernametoupdate = Console.ReadLine();

            candidate = data.Find(candidate => candidate.username == usernametoupdate);
            if (candidate != null)
            {
                Console.WriteLine("\nWhich information you want to update:\n\n1)Username\n2)Email\n3)Phone\n");
                

                switch (Console.ReadLine())
                {

                    case "1":

                        Console.WriteLine("\nNew name:\n");
                        string new_username = Console.ReadLine();

                        candidate.username = new_username;
                        break;

                    case "2":
                        Console.WriteLine("\nNew email:\n");
                        string new_email = Console.ReadLine();

                        candidate.email = new_email;
                        break;

                    case "3":
                        Console.WriteLine("\nNew phone:\n");
                        string new_phone = Console.ReadLine();

                        candidate.phone = new_phone;

                        break;
                }

                Console.WriteLine($"Candidate with username '{usernametoupdate}' updated successfully.");
            }
            else
            {
                Console.WriteLine($"Candidate with username '{usernametoupdate}' not found.");
            }
            SaveCandidatesToFile(data);

        }

        public void Read()
        {

            
            Console.WriteLine("Which candidate you want to read:\nUsername:");
            string usernametoread =Console.ReadLine();
            bool found=false;
            foreach (Candidate item in data)
            {


                if (item.username == usernametoread)
                {
                    Console.WriteLine("-----------------\n"+item.username);
                    Console.WriteLine(item.email);
                    Console.WriteLine(item.phone);
                    found = true;  
                }
            }

            if(!found) 
                {
                    Console.WriteLine($"Candidate with username '{usernametoread}' not found.");
                }
                    
        }
        public  void ReadAllCandidates()
        {
            Console.WriteLine("\nAll Candidates:\n---------------");
            foreach (Candidate item in data)
            {
                
                Console.WriteLine(item.username);
                Console.WriteLine(item.email);
                Console.WriteLine(item.phone);
                Console.WriteLine();
            }

        }


        private  void SaveCandidatesToFile(List<Candidate> candidates)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\ASUS\\OneDrive - GALATASARAY UNIVERSITESI\\Masaüstü\\tasks_sem\\candidates.txt"))
            {
                foreach (var candidate in candidates)
                {
                    writer.WriteLine($"{candidate.username},{candidate.email},{candidate.phone}");
                }
            }

            Console.WriteLine("Candidates saved to the file.");
        }
       private void LoadDataFromFile()
{
    try
    {
        using (StreamReader reader = new StreamReader("C:\\Users\\ASUS\\OneDrive - GALATASARAY UNIVERSITESI\\Masaüstü\\tasks_sem\\candidates.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 3)
                {
                    Candidate candidate = new Candidate
                    {
                        username = parts[0],
                        email = parts[1],
                        phone = parts[2],
                    };
                    data.Add(candidate);
                }
            }
        }
    }
    catch (FileNotFoundException)
    {
        // The file was not found, which is normal if it's the first run or the file is empty.
        // You can handle this case as needed.
    }
}



    }
} 





    
