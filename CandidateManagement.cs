using System;
using System.Collections.Generic;
using System.IO;

namespace tasks_sem
{

    public class Candidate
    {
        public int id { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
    }
    public class CandidateManagement
    {
        private List<Candidate> data = new List<Candidate>();
        public  void start()
        {
            bool ok = true;

            while (ok)
            {
                Console.WriteLine("\nHangi sayi:\n1)Create\n2)Delete\n3)Update\n4)Read All Candidates\n5)Read Specific Candidate\n6)Close the app");
                string key = Console.ReadLine();


                switch (key)
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
                    /*
                    case "5":

                        ReadAllCandidates();
                        break;*/


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

        public  void Create()

        {

            Console.WriteLine("\nCREATE\nUsername:");
            candidate.username = Console.ReadLine();
            Console.WriteLine("\nEmail:");

            candidate.email = Console.ReadLine();
            Console.WriteLine("\nPhone:");
            candidate.phone = Console.ReadLine();
            data.Add(candidate);


            SaveCandidatesToFile(data);
        }

        public static void Delete()
        {

            Console.WriteLine("DELETE\nWhat is the name of the username you want to delete?");
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
            Console.WriteLine("\nUPDATE\nUsername to update:\n");
            string usernametoupdate = Console.ReadLine();

            candidate = data.Find(candidate => candidate.username == usernametoupdate);
            if (candidate != null)
            {
                Console.WriteLine("\nWhich information you want to update:\n\n1)Username\n2)Email\n3)Phone\n");
                string keyUpdate = Console.ReadLine();

                switch (keyUpdate)
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
        public  void ReadAllCandidates()
        {
            Console.WriteLine("\nAll Candidates:\n");
            foreach (Candidate item in data)
            {
                Console.WriteLine(item.id);
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
        public List<Candidate> LoadDataFromFile()
        {
            List<Candidate> data = new List<Candidate>();
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

            }
            return data;
        }



    }
} 





    
