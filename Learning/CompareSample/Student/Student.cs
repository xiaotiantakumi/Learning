﻿using System;
using System.Collections.Generic;

namespace Learning.CompareSample
{
    /// <summary>
    /// 学生クラス
    /// </summary>
    class Student : IComparable<Student>, IComparable
    {
        /// <summary>
        /// 学生番号
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// 名前
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// 数学の評価
        /// </summary>
        public int MathScore { get; }

        /// <summary>
        /// 日本語の評価
        /// </summary>
        public int JapaneseScore { get; }

        /// <summary>
        /// 英語の評価
        /// </summary>
        public int EnglishScore { get; }
        /// <summary>
        /// テスト
        /// </summary>
        private int Hoge { get; }

        /// <summary>
        /// ToString メソッドをオーバーライド
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $@"ID:{this.Id},名前:{this.Name},数学:{this.MathScore},国語:{this.JapaneseScore},英語:{this.EnglishScore}";
        }

        /// <summary>
        /// 標準の比較ルール(英語→IDの順で比較)
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(Student other)
        {
            var first = this.EnglishScore.CompareTo(other.EnglishScore);
            if (first == 0)
            {
                return this.Id.CompareTo(other.Id);
            }
            return first;
        }

        /// <summary>
        /// 標準の比較ルール
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            if (obj == null) return 1;

            var other = obj as Student;
            if (other != null)
            {
                return CompareTo(other);
            }
            else
            {
                throw new ArgumentException("Object is not a Student");
            }
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
        /// Comparison<T>のサンプル。すべての評価で比較する
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static int CompareAllScore(Student x, Student y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // xもyもnullならイコール
                    return 0;
                }
                else
                {
                    // x==null,y!=nullならyのほうが大きいと判断
                    return -1;
                }
            }
            else
            {
                // x!=nullの時
                if (y == null)
                {
                    // yがnullならxが大きいい
                    return 1;
                }
                else
                {
                    // すべての評価で比較
                    var xSum = x.MathScore + x.JapaneseScore + x.EnglishScore;
                    var ySum = y.MathScore + y.JapaneseScore + y.EnglishScore;
                    return xSum.CompareTo(ySum);
                }
            }

        }

        /// <summary>
        /// StudentEnglishScoreComarerが呼び出されるまでStudentEnglishScoreCompはインスタンス化しない
        /// </summary>
        private static readonly Lazy<StudentEnglishScoreComparer> studentEnglishScoreComarer =
            new Lazy<StudentEnglishScoreComparer>(() => new StudentEnglishScoreComparer());

        public static IComparer<Student> StudentEnglishScoreComarer => studentEnglishScoreComarer.Value;
    }
    /// <summary>
    /// IComparable.CompareTo()の説明用
    /// </summary>
    class StudentDummy
    {
    }
}
