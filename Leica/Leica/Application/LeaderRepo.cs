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
        private List<Leader> leaderList = new List<Leader>();


        public void AddLeader(Leader leader) 
        {
            LeaderRepo leaderRepo = new LeaderRepo();

            //hardcode
            Leader newLeader = new Leader("Benjamin", "Benjamin@gmail.com", 2302);
            Leader newLeader1 = new Leader("Vuong", "Vuong@gmail.com", 2604);

            //hardcode
            leaderRepo.AddLeader(newLeader);
            leaderRepo.AddLeader(newLeader1);

            leaderList.Add(leader);

            using(StreamWriter fileWriter = new StreamWriter("Leaders.txt"))
            {

                foreach (Leader leaders in leaderList)
                {
                  fileWriter.WriteLine(leaders.ToString());  
                }

            }
        }

       



    }


}
