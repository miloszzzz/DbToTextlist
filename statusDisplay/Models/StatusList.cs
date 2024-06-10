using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace statusDisplay.Models
{
    public class StatusList : IList<Status>
    {
        public List<Status> Statuses { get; set; }

        public StatusList()
        {
            Statuses = new List<Status>();
        }

        public int Count => ((ICollection<Status>)Statuses).Count;

        public bool IsReadOnly => ((ICollection<Status>)Statuses).IsReadOnly;

        public Status this[int index] { get => ((IList<Status>)Statuses)[index]; set => ((IList<Status>)Statuses)[index] = value; }

        public StatusList RemoveDuplicates()
        {
            StatusList statusList = new StatusList();
            Dictionary<int, bool> idDictionary = new Dictionary<int, bool>();

            foreach (Status status in Statuses)
            {
                if (idDictionary.TryAdd(status.Id, true)) statusList.Add(status);
            }

            return statusList;
        }

        public int IndexOf(Status item)
        {
            return ((IList<Status>)Statuses).IndexOf(item);
        }

        public void Insert(int index, Status item)
        {
            ((IList<Status>)Statuses).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Status>)Statuses).RemoveAt(index);
        }

        public void Add(Status item)
        {
            ((ICollection<Status>)Statuses).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Status>)Statuses).Clear();
        }

        public bool Contains(Status item)
        {
            return ((ICollection<Status>)Statuses).Contains(item);
        }

        public void CopyTo(Status[] array, int arrayIndex)
        {
            ((ICollection<Status>)Statuses).CopyTo(array, arrayIndex);
        }

        public bool Remove(Status item)
        {
            return ((ICollection<Status>)Statuses).Remove(item);
        }

        public IEnumerator<Status> GetEnumerator()
        {
            return ((IEnumerable<Status>)Statuses).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Statuses).GetEnumerator();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetStatusesTexts(bool withNumbers, bool renumber)
        {
            string statusesText = string.Empty;
            int hmiNumber = 1;

            foreach (Status status in Statuses)
            {
                if (status.Id < 1) continue;

                if (withNumbers == false)
                {
                    statusesText += status.Name + "\r\n";
                }
                else
                {
                    if (renumber)
                    {
                        statusesText += hmiNumber++ + "\t" + status.Name + "\r\n";
                    }
                    else
                    {
                        statusesText += status.Id + "\t" + status.Name + "\r\n";
                    }
                }

            }

            return statusesText;
        }


        public string GetSclCode()
        {
            string sclCode = "CASE #In_Status OF\n";
            int hmiNumber = 1;

            foreach (Status status in Statuses)
            {
                if (status.Id < 1) continue;

                sclCode += $"\t{status.Id}:\n\t\t" + $"#Out_HmiStatusDisplay := {hmiNumber++};\n";
            }

            sclCode += "\tELSE\n\t\t#Out_HmiStatusDisplay := -1;\nEND_CASE;";

            return sclCode;
        }
    }
}
