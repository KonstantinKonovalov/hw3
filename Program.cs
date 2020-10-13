using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw3
{
    struct Complex
    {
        public double im;
        public double re;

        public Complex Plus(Complex x)
        {
            Complex y;
            y.im = im + x.im;
            y.re = re + x.re;
            return y;
        }

        public Complex Minus(Complex x)
        {
            Complex y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        public Complex Multi(Complex x)
        {
            Complex y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        override public string ToString()
        {
            return re + "+" + im + "i";
        }
    }

    class ComplexClass
    {
        double im, re;

        public ComplexClass()
        {
            im = 0;
            re = 0;
        }

        public ComplexClass(double im, double re)
        {              
            this.im = im;
            this.re = re;
        }
        public ComplexClass Plus(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = x2.im + im;
            x3.re = x2.re + re;
            return x3;
        }
        public ComplexClass Minus(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = im - x2.im;
            x3.re = re - x2.re;
            return x3;
        }
        public ComplexClass Multi(ComplexClass x2)
        {
            ComplexClass x3 = new ComplexClass();
            x3.im = re * x2.im + im * x2.re;
            x3.re = re * x2.re - im * x2.im;
            return x3;
        }

        public double Im
        {
            get { return im; }
            set
            {
                im = value;
            }
        }
        public double Re
        {
            get { return re; }
            set
            {
                re = value;
            }
        }
        override public string ToString()
        {
            return re + (im < 0 ? "-" : "+") + "i" + Math.Abs(im);
        }
    }
    class Fraction
    {
        long nominator, denominator;

        public Fraction(long nominator, long denominator)
        {
            this.nominator = nominator;
            this.denominator = denominator;
        }
        private static long GCD(long a, long b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            if (a % b == 0) return b;
            return GCD(b, a % b);
        }
        public Fraction Plus(Fraction x)
        {
            long gcd;
            Fraction res = new Fraction(1,1);
            if (denominator == x.denominator)
            {
                res.nominator = nominator + x.nominator;
                res.denominator = denominator;
            }
            else
            {
                res.nominator = nominator * x.denominator + x.nominator * denominator;
                res.denominator = denominator * x.denominator;
            }

            gcd = Fraction.GCD(res.nominator, res.denominator);
        
            res.nominator /= gcd;
            res.denominator /= gcd;
            return res;
        }
        public Fraction Minus(Fraction x)
        {
            Fraction res = new Fraction(1, 1);
            if (denominator == x.denominator)
            {
                res.nominator = nominator - x.nominator;
                res.denominator = denominator;
            }
            else
            {
                res.nominator = nominator * x.denominator - x.nominator * denominator;
                res.denominator = denominator * x.denominator;
            }

            long gcd = Fraction.GCD(res.nominator, res.denominator);

            res.nominator /= gcd;
            res.denominator /= gcd;
            return res;
        }
        public Fraction Divide(Fraction x)
        {
            Fraction res = new Fraction(1, 1);
            res.nominator = nominator * x.denominator;
            res.denominator = denominator * x.nominator;

            long gcd = Fraction.GCD(res.nominator, res.denominator);

            res.nominator /= gcd;
            res.denominator /= gcd;
            return res;
        }
        public Fraction Multi(Fraction x)
        {
            Fraction res = new Fraction(1, 1);
            res.nominator = nominator * x.nominator;
            res.denominator = denominator * x.denominator;

            long gcd = Fraction.GCD(res.nominator, res.denominator);

            res.nominator /= gcd;
            res.denominator /= gcd;
            return res;
        }

        public long Denominator
        {
            get { return denominator; }
            set
            {
                denominator = value;
            }
        }

        public long Nominator
        {
            get { return nominator; }
            set
            {
                nominator = value;
            }
        }

        public double Decimal
        {
            get { return (double) nominator / denominator; }
        }
 
        override public string ToString()
        {

            if ((nominator < 0 && denominator < 0) || (nominator > 0 && denominator > 0))
            {
                return nominator + "/" + denominator;
            }
            else
            {
                return "-" + Math.Abs(nominator) + "/" + Math.Abs(denominator);
            }
            
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Complex complex1;
            complex1.re = 1;
            complex1.im = 1;

            Complex complex2;
            complex2.re = 2;
            complex2.im = 2;

            /*            complex result = complex1.plus(complex2);
                        console.writeline(result.tostring());
                        result = complex1.minus(complex2);
                        console.writeline(result.tostring());
                        result = complex1.multi(complex2);
                        console.writeline(result.tostring());*/


            #region 1. Konstantin Konovalov
            // а) Дописать структуру Complex, добавив метод вычитания комплексных чисел.Продемонстрировать работу структуры.
            // б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса.
            // в) Добавить диалог с использованием switch демонстрирующий работу класса.

            Console.WriteLine("\nПрограмма, демонстрирующая функционал структуры и класса для работы с комплексными числами.\n");
            double re1 = 0.0, im1 = 0.0, re2 = 0.0, im2 = 0.0;
            string[] parts = new string[4];
            do
            {
                Console.Write("Введите два комплексных числа в формате Re1,Im1,Re2,Im2 (напр.: 1,-1,3,7): ");
                parts = Console.ReadLine().Split(',');
            }
            while (!(double.TryParse(parts[0].Trim(), out re1) &&
                    double.TryParse(parts[1].Trim(), out im1) &&
                    double.TryParse(parts[2].Trim(), out re2) &&
                    double.TryParse(parts[3].Trim(), out im2))
            );

            var num1 = new ComplexClass(im1, re1);
            var num2 = new ComplexClass(im2, re2);

            Console.Write("\nВы ввели два комплексных числа " + num1);
            Console.WriteLine(" и " + num2 + "\n");

            int caseSwitch;
            var options = new[] { 1, 2, 3 };
            bool flag;
            do
            {
                Console.Write("\nВведите\n\t 1 для сложения введённых чисел,\n\t " +
                    "2 для вычитания введённых чисел,\n\t " +
                    "3 для умножения введённых чисел,\n\t " +
                    "число отличное от 1, 2 и 3 для выхода: ");
                flag = int.TryParse(Console.ReadLine(), out caseSwitch);
                switch (caseSwitch)
                {
                    case 1:
                        Console.WriteLine($"\nРезультат сложения: {num1.Plus(num2)}");
                        break;
                    case 2:
                        Console.WriteLine($"\nРезультат вычитания: {num1.Minus(num2)}");
                        break;
                    case 3:
                        Console.WriteLine($"\nРезультат умножения: {num1.Multi(num2)}");
                        break;
                    default:
                        Console.WriteLine("\nВыход из программы...");
                        break;
                }
            }
            while (!flag || options.Contains(caseSwitch));
            #endregion

            #region 2. Konstantin Konovalov
            // С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). 
            // Требуется подсчитать сумму всех нечётных положительных чисел. 
            // Сами числа и сумму вывести на экран, используя tryParse.
            int input;
            List<int> elements = new List<int>();
            bool flagB;
            Console.WriteLine("\nПрограмма подсчёта суммы нечётных положительных чисел, введённых пользователем.\n");
            do
            {
                Console.Write("Введите целое число, для выхода введите 0: ");
                flagB = int.TryParse(Console.ReadLine(), out input);
                if (flag && input > 0 && input % 2 == 1) elements.Add(input);
            }
            while (input != 0 || !flagB);
            if (elements.Count > 0)
            {
                Console.WriteLine("\nНечётные положительные числа, введённые пользователем:");
                input = 0;
                foreach (var e in elements)
                {
                    Console.WriteLine($"{e}");
                    input += e;
                }
                Console.WriteLine($"\nСумма нечётных положительных чисел, введённых пользователем: {input}");
            }

            #endregion

            #region 3. Konstantin Konovalov
            // *Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел.
            // *Предусмотреть методы сложения, вычитания, умножения и деления дробей. 
            // *Написать программу, демонстрирующую все разработанные элементы класса.
            // *Добавить свойства типа int для доступа к числителю и знаменателю;
            // *Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
            // **Добавить проверку, чтобы знаменатель не равнялся 0.
            // **Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
            // ***Добавить упрощение дробей.


            // НЕ УСПЕЛ ДОДЕЛАТЬ И ОПТИМИЗИРОВАТЬ !!!
            Console.WriteLine("\nПрограмма работы с дробями.\n");

            var f1 = new Fraction(1, 6);
            var f2 = new Fraction(1, 6);
            var f = f1.Plus(f2);
            Console.WriteLine(f);
            f = f1.Minus(f2);
            Console.WriteLine(f);
            f = f1.Multi(f2);
            Console.WriteLine(f);
            f = f1.Divide(f2);
            Console.WriteLine(f);

            #endregion

            Console.WriteLine("\nДля выхода нажмите любую клавишу...");
            Console.ReadKey();

        }
    }
}
