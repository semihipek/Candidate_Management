using System;
using System.Collections.Generic;
using System.IO;

namespace tasks_sem
{


    public class CandidateManagement
    {



        private List<Candidate> data = new List<Candidate>();
        private int lastAssignedId = 0;
        bool found = false;
        public void start()
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

        private void Create()

        {
            Candidate candidate = new Candidate();

            candidate.id = lastAssignedId + 1;
            Console.WriteLine("\nCREATE\n---------------\nUsername:");
            candidate.username = Console.ReadLine();
            Console.WriteLine("\nEmail:");

            candidate.email = Console.ReadLine();
            Console.WriteLine("\nPhone:");
            candidate.phone = Console.ReadLine();
            data.Add(candidate);

            lastAssignedId++;


            SaveCandidatesToFile(data);
        }

        public void Delete()
        {
            bool flag1 = true;


            while (flag1)
            {
                Console.WriteLine("\n\nPress 1 :Delete a candidate whose username is known\nPress 2: Take a look at candidates");
                string op = Console.ReadLine();
                if (op == "1")
                {
                    Read();
                    if (found)
                    {
                        flag1 = false;
                    }

                }
                else if (op == "2")
                {
                    ReadAllCandidates();
                    flag1 = false;
                }
            }
            Candidate candidate = new Candidate();
            Console.WriteLine("DELETE\n---------------\nWhat is the ID of the username you want to delete?");

            string Id = Console.ReadLine();

            if (int.TryParse(Id, out int IdInput))
            {
                candidate = data.Find(candidate => candidate.id == IdInput);
                if (candidate != null)
                {
                    candidate.isDeleted = true;
                    Console.WriteLine($"Candidate with username '{IdInput}' deleted successfully.");
                }
                else
                {
                    Console.WriteLine($"Candidate with username '{IdInput}' not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input type. Please enter a valid integer");
            }

            if (IdInput == lastAssignedId)
            {
                lastAssignedId--;
            }
            SaveCandidatesToFile(data);


        }

        public void Update()
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
            string usernametoread = Console.ReadLine();

            foreach (Candidate item in data)
            {


                if (item.username == usernametoread && !item.isDeleted)
                {
                    Console.WriteLine("-----------------\n" + item.id);
                    Console.WriteLine(item.username);
                    Console.WriteLine(item.email);
                    Console.WriteLine(item.phone);
                    found = true;
                }
            }

            if (!found)
            {
                Console.WriteLine($"Candidate with username '{usernametoread}' not found.");
            }

        }
        public void ReadAllCandidates()
        {
            Console.WriteLine("\nAll Candidates:\n---------------");
            foreach (Candidate item in data)
            {

                if (!item.isDeleted)
                {
                    Console.WriteLine(item.id);

                    Console.WriteLine(item.username);
                    Console.WriteLine(item.email);
                    Console.WriteLine(item.phone);
                    Console.WriteLine();
                }
            }

        }

        private void SaveCandidatesToFile(List<Candidate> candidates)
        {
            using (StreamWriter writer = new StreamWriter("C:\\Users\\ASUS\\OneDrive - GALATASARAY UNIVERSITESI\\Masaüstü\\tasks_sem\\candidates.txt"))
            {
                writer.WriteLine(lastAssignedId);
                foreach (var candidate in candidates)
                {
                    if (!candidate.isDeleted)
                    {
                        writer.WriteLine($"{candidate.id},{candidate.username},{candidate.email},{candidate.phone}");
                    }
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
                    if ((line = reader.ReadLine()) != null)
                    {
                        lastAssignedId = int.Parse(line);
                    }

                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length == 4)
                        {
                            int id = int.Parse(parts[0]);
                            Candidate candidate = new Candidate
                            {
                                id = id,
                                username = parts[1],
                                email = parts[2],
                                phone = parts[3],
                            };

                            data.Add(candidate);
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {

            }
        }
        } }







