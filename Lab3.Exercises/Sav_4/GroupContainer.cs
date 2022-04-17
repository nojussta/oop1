using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_4
{
    class GroupContainer
    {
        private Group[] allGroups;
        private int Capacity;
        public int Count { get; private set; }
        public GroupContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            allGroups = new Group[capacity];
        }
        public void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Group[] newGroups = new Group[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    newGroups[i] = this.allGroups[i];
                }
                this.allGroups = newGroups;
                this.Capacity = minimumCapacity;
            }
        }
        public void Add(Group group)
        {
            if (this.Capacity == this.Count)
            {
                EnsureCapacity(2 * this.Count);
            }
            this.allGroups[this.Count++] = group;
        }

        public Group Get(int index)
        {
            return this.allGroups[index];
        }

        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Group a = this.allGroups[i];
                    Group b = this.allGroups[i + 1];
                    if (a.CompareTo(b) < 0)
                    {
                        this.allGroups[i] = b;
                        this.allGroups[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public static GroupContainer GetGroups(List<string> sortLetters, StudentContainer students)
        {
            GroupContainer groups = new GroupContainer();
            foreach (string sortLetter in sortLetters)
            {
                groups.Add(new Group(sortLetter, Math.Round(students.GetAverageMarksByGroup(sortLetter),2)));
            }
            return groups;
        }
    }
}
