using System.Collections.Generic;

namespace Learning.CompareSample
{
    /// <summary>
    /// 数学の評価で比較
    /// </summary>
    class StudentMathScoreComp : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.MathScore.CompareTo(y.MathScore);
        }
    }
}