using System;
using System.Collections.Generic;

namespace Learning.CompareSample
{
    /// <summary>
    /// 学生クラス
    /// </summary>
    class Student : IComparable<Student>,IComparable
    {
        /// <summary>
        /// 学生番号
        /// </summary>
        public int Id { get;}

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// 数学の評価
        /// </summary>
        public int MathScore { get;}
        /// <summary>
        /// 日本語の評価
        /// </summary>
        public int JapaneseScore { get;}
        /// <summary>
        /// 英語の評価
        /// </summary>
        public int EnglishScore { get;}

        /// <summary>
        /// 標準の比較ルール(IDで比較)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Student other)
        {
            return this.Id.CompareTo(other.Id);
        }
        /// <summary>
        /// 標準の比較ルール
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;

            var other = obj as Student;
            if (other != null)
                return this.Id.CompareTo(other.Id);
            else
                throw new ArgumentException("Object is not a Student");
        }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="mathScore"></param>
        /// <param name="japaneseScore"></param>
        /// <param name="englishScore"></param>
        public Student(int id, string name, int mathScore, int japaneseScore, int englishScore)
        {
            Id = id;
            Name = name;
            MathScore = mathScore;
            JapaneseScore = japaneseScore;
            EnglishScore = englishScore;
        }
        /// <summary>
        /// ToString メソッドをオーバーライド
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $@"ID:{this.Id},名前:{this.Name},数学:{this.MathScore},国語:{this.JapaneseScore},英語:{this.EnglishScore}";
        }

    }
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
    /// <summary>
    /// 英語の評価で比較
    /// </summary>
    class StudentEnglishScoreComp : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            return x.EnglishScore.CompareTo(y.EnglishScore);
        }
    }
}
