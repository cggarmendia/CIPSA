using CIPSA.Util.ConsoleApp;
using CIPSA.Util.ConsoleApp.Class.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CIPSA.M_IX.ConsoleApp
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

                M_IX_Logic.ExecuteExercise(ref answerOfQuestion);

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

    class M_IX_Logic
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
                }
        }

        #endregion

        #region Exercise1

        private static void Exercise1()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 1:", useReadLine: false);

            ConsoleAppPrintUtil.PrintText("Complete los datos restantes del alumno 1:", useConsoleClear: false);

            var questions = new string[] {
                "¿Cuáles son tus apellidos?",
                "¿Qué edad tienes?",
                "¿Cuál es tu nombre?"
            };

            var student1 = GetStudentWithoutName(questions);
            student1.Name = "Alumno 1";

            ConsoleAppPrintUtil.PrintText($"Los datos del alumno 1 son > {student1}.");

            ConsoleAppPrintUtil.PrintText("Complete los datos del alumno 2:");

            var student2 = GetStudentWithoutName(questions);
            student2.Name = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[2]);

            ConsoleAppPrintUtil.PrintText($"Los datos del alumno 2 son > {student2}.");
        }

        private static Student GetStudentWithoutName(string[] questions)
        {
            var student = new Student
            {
                LastName = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[0]),

                Age = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive(questions[1], 150)
            };

            return student;
        }

        #endregion

        #region Exercise2

        private static void Exercise2()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 2:", useReadLine: false);

            ConsoleAppPrintUtil.PrintText("Complete los datos del alumno:", useConsoleClear: false);

            var questions = new string[] {
                "¿Cuáles son tus apellidos?",
                "¿Qué edad tienes?",
                "¿Cuál es tu nombre?"
            };

            var student = new Student();

            student.Name = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[2]);

            student.LastName = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[0]);

            student.Age = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive(questions[1], 150);

            ConsoleAppPrintUtil.PrintText($"Los datos del alumno son > {student}.");
        }

        #endregion

        #region Exercise3

        private static void Exercise3()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 3:", useReadLine: false);

            ConsoleAppPrintUtil.PrintText("Complete los datos del alumno:", useConsoleClear: false);

            var questions = new string[] {
                "¿Cuáles son tus apellidos?",
                "¿Qué edad tienes?",
                "¿Cuál es tu nombre?",
                "¿Cuál es la nota del examen?"
            };

            var student = new Student
            {
                Name = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[2]),

                LastName = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[0]),

                Age = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive(questions[1], 150),

                ExaminationNote = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive(questions[3], 10)
            };

            ConsoleAppPrintUtil.PrintText($"Los datos del alumno son > {student}.");
        }

        #endregion

        #region Exercise4

        private static void Exercise4()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 4:", useReadLine: false);

            ConsoleAppPrintUtil.PrintText("Complete los datos del alumno:", useConsoleClear: false);

            var questions = new string[] {
                "¿Cuáles son tus apellidos?",
                "¿Qué edad tienes?",
                "¿Cuál es tu nombre?",
                "¿Cuál es la nota del examen?",
                "¿Cuál es su género?"
            };

            var student = new Student
            {
                Name = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[2]),

                LastName = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[0]),

                Age = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive(questions[1], 150),

                ExaminationNote = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive(questions[3], 10),

                Sex = ConsoleAppPrintUtil.PrintQuestionWithCharAnswerRecursive(questions[4], correctAnswers: new string[] { "H", "M"})
            };

            ConsoleAppPrintUtil.PrintText($"Los datos del alumno son > {student}.");
        }

        #endregion

        #region Exercise5

        private static void Exercise5()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 5:", useReadLine: false);

            ConsoleAppPrintUtil.PrintText("Complete los datos del alumno:", useConsoleClear: false);

            var questions = new string[] {
                "¿Cuáles son tus apellidos?",
                "¿Qué edad tienes?",
                "¿Cuál es tu nombre?",
                "¿Cuál es la nota del examen?",
                "¿Cuál es su género?",
                "¿Cuál es el nombre de la Asignatura?",
                "¿Cuál es el área de la Asignatura?"
            };

            var student = new Student
            {
                Name = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[2]),

                LastName = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[0]),

                Age = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive(questions[1], 150),

                ExaminationNote = ConsoleAppPrintUtil.PrintQuestionWithIntAnswerLessThanRecursive(questions[3], 10),

                Sex = ConsoleAppPrintUtil.PrintQuestionWithCharAnswerRecursive(questions[4], correctAnswers: new string[] { "H", "M" })
            };

            ConsoleAppPrintUtil.PrintText("Complete los datos de las 10 asignaturas del alumno:");

            do
            {
                ConsoleAppPrintUtil.PrintText($"Complete los datos de la Asignatura {student.Subjects.Count() + 1}");

                var asignatura = new Subject() {
                    Name = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[5]),
                    Area = ConsoleAppPrintUtil.PrintQuestionWithStringAnswerRecursive(questions[6])
                };
                student.Subjects.Add(asignatura);

            } while (student.Subjects.Count() < 10);

            ConsoleAppPrintUtil.PrintText(GetExercise5Text(student));
        }

        private static string GetExercise5Text(Student alumno)
        {
            var exercise5Text = new StringBuilder();

            exercise5Text.AppendLine($"Los datos del alumno son > {alumno}.");

            exercise5Text.AppendLine(alumno.GetSubjectsStringBuilder().ToString());

            return exercise5Text.ToString();
        }

        #endregion

        #region Exercise6

        private static void Exercise6()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 6:", useReadLine: false);

            var students = GetStudents(3, aula: 1);

            var classroom = new Classroom() {
                Students = students
            };

            ConsoleAppPrintUtil.PrintText(GetExercise6Text(classroom));
        }

        private static ICollection<Student> GetStudents(int count, int aula)
        {
            var students = new List<Student>();
            for (int i = 0; i < count; i++)
            {
                students.Add( 
                        new Student
                        {
                            Name = $"Name {i}",
                            LastName = $"LastName {i}",
                            Sex = i % 2 == 0 ? 'H' : 'M',
                            ExaminationNote = (10 - i) - aula ,
                            Age = 30 - i
                        }
                    );
            }
            return students;
        }

        private static string GetExercise6Text(Classroom aula)
        {
            var exercise6Text = new StringBuilder();

            exercise6Text.AppendLine("Datos del aula --------------------------");
            exercise6Text.AppendLine($"Media de los alumnos: {aula.GetExaminationNoteAverageOfStudents()}");
            exercise6Text.AppendLine($"Número de hombres: {aula.GetNumberOfStudents('H')}");
            exercise6Text.AppendLine($"Número de mujeres: {aula.GetNumberOfStudents('M')}");

            return exercise6Text.ToString();
        }

        #endregion

        #region Exercise7

        private static void Exercise7()
        {
            ConsoleAppPrintUtil.PrintTextWithLineSeparator("Ejercicio 7:", useReadLine: false);

            var academy = new Academy() {
                Classrooms = GetAulas(2)
            };

            ConsoleAppPrintUtil.PrintText(GetExercise7Text(academy));
        }

        private static ICollection<Classroom> GetAulas(int count)
        {
            var classrooms = new List<Classroom>();
            for (int i = 0; i < count; i++)
            {
                classrooms.Add(new Classroom() {
                    Students = GetStudents(3, aula: i + 1)
                });
            }
            return classrooms;
        }

        private static string GetExercise7Text(Academy academia)
        {
            var exercise7Text = new StringBuilder();

            exercise7Text.AppendLine("Datos de la academia --------------------------");
            exercise7Text.AppendLine($"Media de las aulas: {String.Join(" / ",academia.GetAverageOfTheClassrooms())}");
            exercise7Text.AppendLine($"Número de hombres: {academia.GetNumberOfAlumno('H')}");
            exercise7Text.AppendLine($"Número de mujeres: {academia.GetNumberOfAlumno('M')}");

            return exercise7Text.ToString();
        }

        #endregion
    }
}
