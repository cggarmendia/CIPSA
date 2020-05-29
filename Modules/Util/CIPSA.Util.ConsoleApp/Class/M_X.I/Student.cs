namespace CIPSA.Util.ConsoleApp.Class.M_X.I
{
    public class Student : Person
    {
        #region Properties
        public int MathNote { get; set; }
        public int SpanishNote { get; set; }
        public int EnglishNote { get; set; }
        #endregion

        #region Ctors
        public Student()
            : base()
        {
            MathNote = 0;
            SpanishNote = 0;
            EnglishNote = 0;
        }

        public Student(string name, string lastName, int mathNote, int spanishNote, int englishNote)
            : base(name, lastName)
        {
            MathNote = mathNote;
            SpanishNote = spanishNote;
            EnglishNote = englishNote;
        }
        #endregion

        #region Methods
        public override string GetInfo()
        {
            return $"Nombre: {Name}, Apellidos: {LastName}, Nota de matemática: {MathNote}, Nota de lengua: {SpanishNote}, Nota de inglés: {EnglishNote}";
        }
        #endregion
    }
}
