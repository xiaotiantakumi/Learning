using System.Collections.Generic;

namespace Learning.CompareSample
{
    /// <summary>
    /// Name比較
    /// </summary>
    class StudentNameComp : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.Name.CompareTo(y.Name);
        }
    }
}