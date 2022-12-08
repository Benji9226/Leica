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

        /// <summary>
        /// Repository constructor
        /// </summary>
        public ChecklistRepo()
        {
            InitializeRepository();
        }

        /// <summary>
        /// Initilizes the repository from text file 'Checklists.txt'.
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
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

                            Checklist checklist = new Checklist();
                            checklist.Q1 = bool.Parse(parts[0]);
                            checklist.Q2 = bool.Parse(parts[1]);
                            checklist.Q3 = bool.Parse(parts[2]);
                            checklist.Q4 = bool.Parse(parts[3]);
                            checklist.Q5 = bool.Parse(parts[4]);
                            checklist.Q6 = bool.Parse(parts[5]);


                            checklistList.Add(checklist);

                            line = sr.ReadLine();
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("Checklists.txt does not exist.");
            }
        }

        /// <summary>
        /// Adds a new checklist to the list.
        /// </summary>
        public void Add()
        {
            Checklist checklist = new Checklist();
            checklistList.Add(checklist);
        }

        /// <summary>
        /// Removes a checklist from the list at given index parameter.
        /// </summary>
        /// <param name="index"></param>
        public void Remove(int index)
        {
            checklistList.RemoveAt(index);
        }

        /// <summary>
        /// Returns a list of all checklists.
        /// </summary>
        /// <returns>A List containing Checklists</returns>
        public List<Checklist> GetAll()
        {
            return checklistList;
        }

        /// <summary>
        /// Updates the text file 'Checklists.txt' from the current active repository checklistList when called.
        /// </summary>
        public void UpdateChecklistsFile()
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
