using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TSD.Linq.Task1.Lib.Test
{



    public class MainTask2
    {
        Func<int, bool> anneeBissTrueOrFalse = (annee) => (annee % 4 == 0 && (annee % 100 != 0 || (annee % 100 == 0 && annee % 400 == 0)));

        [Test]
        public void anneeBissTrueOrFalsTest()
        {
            int annee = 2400;
            bool anneeBiss = anneeBissTrueOrFalse(annee);
            Console.WriteLine("Is " + annee.ToString() + " a leap year ?  " + anneeBiss);
        }

        

        [Test]
        public void IsMyCollectionIsGood()
        {
            MyCollection<int> myCollection = new MyCollection<int>();
            myCollection.Add(1);
            myCollection.Add(2);
            myCollection.Add(3);
            myCollection.Add(4);

            // size of my collection
            int sizeOfMyCollection = myCollection.Size();

            // display of my collection
            System.Console.WriteLine("my collection : ");
            myCollection.displayMyCollection();
            System.Console.WriteLine();
            System.Console.WriteLine("size of my collection : " + sizeOfMyCollection);

        }

    }

    public class MyCollection<T>
    {

        private List<T> l;

        public MyCollection()
        {
            l = new List<T>();
        }

        public void Add(T element)
        {
            Random random = new Random();
            int binaire = random.Next(0, 1);
            if (binaire == 0)
            {
                l.Add(element);
            }
            else
            {
                l.Insert(0, element);
            }
        }

        public T Get(int index)
        {
            Random random = new Random();
            int binaire = random.Next(0, index);
            return l[binaire];
        }

        public bool IsEmpty()
        {
            return l.Count == 0;
        }

        public int Size()
        {
            return l.Count;
        }

        public void displayMyCollection()
        {
            for (int i = 0; i < l.Count; i++)
            {
                Console.WriteLine(l[i]);
            }
        }




    }






}



