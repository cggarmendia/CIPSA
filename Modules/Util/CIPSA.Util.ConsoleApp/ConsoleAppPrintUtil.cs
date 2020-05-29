using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CIPSA.Util.ConsoleApp
{
    public static class ConsoleAppPrintUtil
    {
        #region .: Public Methods :.

        public static decimal PrintQuestionWithDecimalAnswerRecursive(string question)
        {
            var answerOfQuestion = decimal.MinValue;
            Console.Clear();
            Console.WriteLine(question);

            if (!decimal.TryParse(Console.ReadLine(), out answerOfQuestion) || answerOfQuestion <= 0.0M)
            {
                answerOfQuestion = decimal.MinValue;
                PrintTextWithLineSeparator("Lo siento, pero la respuesta debe ser un #.");
                answerOfQuestion = PrintQuestionWithDecimalAnswerRecursive(question);
            }

            return answerOfQuestion;
        }

        public static string PrintQuestionWithStringAnswerRecursive(string question)
        {
            Console.Clear();
            Console.WriteLine(question);
            var answerOfQuestion = Console.ReadLine();

            if (answerOfQuestion.Equals(string.Empty))
            {
                answerOfQuestion = string.Empty;
                PrintTextWithLineSeparator($"Lo siento pero la respuesta no debe ser un texto vacío.");
                answerOfQuestion = PrintQuestionWithStringAnswerRecursive(question);
            }

            return answerOfQuestion;
        }

        public static string PrintQuestionWithStringAnswer(string question)
        {
            Console.Clear();
            Console.WriteLine(question);
            return Console.ReadLine();
        }

        public static char PrintQuestionWithCharAnswerRecursive(string question, IEnumerable<string> correctAnswers)
        {
            var answerOfQuestion = char.MinValue;

            Console.Clear();
            Console.WriteLine($"{question} (La respuesta debe ser {String.Join("/", correctAnswers)}.)");
            var tempAnswer = Console.ReadLine();

            if (!char.TryParse(tempAnswer, out answerOfQuestion) || ( !correctAnswers.Any(correctAnswer => correctAnswer.Equals(tempAnswer)) ) )
            {
                answerOfQuestion = char.MinValue;
                PrintTextWithLineSeparator($"Lo siento pero la respuesta debe ser {String.Join(" / ", correctAnswers)}.");
                answerOfQuestion = PrintQuestionWithCharAnswerRecursive(question, correctAnswers);
            }

            return answerOfQuestion;
        }
        
        public static void PrintTextWithLineSeparator(string text, bool useReadLine = true)
        {
            Console.Clear();
            Console.WriteLine(text);
            Console.WriteLine(ConsoleAppUtil.LineSeparator);
            PrintWriteLineEmpty();
            if (useReadLine)
                Console.ReadLine();
        }

        public static void PrintText(string text, bool useConsoleClear = true, bool useReadLine = true)
        {
            if(useConsoleClear)
                Console.Clear();
            Console.WriteLine(text);
            if (useReadLine)
            {
                Console.WriteLine("");
                Console.WriteLine("---- Presione <ENTER> para continuar ----");
                Console.ReadLine();
            }
        }

        public static void PrintDivision(int number1, int number2)
        {
            Console.Clear();
            try
            {
                Console.WriteLine($"Valor división: {number1 / number2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Excepción controlada: {ex}");
            }
            Console.ReadLine();
        }

        public static decimal PrintDivision(string text1, string text2) {
            var result = 0M;

            try
            {
                result = int.Parse(text1) / int.Parse(text2);
                PrintText($"El resultado de la división es: {result}", useReadLine: false);
            }
            catch (DivideByZeroException)
            {
                PrintText("La división entre cero no está definida.", useReadLine: false);
            }
            catch (ArgumentNullException)
            {
                PrintText("Debe insertar dos valores y ninguno de los dos puede ser un texto vacío.", useReadLine: false);
            }
            catch (FormatException)
            {
                PrintText("La división debe ser entre números.", useReadLine: false);
            }
            catch (OverflowException)
            {
                PrintText("La division arrojo un resultado desbordado.", useReadLine: false);
            }
            finally
            {
                Console.ReadKey();
            }

            return result;
        }

        public static void PrintWriteLineEmpty()
        {
            Console.WriteLine(String.Empty);
        }

        public static int PrintQuestionWithIntAnswerRecursive(string question)
        {
            var answerOfQuestion = int.MinValue;
            Console.Clear();
            Console.WriteLine(question);

            var answerOfQuestionTemp = Console.ReadLine();

            if (!IsPositiveNumber(answerOfQuestionTemp))
            {
                answerOfQuestion = int.MinValue;
                PrintTextWithLineSeparator("Lo siento, pero la respuesta debe ser un # entero positivo.");
                answerOfQuestion = PrintQuestionWithIntAnswerRecursive(question);
            }
            else
                answerOfQuestion = int.Parse(answerOfQuestionTemp);

            return answerOfQuestion;
        }

        public static int PrintQuestionWithIntAnswerLessThanRecursive(string question, int lessThan)
        {
            var answerOfQuestion = int.MinValue;
            Console.Clear();
            Console.WriteLine(question);

            var answerOfQuestionTemp = Console.ReadLine();

            if (!IsPositiveNumber(answerOfQuestionTemp, lessThan: lessThan))
            {
                answerOfQuestion = int.MinValue;
                PrintTextWithLineSeparator($"Lo siento, pero la respuesta debe ser un # entero positivo menor que {lessThan}.");
                answerOfQuestion = PrintQuestionWithIntAnswerLessThanRecursive(question, lessThan);
            }
            else
                answerOfQuestion = int.Parse(answerOfQuestionTemp);

            return answerOfQuestion;
        }

        public static int PrintQuestionWithIntAnswerEqualThanRecursive(string question, int equalThan)
        {
            var answerOfQuestion = int.MinValue;
            Console.Clear();
            Console.WriteLine(question);

            var number = PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(question);

            if (number < 0)
            {
                answerOfQuestion = number;
            }
            else if (number < equalThan)
            {
                answerOfQuestion = int.MinValue;
                PrintTextWithLineSeparator($"Lo siento, pero el número está por encima del valor introducido.");
                answerOfQuestion = PrintQuestionWithIntAnswerEqualThanRecursive(question, equalThan);
            }
            else if (number > equalThan)
            {
                answerOfQuestion = int.MinValue;
                PrintTextWithLineSeparator($"Lo siento, pero el número está por debajo del valor introducido.");
                answerOfQuestion = PrintQuestionWithIntAnswerEqualThanRecursive(question, equalThan);
            }
            else
                answerOfQuestion = number;

            return answerOfQuestion;
        }

        public static int PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(string question)
        {
            var answerOfQuestion = int.MinValue;
            Console.Clear();
            Console.WriteLine(question);

            if (!int.TryParse(Console.ReadLine(), out answerOfQuestion))
            {
                answerOfQuestion = int.MinValue;
                PrintTextWithLineSeparator("Lo siento, pero la respuesta debe ser un # entero.");
                answerOfQuestion = PrintQuestionWithIntPositiveOrNegativeAnswerRecursive(question);
            }

            return answerOfQuestion;
        }
        
        public static ArrayList PrintQuestionWithArrayListIntAnswerRecursive(string question, int count)
        {
            var answerOfQuestion = default(ArrayList);
            Console.Clear();
            Console.WriteLine(question);
            var answerOfQuestionTemp = Console.ReadLine().Split(',').ToList();
            if (answerOfQuestionTemp.Count < count || answerOfQuestionTemp.Count > count || answerOfQuestionTemp.Exists(number => !IsPositiveNumber(number)))
            {
                answerOfQuestion = default(ArrayList);
                PrintTextWithLineSeparator($"Lo siento, pero la respuesta deben ser {count} #s concatenados por una coma.");
                answerOfQuestion = PrintQuestionWithArrayListIntAnswerRecursive(question, count);
            }
            else {
                answerOfQuestion = new ArrayList(10);
                answerOfQuestionTemp.ForEach( number => answerOfQuestion.Add(int.Parse(number)) );
            }

            return answerOfQuestion;
        }

        #endregion

        #region .: Private Methods :.

        private static bool IsPositiveNumber(string number, int lessThan = int.MaxValue)
        {
            var isNumber = true;
            if (int.TryParse(number, out int numberParse))
            {
                if (numberParse <= 0 || numberParse > lessThan)
                    isNumber = false;
            }
            else
                isNumber = false;
            return isNumber;
        }

        #endregion
    }
}
