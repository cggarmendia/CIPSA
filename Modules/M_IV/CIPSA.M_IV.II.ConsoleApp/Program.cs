using CIPSA.Util.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA.M_IV.II.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var answerOfQuestion = string.Empty;
            var correctAnswerOfExerciseOption = new List<string>() { "E", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18", "19", "20", "21" };
            var exerciseNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21 };
            do
            {
                answerOfQuestion = ConsoleAppUtil.ShowExerciseOption(answerOfQuestion, exerciseNumbers, correctAnswerOfExerciseOption);

                M_IV_II_Logic.ExecuteExercise(answerOfQuestion);

                RestartAnswerOfQuestion(ref answerOfQuestion);
            }
            while (answerOfQuestion != "E");
        }

        private static void RestartAnswerOfQuestion(ref string answerOfQuestion)
        {
            if (int.TryParse(answerOfQuestion, out int exercise))
                answerOfQuestion = string.Empty;
        }
    }

    class M_IV_II_Logic
    {
        #region Execute-Exercise

        public static void ExecuteExercise(string answerOfQuestion)
        {
            if (int.TryParse(answerOfQuestion, out int exercise))
                switch (exercise)
                {
                    case 1:
                        Exercise1();
                        break;
                    case 2:
                        Exercise2();
                        break;
                    case 3:
                        Exercise3();
                        break;
                    case 4:
                        Exercise4();
                        break;
                    case 5:
                        Exercise5();
                        break;
                    case 6:
                        Exercise6();
                        break;
                    case 7:
                        Exercise7();
                        break;
                    case 8:
                        Exercise8();
                        break;
                    case 9:
                        Exercise9();
                        break;
                    case 10:
                        Exercise10();
                        break;
                    case 11:
                        Exercise11();
                        break;
                    case 12:
                        Exercise12();
                        break;
                    case 13:
                        Exercise13();
                        break;
                    case 14:
                        Exercise14();
                        break;
                    case 15:
                        Exercise15();
                        break;
                    case 16:
                        Exercise16();
                        break;
                    case 17:
                        Exercise17();
                        break;
                    case 18:
                        Exercise18();
                        break;
                    case 19:
                        Exercise19();
                        break;
                    case 20:
                        Exercise20();
                        break;
                    case 21:
                        Exercise21();
                        break;
                }
        }

        #endregion

        #region Exercise1

        private static void Exercise1()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 1:");
            
            var questions = new string[] {
                "Introduzca su nombre:",
                "Introduzca sus apellidos:",
                "Introduzca su edad:"
            };

            var name = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[0]);

            var lastName = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[1]);

            var age = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive(questions[2], 150);

            ConsoleAppPrintUtil.PrintText(GetExercise1Text(name, lastName, age));
        }

        private static string GetExercise1Text(string name, string lastName, int age)
        {
            var exercise5Text = new StringBuilder();

            exercise5Text.AppendLine("Los datos introducidos fueron");
            exercise5Text.AppendLine($"Nombre: {name}. ");
            exercise5Text.AppendLine($"Apellidos: {lastName}.");
            exercise5Text.AppendLine($"Edad: {age}. ");

            return exercise5Text.ToString();
        }
        
        #endregion

        #region Exercise2

        private static void Exercise2()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 2:");

            var questions = new string[] {
                "Introduce un número aleatorio: ",
                "Introduce otro número aleatorio: "
            };

            var number1 = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(questions[0]);

            var number2 = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(questions[1]);

            ConsoleAppPrintUtil.PrintText(GetExercise2Text(number1, number2));
        }

        private static string GetExercise2Text(int number1, int number2)
        {
            var text = string.Empty;
            if (number1 == number2)
                text = $"El mayor número entre: {number1} y {number2} es: {number2}";
            else if (number1 < number2)
                text = $"El mayor número entre: {number1} y {number2} es: {number2}";
            else
                text = $"El mayor número entre: {number1} y {number2} es: {number1}";
            return text;
        }

        #endregion

        #region Exercise3

        private static void Exercise3()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 3:");

            var noteExam = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive("Introduce la nota del examen: ", 10);

            ConsoleAppPrintUtil.PrintText(GetExercise3Text(noteExam));
        }

        private static string GetExercise3Text(int noteExam)
        {
            var text = string.Empty;
            if (noteExam <= 5)
                text = $"Suspenso con nota: {noteExam}";
            else
                text = $"Aprobado con nota: {noteExam}";
            return text;
        }

        #endregion

        #region Exercise4

        private static void Exercise4()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 4:");

            var noteExam = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive("Introduce la nota del examen: ", 10);

            ConsoleAppPrintUtil.PrintText(GetExercise4Text(noteExam));
        }

        private static string GetExercise4Text(int noteExam)
        {
            var text = string.Empty;

            if (noteExam <= 5)
                text = $"Suspenso con nota: {noteExam}";
            else if (noteExam >= 5 & noteExam < 7)
                text = $"Aprobado con nota: {noteExam}";
            else if (noteExam >= 7 & noteExam < 9)
                text = $"Notable con nota: {noteExam}";
            else if (noteExam == 9)
                text = $"Sobresaliente con nota: {noteExam}";
            else
                text = $"Matrícula de honor con nota: {noteExam}";

            return text;
        }

        #endregion

        #region Exercise5

        private static void Exercise5()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 5:", useReadLine: false);

            var random = new Random();

            var number1 = random.Next(10, 100);
            var number2 = random.Next(10, 100);
            var number3 = random.Next(10, 100);

            ConsoleAppPrintUtil.PrintText(GetExercise5PrintRandom(number1, number2, number3));

            ConsoleAppPrintUtil.PrintText(GetExercise5Text(number1, number2, number3));
        }

        private static string GetExercise5PrintRandom(int number1, int number2, int number3)
        {
            var exercise5RandomText = new StringBuilder();

            exercise5RandomText.AppendLine($"Primer número aleatorio: {number1}");

            exercise5RandomText.AppendLine($"Segundo número aleatorio: {number2}");

            exercise5RandomText.AppendLine($"Tercer número aleatorio: {number3}");

            return exercise5RandomText.ToString();
        }

        private static string GetExercise5Text(int number1, int number2, int number3)
        {
            var exercise5Text = new StringBuilder();

            var average = (number1 + number2 + number3) / 3;
            exercise5Text.AppendLine($"El promedio de los tres números es: {average}");

            var max = Math.Max(number1, Math.Max(number2, number3));
            exercise5Text.AppendLine($"El mayor número entre: {number1}, {number2} y {number3} es: {max}");

            var min = Math.Min(number1, Math.Min(number2, number3));
            exercise5Text.AppendLine($"El menor número entre: {number1}, {number2} y {number3} es: {min}");

            return exercise5Text.ToString();
        }
        
        #endregion

        #region Exercise6

        private static void Exercise6()
        {
            ConsoleAppPrintUtil.PrintText("Alcance no definido en el ejercicio.");
        }

        #endregion

        #region Exercise7

        private static void Exercise7()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 7:");

            var questions = new string[]{
                "¿En qué año estamos? ",
                "Escribe un año cualquiera: "
            };

            var year = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[0]);
            
            var yearRandom = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[1]);

            ConsoleAppPrintUtil.PrintText(GetExercise7Text(year, yearRandom));
        }

        private static string GetExercise7Text(int year, int yearRandom)
        {
            var text = string.Empty;

            if (year == yearRandom)
                text = "¡Son el mismo año!";
            else if (year < yearRandom)
                text = $"Para llegar al año: {yearRandom} faltan: {yearRandom - year} años.";
            else
                text = $"Desde el año {yearRandom} han pasado {year - yearRandom} años.";

            return text;
        }

        #endregion

        #region Exercise8

        private static void Exercise8()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 8:");

            var questions = new string[] {
                "Escribe un número: ",
                "Escribe otro número: ",
                "Escribe otro número más: "
            };

            var number1 = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[0]);

            var number2 = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[1]);

            var number3 = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[2]);
            
            ConsoleAppPrintUtil.PrintText(GetExercise8Text(number1, number2, number3));
        }

        private static string GetExercise8Text(int number1, int number2, int number3)
        {
            var text = string.Empty;

            if (number1 == number2 && number2 == number3)
                text = $"Has escrito los tres números iguales: {number1}, {number2} y {number3}.";
            else if (number1 == number2 || number3 == number2 || number1 == number3)
                text = $"Has escrito un de los números dos veces: {number1}, {number2} y {number3}.";
            else
                text = $"Los tres números escritos son distintos: {number1}, {number2} y {number3}.";

            return text;
        }

        #endregion

        #region Exercise9

        private static void Exercise9()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 9:", useReadLine: false);

            for (int forIndex = 0; forIndex < 100; forIndex++)
                ConsoleAppPrintUtil.PrintText($"ForLoop - {forIndex + 1} - No lanzaré avioncitos de papel en clase.", useConsoleClear: false, useReadLine: false);

            int doIndex = 0;
            do
            {
                ConsoleAppPrintUtil.PrintText($"DoLoop - {doIndex + 1} - No lanzaré avioncitos de papel en clase.", useConsoleClear: false, useReadLine: false);        
                doIndex++;
            } while (doIndex < 100);

            int whileIndex = 0;
            while (whileIndex < 100)
            {
                ConsoleAppPrintUtil.PrintText($"WhileLoop - {whileIndex + 1} - No lanzaré avioncitos de papel en clase.", useConsoleClear: false, useReadLine: false);
                whileIndex++;
            }

            ConsoleAppPrintUtil.PrintText("Ciclos terminados.", useConsoleClear: false);

        }

        #endregion

        #region Exercise10

        private static void Exercise10()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 10:");

            var number = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive("Escribe un número entre 1 y 10: ", 10);

            ConsoleAppPrintUtil.PrintText($"Tabla de mutiplicar del {number}.", useReadLine: false);
            for (int i = 1; i <= 10; i++)
                ConsoleAppPrintUtil.PrintText($"{number}x{i}={number * i}", useConsoleClear: false, useReadLine: false);

            ConsoleAppPrintUtil.PrintText("", useConsoleClear: false);
        }

        #endregion

        #region Exercise11

        private static void Exercise11()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 11:");

            var number = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("Escribe un número: ");

            int factorial = 1;

            for (int i = 1; i <= number; i++)
            {
                factorial = factorial * i;
            }

            ConsoleAppPrintUtil.PrintText($"El factorial de {number} es: {factorial}");
        }

        #endregion

        #region Exercise12

        private static void Exercise12()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 12:");

            var cantNumbers = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("¿Cuántos números introducirás?");

            var sum = 0;

            for (int i = 0; i < cantNumbers; i++)
                sum = sum + ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive($"Introduzca el número {i+1} de {cantNumbers}: ");
            
            ConsoleAppPrintUtil.PrintText($"La suma de los números introducidos es: {sum}");
        }

        #endregion

        #region Exercise13

        private static void Exercise13()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 13:");

            var number = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("Introduzca un número para multiplicarlo por los siguientes 5 números:");

            var multiply = 1M;

            for (int i = number; i < number + 5; i++)
                multiply *= i;

            ConsoleAppPrintUtil.PrintText($"El producto de {number} con sus siguientes 5 números es: {multiply}");
        }

        #endregion

        #region Exercise14

        private static void Exercise14()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 14:");

            var cantNumber = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("¿Cuántos números va a introducir?");

            var numbers = new List<int>();

            for (int i = 0; i < cantNumber; i++)
                numbers.Add(ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive($"Introduzca el número {i + 1}:"));

            var cantNegative = numbers.Count(number => number < 0);

            ConsoleAppPrintUtil.PrintText($"La cantidad de números negativos introducida es: {cantNegative}");
        }

        #endregion

        #region Exercise15

        private static void Exercise15()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 15:");

            var numbers = new List<int>();

            var isNegative = false;
            do
            {
                var number = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive($"Introduzca un número entero:");
                if (number > 0)
                    numbers.Add(number);
                else
                    isNegative = true;
            } while (!isNegative && numbers.Count() < 10);

            ConsoleAppPrintUtil.PrintText($"Los números introducidos fueron: {String.Join(",", numbers)}");
        }

        #endregion

        #region Exercise16

        private static void Exercise16()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 16:");

            var high = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("Introduzca el alto del rectángulo:");
            var width = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("Introduzca el ancho del rectángulo:");

            ConsoleAppPrintUtil.PrintText(GetExercise16Text(high, width));
        }

        private static string GetExercise16Text(int high, int width)
        {
            var exercise16Text = new StringBuilder();

            exercise16Text.AppendLine($"Alto del rectángulo: {high}");
            exercise16Text.AppendLine($"Ancho del rectángulo: {width}");

            for (int i = 0; i < high; i++)
            {
                var row = new StringBuilder();
                for (int j = 0; j < width; j++)
                    row.Append("*");
                exercise16Text.AppendLine(row.ToString());
            }

            return exercise16Text.ToString();
        }

        #endregion

        #region Exercise17

        private static void Exercise17()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 17:");

            var high = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("Introduzca el altura del triángulo:");

            ConsoleAppPrintUtil.PrintText(GetExercise17Text(high));
        }

        private static string GetExercise17Text(int high)
        {
            var exercise17Text = new StringBuilder();

            exercise17Text.AppendLine($"Altura del triángulo: {high}");

            for (int i = 1; i <= high; i++)
            {
                var row = new StringBuilder();
                for (int j = 0; j < i; j++)
                    row.Append("*");
                exercise17Text.AppendLine(row.ToString());
            }

            return exercise17Text.ToString();
        }

        #endregion

        #region Exercise18

        private static void Exercise18()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 18:");

            var high = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("Introduzca el altura del triángulo:");

            ConsoleAppPrintUtil.PrintText(GetExercise18Text(high));
        }

        private static string GetExercise18Text(int high)
        {
            var exercise17Text = new StringBuilder();

            exercise17Text.AppendLine($"Altura del triángulo: {high}");

            for (int i = high; i >= 1; i--)
            {
                var row = new StringBuilder();
                for (int j = 0; j < i; j++)
                    row.Append("*");
                exercise17Text.AppendLine(row.ToString());
            }

            return exercise17Text.ToString();
        }

        #endregion

        #region Exercise19

        private static void Exercise19()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 19:");

            var number = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("Introduzca un número:");

            bool isPrime = IsPrime(number);

            ConsoleAppPrintUtil.PrintText(GetExercise19Text(isPrime));
        }

        private static bool IsPrime(int number)
        {
            var isPrime = true;

            if (number <= 1)
                isPrime = false;
            else if (number == 2)
                isPrime = true;
            else if (number % 2 == 0)
                isPrime = false;
            else
            {
                var boundary = (int)Math.Floor(Math.Sqrt(number));

                for (int i = 3; i <= boundary && isPrime; i += 2)
                    if (number % i == 0)
                        isPrime = false;
            }

            return isPrime;
        }

        private static string GetExercise19Text(bool isPrime)
        {
            return isPrime ? "Es un número primo" : "No es un número primo";
        }

        #endregion

        #region Exercise20

        private static void Exercise20()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 29:");
            var foundNumber = false;
            var breakCondition = false;
            var random = new Random();
            var numberToFound = random.Next(1, 100);
            do
            {
                var number = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive("Introduzca un número:");
                if (number < 0)
                    breakCondition = true;
                else if (number < numberToFound)
                    ConsoleAppPrintUtil.PrintText($"Lo siento, pero el número está por encima del valor introducido.");
                else if (number > numberToFound)
                    ConsoleAppPrintUtil.PrintText($"Lo siento, pero el número está por debajo del valor introducido.");
                else
                    foundNumber = true;
            } while (!foundNumber && !breakCondition);

            ConsoleAppPrintUtil.PrintText(GetExercise20Text(foundNumber));
        }

        private static string GetExercise20Text(bool foundNumber)
        {
            var text = string.Empty;
            if (foundNumber)
                text = "Encontró el número";
            else
                text = "El programa se detuvo por alguna condición";
            return text;
        }

        #endregion

        #region Exercise21

        private static void Exercise21()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 29:", useReadLine: false);
            ConsoleAppPrintUtil.PrintText("Valor mínimo: 0.", useConsoleClear: false, useReadLine: false);
            ConsoleAppPrintUtil.PrintText("Valor máximo: 100.", useConsoleClear: false, useReadLine: false);
            ConsoleAppPrintUtil.PrintText("Piense un número entre 0 y 100 a ver si lo adivino.", useConsoleClear: false, useReadLine: false);
            var min = 1;
            var max = 100;
            var foundNumber = false;
            do
            {
                int number = GetNumber(min, max);
                Console.Write($"¿Es {number}?");
                var response = Console.ReadLine();
                foundNumber = FoundNumber(response, number, ref min, ref max);
            } while (!foundNumber);

            ConsoleAppPrintUtil.PrintText(GetExercise21Text(foundNumber));
        }

        private static bool FoundNumber(string response, int number, ref int min, ref int max)
        {
            var found = false;
            if (response.Equals("igual"))
                found = true;
            else if (response.Equals("mayor"))
            {
                min = number;
            }
            else if (response.Equals("menor"))
            {
                max = number;
            }
            return found;
        }

        private static int GetNumber(int min, int max)
        {
            int number = 0;
            if (min == max)
                number = min;
            else {
                var difference = max - min;
                number = min + (difference / 2);
            }
            return number;
        }

        private static string GetExercise21Text(bool foundNumber)
        {
            var text = string.Empty;
            if (foundNumber)
                text = "Gracias por jugar conmigo.";
            else
                text = "El programa se detuvo por alguna condición";
            return text;
        }

        #endregion
    }
}
