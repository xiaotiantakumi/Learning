using System;
using System.Collections.Generic;
using static System.Console;

namespace Learning
{
    class Program
    {
        static void Main(string[] args)
        {
            var comp = new CompareSample.CompareSample();
            comp.Execute();

            //LazyEvaluation();
        }

        //private static IEnumerable<TResult> Generate<TResult>(int number, Func<TResult> generator)
        //{
        //    for (var i = 0; i < number; i++) 
        //        yield return generator();
        //}

        //private static void LazyEvaluation()
        //{
        //    WriteLine($" 1 番目のテスト開始時間: {DateTime.Now:T}");
        //    var sequence = Generate(10, () => DateTime.Now);
        //    WriteLine(" 待機 中.... エンター キー を 押し て ください");
        //    ReadLine();

        //    WriteLine(" 走査中..."); 
        //    foreach (var value in sequence) 
        //        WriteLine($"{ value:T}"); 
            
        //    WriteLine(" 待機 中.... エンター キー を 押し て ください"); 
        //    ReadLine(); 
            
        //    WriteLine(" 走査中..."); 
        //    foreach (var value in sequence) 
        //        WriteLine($"{ value: T}");
        //}

    }
}
