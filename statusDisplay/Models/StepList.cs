using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace statusDisplay.Models
{
    public class StepList : IList<Step>
    {
        public List<Step> Steps { get; set; }

        public StepList()
        {
            Steps = new List<Step>();
        }

        public int Count => ((ICollection<Step>)Steps).Count;

        public bool IsReadOnly => ((ICollection<Step>)Steps).IsReadOnly;

        public Step this[int index] { get => ((IList<Step>)Steps)[index]; set => ((IList<Step>) Steps)[index] = value; }

        public int IndexOf(Step item)
        {
            return ((IList<Step>)Steps).IndexOf(item);
        }

        public void Insert(int index, Step item)
        {
            ((IList<Step>)Steps).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Step>)Steps).RemoveAt(index);
        }

        public void Add(Step item)
        {
            ((ICollection<Step>)Steps).Add(item);
        }

        public void Clear()
        {
            ((ICollection<Step>)Steps).Clear();
        }

        public bool Contains(Step item)
        {
            return ((ICollection<Step>)Steps).Contains(item);
        }

        public void CopyTo(Step[] array, int arrayIndex)
        {
            ((ICollection<Step>)Steps).CopyTo(array, arrayIndex);
        }

        public bool Remove(Step item)
        {
            return ((ICollection<Step>)Steps).Remove(item);
        }

        public IEnumerator<Step> GetEnumerator()
        {
            return ((IEnumerable<Step>)Steps).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Steps).GetEnumerator();
        }
    }
}
