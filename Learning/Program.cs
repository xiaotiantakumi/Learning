using System;
using System.Collections.Generic;
using Learning.CompareSample;

namespace Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            var students1 = GetStudents();
            var comp1 = new CompareSample.CompareSample(students1,true);
            comp1.Execute();

            var students2 = GetStudentsMany();
            var comp2 = new CompareSample.CompareSample(students2,false);
            comp2.Execute();
        }
        /// <summary>
        /// サンプルCompareをデバッグしながら確認する
        /// </summary>
        /// <returns></returns>
        private static List<Student> GetStudents()
        {
            var students = new List<Student>()
            {
                new Student(3, "Taro Hoge", 60, 60, 60),
                new Student(2, "Hana Foo", 20, 28, 26),
                new Student(1, "山田 一郎", 42, 61, 33),
                new Student(4, "北村 善太", 90, 20, 50),
                new Student(8, "中村 裕也", 100, 100, 100),
            };
            return students;
        }
        /// <summary>
        /// 速度確認用に大量データを作る
        /// </summary>
        /// <returns></returns>
        private static List<Student> GetStudentsMany()
        {
            List<string> names = new List<string>()
            {
                "hoge",
                "fuga",
                "yamada",
                "oda"
            };
            var students = new List<Student>();
            var rand = new Random();
            for (int i = 0; i < 100000; i++)
            {
                var index = rand.Next(0, 3);
                students.Add(new Student(i, names[index] + i.ToString(), rand.Next(0,100), rand.Next(0, 100), rand.Next(0, 100)));
            }
            return students;
        }
    }
}
