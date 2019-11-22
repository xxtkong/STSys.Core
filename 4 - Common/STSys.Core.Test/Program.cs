using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Security.Cryptography;
using System.Text;

namespace STSys.Core.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //var summary = BenchmarkRunner.Run<Md5VsSha256>();
            BenchmarkRunner.RunUrl("www.shoutu.com.cn");
        }
    }



    public class Md5VsSha256
    {
        [Benchmark]
        public void Test()
        {
            Console.WriteLine("11111111111");
        }

    }
}
