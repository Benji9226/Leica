using Leica.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leica.Application
{
    public class ChecklistRepo
    {
        public List<Checklist> checklistList = new List<Checklist>();

        public ChecklistRepo()
        {
            InitializeRepository();
        }

        public void InitializeRepository()
        {
            try
            {
                if (File.Exists("Checklists.txt"))
                {
                    using (StreamReader sr = new StreamReader("Checklists.txt"))
                    {
                        string line = sr.ReadLine();

                        while (line != null)
                        {
                            string[] parts = line.Split(';');

                            Checklist checklist = new Checklist(bool.Parse(parts[0]), bool.Parse(parts[1]), bool.Parse(parts[2]),
                                                                bool.Parse(parts[3]), bool.Parse(parts[4]), bool.Parse(parts[5]));
                            checklistList.Add(checklist);

                            line = sr.ReadLine();
                        }
                    }
                }
            }
            catch (IOException)
            {
                throw;
            }
        }

        public void Add()
        {
            Checklist result = new Checklist(false, false, false, false, false, false);
            checklistList.Add(result);
        }

        public List<Checklist> GetAll()
        {
            return checklistList;
        }
        public void AddChecklistsToFile()
        {
            using (StreamWriter fileWriter = new StreamWriter("Checklists.txt"))
            {
                foreach (Checklist checklist in checklistList)
                {
                    fileWriter.WriteLine(checklist.ToString());
                }
            }
        }
    }
}
