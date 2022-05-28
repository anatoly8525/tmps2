using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace composite
{
    abstract class item
    {
        protected string itemname;
        protected string ownername;
        public void SetOwner(string o) => ownername = o;

        public item(string name) => itemname = name;

        public virtual void Add(item subitem)
        {
        }

        public virtual void Remove(item subitem)
        {
        }

        public abstract void Display();
    }

    class ClickableItem : item
    {
        public ClickableItem(string name) : base(name)
        {
        }

        public override void Add(item subitem)
        {
            throw new Exception();
        }

        public override void Remove(item subitem)
        {
            throw new Exception();

        }

        public override void Display()
        {
            Console.WriteLine(itemname);


        }

        class DropDownItem : item
        {
            private List<item> children;

            public DropDownItem(string name) : base(name)
            {
                children = new List<item>();
            }

            public override void Add(item subitem)
            {
                subitem.SetOwner(this.itemname);
                children.Add(subitem);
            }

            public override void Remove(item subitem)
                => children.Remove(subitem);

            public override void Display()
            {
                foreach (item item in children)
                {
                    if (ownername != null)
                        Console.WriteLine(ownername + itemname);
                    item.Display();
                }
            }
        }

        class Program
        {
            static void Main(string[] args)
            {
                item file = new DropDownItem("Файл->");

                item create = new DropDownItem("Создать->");
                item open = new DropDownItem("Открыть->");
                item exit = new ClickableItem("Выход");

                file.Add(create);
                file.Add(open);
                file.Add(exit);

                item project = new ClickableItem("Проект...");
                item repository = new ClickableItem("Репозиторий");

                create.Add(project);
                create.Add(repository);

                item solution = new ClickableItem("Решение...");
                item folder = new ClickableItem("Папка...");

                open.Add(solution);
                open.Add(folder);

                file.Display();
                Console.WriteLine();

                file.Remove(create);
                file.Display();
            }
        }
    }
}