using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        partial class Tree
        {
            private string a; // хранимая строка
            private int count;    // счётчик повторений
            private Tree left;    // ссылка на левое поддерево
            private Tree right;   // ссылка на правое поддерево
        }

        partial class Tree
        {
            public void Insert(string value)
            {
                if (this.a == null)
                {
                    this.a = value;
                    this.count = 1;
                }
                else
                {
                    if (this.a.CompareTo(value) == 1)
                    {
                        if (left == null)
                            this.left = new Tree();
                        left.Insert(value);
                    }
                    else if (this.a.CompareTo(value) == -1)
                    {
                        if (right == null)
                            this.right = new Tree();
                        right.Insert(value);
                    }
                    else
                        this.count++;
                }
            }
        }

        // поиск
        partial class Tree
        {
            public Tree Search(string value)
            {
                if (this.a == value)
                    return this;
                else if (this.a.CompareTo(value) == 1)
                {
                    if (left != null)
                        return this.left.Search(value);
                    else
                        throw new Exception("Искомого узла в дереве нет");
                }
                else
                {
                    if (right != null)
                        return this.right.Search(value);
                    else
                        throw new Exception("Искомого узла в дереве нет");
                }
            }
        }

        partial class Tree
        {
            // отображение в строку
            public string Display(Tree t)
            {
                string result = "";
                if (t.left != null)
                    result += Display(t.left);
                result += t.a + " ";
                if (t.right != null)
                    result += Display(t.right);
                return result;
            }
        }
        


        static void Main(string[] args)

        {
            Tree t = new Tree();
            t.Insert("Диана");
            t.Insert("Маша");
            t.Insert("Дима");
            t.Insert("Оля");
            t.Insert("Марина");
            t.Insert("Петя");

            Console.WriteLine(t.Display(t));
            Tree s = t.Search("Оля");
            Console.WriteLine(s.Display(s));
            Console.Read();
        }
    }
}
