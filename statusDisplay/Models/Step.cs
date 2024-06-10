using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statusDisplay.Models
{
    public class Step
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public Step(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public Step(string id, string name)
        {
            if (int.TryParse(id, out int outId))
            {
                Id = outId;
                Name = name;
            }
            else
            {
                Id = -1;
                Name = name;
            }
        }


        public static StepList GraphToStepList(string db)
        {
            var steps = new StepList();
            string[] lines = db.Split("\n");

            foreach (string line in lines)
            {
                string[] cells = line.Split("\t");

                if (cells.Length >= 4)
                {
                    bool itsStep = cells.Any(c => c.Contains("Step"));

                    if (itsStep)
                    {
                        Step step = new(0, cells[1]);

                        steps.Add(step);
                    }
                }
            }

            return steps;
        }
    }
}
