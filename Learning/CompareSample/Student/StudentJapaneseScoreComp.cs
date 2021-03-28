using System.Collections.Generic;

namespace Learning.CompareSample
{
    /// <summary>
    /// 日本語の評価で比較
    /// </summary>
    class StudentJapaneseScoreComp : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.JapaneseScore.CompareTo(y.JapaneseScore);
        }
    }
}