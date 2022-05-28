using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32.SafeHandles;

namespace decorator
{
    interface IProcessor
    {
        void Process();

    }

    class Transmitter : IProcessor
    {
        private string data;
        public Transmitter(string data) => this.data = data;
        public void Process() => Console.WriteLine("Данные " + data + "Переданы по каналу связи");
    }

    abstract class Shell : IProcessor
    {
        protected IProcessor processor;
        public Shell(IProcessor pr) => processor = pr;
        public virtual void Process() => processor.Process();
    }

    class HammingCoder : Shell
    {
        public HammingCoder(IProcessor pr) : base(pr)
        {
        }

        public override void Process()
        {
            Console.WriteLine("Наложен помехоустойчивый код Хэмминга ->");
            processor.Process();
        }

        class Encryptor : Shell
        {
            public Encryptor(IProcessor pr) : base(pr)
            {
            }

            public override void Process()
            {
                Console.WriteLine("Шифрование данных->");
                processor.Process();
            }
        }


        class Program
        {
            static void Main(string[] args)
            {
                IProcessor transmitter = new Transmitter("12345 ");
                transmitter.Process();
                Console.WriteLine();

                Shell hammingCoder = new HammingCoder(transmitter);
                hammingCoder.Process();
                Console.WriteLine();

                Shell encoder = new Encryptor(hammingCoder);
                encoder.Process();
            }
        }
    }
}