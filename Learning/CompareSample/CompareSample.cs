using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Learning.CompareSample
{
    /// <summary>
    /// IComparer<Student>,IComparable<Student>,IComparableのサンプル
    /// </summary>
    class CompareSample
    {
        private List<Student> _students;
        private bool _isWriteConsole = false;
        private Stopwatch _sw;

        /// <summary>
        /// コンストラクターでリストを作成
        /// </summary>
        public CompareSample(List<Student> students,bool isWriteConsole)
        {
            this._students = students;
            this._isWriteConsole = isWriteConsole;
            _sw = new System.Diagnostics.Stopwatch();
        }
        public void LogElapsed(Action action)
        {
            var sw = new Stopwatch();
            sw.Start();
            action?.Invoke();
            sw.Stop();
            Console.WriteLine(sw.Elapsed.TotalMilliseconds);
        }
        /// <summary>
        /// サンプルの実行
        /// </summary>
        public void Execute()
        {
            // オブジェクト型の配列。Sortで何が使われるかを確認する用
            var objStudents = CreateArrayStudentObj();

            // IComparableが実行するところを確認する
            LogElapsed(() => SortObjStudents(objStudents));
            //SortObjStudents(objStudents);

            // IComparable<Student>を使う
            LogElapsed(() => SortGenericIComparable());

            // 名前でソート
            LogElapsed(() => SortByName());

            // 数学でソート
            LogElapsed(() => SortByMath());

            // 国語でソート
            LogElapsed(() => SortByJapanese());

            // 英語でソート
            LogElapsed(() => SortByEnglishUseLazyComparer());

            // こちらはComparison<T>のサンプルとなります。
            LogElapsed(() => SortAllScoreUseComparison());
            

            // ちなみに、上記ではstaticでStudent内部にComparison<T>を実装しましたが、以下のようにラムダ式でも実装できる。
            // ところで以下の実装だとすべてが等しくなるので順序は変化しない。
            _students.Sort((x, y) =>
            {
                return 0;
            } );
        }

        /// <summary>
        /// ArrayListは非推奨。.NET Frameworkバージョン2.0以前で使われていたようです。
        /// ArrayListクラスの要素はObject型となります。
        /// .NET Frameworkバージョン2.0からはListが登場したので、それを使う。
        /// ただ、今回はサンプルでIComparableを使うので必要。
        /// </summary>
        /// <returns></returns>
        private ArrayList CreateArrayStudentObj()
        {
            // Studentに実装した非ジェネリック版のIComparableを使うためにArrayListを使う。
            // object型で格納される。
            ArrayList objStudents = new ArrayList();
            foreach (var student in _students)
            {
                objStudents.Add(student);
            }

            return objStudents;
        }

        /// <summary>
        /// 標準のソートルール,IDで比較(IComparableが使われる)を確認
        /// </summary>
        /// <param name="objStudents"></param>
        private void SortObjStudents(ArrayList objStudents)
        {
            // 標準のソートルール,IDで比較(IComparableが使われる)
            // StudentにIComparableを実装していないとSort()のタイミングでSystem.InvalidOperationExceptionが出る
            objStudents.Sort();
            var ret = objStudents.Cast<Student>();
            Console.WriteLine(nameof(SortObjStudents));
            WriteSortResult(ret);
        }

        /// <summary>
        /// ジェネリック版の標準ソートルール確認
        /// </summary>
        private void SortGenericIComparable()
        {
            // 標準のソートルール(IComparable<Student>が使われる)
            // ちなみに、List<T>に実装されているSortを使うと、students自体の順番が変化する。
            // students.OrderBy...だとstudentsは変化しません。
            _students.Sort();
            Console.WriteLine(nameof(SortGenericIComparable));
            WriteSortResult(_students);
        }

        /// <summary>
        /// 名前でソート
        /// </summary>
        private void SortByName()
        {
            // 名前のソートルール　以下コメントアウトの方法でソートするとstudents自体の順番が並び変わってしまう
            //students.Sort(new StudentNameComp());
            var tmpStudent = _students.OrderBy(x => x, new StudentNameComp()).ToList();
            Console.WriteLine(nameof(SortByName));
            WriteSortResult(tmpStudent);
        }

        /// <summary>
        /// 数学のソート
        /// </summary>
        private void SortByMath()
        {
            // 数学のソートルール(OrderByだと評価の低い順)
            //students.Sort(new StudentMathScoreComp());
            var tmpStudent = _students.OrderBy(x => x, new StudentMathScoreComp()).ToList();
            Console.WriteLine(nameof(SortByMath));
            WriteSortResult(tmpStudent);
        }


        /// <summary>
        /// 国語のソート
        /// </summary>
        private void SortByJapanese()
        {
            var tmpStudent = _students.OrderByDescending(x => x, new StudentJapaneseScoreComp()).ToList();
            Console.WriteLine(nameof(SortByJapanese));
            WriteSortResult(tmpStudent);
        }

        /// <summary>
        /// 英語のソート
        /// </summary>
        private void SortByEnglishUseLazyComparer()
        {
            var tmpStudent = _students.OrderByDescending(x => x, Student.StudentEnglishScoreComarer).ToList();
            Console.WriteLine(nameof(SortByEnglishUseLazyComparer));
            WriteSortResult(tmpStudent);
        }

        /// <summary>
        /// 数学，国語，英語の評価の合計で比較する。
        /// </summary>
        private void SortAllScoreUseComparison()
        {
            _students.Sort(Student.CompareAllScore);
            Console.WriteLine(nameof(SortAllScoreUseComparison));
            WriteSortResult(_students);
        }

        /// <summary>
        /// 結果を出力
        /// </summary>
        /// <param name="students"></param>
        private void WriteSortResult(IEnumerable<Student> students)
        {
            if (!_isWriteConsole || students == null)
            {
                return;
            }
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }

            Console.WriteLine();
        }
    }
}