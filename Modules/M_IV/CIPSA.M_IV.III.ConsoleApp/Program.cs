using CIPSA.Util.ConsoleApp;
using CIPSA.Util.ConsoleApp.CustomException;
using System;
using System.Collections.Generic;

namespace CIPSA.M_IV.III.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var answerOfQuestion = string.Empty;
            var correctAnswerOfExerciseOption = new List<string>() { "E", "1", "2", "3", "4", "5", "6", "7", "8" };
            var exerciseNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            do
            {
                answerOfQuestion = ConsoleAppUtil.ShowExerciseOption(answerOfQuestion, exerciseNumbers, correctAnswerOfExerciseOption);

                M_IV_III_Logic.ExecuteExercise(answerOfQuestion);

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

    class M_IV_III_Logic
    {
        #region Execute-Exercise

        public static void ExecuteExercise(string answerOfQuestion)
        {
            if (int.TryParse(answerOfQuestion, out int exercise))
                switch (exercise)
                {
                    case 1:
                        Exercise1_2();
                        break;
                    case 2:
                        Exercise1_2();
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
                }
        }

        #endregion

        #region Exercise2

        private static void Exercise1_2()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 1-2:");

            var questions = new string[] {
                "Introduzca un texto:"
            };

            var text = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[0]);

            try
            {
                var textParse = int.Parse(text);
                ConsoleAppPrintUtil.PrintText("Número correcto");
            }
            catch (Exception)
            {
                ConsoleAppPrintUtil.PrintText("Número incorrecto");
            }
        }

        #endregion

        #region Exercise3

        private static void Exercise3()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 3:");

            var temperature = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive("Introduce una temperatura en grados Fahrenheit: ");

            try
            {
                var temperatureNumber = int.Parse(temperature);
                ConsoleAppPrintUtil.PrintText($"La temperatura en grados celsius es de: {temperatureNumber}");
            }
            catch (Exception ex)
            {
                ConsoleAppPrintUtil.PrintText(ex.Message, useConsoleClear: false, useReadLine: false);
                ConsoleAppPrintUtil.PrintText(ex.StackTrace, useConsoleClear: false);
            }
        }

        #endregion

        #region Exercise4

        private static void Exercise4()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 4:");

            var questions = new string[]{
                "Introduzca el primer número: ",
                "Introduzca el segundo número: "
            };

            var number1 = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(questions[0]);

            var number2 = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(questions[1]);

            try
            {
                var result = number1 / number2;
                ConsoleAppPrintUtil.PrintText($"El resultado de la división es: {result}");
            }
            catch (DivideByZeroException)
            {
                ConsoleAppPrintUtil.PrintText("La división entre cero no está definida.");
            }
            catch (Exception)
            {
                ConsoleAppPrintUtil.PrintText("Ocurrió un error inesperado.");
            }            
        }

        #endregion

        #region Exercise5

        private static void Exercise5()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 4:");

            var questions = new string[]{
                "Introduzca el primer número: ",
                "Introduzca el segundo número: "
            };

            var answer1 = ConsoleAppPrintUtil.PrintQuestionWithStringAnswer(questions[0]);

            var answer2 = ConsoleAppPrintUtil.PrintQuestionWithStringAnswer(questions[1]);

            var number1 = answer1 == string.Empty ? null : answer1;

            var number2 = answer2 == string.Empty ? null : answer2;

            ConsoleAppPrintUtil.PrintDivision(number1, number2);
        }

        #endregion

        #region Exercise6

        private static void Exercise6()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 6:");
            ConsoleAppUtil.TryDivisionRecursive();
        }

        #endregion

        #region Exercise7

        private static void Exercise7()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 7:");

            var questions = new string[]{
                "Introduzca un número para calcular su factorial:"
            };

            var number = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(questions[0]);

            try
            {
                decimal factory = GetFactory(number);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                ConsoleAppPrintUtil.PrintText(ex.Message);
            }
        }

        private static int GetFactory(int number)
        {
            if (number < 0 || number >= 15)
                throw new ArgumentOutOfRangeException("El rango del # para calcular el factorial es [0,15]");
            ConsoleAppUtil.TryFactorial(number, out int factorial);
            return factorial;

        }

        #endregion

        #region Exercise8

        private static void Exercise8()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 8:");

            var questions = new string[]{
                "Introduzca un número para calcular su factorial:"
            };

            var number = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(questions[0]);

            try
            {
                decimal factory = GetFactoryWithCustomException(number);
            }
            catch (TePasasteException ex)
            {
                ConsoleAppPrintUtil.PrintText(ex.Message);
            }
        }

        private static int GetFactoryWithCustomException(int number)
        {
            if (number < 0 || number >= 15)
                throw new TePasasteException("El rango del # para calcular el factorial es [0,15]");
            ConsoleAppUtil.TryFactorial(number, out int factorial);
            return factorial;
        }

        #endregion
    }
}