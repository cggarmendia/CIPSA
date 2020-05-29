using CIPSA.Util.ConsoleApp;
using CIPSA.Util.ConsoleApp.Class.M_X.III;
using CIPSA.Util.ConsoleApp.Enum.M_X.III;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIPSA.M_X.III.ConsoleApp
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

                M_X_I_Logic.ExecuteExercise(ref answerOfQuestion);

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

    class M_X_I_Logic
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
                }
        }

        #endregion

        #region Exercise1

        private static void Exercise1()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 1:", useReadLine: false);

            var persona1 = CreatePersona(name: "Persona 1", lastName: "Apellidos", phoneNumber: "123456", email: "persona1@mail.com", accreditation: AccreditationEnum.Institucional, sex: SexEnum.Femenino);

            var persona2 = CreatePersona(name: "Persona 2", lastName: "Apellidos", phoneNumber: "654321", email: "persona2@mail.com", accreditation: AccreditationEnum.Especializada, sex: SexEnum.Masculino);

            ConsoleAppPrintUtil.PrintText(GetExercise1Text(persona1, persona2), useConsoleClear: false);
        }

        private static Person CreatePersona(string name, string lastName, string phoneNumber, string email,
            AccreditationEnum accreditation, SexEnum sex)
        {
            return new Person(name, lastName, phoneNumber, email, accreditation, sex);
        }

        private static string GetExercise1Text(Person persona1, Person persona2)
        {
            var text = new StringBuilder();

            text.AppendLine("Persona 1:");
            persona1.ToString().Split(',').ToList().ForEach(prop => text.AppendLine($" > {prop.TrimStart()}"));
            text.AppendLine("Persona 2:");
            persona2.ToString().Split(',').ToList().ForEach(prop => text.AppendLine($" > {prop.TrimStart()}"));

            return text.ToString();
        }

        #endregion

        #region Exercise2

        private static void Exercise2()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 2:", useReadLine: false);

            ConsoleAppPrintUtil.PrintText(GetExercise2Text(GetEmployees()), useConsoleClear: false);
        }

        private static IEnumerable<Employee> GetEmployees()
        {
            var employees = new List<Employee>();
            var random = new Random();

            int index = 0;
            do
            {
                employees.Add(CreateEmployee($"Empleado {index + 1}", random.Next(1, 999999999), GetTurnEnum(index)));
                index++;
            }
            while (index < 10);

            return employees;
        }

        private static TurnEnum GetTurnEnum(int index)
        {
            var turn = TurnEnum.Manana;
            if (index > 3 && index < 7)
                turn = TurnEnum.Noche;
            else if (index >= 7)
                turn = TurnEnum.Tarde;
            return turn;
        }

        private static Employee CreateEmployee(string name, int phoneNumber, TurnEnum turn)
        {
            return new Employee(name, phoneNumber, turn);
        }

        private static string GetExercise2Text(IEnumerable<Employee> employees)
        {
            var text = new StringBuilder();
            var employeeIndex = 1;
            foreach (var employee in employees)
            {
                text.AppendLine($"Empleado {employeeIndex++}:");
                employee.ToString().Split(',').ToList().ForEach(prop => text.AppendLine($" > {prop.TrimStart()}"));
            }

            return text.ToString();
        }

        #endregion

        #region Exercise3

        private static void Exercise3()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 2:", useReadLine: false);

            var donut = CreateDonut(19.45, true);
            var muffin = CreateMuffin(34.56, "Magdalena Premiun");
            var cake = CreateCake(SizeEnum.Mediano, 5, "Feliz cumpleaños");

            ConsoleAppPrintUtil.PrintText(GetExercise3Text(donut, muffin, cake), useConsoleClear: false);
        }

        private static Cake CreateCake(SizeEnum size, int numberOfCandles, string customText)
        {
            return new Cake(size, numberOfCandles, customText);
        }

        private static Muffin CreateMuffin(double price, string specificName)
        {
            return new Muffin(price, specificName);
        }

        private static Donut CreateDonut(double price, bool hasHole)
        {
            return new Donut(price, hasHole);
        }

        private static string GetExercise3Text(Donut donut, Muffin muffin, Cake cake)
        {
            var text = new StringBuilder();

            text.AppendLine($"Donut:");
            donut.ToString().Split(',').ToList().ForEach(prop => text.AppendLine($" > {prop.TrimStart()}"));

            text.AppendLine("");

            text.AppendLine($"Magdalenas:");
            muffin.ToString().Split(',').ToList().ForEach(prop => text.AppendLine($" > {prop.TrimStart()}"));

            text.AppendLine("");

            text.AppendLine($"Pastel:");
            cake.ToString().Split(',').ToList().ForEach(prop => text.AppendLine($" > {prop.TrimStart()}"));

            return text.ToString();
        }
        #endregion
    }
}
