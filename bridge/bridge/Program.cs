using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bridge
{
    interface IDataReader
    {
        void Read();
    }

    class DatabaseReader: IDataReader
    {
        public void Read() => Console.WriteLine("Данные из базы данных");
    }

    class FileReader : IDataReader
    {
        public void Read() => Console.WriteLine("Данные из файла");
    }

    abstract class Sender
    {
        protected IDataReader reader;
        public Sender(IDataReader dr) => reader = dr;
        public void SetDataReader(IDataReader dr) => reader = dr;
        public abstract void Send();
    }

    class EmailSender: Sender
    {
        public EmailSender(IDataReader dr) : base(dr){ }

        public override void Send()
        {
            reader.Read();
            Console.WriteLine("Отправлены при помощи Email");
            
        }
    }
    
    class TelegramBotSender: Sender
    {
        public TelegramBotSender(IDataReader dr) : base(dr){ }

        public override void Send()
        {
            reader.Read();
            Console.WriteLine("Отправлены при помощи telegram бота");
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Sender sender = new EmailSender(new DatabaseReader());
            sender.Send();
            
            sender.SetDataReader(new FileReader());
            sender.Send();

            sender = new TelegramBotSender(new DatabaseReader());
            sender.Send();
        }
    }
}