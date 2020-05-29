using CIPSA.Util.ConsoleApp;
using CIPSA.Util.ConsoleApp.Enum;
using System;
using System.Collections.Generic;

namespace CIPSA.M_IV.I.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var answerOfQuestion = string.Empty;
            var correctAnswerOfExerciseOption = new List<string>() { "E", "1", "2", "3" };
            var exerciseNumbers = new List<int>() { 1, 2, 3 };
            do
            {
                answerOfQuestion = ConsoleAppUtil.ShowExerciseOption(answerOfQuestion, exerciseNumbers, correctAnswerOfExerciseOption);
                M_IV_I_Logic.ExecuteExercise(answerOfQuestion);

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

    class M_IV_I_Logic
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
                }
        }

        #endregion

        #region Exercise1

        private static void Exercise1()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 1:");

            var questions = new string[]{
                "Introduzca el primer valor de la operación:",
                "Introduzca el segundo valor de la operación:"
            };

            var number1 = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(questions[0]);

            var number2 = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(questions[1]);

            ConsoleAppPrintUtil.PrintDivision(number1, number2);
        }

        #endregion

        #region Exercise2

        private static void Exercise2()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 2:");
            try
            {
                var questions = new string[]{
                    "Introduce un número de día entre 1 y 365: "
                };

                var numberOfDays = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(questions[0]);

                if (numberOfDays < 1 || numberOfDays > 365)
                    throw new ArgumentOutOfRangeException($"Día fuera de intervalo");

                var daysInMonths = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                var monthNumber = Exercise2GetMonthNumber(daysInMonths, ref numberOfDays);

                ConsoleAppPrintUtil.PrintText($"Día: {numberOfDays} - Mes: { (MountNameEnum)monthNumber }");
            }
            catch (Exception caught)
            {
                Console.WriteLine($"Excepción controlada: {caught}");
                Console.Read();
            }
        }

        private static int Exercise2GetMonthNumber(int[] daysInMonths, ref int answerOfQuestion1)
        {
            var monthNumber = 0;

            foreach (var dayInMonth in daysInMonths)
            {
                if (answerOfQuestion1 <= dayInMonth)
                    break;
                answerOfQuestion1 -= dayInMonth;
                monthNumber++;
            }
            return monthNumber;
        }

        #endregion

        #region Exercise3

        private static void Exercise3()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 3:");
            try
            {
                var numberOfTheYear = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("Introduce un número de año: ");

                //if ((numberOfTheYear % 4 == 0) && (numberOfTheYear % 100 != 0 || numberOfTheYear % 400 == 0))
                //    ConsoleAppPrintUtil.PrintText("Es un año bisiesto");
                //else
                //    ConsoleAppPrintUtil.PrintText("NO es un año bisiesto");

                var isLeapYear = (numberOfTheYear % 4 == 0) && (numberOfTheYear % 100 != 0 || numberOfTheYear % 400 == 0);
                var maxOfDay = isLeapYear ? 366 : 365;

                var numberOfDays = ConsoleAppPrintUtil.PrintQuestionWithIntPositiveOrNegativeAnswerRecursive($"Introduce un número de día entre 1 y {maxOfDay}: ");
                if (numberOfDays < 1 || numberOfDays > maxOfDay)
                    throw new ArgumentOutOfRangeException($"Día fuera de intervalo");

                var monthNumber = Exercise3MonthNumber(isLeapYear, ref numberOfDays);

                ConsoleAppPrintUtil.PrintText($"Día: {numberOfDays} - Mes: { (MountNameEnum)monthNumber }");
            }
            catch (Exception caught)
            {
                Console.WriteLine($"Excepción controlada: {caught}");
                Console.Read();
            }
        }

        private static int Exercise3MonthNumber(bool isLeapYear, ref int numberOfDays)
        {
            var monthNumber = int.MinValue;
            if (isLeapYear)
            {
                var daysInMonthsLeapYear = new int[] { 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                monthNumber = Exercise2GetMonthNumber(daysInMonthsLeapYear, ref numberOfDays);
            }
            else
            {
                var daysInMonths = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
                monthNumber = Exercise2GetMonthNumber(daysInMonths, ref numberOfDays);
            }
            return monthNumber;
        }

        #endregion
    }
}