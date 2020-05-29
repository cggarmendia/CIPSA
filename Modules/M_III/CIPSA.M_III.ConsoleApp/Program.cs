using CIPSA.Util.ConsoleApp;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CIPSA.M_III.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var answerOfQuestion = string.Empty;
            var correctAnswerOfExerciseOption = new List<string>() { "E", "1", "2", "3", "4", "5" };
            var exerciseNumbers = new List<int>() { 1, 2, 3, 4, 5 };
            do
            {
                answerOfQuestion = ConsoleAppUtil.ShowExerciseOption(answerOfQuestion, exerciseNumbers, correctAnswerOfExerciseOption);

                M_III_Logic.ExecuteExercise(answerOfQuestion);

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

    class M_III_Logic
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
                }
        }

        #endregion

        #region Exercise1

        private static void Exercise1()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 1:");

            const string phrase1 = "Apaga y vámonos.";
            const string phrase2 = "Coser y cantar.";
            const string phrase3 = "El quinto pino.";

            Console.WriteLine($"Frase 1: {phrase1}");
            Console.WriteLine($"Frase 2: {phrase2}");
            Console.WriteLine($"Frase 3: {phrase3}");

            Console.ReadLine();
        }

        #endregion

        #region Exercise2

        private static void Exercise2()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 2:");

            var answerOfQuestions = new List<object>();

            var questions = new string[] {
                "¿Cómo te llamas?",
                "¿Dónde vives?",
                "¿Cuántos años tienes?",
                "¿Te gusta el deporte?",
                "¿Hace calor hoy?"
            };

            var name = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[0]);
            answerOfQuestions.Add(name);

            var address = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[1]);
            answerOfQuestions.Add(address);

            var age = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[2]);
            answerOfQuestions.Add(age);

            var likeSport = ConsoleAppPrintUtil.PrintQuestionWithCharAnswerRecursive(questions[3], correctAnswers : new string []{ "S", "N"} );
            answerOfQuestions.Add(likeSport);

            var hotDay = ConsoleAppPrintUtil.PrintQuestionWithCharAnswerRecursive(questions[4], correctAnswers: new string[] { "S", "N" });
            answerOfQuestions.Add(hotDay);

            Exercise2ShowAnswerOfQuestions(answerOfQuestions);
        }

        private static void Exercise2ShowAnswerOfQuestions(List<object> answerOfQuestions)
        {
            Console.Clear();

            for (int i = 0; i < answerOfQuestions.Count; i++)
            {
                var answerText = $"Respuesta {i + 1}:";
                Console.WriteLine($"{answerText} {answerOfQuestions.ElementAt(i)}");
                Console.WriteLine("");
            }

            Console.ReadLine();
        }

        #endregion

        #region Exercise3

        private static void Exercise3()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 3:");

            var questions = new string[] {
                "Introduzca el primer valor de la operación:",
                "Introduzca el segundo valor de la operación:"
            };

            var number1 = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[0]);

            var number2 = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[1]);

            ConsoleAppPrintUtil.PrintText($"La suma entre dichos valores es: {number1 + number2}");
        }

        #endregion

        #region Exercise4

        private static void Exercise4()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 4:");

            var questions = new string[] {
                "¿Cómo te llamas?",
                "¿Cuántas horas has trabajado?",
                "¿Qué precio cobras por hora?"
            };

            var name = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[0]);
            
            var hoursWorked = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[1]);
            
            var priceByHour = ConsoleAppPrintUtil.PrintQuestionWithDecimalAnswerRecursive(questions[2]);

            var answerText = Exercise4GetAnswerText(name, hoursWorked, priceByHour);

            ConsoleAppPrintUtil.PrintText(answerText);
        }

        private static string Exercise4GetAnswerText(string name, int hoursWorked, decimal priceByHour)
        {
            var grossSalary = hoursWorked * priceByHour;
            var retentions = grossSalary * 0.05M;
            var netIncome = grossSalary - retentions;
            var answerText =
                $"Hola {name}. Su sueldo bruto es: {grossSalary}, su sueldo neto es: {netIncome} y se le retiene: {retentions}.";
            return answerText;
        }

        #endregion

        #region Exercise5

        private static void Exercise5()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 5:");

            Console.Clear();

            var a = Math.Pow(5, 2) + Math.Pow(5, 2);
            Console.WriteLine($"5^2 + 5^2 = {a}");
            Console.WriteLine(ConsoleAppUtil.LineSeparator);

            var b = Math.Sin(2.21) + Math.Cos(3.4);
            Console.WriteLine($"sin(2.21) + cos(3.4) = {b}");
            Console.WriteLine(ConsoleAppUtil.LineSeparator);

            var c = ( 2 + Math.Sqrt(25) ) / 7;
            Console.WriteLine($"( 2+sqrt(25) ) / 7 = {c}");

            Console.ReadLine();
        }

        #endregion
    }
}
