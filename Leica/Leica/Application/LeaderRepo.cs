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

        public void AddLeader(Leader leader) 
        {
            leaderList.Add(leader);
            AddLeadersToFile(leaderList);
        }

        /// <summary>
        /// Helping method
        /// </summary>
        /// <param name="leaderList"></param>
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