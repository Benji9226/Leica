using Leica.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Application
{
    public class LeaderRepo
    {
        public List<Leader> leaderList = new List<Leader>();

        /// <summary>
        /// Repository constructor
        /// </summary>
        public LeaderRepo()
        {
            InitializeRepository();
        }

        /// <summary>
        /// Initilizes the repository from text file 'Leaders.txt'
        /// If the textfile does not exists it creates a new file with default values
        /// The program informs the user of this through some writelines before proceding to the program.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public void InitializeRepository()
        {
            try
            {
                if (File.Exists("Leaders.txt"))
                {
                    using (StreamReader sr = new StreamReader("Leaders.txt"))
                    {
                        string line = sr.ReadLine();

                        while (line != null)
                        {
                            string[] parts = line.Split(';');

                            Leader tempLeader = new Leader(parts[0], parts[1], int.Parse(parts[2]));
                            leaderList.Add(tempLeader);

                            line = sr.ReadLine();
                        }
                    }
                }
                else
                {
                    using (StreamWriter sw = new StreamWriter("Leaders.txt"))
                    {
                        Leader tempLeader = new Leader("defaultName", "email@", 0);
                        sw.WriteLine(tempLeader.ToString());
                        leaderList.Add(tempLeader);
                    }
                    Console.WriteLine("WARNING!");
                    Console.WriteLine("Leaders.txt did not exist. " +
                                      "\n" +
                                      "\nYour default login is: " +
                                      "\nEMAIL: email@ " +
                                      "\nPASSWORD: 0 " +
                                      "\n" +
                                      "\nIf you wish to change these a 'Leaders.txt' file has been created in the bin/debug/net6.0 directory" +
                                      "\nEdit the file text so it remains like the following example: " +
                                      "\nmyName;example@mail.com;1234");
                    Console.WriteLine();
                    Console.WriteLine("PRESS ENTER TO CONTINUE TO THE PROGRAM");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            catch (FileNotFoundException e)
            {
                throw new FileNotFoundException("Leaders.txt does not exists. Please create a textfile called 'Leaders.txt' in the bin/debug/net6.0 directory with a name, email and password. Should be written as the following example: myName;example@mail.com;1234", e);
            }
        }
    }
}