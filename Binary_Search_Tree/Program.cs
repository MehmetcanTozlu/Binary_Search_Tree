using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            List agac = new List();
            agac.Create();
            Console.ReadKey();
        }
    }
    class Tree
    {
        public int data;
        public Tree left;//sol child node
        public Tree right;//sağ child node
    }
    class List
    {
        public void Create()
        {
            Tree agac = null;
            agac = Ekle(agac, 56);
            agac = Ekle(agac, 200);
            agac = Ekle(agac, 26);
            agac = Ekle(agac, 190);
            agac = Ekle(agac, 213);
            agac = Ekle(agac, 18);
            agac = Ekle(agac, 28);
            agac = Ekle(agac, 12);
            agac = Ekle(agac, 24);
            agac = Ekle(agac, 27);
            Dolas2(agac);
            Console.WriteLine("Arama Sonucu : "+Bul(agac, 100));
            Console.WriteLine("Arama Sonucu : "+Bul(agac, 24));
            Console.WriteLine("Max Değer : "+MaxValue(agac));
            Console.WriteLine("Max Değer : "+MinValue(agac));
            Console.WriteLine("--------------------------------");
            agac = Sil(agac, 56);
            Dolas2(agac);
        }
        Tree Ekle(Tree agac, int x)//Insertion
        {
            if(agac == null)//Ağaç boşken
            {
                Tree root = new Tree();
                root.data = x;
                root.left = null;
                root.right = null;
                return root;
            }
            if (agac.data < x)//agacın datası gelen veriden küçükse sağa ekleme işlemi yapıcaz
            {
                agac.right = Ekle(agac.right, x);//agacın sağına x'i ekle(Ekle(agac.right,x)) ve eklenen değeri agacın sağına ata(agac.right)
                return agac;
            }
            agac.left = Ekle(agac.left, x);//degilse agacın soluna x'i ekle(Ekle(agac.left,x)) ve elenen degeri agacın solu yap(agac.left)
            return agac;
        }
        void Dolas(Tree agac)//Traversal - Inorder(a+b) küçükten büyüğe
        {
            if(agac == null)
                return;
            Dolas(agac.left);
            Console.WriteLine(agac.data);
            Dolas(agac.right);
        }
        void Dolas1in2si(Tree agac)
        {
            if (agac == null)
                return;
            Dolas1in2si(agac.left);
            Console.WriteLine(agac.data);
            Dolas1in2si(agac.right);
        }
        void Dolas2(Tree agac)//Traversal - Preordor(+ab)
        {
            if(agac == null)
                return;
            Console.WriteLine(agac.data);
            Dolas2(agac.left);
            Dolas2(agac.right);
        }
        void Dolas3(Tree agac)//Traversal - Postorder(ab+)
        {
            if(agac == null)
                return;
            Dolas3(agac.left);
            Dolas3(agac.right);
            Console.WriteLine(agac.data);
        }
        int Bul(Tree agac, int x)
        {
            if (agac == null)//aranan eleman root node değilse
                return -1;
            if(agac.data == x)//aranan eleman root node ise
                return 1;
            if (Bul(agac.right, x) == 1)//sağ alt ağaçta arıyoruz
            {
                return 1;
            }
            if (Bul(agac.left, x) == 1)//sol alt ağacta arıyoruz
            {
                return 1;
            }
            return -1;
        }
        int MaxValue(Tree agac)//Maximum Node, Ağacın en sağındaki eleman en büyük eleman
        {
            while(agac.right != null)//sağ alt ağaç null değilse
            {
                agac = agac.right;//en sağ al ağaca git
            }
            return agac.data;
        }
        int MinValue(Tree agac)//Minimum Node, Ağacın en solundaki eleman en küçük elemandır
        {
            if(agac.left != null)//sol alt ağac null değise
            {
                agac = agac.left;//en sol alt ağaca git
            }
            return agac.data;
        }
        Tree Sil(Tree agac, int x)//Deletion İşlemi
        {
            //Sİlme işleminde ya sol alt ağacın en büyük elemanını Root'a getiricez ya da sağ alt ağacın en küçük elemanını Root'a getiricez
            if (agac == null)//ağaç boşsa yani hiç node yoksa
                return null;
            if(agac.data == x)//aradığımız değeri bulduysak
            {
                if(agac.left == null && agac.right == null)//silinecek node'un sağ ve sol alt çocuğu yoksa null döndür
                    return null;
                if (agac.right != null)//agacın sağı null değilse
                {
                    agac.data = MinValue(agac.right);//sağ taraftaki en küçük agac'ı, agacın yerine koy
                    agac.right = Sil(agac.right, MinValue(agac.right));//agacı sil
                    return agac;
                }
                agac.data = MaxValue(agac.left);//sol taraftaki en büyük agac'ı, agacın yerine koy
                agac.left = Sil(agac.left, MaxValue(agac.left));//agacı sil
                return agac;
            }
            if(agac.data < x)
            {
                agac.right = Sil(agac.right, x);//agacın sağındaki değeri sil yine agacın sağı yap
                return agac;
            }
            agac.left = Sil(agac.left, x);//agacın solundaki değeri sil yine agacın solu yap
            return agac;
        }
    }
}