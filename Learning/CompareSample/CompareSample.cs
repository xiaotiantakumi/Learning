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

            // 標準のソートルール(IComparable<Student>が使われる)
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
            // 英語のソートルール。Student内部のクラスとしてIComparer<Student>を用意している。
            // この場合は、遅延実行してインスタンスを取得するほうがよい。
            // (こちらもOrderByDescendingだと評価の高い順)
            foreach (var student in students.OrderByDescending(x => x, Student.StudentEnglishScoreComarer))
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine();
            // 数学，国語，英語の評価の合計で比較する。
            // ここではComparison<T>のサンプル例として
            // ちなみに、List<T>に実装されているSortを使うと、students自体の順番が変化する。
            // students.OrderBy...だとstudentsは変化しません。
            students.Sort(Student.CompareAllScore);
            Console.WriteLine();

            // ちなみに、上記ではstaticでStudent内部にComparison<T>を実装しましたが、以下のようにもできる。
            students.Sort((x, y) =>
            {
                return 0;
            } );

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