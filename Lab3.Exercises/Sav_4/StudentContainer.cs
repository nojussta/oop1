using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sav_4
{
    class StudentContainer
    {
        private Student[] allStudents;
        private int Capacity;
        public int Count { get; private set; }
        public StudentContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            allStudents = new Student[this.Capacity];
        }
        public void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Student[] newStudents = new Student[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    newStudents[i] = this.allStudents[i];
                }
                this.Capacity = minimumCapacity;
                this.allStudents = newStudents;
            }
        }
        public void Add(Student student)
        {
            if (this.Capacity == this.Count)
            {
                EnsureCapacity(2 * this.Count);
            }
            this.allStudents[this.Count++] = student;
        }

        public Student Get(int index)
        {
            return this.allStudents[index];
        }

        public List<string> FindGroups()
        {
            List<string> groups = new List<string>();
            for (int i = 0; i < this.Count; i++)
            {
                if (!groups.Contains(this.allStudents[i].Group))
                {
                    groups.Add(this.allStudents[i].Group);
                }
            }
            return groups;
        }

        public double GetAverageMarksByGroup(string group)
        {
            double sum = 0;
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.allStudents[i].Group == group)
                {
                    for (int j = 0; j < this.allStudents[i].MarksCounter; j++)
                    {
                        sum += this.allStudents[i].Marks[j];
                        count++;
                    }
                }
            }
            double avg = sum / count;
            return avg;
        }
    }
}
