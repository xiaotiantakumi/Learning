using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Learning.CompareSample
{
    /// <summary>
    /// IComparer<Student>,IComparable<Student>,IComparableのサンプル
    /// </summary>
    class CompareSample
    {
        /// <summary>
        /// サンプルの実行
        /// </summary>
        public void Execute()
        {
            List<Student> students = new List<Student>()
            {
                new Student(3, "Taro Hoge", 60, 60, 60),
                new Student(2, "Hana Foo", 20, 28, 26),
                new Student(1, "山田 一郎", 42, 61, 33),
                new Student(4, "北村 善太", 90, 20, 50),
                new Student(8, "中村 裕也", 100, 100, 100),
            };

            UseStudentIComparable(students);

            // 標準のソートルール
            foreach (var student in students.OrderBy(x => x))
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();


            Console.WriteLine();
            // 名前のソートルール
            foreach (var student in students.OrderBy(x => x, new StudentNameComp()))
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();
            // 数学のソートルール(OrderByだと評価の低い順)
            foreach (var student in students.OrderBy(x => x, new StudentMathScoreComp()))
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();
            // 国語のソートルール(OrderByDescendingだと評価の高い順)
            foreach (var student in students.OrderByDescending(x => x, new StudentJapaneseScoreComp()))
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();
            // 英語のソートルール(OrderByDescendingだと評価の高い順)
            foreach (var student in students.OrderByDescending(x => x, new StudentEnglishScoreComp()))
            {
                Console.WriteLine(student.ToString());
            }
        }
        /// <summary>
        /// Studentに実装した非ジェネリック版のIComparableを使う
        /// </summary>
        /// <param name="students"></param>
        private void UseStudentIComparable(List<Student> students)
        {
            ArrayList objStudents = new ArrayList();
            foreach (var student in students)
            {
                objStudents.Add(student);
            }

            // 標準のソートルール(IComparableが使われる)
            // StudentにIComparableを実装していないとSort()のタイミングでSystem.InvalidOperationExceptionが出る
            objStudents.Sort();
            foreach (var student in objStudents)
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
}