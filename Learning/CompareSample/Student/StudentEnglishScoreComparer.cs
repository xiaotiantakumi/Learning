using System.Collections.Generic;

namespace Learning.CompareSample
{
    /// <summary>
    /// 英語の評価で比較
    /// </summary>
    internal class StudentEnglishScoreComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.EnglishScore.CompareTo(y.EnglishScore);
        }
    }
}