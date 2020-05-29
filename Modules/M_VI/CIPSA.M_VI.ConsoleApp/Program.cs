using CIPSA.Util.ConsoleApp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIPSA.M_VI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var answerOfQuestion = string.Empty;
            var correctAnswerOfExerciseOption = new List<string>() { "E", "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11" };
            var exerciseNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 };
            do
            {
                answerOfQuestion = ConsoleAppUtil.ShowExerciseOption(answerOfQuestion, exerciseNumbers, correctAnswerOfExerciseOption);

                M_VI_Logic.ExecuteExercise(ref answerOfQuestion);

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

    class M_VI_Logic
    {
        #region Execute-Exercise

        public static void ExecuteExercise(ref string answerOfQuestion)
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
                }
        }

        #endregion

        #region Exercise1

        private static void Exercise1()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 1:", useReadLine: false);
            ConsoleAppPrintUtil.PrintText($"Abecedario: " + String.Join(",", ConsoleAppUtil.GetAbecedario().ToArray()), useConsoleClear: false);
        }

        #endregion

        #region Exercise2

        private static void Exercise2()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 2:");

            var numbers = 
                ConsoleAppPrintUtil.PrintQuestionWithArrayListIntAnswerRecursive("Introduce diez números separados por una coma:", 10);

            numbers.Reverse();

            ConsoleAppPrintUtil.PrintText($"Los números introducidos en orden inverso fueron: {String.Join(",", numbers.ToArray())}");
        }

        #endregion

        #region Exercise3

        private static void Exercise3()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 3:");

            var numbers =
                ConsoleAppPrintUtil.PrintQuestionWithArrayListIntAnswerRecursive("Introduce diez números separados por una coma:", 10);

            numbers.Reverse();

            var greaterThan22 = 0;

            foreach (int number in numbers)
            {
                if (number > 22)
                    greaterThan22++;
            }

            string greaterThan22Text = GetGreaterThan22Text(greaterThan22);

            ConsoleAppPrintUtil.PrintText($"Los números introducidos en orden inverso fueron: {String.Join(",", numbers.ToArray())}. {greaterThan22Text}");
        }

        private static string GetGreaterThan22Text(int greaterThan22)
        {
            var greaterThan22Text = string.Empty;

            if (greaterThan22 == 0)
                greaterThan22Text = "No existen #s superiores a 22.";
            else
                greaterThan22Text = greaterThan22 > 1 ? $"Existe {greaterThan22} #s superiores a 22." : "Existe 1 # superior a 22.";

            return greaterThan22Text;
        }

        #endregion

        #region Exercise4

        private static void Exercise4()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 4:", useReadLine: false);

            var numbers = new ArrayList(11) { 12, 12, 12, 13, 14, 15, 15, 15, 16, 16, 17 };
            
            var repeatedNumbersText = GetRepeatedNumbersText(numbers);

            ConsoleAppPrintUtil.PrintText(
                repeatedNumbersText.Any()
                    ? $"Los #s repetidos son: {String.Join(",", repeatedNumbersText)}"
                    : "No hay #s repetidos",
                useConsoleClear: false);
        }

        private static List<string> GetRepeatedNumbersText(ArrayList numbers)
        {
            var repeatedNumbers = GetRepeatedNumbers(numbers);

            var repeatedNumbersText = new List<string>();

            foreach (var item in repeatedNumbers.Keys)
                repeatedNumbersText.Add(item.ToString());

            return repeatedNumbersText;
        }

        private static Hashtable GetRepeatedNumbers(ArrayList numbers)
        {
            var repeatedNumbers = new Hashtable();

            for (int i = 0; i < numbers.Count; i++)
            {
                var number = numbers[i];
                numbers.RemoveAt(i);
                if (numbers.Contains(number))
                {
                    if (!repeatedNumbers.ContainsKey(number))
                    {
                        repeatedNumbers.Add(number, number);
                    }
                }
                i--;
            }

            return repeatedNumbers;
        }

        #endregion

        #region Exercise5

        private static void Exercise5()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 5:");

            var questions = new string[] {
                "Nº de valores a introducir:",
                "Valor"
            };

            var countOfNumbers = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[0]);

            var numbers = ConsoleAppUtil.GetArrayListOfNumbers(countOfNumbers);

            ConsoleAppPrintUtil.PrintText(GetExercise5Text(numbers));
        }

        private static string GetExercise5Text(ArrayList numbers)
        {
            var exercise5Text = new StringBuilder();
            exercise5Text.AppendLine($"Los valores introducidos son: {String.Join(",", numbers.ToArray())}. ");

            var max = ConsoleAppUtil.Max(numbers);
            exercise5Text.AppendLine($"El máximo valor es: {max}. ");

            var min = ConsoleAppUtil.Min(numbers);
            exercise5Text.AppendLine($"El mínimo valor es: {min}.");

            var sum = ConsoleAppUtil.Sum(numbers);
            exercise5Text.AppendLine($"La suma de todos los valores es: {sum}. ");

            return exercise5Text.ToString();
        }

        #endregion

        #region Exercise6

        private static void Exercise6()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 6:");

            var questions = new string[] {
                "Nº de valores a introducir para cada serie:"
            };

            var countOfNumbers = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[0]);

            var numbersOfSerie1 = ConsoleAppUtil.GetArrayListOfNumbers(countOfNumbers, text: "Serie 1 > Valor");

            var numbersOfSerie2 = ConsoleAppUtil.GetArrayListOfNumbers(countOfNumbers, text: "Serie 2 > Valor");

            ConsoleAppPrintUtil.PrintText(GetExercise6Text(numbersOfSerie1, numbersOfSerie2));
        }

        private static string GetExercise6Text(ArrayList numbersOfSerie1, ArrayList numbersOfSerie2)
        {
            var exercise6Text = new StringBuilder();

            for (int i = 0; i < numbersOfSerie1.Count; i++)
            {
                var numberOfSerie1 = long.Parse(numbersOfSerie1[i].ToString());
                var numberOfSerie2 = long.Parse(numbersOfSerie2[i].ToString());
                if (numberOfSerie1 == numberOfSerie2)
                    exercise6Text.AppendLine($"{numberOfSerie1} es igual a {numberOfSerie2}");
                else if (numberOfSerie1 > numberOfSerie2)
                    exercise6Text.AppendLine($"{numberOfSerie1} es mayor que {numberOfSerie2}");
                else
                    exercise6Text.AppendLine($"{numberOfSerie1} es menor que {numberOfSerie2}");
            }

            return exercise6Text.ToString();
        }

        #endregion

        #region Exercise7

        private static void Exercise7()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 7:", useReadLine: false);

            var numbers = new ArrayList(10) { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            
            ConsoleAppPrintUtil.PrintText(GetExercise7Text(numbers), useConsoleClear: false);
        }
        
        private static string GetExercise7Text(ArrayList numbers)
        {
            var exercise7Text = new StringBuilder();
            exercise7Text.AppendLine($"Los 10 valores iniciales son: {String.Join(",", numbers.ToArray())}. ");

            var firstFive = new int[5];
            Array.Copy(numbers.ToArray(), 0, firstFive, 0, 5);
            exercise7Text.AppendLine($"Primeros 5: { String.Join(",", firstFive)}.");

            var lastFive = new int[5];
            Array.Copy(numbers.ToArray(), 5, lastFive, 0, 5);
            exercise7Text.AppendLine($"Últimos 5: { String.Join(",", lastFive)}.");

            return exercise7Text.ToString();
        }

        #endregion

        #region Exercise8

        private static void Exercise8()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 8:", useReadLine: false);

            ConsoleAppPrintUtil.PrintText("Introduzca 10 notas.", useConsoleClear: false);

            var notes = ConsoleAppUtil.GetArrayListOfNumbersLessThan(10, "Nota", 10);

            var approvedNote = new ArrayList();
            var suspendedNote = new ArrayList();
            foreach (int note in notes)
                if (note <= 5)
                    suspendedNote.Add(note);
                else
                    approvedNote.Add(note);

            ConsoleAppPrintUtil.PrintText(GetExercise8Text(notes, approvedNote, suspendedNote));
        }

        private static string GetExercise8Text(ArrayList notes, ArrayList approvedNote, ArrayList suspendedNote)
        {
            var exercise6Text = new StringBuilder();

            exercise6Text.AppendLine($"Aprobados: {approvedNote.Count}");
            exercise6Text.AppendLine($"Suspensos: {suspendedNote.Count}");
            exercise6Text.AppendLine($"Media total: {ConsoleAppUtil.Sum(notes) / notes.Count}");
            exercise6Text.AppendLine($"Media de los aprobados: {ConsoleAppUtil.Sum(approvedNote) / approvedNote.Count}");
            exercise6Text.AppendLine($"Media de los suspensos: {ConsoleAppUtil.Sum(suspendedNote) / suspendedNote.Count}");

            return exercise6Text.ToString();
        }

        #endregion

        #region Exercise9

        private static void Exercise9()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 9:", useReadLine: false);

            var numbers = Exercise9GetNumbers();

            ConsoleAppPrintUtil.PrintText(GetExercise9Text(numbers));
        }

        private static ArrayList Exercise9GetNumbers()
        {
            var numbers = new ArrayList();

            var isNegativeNumber = false;
            do
            {
                var number = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive("Introduzca un #:");
                if (number >= 0)
                    numbers.Add(number);
                else
                    isNegativeNumber = true;
            } while (!isNegativeNumber);

            return numbers;
        }

        private static string GetExercise9Text(ArrayList numbers)
        {
            return $"Los #s ingresados hasta el valor negativo fueron: {String.Join(",", numbers.ToArray())}";
        }

        #endregion

        #region Exercise10

        private static void Exercise10()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 10:", useReadLine: false);
            ConsoleAppPrintUtil.PrintText("Introduzca 5 #s adicionales.", useConsoleClear: false);

            var numbers = new ArrayList(10) { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };

            var anotherFiveNumber = ConsoleAppUtil.GetArrayListOfNumbers(5, text: "# adicional");

            numbers.InsertRange(10, anotherFiveNumber);

            numbers.Sort();

            numbers.RemoveAt(7);

            ConsoleAppPrintUtil.PrintText(GetExercise10Text(numbers));
        }

        private static string GetExercise10Text(ArrayList numbers)
        {
            return $"La lista resultante de #s es: {String.Join(",",numbers.ToArray())}";
        }

        #endregion
    }
}
