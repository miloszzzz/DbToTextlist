using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml;
<<<<<<< HEAD
using static statusDisplay.Models.StringExtensions;
=======
>>>>>>> 595a7f7451ae470177e7d8afc4dfce27a269c8e2

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
                        Status status = new Status(cells[3], cells[1]);

<<<<<<< HEAD
                        status.Name = status.Name.SeparateWords();

=======
>>>>>>> 595a7f7451ae470177e7d8afc4dfce27a269c8e2
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
<<<<<<< HEAD

=======
>>>>>>> 595a7f7451ae470177e7d8afc4dfce27a269c8e2
    }
}
