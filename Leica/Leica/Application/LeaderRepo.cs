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

        public LeaderRepo()
        {
            InitializeRepository();
        }

        public void InitializeRepository()
        {
            try
            {
                using (StreamReader sr = new StreamReader("Leaders.txt"))
                {
                    String line = sr.ReadLine();

                    while (line != null)
                    {
                        string[] parts = line.Split(';');

                        Leader tempLeader = new Leader(parts[0], parts[1], int.Parse(parts[2]));
                        leaderList.Add(tempLeader);

                        line = sr.ReadLine();
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        public Leader Add(string name, string email, int password)
        {
            Leader result = null;

            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email))
            {
                result = new Leader(name, email, password);
                leaderList.Add(result);
            }
            else
                throw (new ArgumentException("Not all arguments are valid."));
            return result;
        }

        public List<Leader> GetAll()
        {
            return leaderList;
        }

        public void AddLeadersToFile()
        {
            using (StreamWriter fileWriter = new StreamWriter("Leaders.txt"))
            {
                foreach (Leader leaders in leaderList)
                {
                    fileWriter.WriteLine(leaders.ToString());
                }
            }
        }
    }
}