using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace domashka3
{
    #region задание 1

    /// <summary>
    /// а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
    /// б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса.
    /// в) Добавить диалог с использованием switch демонстрирующий работу класса.
    /// </summary>
    struct strukura // создаем структуру комплекс
    {
        public double im; // создаем переменную im
        public double re; // создаем переменную re
        public strukura(double IM, double RE) // делал это для попробовать короткую запись на ретерн ту стринг
        {
            this.im = IM;
            this.re = RE;
        }

        //  в C# в структурах могут храниться также действия над данными

        //  static void Plus(Complex x) так объявить метод не могу
        public strukura Plus(strukura x) // делает(создает) метод, в данном случае со значениями к complex2 и в нем делает метод который складывает значение частей комплексных чисел 
        {
            strukura y; // создаем структуру , когда вернем y который тут считаем, мы получим значение сложения комплексных чисел comp3.Plus(complex2);  
            y.im = im + x.im; // то что y это новое число , x это Plus(complex2); так как Plus(strukura x) 
            y.re = re + x.re; // im + re это наследованно от comp3.Plus
            return y; // получаем {1+1i} + {2+2i} = {3+3i}
        }
        //  Пример произведения двух комплексных чисел
        public strukura Multi(strukura x) // в этом методе мы будем считать общую часть числа другим способом. не просто сложение, но и вот y.im = re * x.im + im * x.re;
        {
            strukura y;
            y.im = re * x.im + im * x.re;
            y.re = re * x.re - im * x.im;
            return y;
        }
        public strukura minus(strukura x) // надо прям рбязательно все части инициализировать этот метод не используется в программе
        {
            strukura y;
            y.im = im - x.im; // то что y это новое число , x это Plus(complex2); так как Plus(strukura x) 
            y.re = re - x.re; // обязательно должны быть значения
            return y;
        }
        public string ToString()
        {
            //return re + "-" + im + "i"; // notuse=1shalomnotuse
            // Console.WriteLine("public string ToString получает return re - " + "im + i ");
            return $"{re} + {im}i"; // заменил длинную запись выше на покороче

        }
    }


    #endregion
    #region задание 1 б)
    // выбрал этот вариант
    //б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса. // (a1a2−b1b2)+(a1b2+b1a2)i
    class Complex_cl
    {
        // Все методы и поля публичные. Мы можем получить доступ к ним из другого класса.
        public double im;
        public double re;

        public Complex_cl Plus(Complex_cl x2)
        {
            Complex_cl x3 = new Complex_cl();
            x3.im = x2.im + this.im;
            x3.re = x2.re + this.re;
            return x3;
        }
        public Complex_cl minus(Complex_cl x2)
        {
            Complex_cl x3 = new Complex_cl();
            x3.im = x2.im - this.im;
            x3.re = x2.re - this.re;
            return x3;
        }
        public Complex_cl umojil(Complex_cl x2)
        {
            Complex_cl x3 = new Complex_cl();
            x3.im = this.re * x2.im + this.im * x2.re;
            x3.re = this.re * x2.im - this.im * x2.re;
            //y.im = re * x.im + im * x.re;
            //y.re = re * x.re - im * x.im;
            return x3;
        }

        public string ToString()
        {
            return re + "+" + im + "i";
        }
    }
    #endregion
    #region задание 3 создаю класс
    /// <summary>
    /// 3.	*Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей.
    /// Написать программу, демонстрирующую все разработанные элементы класса.
    /// * Добавить свойства типа int для доступа к числителю и знаменателю;
    /// * Добавить свойство типа double только на чтение, чтобы получить десятичную дробь числа;
    /// ** Добавить проверку, чтобы знаменатель не равнялся 0. Выбрасывать исключение ArgumentException("Знаменатель не может быть равен 0");
    /// *** Добавить упрощение дробей.
    /// </summary>
    class Drob
    {
        // Все методы и поля публичные. Мы можем получить доступ к ним из другого класса.
        public int up_str;
        public int down_str;
        public double desyatki;

        public Drob Plus(Drob drob2)
        {
            Drob drob3 = new Drob();
            drob3.up_str = this.up_str * drob2.down_str + drob2.up_str * this.down_str;
            drob3.down_str = drob2.down_str * this.down_str;
            drob3.desyatki = drob3.up_str / drob3.down_str;


            return drob3;
        }


        public Drob minus(Drob drob2)
        {
            Drob drob3 = new Drob();
            /* int up1 = this.up_str * drob2.down_str;
             int up2 = drob2.up_str * this.down_str;
             double up3 = up1 - up2;
             drob2.up_str = Convert.ToInt32(up3);*/
            drob3.up_str = ((this.up_str * drob2.down_str) - (drob2.up_str * this.down_str));
            drob3.down_str = drob2.down_str * this.down_str;
            return drob3;
        }
        public Drob del(Drob drob2)

        {
            Drob drob3 = new Drob();
            drob3.up_str = this.up_str * drob2.down_str;
            drob3.down_str = this.down_str * drob2.up_str;
            return drob3;
        }

        public Drob umnog(Drob drob2)

        {
            Drob drob3 = new Drob();
            drob3.up_str = this.up_str * drob2.up_str;
            drob3.down_str = this.down_str * drob2.down_str;
            return drob3;
        }


        /*public Drob minus(Drob x2)
        {
            Complex_cl x3 = new Complex_cl();
            x3.im = x2.im - this.im;
            x3.re = x2.re - this.re;
            return x3;
        }
        public Drob umojil(Drob x2)
        {
            Complex_cl x3 = new Complex_cl();
            x3.im = this.re * x2.im + this.im * x2.re;
            x3.re = this.re * x2.im - this.im * x2.re;
            //y.im = re * x.im + im * x.re;
            //y.re = re * x.re - im * x.im;
            return x3;
        }

        public string ToString()
        {
            return re + "+" + im + "i";
        }
    }*/
        /* class Drob
         {
             int Drob_up;
             int Drob_down;



             public Drob Plus(Drob x2)
             {
                 Drob result = new Drob();
                 result.Drob_up = x2.Drob_up + this.Drob_up;
                 result.Drob_down = x2.Drob_down + this.Drob_down;
                 return result;
             }

         }*/
        #endregion
        #region Main menu
        class Program
        {

            static int GetValue(string message) // метод который проверит ты ввел инт32 или нет в переменную num_after
            {
                string num_before;
                bool flag_parse;
                int num_after; // нам потребуется спросить номер кейса задачи и у нас есть функционал проверки на то чтобы значение было int 32 и соответсвовало кейсам далее
                do
                {
                    // Console.WriteLine("int.TryParse(num_before, out num_after);");
                    // Console.Clear();
                    Console.WriteLine("Введите номер задачи от 1 до 3. принимаются только целые числа."); // спецально так записал, варианты вывода проверял
                    num_before = Console.ReadLine(); // запишем num_before
                                                     //  Если перевод произошел неправильно, то результатом будет false
                    flag_parse = int.TryParse(num_before, out num_after); // если метод .tryparse сможет сделать int из строки s то он сделает out в num_after тоесть передаст значение num_before в num_after и
                                                                          // сообшит переменной flag true,
                                                                          //  если не получится int32 то сообшит во flag false 
                }
                while (!flag_parse);  //  Пока переворачивает булевое значение flag_parse
                return num_after; // если вечный цикл закончится, метод вернет num_after
            }
            static void Main(string[] args)
            {
                string first_name = "DART";
                string last_name = "VAIDER";
                bool flag_switch = true; //ненужный флаг в моем случае             
                int value; // описываем переменную велью как инт
                do
                {
                    Console.Clear();
                    Console.Title = ("Меню");
                    Console.Clear();
                    Console.WriteLine("Введите номер задачи 1-3.");
                    value = GetValue(""); // даем значение велью методом GetValue // и там метод уже либо пропустит int32 либо будет бесконечно вызыватся, пока ты не напишиш цифры удовлетворяющие условия
                                          // гет валью дает нам проверку на вводимы знаки, а диапазон мы сдесь даже не ставили У НАС ВСЕГО 3 КЕЙСА


                    switch (value)
                    {
                        case 1:
                            dz1(value);

                            break;
                        case 2:
                            dz2();
                            break;
                        case 3:
                            dz3(first_name, last_name);
                            break;
                            /* default:      // тут она не нужна дефаулт, но оставил для примера // выше проверка убивает смысл дкефаулта
                                 flag_switch = !flag_switch; // думаю как сделать проверку на X при чем тут не равно b  // как я понял                     
                                 Console.Write("у меня есть только 3 задачи, не хочу играть, не по правилас, вводи 1-3");
                                 break;*/


                    }
                } while (true);  // только если выполним кейс пройдем дальше, получим true, но тут и так лежит тру
            }

            #endregion
            #region задание 1
            /// <summary>
            /// а) Дописать структуру Complex, добавив метод вычитания комплексных чисел. Продемонстрировать работу структуры.
            /// б) Дописать класс Complex, добавив методы вычитания и произведения чисел.Проверить работу класса.
            /// в) Добавить диалог с использованием switch демонстрирующий работу класса.
            /// </summary>
            /// 

            static void dz1(int value) // надо описать переменную, не хочу новую переменную придумывать для кейсов все равно она не используется, кроме как навигация меню
            {
                Console.Clear();
                Console.Title = ("меню первой задачи");
                Console.WriteLine($"Введи 1 для того чтобы посмотреть вычитание комплексных чисел");
                Console.WriteLine($"Введи 2 для того чтобы посмотреть вычитание и умножение комплексных чисел, представленных в виде класса");
                bool flag_switch = true;
                do
                {

                    Console.Clear();

                    value = GetValue(""); // даем значение велью методом GetValue // и там метод уже либо пропустит int32 либо будет бесконечно вызыватся, пока ты не напишиш цифры удовлетворяющие условия
                                          // гет валью дает нам проверку на вводимы знаки, а диапазон мы сдесь даже не ставили У НАС ВСЕГО 3 КЕЙСА


                    switch (value)
                    {
                        case 1:
                            dz1_a();

                            break;
                        case 2:
                            dz1_b();
                            break;
                        default:      // т
                            flag_switch = !flag_switch; //                   
                            Console.WriteLine("А = 1, Б = 2");
                            break;
                    }
                } //if (input == 0) break;
                while (flag_switch);
                {
                    Console.WriteLine(" пока пока для продолжения нажмит любую клавишу");
                    Console.ReadKey();
                }

            }
            #region dz1_a
            static void dz1_a()
            {
                Console.Clear();
                Console.Title = ("задача 1-а ");
                strukura comp3; // мы объявляем какойто комлекс числа, в виде структуры и оно должно получить хоть какоето значение в данном примере
                comp3.im = 1; // сообщаем числу comp3, часть im  - im это переменная , мы почемуто её не объявили раньше, а объявим в структуре
                comp3.re = 1;  // сообщаем числу comp3, часть re  - re это переменная , и мы дали ей значение
                Console.WriteLine($"comp3 = {comp3.im} + {comp3.re}i");

                strukura complex2 = new strukura(2, 2);
                // дописал  public Complex(double IM, double RE)
                //{
                //    this.im = IM;
                //    this.re = RE;
                //}
                /* strukura complex2; // объявляем другой комлес числа
                 complex2.re = 2;
                 complex2.im = 2;*/

                strukura result = comp3.minus(complex2); // сразу объявляем структуру result  и даем = comp3 и вызываем к нему метод минус от complex2 

                // по заданию, нам остается продемонстрировать как почситается комплес, но комлекс надо еще представить в виде строки пишим метод

                Console.WriteLine($"complex3 = {comp3} - {complex2}");
                Console.WriteLine($"complex2 = {complex2.im} + {complex2.re}i"); // надо обработать ту стринг

                Console.WriteLine($"результат вычитания комплексных чисел посредством структуры = {result.im} + {result.re}i"); // ту стринг метод нужен?

                Console.WriteLine(result.ToString());

                Console.ReadKey();
            }
            #endregion
            #region dz1_b
            static void dz1_b()
            {
                Console.Clear();
                Console.Title = ("задача 1-б");
                Complex_cl complex1 = new Complex_cl();
                complex1.re = 1;
                complex1.im = 1;
                Console.WriteLine($"complex1 = {complex1.re} + {complex1.im}i");


                Complex_cl complex2 = new Complex_cl();
                complex2.re = 2;
                complex2.im = 2;
                Console.WriteLine($"complex2 = {complex2.re} + {complex2.im}i");

                Complex_cl result = complex1.umojil(complex2); // перезапишем resulrs он же complex3 
                Console.WriteLine($"complex3 = {result.re} + {result.im}i");
                Console.WriteLine($"({complex1.im} + {complex1.re}i) * ({complex2.im} + {complex2.re}i) = complex3 = {result.re} + {result.im}i");
                Console.WriteLine($"результат умножения комплексных чисел посредством класса = ({complex1.im} + {complex1.re}i) * ({complex2.im} + {complex2.re}i) = complex3 = {result.re} + {result.im}i");
                Console.WriteLine(result.ToString());
                Console.ReadKey();
                // в конец запутался но вроде реализовал формулу
            }
            #endregion
            #endregion
            #region задание 2 С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечётных положительных чисел. 

            /// <summary>
            /// С клавиатуры вводятся числа, пока не будет введён 0 (каждое число в новой строке). Требуется подсчитать сумму всех нечётных положительных ЦЕЛЫХ чисел.
            /// </summary>
            static void dz2()
            {

                Console.Title = ("2.	С клавиатуры вводятся числа, пока не будет введен 0. ");
                double score = 0;
                double input = 0;
                double into = 0;
                bool flag = false;


                while (true) // Вечный цикл
                {
                    while (!flag)
                    {
                        Console.Clear(); // Чистим консоль.
                        Console.WriteLine($"Сумма всех чисел = {score}"); // Вывод суммы чисел.
                        Console.Write("Повторите ввод числа: "); // Вывод сообщения.

                        flag = double.TryParse(Console.ReadLine(), out input); // Защита от дурака // try parse то что я искал // out input записывает в input
                        if (input > 0 && input % 2 == 1) // делаем условие проверка на нечет и положительное
                            into = input; // если условие выполнено, записываем введенное число, дальше мы его сложим
                        else
                            into = 0; // условие не выполнено, даем введенному значению 0 и не пытаемся trytoparse
                    }

                    flag = false; // Избавляемся от бага. // запомни это  // баг когда вводим double
                    score = score + into; // Прибавляем к сумме чисел новое число прошедшее условие проверки на + и нечет

                    if (input == 0) break; // Выход из вечного цикла:
                }

                Console.Clear(); // Чистим консоль.
                Console.WriteLine($"Итоговая сумма всех чисел: {score}"); // Вывод итоговой суммы чисел.
                Console.ReadKey(); // Ждём нажатие клавиши.
            }

            #endregion
            #region задание задача 3 , числители знаменатели дроби
            /// <summary>
            ///3.	*Описать класс дробей — рациональных чисел, являющихся отношением двух целых чисел. Предусмотреть методы сложения, вычитания, умножения и деления дробей.
            /// Написать программу, демонстрирующую все разработанные элементы класса.
            /// </summary>
            static void dz3(string first_name, string last_name)
            {
                /*double chislitel;
                int znamenatel;
                bool x;
                Console.Clear();
                Console.Title = ("задача 3 , числители знаменатели дроби");
                Drob drob1 = new Drob();
                Console.WriteLine($"Привет, сейчас мы будем складывать, умножать,делить, вычитать ДРОБИ" +
                    $"Введи числитель:");
                flag = int.TryParse(Console.ReadLine(), out drob1.up_str); // Защита от дурака // try parse то что я искал // out input записывает в input
               // drob1.up_str = 1;
                drob1.down_str = 1;
                Console.WriteLine($"complex1 = {chislitel.up_str}^ " +
                    $"| {drob1.down_str}down");*/
                bool flag_drob;
                Console.Clear();
                Console.Title = ("задача 3");
                Drob drob1 = new Drob();
                drob1.up_str = 1;
                Console.WriteLine($"Привет, сейчас мы будем складывать, умножать,делить, вычитать ДРОБИ ");
                Console.WriteLine($"Введи числитель:");
                flag_drob = int.TryParse(Console.ReadLine(), out drob1.up_str);
                drob1.down_str = 1;
                int input_z = 0;

                // нужна проверка на ввод знаменатель !=0
                Console.WriteLine($"Введи знаменатель:");
                while (true) // Вечный цикл
                {
                    flag_drob = int.TryParse(Console.ReadLine(), out input_z); // Защита от дурака // try parse то что я искал // out input записывает в input

                    while (!flag_drob)
                    {

                        if (input_z != 0) // делаем условие проверка на нечет и положительное
                            drob1.down_str = input_z; // если условие выполнено, записываем введенное число, дальше мы его сложим
                        else
                            input_z = 0; // условие не выполнено, даем введенному значению 0 и не пытаемся trytoparse
                        Console.WriteLine("");
                        Console.WriteLine("Повторите ввод числа: "); // Вывод сообщения. если пробел сообщить

                        flag_drob = int.TryParse(Console.ReadLine(), out input_z); // Защита от дурака // try parse то что я искал // out input записывает в input
                        break;
                    }

                    flag_drob = !false; // Избавляемся от бага. // запомни это  // баг когда вводим double
                    // score = score + into; // Прибавляем к сумме чисел новое число прошедшее условие проверки на + и нечет
                    drob1.down_str = input_z;
                    if (input_z != 0)
                    {
                        Console.SetCursorPosition(0, 3);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("ArgumentException(вы устранили конфликт - знаменатель не может быть равен 0) || на 0 делить нельзя"); // Вывод сообщения
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    } // Выход из вечного цикла:
                    else if (input_z == 0)
                        Console.SetCursorPosition(0, 3);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ArgumentException(Знаменатель не может быть равен 0) || введите корректное значение: "); // Вывод сообщения. // Выход из вечного цикла:
                    Console.ForegroundColor = ConsoleColor.White;
                }

                /* Console.WriteLine($"Введи знаменатель:");
                 flag_drob = int.TryParse(Console.ReadLine(), out drob1.down_str);
                /* if (input > 0 && input % 2 == 1) // делаем условие проверка на нечет и положительное
                     into = input; // если условие выполнено, записываем введенное число, дальше мы его сложим
                 else
                     into = 0; // условие не выполнено, даем введенному значению 0 и не пытаемся trytoparse
             }*/
                Console.WriteLine($"chislitel  =_{drob1.up_str}_ | ");
                Console.WriteLine($"znamenatel = {drob1.down_str}  | ");

                Console.WriteLine($"А сейчас введем вторую дробь ");

                Drob drob2 = new Drob();
                Console.WriteLine($"Привет, сейчас мы будем складывать, умножать,делить, вычитать ДРОБИ ");
                Console.WriteLine($"Введи числитель:");
                flag_drob = int.TryParse(Console.ReadLine(), out drob2.up_str);
                Console.WriteLine($"Введи знаменатель:");

                //проверка на не 0
                while (true) // Вечный цикл
                {
                    flag_drob = int.TryParse(Console.ReadLine(), out input_z); // Защита от дурака // try parse то что я искал // out input записывает в input

                    while (!flag_drob)
                    {

                        if (input_z != 0) // делаем условие проверка на нечет и положительное
                            drob1.down_str = input_z; // если условие выполнено, записываем введенное число, дальше мы его сложим

                        else
                            input_z = 0; // условие не выполнено, даем введенному значению 0 и не пытаемся trytoparse
                        Console.WriteLine("");
                        Console.WriteLine("Повторите ввод числа: "); // Вывод сообщения.Вывод сообщения. если пробел сообщить

                        flag_drob = int.TryParse(Console.ReadLine(), out input_z); // Защита от дурака // try parse то что я искал // out input записывает в input
                        break;
                    }

                    flag_drob = !false; // Избавляемся от бага. // запомни это  // баг когда вводим double
                    // score = score + into; // Прибавляем к сумме чисел новое число прошедшее условие проверки на + и нечет
                    drob2.down_str = input_z;
                    if (input_z != 0)
                    {
                        Console.SetCursorPosition(0, 11);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("ArgumentException(вы устранили конфликт - знаменатель не может быть равен 0) || на 0 делить нельзя"); // Вывод сообщения
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                    }// Выход из вечного цикла:
                    else if (input_z == 0)
                        Console.SetCursorPosition(0, 11);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ArgumentException(Знаменатель не может быть равен 0) || введите корректное значение: "); // Вывод сообщения. // Выход из вечного цикла:
                    Console.ForegroundColor = ConsoleColor.White;
                }
                // конец проверки

                // flag_drob = int.TryParse(Console.ReadLine(), out drob2.down_str);
                Console.WriteLine($"chislitel  =_{drob2.up_str}_ | ");
                Console.WriteLine($"znamenatel = {drob2.down_str}  | ");

                // начинаем операции они же методы сложения итд

                Drob result_plus = drob1.Plus(drob2); // перезапишем resulrs он же result_plus 

                Console.WriteLine($"результат сложения числитель  = {drob1.up_str}  +  {drob2.up_str}  =  {result_plus.up_str}");
                Console.WriteLine($"результат сложения знаменател = {drob1.down_str}     {drob2.down_str}  =  {result_plus.down_str}  ||  {result_plus.up_str}/{result_plus.down_str}  || " +
                    $" НОД числителя и знаменателя {NOD(result_plus.up_str, result_plus.down_str) } =  {result_plus.up_str / NOD(result_plus.up_str, result_plus.down_str)}/{result_plus.down_str / NOD(result_plus.up_str, result_plus.down_str)}  ");
                Console.WriteLine($"сокращенная дробь = {result_plus.up_str / NOD(result_plus.up_str, result_plus.down_str)}/{result_plus.down_str / NOD(result_plus.up_str, result_plus.down_str)}  ");
                double plus_up = Convert.ToDouble(result_plus.up_str);
                double plus_down = Convert.ToDouble(result_plus.down_str);
                //Console.WriteLine($"результат сложения дробей в виде десятичной дроби = {result_plus.up_str} / {result_plus.down_str}  =  {result_plus.desyatki:f5}"); // так не считает // с инт округляет до ближайшего целого вниз
                Console.WriteLine($"результат сложения дробей в виде десятичной дроби = {plus_up} / {plus_down}  =  {plus_up / plus_down}");
                Console.WriteLine("НОД от числителя " + result_plus.up_str + " и знаменателя " + result_plus.down_str + " Получается = " + NOD(result_plus.up_str, result_plus.down_str));
                Console.WriteLine($"");

                // начинаем операции вычетания дробей

                Drob result_minus = drob1.minus(drob2); // перезапишем resulrs он же result_minus 

                Console.WriteLine($"результат вычетания числитель  = {drob1.up_str}  -  {drob2.up_str}  =  {result_minus.up_str}");
                Console.WriteLine($"результат вычетания знаменател = {drob1.down_str}     {drob2.down_str}  =  {result_minus.down_str}  ||  {result_minus.up_str}/{result_minus.down_str} ");
                Console.WriteLine($"сокращенная дробь = {result_minus.up_str / NOD(result_minus.up_str, result_minus.down_str)}/{result_minus.down_str / NOD(result_minus.up_str, result_minus.down_str)}  ");
                double minus_up = Convert.ToDouble(result_minus.up_str);
                double minus_down = Convert.ToDouble(result_minus.down_str);
                Console.WriteLine($"результат вычетания дробей в виде десятичной дроби = {minus_up} / {minus_down}  =  {minus_up / minus_down}");
                Console.WriteLine($"");

                // начинаем операции деления дробей

                Drob result_delen = drob1.del(drob2); // перезапишем resulrs он же result_minus 

                Console.WriteLine($"результат деления числитель  = {drob1.up_str}  /  {drob2.up_str}  =  {result_delen.up_str}");
                Console.WriteLine($"результат деления знаменател = {drob1.down_str}     {drob2.down_str}  =  {result_delen.down_str}  ||  {result_delen.up_str}/{result_delen.down_str} ");
                Console.WriteLine($"сокращенная дробь = {result_delen.up_str / NOD(result_delen.up_str, result_delen.down_str)}/{result_delen.down_str / NOD(result_delen.up_str, result_delen.down_str)}  ");

                double delen_up = Convert.ToDouble(result_delen.up_str);
                double delen_down = Convert.ToDouble(result_delen.down_str);
                Console.WriteLine($"результат деления дробей в виде десятичной дроби = {delen_up} / {delen_down}  =  {delen_up / delen_down}");
                Console.WriteLine($"");


                // начинаем операции умножения дробей

                Drob result_umnogenie = drob1.umnog(drob2);
                Console.WriteLine($"результат умножения числитель  = {drob1.up_str}  *  {drob2.up_str}  =  {result_umnogenie.up_str}");
                Console.WriteLine($"результат умножения знаменател = {drob1.down_str}     {drob2.down_str}  =  {result_umnogenie.down_str}  ||  {result_umnogenie.up_str}/{result_umnogenie.down_str} ");
                Console.WriteLine($"сокращенная дробь = {result_umnogenie.up_str / NOD(result_umnogenie.up_str, result_umnogenie.down_str)}/{result_umnogenie.down_str / NOD(result_umnogenie.up_str, result_umnogenie.down_str)}  ");

                double umnogenie_up = Convert.ToDouble(result_umnogenie.up_str);
                double umnogenie_down = Convert.ToDouble(result_umnogenie.down_str);
                Console.WriteLine($"результат умножения дробей в виде десятичной дроби = {umnogenie_up} / {umnogenie_down}  =  {umnogenie_up / umnogenie_down}");
                Console.WriteLine($"");

                /*
                Console.WriteLine("Привет, сегодня мы попробуем вычеслить алгоритм Евклида. НОД - является наибольшим целым числом, которое может разделять два значения без остатка");
                Console.ReadKey();
                Console.SetCursorPosition(10, 15);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Clear();
                Console.Write("Введи первое число:");
                int a = Convert.ToInt32(Console.ReadLine());
                Console.SetCursorPosition(10, 15);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Clear();
                Console.Write("Введи второе число:");
                int b = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                Console.SetCursorPosition(10, 15);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("НОД от первого числа " + a + " и второго числа " + b + " Получается = " + NOD(a, b)); // выводит на экран результат выполнения метода от переменных A и B 
                Console.ReadKey();
            */



                //CREDITS 
                #region credits
                Console.SetCursorPosition(13, 36);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Автор : " + first_name + " " + last_name);
                Console.SetCursorPosition(10, 38);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("THE FORCE BE WITH U... SEE YA LATER");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("AND WITH THE FORCE... I WILL REDUCE FRACTURE ");
                Console.ForegroundColor = ConsoleColor.White;
                #endregion
                /* 

                 Complex_cl result = complex1.umojil(complex2); // перезапишем resulrs он же complex3 

                 Console.WriteLine($"complex3 = {result.re} + {result.im}i");

                 Console.WriteLine($"({complex1.im} + {complex1.re}i) * ({complex2.im} + {complex2.re}i) = complex3 = {result.re} + {result.im}i");
                 Console.WriteLine($"результат умножения комплексных чисел посредством класса = ({complex1.im} + {complex1.re}i) * ({complex2.im} + {complex2.re}i) = complex3 = {result.re} + {result.im}i");
                 Console.WriteLine(result.ToString());*/
                Console.ReadKey();
                // в конец запутался но вроде реализовал формулу
            }
            static int NOD(int a, int b) // Описывает вычесления НОД от двух чисел // позже вызовем метод вычисления 1ой строкой
            {
                ////////////////////////////////////////////////// Проверка НОД по модулю числителя и знаменателя
                if (a < 0) { // если меньше 0
                    a = Convert.ToInt32( Math.Sqrt((Math.Pow(a,2)))); // преобразуем в положительное
                }
                else if (b < 0)// если меньше 0
                {// преобразуем в положительное
                    b = Convert.ToInt32(Math.Sqrt((Math.Pow(b, 2))));
                }
                ///////////////////////////////////////////////////////////// конец проверки
                while (a != b) // если а не равно б
                    if (a > b) a = a - b; else b = b - a;
                return a;
            }

            #endregion



        }
    }
}
