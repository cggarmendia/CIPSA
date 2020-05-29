using CIPSA.Util.ConsoleApp;
using CIPSA.Util.ConsoleApp.Class.M_V;
using CIPSA.Util.ConsoleApp.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace CIPSA.M_V.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var answerOfQuestion = string.Empty;
            var correctAnswerOfExerciseOption = new List<string>() { "E", "1", "2", "3", "4", "5", "6", "7" };
            var exerciseNumbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7 };
            do
            {
                answerOfQuestion = ConsoleAppUtil.ShowExerciseOption(answerOfQuestion, exerciseNumbers, correctAnswerOfExerciseOption);

                M_V_Logic.ExecuteExercise(answerOfQuestion);

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

    class M_V_Logic
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
                }
        }

        #endregion

        #region Exercise1

        private static void Exercise1()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 1:");

            var questions = new string[] {
                "Introduce primer número:",
                "Introduce segundo número:"
            };

            var number1 = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[0]);

            var number2 = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[1]);

            ConsoleAppPrintUtil.PrintText($"El valor mayor es: {ConsoleAppUtil.Max(number1, number2)}");
        }

        #endregion

        #region Exercise2

        private static void Exercise2()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 2:");

            var questions = new string[] {
                "Introduce primer número:",
                "Introduce segundo número:"
            };

            var number1 = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[0]);

            var number2 = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive(questions[1]);

            ConsoleAppPrintUtil.PrintText($"Antes del swap: x = {number1}, y = {number2}");

            ConsoleAppUtil.Swap(ref number1, ref number2);

            ConsoleAppPrintUtil.PrintText($"Después del swap: x = {number1}, y = {number2}");
        }
                
        #endregion

        #region Exercise3

        private static void Exercise3()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 3:");

            var number = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("Número para el factorial:");

            var hasFactorial = ConsoleAppUtil.TryFactorial(number, out int factorial);

            if (hasFactorial)
                ConsoleAppPrintUtil.PrintText($"Factorial({number}) = {factorial}");
            else
                ConsoleAppPrintUtil.PrintText($"No se puede calcular el factorial de: {number}");            
        }

        #endregion

        #region Exercise4

        private static void Exercise4()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 4:");

            var number = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerRecursive("Número para el factorial:");

            var hasFactorial = ConsoleAppUtil.TryFactorialRecursive(number, out int factorial);

            if (hasFactorial)
                ConsoleAppPrintUtil.PrintText($"Factorial({number}) = {factorial} (recursivo)");
            else
                ConsoleAppPrintUtil.PrintText($"No se puede calcular el factorial de: {number} (recursivo)");
        }

        #endregion

        #region Exercise5

        private static void Exercise5()
        {
            Console.Clear();
            var bankAccount1 = new BankAccount();
            bankAccount1.Populate(100);
            var bankAccount2 = new BankAccount();
            bankAccount2.Populate(100);
            Console.WriteLine("---------Antes de la trasnferencia------------");
            ConsoleAppPrintUtil.PrintText(GetCuentaBancariaText(bankAccount1), useConsoleClear: false, useReadLine: false);
            ConsoleAppPrintUtil.PrintText(GetCuentaBancariaText(bankAccount2), useConsoleClear: false, useReadLine: false);
            bankAccount1.TransferOf(bankAccount2, 10);
            Console.WriteLine("---------Después de la trasnferencia-----------");
            ConsoleAppPrintUtil.PrintText(GetCuentaBancariaText(bankAccount1), useConsoleClear: false, useReadLine: false);
            ConsoleAppPrintUtil.PrintText(GetCuentaBancariaText(bankAccount2), useConsoleClear: false, useReadLine: false);
            Console.Read();
        }

        private static string GetCuentaBancariaText(BankAccount cuenta)
        {
            var text = new StringBuilder();
            text.AppendLine($"Número de cuenta es: {cuenta.Number}");
            text.AppendLine($"Saldo de cuenta es: {cuenta.Balance}");
            text.AppendLine($"Tipo de cuenta es: {cuenta.AccountType}");
            return text.ToString();
        }

        #endregion

        #region Exercise6

        private static void Exercise6()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 6:");

            const string text1 = "Escriba una cadena para invertirla:";
            var answer = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(text1);

            string answerReverse = ConsoleAppUtil.Reverse(answer);

            ConsoleAppPrintUtil.PrintText($"Cadena invertida: {answerReverse}");
        }

        #endregion

        #region Exercise7

        private static void Exercise7()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 7:");

            const string text1 = "Path del fichero de lectura:";
            var fileFromPath = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(text1);

            const string text2 = "Path del fichero de escritura:";
            var fileToPath = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(text2);

            var transferData = ConsoleAppUtil.TransferDataFromFile(fileFromPath, fileToPath);

            Exercise7PrintText(transferData);
        }

        private static void Exercise7PrintText(TransferDataResultEnum transferData)
        {
            switch (transferData)
            {
                case TransferDataResultEnum.Transfer:
                    ConsoleAppPrintUtil.PrintText("Datos transferidos.");
                    break;

                case TransferDataResultEnum.FileNotFound:
                    ConsoleAppPrintUtil.PrintText("Fichero de entrada no encontrado.");
                    break;

                case TransferDataResultEnum.Unknown:
                    ConsoleAppPrintUtil.PrintText("Excepción inesperada.");
                    break;
            }
        }

        #endregion
    }
}
