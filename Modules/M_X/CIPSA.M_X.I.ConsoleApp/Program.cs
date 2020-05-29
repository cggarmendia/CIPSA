using CIPSA.Util.ConsoleApp;
using CIPSA.Util.ConsoleApp.Class.M_X.I;
using CIPSA.Util.ConsoleApp.Enum;
using CIPSA.Util.ConsoleApp.Extension;
using System.Collections.Generic;
using System.Text;

namespace CIPSA.M_X.I.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var answerOfQuestion = string.Empty;
            var correctAnswerOfExerciseOption = new List<string>() { "E", "1", "3", "4", "5" };
            var exerciseNumbers = new List<int>() { 1, 3, 4, 5 };
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
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 1:", useReadLine: false);

            ConsoleAppPrintUtil.PrintText("Los objetos han sido creados:", useConsoleClear: false, useReadLine: false);

            var house = CreateHouse(surface: 100, plants: 2, habitations: 3, bedrooms: 2, bathrooms: 1);

            var office = CreateOffice(surface: 100, plants: 2, habitations: 3, fireExtinguishers: 1, phones: 1);

            ConsoleAppPrintUtil.PrintText(GetExercise1Text(house, office), useConsoleClear: false);
        }

        private static string GetExercise1Text(House house, Office office)
        {
            var text = new StringBuilder();

            text.AppendLine("OBJETO OFICINA:");
            text.AppendLine(office.ToString());
            text.AppendLine("OBJETO CASA:");
            text.AppendLine(house.ToString());

            return text.ToString();
        }

        private static Office CreateOffice(int fireExtinguishers, int phones, int surface, int plants, int habitations)
        {
            return new Office( fireExtinguishers, phones, surface, plants, habitations);
        }

        private static House CreateHouse(int bedrooms, int bathrooms, int surface, int plants, int habitations)
        {
            return new House(bedrooms, bathrooms, surface, plants, habitations);
        }

        #endregion

        #region Exercise3

        private static void Exercise3()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 3:", useReadLine: false);

            var dog = CreateDog(color: "negro", scientificName: "perro", alimentacion: FeedingEnum.Carnivoro, velocidad: 60);

            var cat = CreateCat(raza: "persa", scientificName: "perro", alimentacion: FeedingEnum.Carnivoro, velocidad: 40);

            Animal animal1 = dog;
            Animal animal2 = cat;

            var dogToString = animal1.ToString();
            var dogRun = animal1.Run();
            var dogJump = animal1.Jump();
            //var perroColor = animal1.Color; Es una propiedad de una de las especificaciones
            //var perroRaza = animal1.Raza; Es una propiedad de una de las especificaciones

            var catToString = animal2.ToString();
            var catRun = animal2.Run();
            var catJump = animal2.Jump();
            //var gatoColor = animal2.Color; Es una propiedad de una de las especificaciones
            //var gatoRaza = animal2.Raza; Es una propiedad de una de las especificaciones

            ConsoleAppPrintUtil.PrintText("Los objetos han sido creados y analizado su comportamiento.", useConsoleClear: false);
        }

        private static Dog CreateDog(string color, string scientificName, FeedingEnum alimentacion, int velocidad)
        {
            return new Dog(color, scientificName, alimentacion, velocidad);
        }

        private static Cat CreateCat(string raza, string scientificName, FeedingEnum alimentacion, int velocidad)
        {
            return new Cat(raza, scientificName, alimentacion, velocidad);
        }

        #endregion

        #region Exercise4

        private static void Exercise4()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 4:", useReadLine: false);

            Teacher teacher = CreateProfesor(name: "Profesor", lastName: "Apellidos", assignedClassroom: "1", isTutor: true);
            Person teacherPerson = teacher;

            Director director = CreateDirector(name: "Director", lastName: "Apellidos", college: "Colegio", seniority: 40);
            Person directorPerson = director;

            Student student = CreateAlumno(name: "Alumno", lastName: "Apellidos", englishNote: 6, mathNote: 10, spanishNote: 8);
            Person studentPerson = student;

            ConsoleAppPrintUtil.PrintText(GetExercise5Text(teacherPerson, directorPerson, studentPerson), useConsoleClear: false);
        }

        private static string GetExercise5Text(Person profesorPersona, Person directorPersona, Person alumnoPersona)
        {
            var text = new StringBuilder();
            text.AppendLine($"Profesor: {profesorPersona.GetInfo()}");
            text.AppendLine($"Director: {directorPersona.GetInfo()}");
            text.AppendLine($"Alumno: {alumnoPersona.GetInfo()}");
            return text.ToString();
        }

        private static Teacher CreateProfesor(string name, string lastName, string assignedClassroom, bool isTutor)
        {
            return new Teacher(name, lastName, assignedClassroom, isTutor);
        }

        private static Student CreateAlumno(string name, string lastName, int mathNote, int spanishNote, int englishNote)
        {
            return new Student(name, lastName, mathNote, spanishNote, englishNote);
        }

        private static Director CreateDirector(string name, string lastName, string college, int seniority)
        {
            return new Director(name, lastName, college, seniority);
        }

        #endregion

        #region Exercise5

        private static void Exercise5()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 5:", useReadLine: false);

            var phrase = "Se debe sustituir casa por edificio";
            ConsoleAppPrintUtil.PrintText($"Frase antes del replace: {phrase}", useConsoleClear: false, useReadLine: false);

            var oldWord = "casa";
            var newWord = "edificio";
            phrase = phrase.ReplaceWord(oldWord, newWord);

            ConsoleAppPrintUtil.PrintText($"Frase después del replace: {phrase}", useConsoleClear: false, useReadLine: false);

            var phraseWithVowels = "Arquitecto";

            ConsoleAppPrintUtil.PrintText($"La palabra: {phraseWithVowels}, tiene {phraseWithVowels.CountVowels()} vocales.", useConsoleClear: false);

        }
        
        #endregion
    }
}
