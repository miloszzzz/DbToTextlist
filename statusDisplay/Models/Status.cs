using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml;
using static statusDisplay.Models.StringExtensions;

namespace statusDisplay.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Status(int id, string name)
        {
            Id = id;
            Name = name;
        }


        public Status(string id, string name)
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


        public static StatusList DbToStatusList(string db)
        {
            var statuses = new StatusList();
            string[] lines = db.Split("\n");

            foreach (string line in lines)
            {
                string[] cells = line.Split("\t");

                if (cells.Length >= 4)
                {
                    bool itsInteger = cells.Any(c => Status.isIntegerType(c));

                    if (itsInteger)
                    {
                        Status status = new(cells[3], cells[1]);

                        status.Name = status.Name.SeparateWords();

                        if (status.Id != -1) statuses.Add(status);
                    }
                }
            }

            statuses = statuses.RemoveDuplicates();

            return statuses;
        }


        /// <summary>
        /// Checks if it is name of integer datatype
        /// </summary>
        /// <param name="variableType">Datatype name</param>
        /// <returns></returns>
        public static bool isIntegerType(string variableType)
        {
            string[] integerTypes = { "Int", "UInt", "SInt",
                "USInt", "LInt", "ULInt"};

            foreach (string integerType in integerTypes)
            {
                if (integerType == variableType) return true;
            }
            return false;
        }

    }
}
