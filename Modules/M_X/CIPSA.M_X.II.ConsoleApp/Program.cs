using CIPSA.Util.ConsoleApp;
using CIPSA.Util.ConsoleApp.Class.M_X.II;
using System.Collections.Generic;
using System.Text;

namespace CIPSA.M_X.II.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var answerOfQuestion = string.Empty;
            var correctAnswerOfExerciseOption = new List<string>() { "E", "4" };
            var exerciseNumbers = new List<int>() { 4 };
            do
            {
                answerOfQuestion = ConsoleAppUtil.ShowExerciseOption(answerOfQuestion, exerciseNumbers, correctAnswerOfExerciseOption);

                M_X_II_Logic.ExecuteExercise(ref answerOfQuestion);

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

    class M_X_II_Logic
    {
        #region Execute-Exercise

        public static void ExecuteExercise(ref string answerOfQuestion)
        {
            if (int.TryParse(answerOfQuestion, out int exercise))
                switch (exercise)
                {
                    case 4:
                        Exercise4();
                        break;
                }
        }

        #endregion

        #region Exercise4

        private static void Exercise4()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 4:", useReadLine: false);

            var person1 = CreatePerson(name: "Persona 1", age: 50, sex: 'M');

            var person2 = CreatePerson(name: "Persona 2", age: 60, sex: 'M');

            var person3 = CreatePerson(name: "Persona 3", age: 70, sex: 'F');
            
            ConsoleAppPrintUtil.PrintText("Personas creadas: ", useConsoleClear: false, useReadLine: false);
            ConsoleAppPrintUtil.PrintWriteLineEmpty();

            ConsoleAppPrintUtil.PrintText(GetPersonText(person1), useConsoleClear: false, useReadLine: false);
            ConsoleAppPrintUtil.PrintText(GetPersonText(person2), useConsoleClear: false, useReadLine: false);
            ConsoleAppPrintUtil.PrintText(GetPersonText(person3), useConsoleClear: false, useReadLine: false);

            ConsoleAppPrintUtil.PrintWriteLineEmpty();

            var higherPerson = person1 > person2;
            ConsoleAppPrintUtil.PrintText($"Entre la persona 1 y 2 la mayor es: {higherPerson}", useConsoleClear: false, useReadLine: false);
            var lowerPerson = person1 < person3;
            ConsoleAppPrintUtil.PrintText($"Entre la persona 1 y 3 la menor es: {lowerPerson}", useConsoleClear: false, useReadLine: false);
            var equalsSex = person1 == person3 ? "Si" : "No";
            ConsoleAppPrintUtil.PrintText($"Las personas 1 y 3 tienen el mismo sexo: {equalsSex}", useConsoleClear: false, useReadLine: false);
            var differentSex = person2 != person3 ? "Si" : "No";
            ConsoleAppPrintUtil.PrintText($"Las personas 2 y 3 tienen diferentes sexo: {differentSex}", useConsoleClear: false);

        }

        private static string GetPersonText(Person persona)
        {
            var text = new StringBuilder();
            text.AppendLine($"Persona: {persona}");
            return text.ToString();
        }

        private static Person CreatePerson(string name, int age, char sex)
        {
            return new Person(name, age, sex);
        }

        #endregion
    }
}
