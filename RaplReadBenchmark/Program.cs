using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;

using NumT = System.Decimal;


namespace RaplReadBenchmark
{
    [SimpleJob(RuntimeMoniker.Net60)]
    [SimpleJob(RuntimeMoniker.Net50, baseline: true)]
    [RPlotExporter]
    public class RaplBench
    {
        StreamReader sr;
        FileStream s;
        byte[] buff = new byte[1024];
        int iterations = 1_000_000;


        private const string FILE_PATH = "/sys/devices/virtual/powercap/intel-rapl/intel-rapl:0/energy_uj";
        private NumT read_rapl_value()
        {
            string raw_value = File.ReadAllText(FILE_PATH);
            return NumT.Parse(raw_value);
        }
        [Benchmark]
        public NumT Read_rapl_value()
        {
            NumT n = default;
            for (int i = 0; i < iterations; ++i)
                n = read_rapl_value();
            return n;
        }


        private NumT read_rapl_value_no_fileopen()
        {
            s.Seek(0, SeekOrigin.Begin);
            string raw_value = sr.ReadLine();
            return NumT.Parse(raw_value);
        }
        [Benchmark]
        public NumT Read_rapl_value_no_fileopen()
        {
            NumT n = default;
            for (int i = 0; i < iterations; ++i)
                n = read_rapl_value_no_fileopen();
            return n;
        }


        [Benchmark]
        public NumT Read_rapl_value_no_fileopen_buffer()
        {
            NumT n = default;
            for (int i = 0; i < iterations; ++i)
                n = read_rapl_value_no_fileopen_buffer();
            return n;
        }
        private NumT read_rapl_value_no_fileopen_buffer()
        {
            s.Seek(0, SeekOrigin.Begin);
            s.Read(buff, 0, 1024);
            string raw_value = Encoding.ASCII.GetString(buff);
            return NumT.Parse(raw_value);
        }

        [Benchmark]
        public NumT Read_rapl_value_no_fileopen_readtoend()
        {
            NumT n = default;
            for (int i = 0; i < iterations; ++i)
                n = read_rapl_value_no_fileopen_readtoend();
            return n;
        }
        private NumT read_rapl_value_no_fileopen_readtoend()
        {
            s.Seek(0, SeekOrigin.Begin);
            string raw_value = sr.ReadToEnd();
            return NumT.Parse(raw_value);
        }

        [GlobalSetup]
        public void Setup()
        {
            s = File.OpenRead(FILE_PATH);
            sr = new StreamReader(s);
        }
        [GlobalCleanup]
        public void Teardown() {
            s.Close();
            sr.Close();
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<RaplBench>();
        }
    }
}