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

        public void AddLeadersToFile(List<Leader> leaderList)
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