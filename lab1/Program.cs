//JUSTYNA DREGER
//nr. albumu: 39254
//dj39254@zut.edu.pl

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace lab1
{
    class Table {
        //liczba kolumn
        int columns;
        //wszystkie elementy pliku
        List<string> elements;
        //tresc wierszy
        List<string> values;
        //tresc stopki
        List<string> foot;
        //tresc naglowka
        List<string> head;
        public Table(int columns,List<string>values,List<string>head,List<string>foot) {
            this.columns = columns;
            this.elements = new List<string>();
            this.values = values.ToList();
            this.head = head;
            this.foot = foot;
        }
        public Table(int columns) {
            this.columns = columns;
            this.elements = new List<string>();
        }
        //dodanie zawartości komórek tabeli
        public void AddValues(List<string> list) { this.values = list; }
        //dodanie nagłówka
        public void AddHead(List<string> list) { this.head = list; }
        //dodanie stopki
        public void AddFoot(List<string> list) { this.foot = list; }
        //dodanie wiersza
        public void AddRow(List<string> list) {
            if (values == null) {
                this.values = new List<string>();
            }
            foreach (string l in list) {
                this.values.Add(l);
            }
        }
        //dodanie ciała
        private void AddBody() {
            elements.Add("<tbody>");
            int i = 0;
            foreach (string value in values) {
                if (i == 0) {
                    elements.Add("<tr>");
                }
                elements.Add("<td>"+value+"</td>");
                i++;
                if (i == columns)
                {
                    elements.Add("</tr>");
                    i = 0;
                }
            }
            elements.Add("</tbody>");
        }
        //tworzenie tabeli
        public List<string> MakeTable() {
            elements.Add("<table>");
            if (head != null) {
                elements.Add("<thead><tr>");
                foreach (string h in head) {
                    elements.Add("<th>"+h+"</th>");
                }
                elements.Add("</tr></thead>");
            }
            if (values != null) {
                AddBody();
            }
            if (foot != null) {
                elements.Add("<tfoot><tr>");
                foreach (string f in foot)
                {
                    elements.Add("<td>" + f + "</td>");
                }
                elements.Add("</tr></tfoot>");
            }
            elements.Add("</table>");
            return elements;
        }
    }
    class Program
    {
        //tabela 2x2 z prostymi liczbami
        static void Test1()
        {
            Console.WriteLine("\nTEST 1 - TABELA 2X2 Z PROSTYMI LICZBAMI\n");
            string file = "plik1.html";
            StreamWriter writer = File.CreateText(file);
            List<string> values = new List<string>();
            for (int i = 10; i < 14; i++) {
                values.Add(i.ToString());
            }
            Table table = new Table(2, values, null, null);
            writer.WriteLine("<!DOCTYPE html>");
            foreach (string c in table.MakeTable())
            {
                writer.WriteLine(c);
            }
            writer.Close();
            Console.WriteLine(" ZAJRZYJ DO PLIKU " +file);
        }
        //tabela 2x3 z długimi tekstami
        static void Test2() {
            Console.WriteLine("\nTEST 2 - TABELA 2X3 Z DLUGIMI TEKSTAMI\n");
            string file = "plik2.html";
            StreamWriter writer = File.CreateText(file);
            List<string> values = new List<string>();
            values.Add("Justyna");
            values.Add("Katarzyna");
            values.Add("Faustyna");
            values.Add("Aleksandra");
            values.Add("Anastazja");
            values.Add("Magdalena");
            Table table = new Table(3, values, null, null);
            writer.WriteLine("<!DOCTYPE html>");
            foreach (string c in table.MakeTable())
            {
                writer.WriteLine(c);
            }
            writer.Close();
            Console.WriteLine("ZAJRZYJ DO PLIKU "+file);
        }
        //odczyt danych z pliku, zapis do pliku .html
        static void Test3() {
            Console.WriteLine("\nTEST 3 - ODCZYT DANYCH I ZAPIS DO PLIKU HTML\n");
            string file = "plik3.html";
            StreamWriter writer= File.CreateText(file);
            var read = File.ReadAllLines("dane.txt");
            List<string> values = new List<string>();
            foreach (var line in read) {
                var l=line.Split(';');
                foreach (var k in l)
                {
                    values.Add(k.ToString());
                }
            }
            Table table = new Table(3,values,null,null);
            //zapis do pliku
            writer.WriteLine("<!DOCTYPE html>");
            foreach (string el in table.MakeTable())
            {
                writer.WriteLine(el);
            }
            writer.Close();
            Console.WriteLine("ZAJRZYJ DO PLIKU "+file);
        }
        //tabela 2x5 z wierszem nagłówkowym
        static void Test4() {
            Console.WriteLine("\nTEST 4 - TABELA 2X5 Z WIERSZEM NAGLOWKOWYM\n");
            string file = "plik4.html";
            StreamWriter writer = File.CreateText(file);
            List<string> values = new List<string>();
            values.Add("1");
            values.Add("Justyna");
            values.Add("Dreger");
            values.Add("dj39254@zut.edu.pl");
            values.Add("22.01.97");
            values.Add("2");
            values.Add("Krzysztof");
            values.Add("Kowalski");
            values.Add("kk23456@gmail.com");
            values.Add("12.12.67");
            List<string> head = new List<string>();
            head.Add("nr");
            head.Add("Imie");
            head.Add("Nazwisko");
            head.Add("E-mail");
            head.Add("Data");
            Table table = new Table(5, values, head, null);
            writer.WriteLine("<!DOCTYPE html>");
            foreach (string el in table.MakeTable())
            {
                writer.WriteLine(el);
            }
            writer.Close();
            Console.WriteLine("ZAJRZYJ DO PLIKU "+file);
        }
        static void Main(string[] args)
        {
            Test1();
            Console.WriteLine();
            Test2();
            Console.WriteLine();
            Test3();
            Console.WriteLine();
            Test4();
        }
    }
}
