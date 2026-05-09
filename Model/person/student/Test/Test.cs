using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.person.student.Test
{
    internal class Test
    {
        private int _subjectID;
        private string _test_Subject;
        private int _teacherID;
        private int _studentID;
        private int _grade;
        private bool _isPassed;
        private string _comment;

        public int SubjectID
        {
            get { return _subjectID; }
            set { _subjectID = value; }
        }
        public string TastSubject
        {
            get { return _test_Subject; }
            set { _test_Subject = value; }
        }
        public int TeacherID
        {
            get { return _teacherID; }
            set { _teacherID = value; }
        }
        public int StudentID
        {
            get { return _studentID; }
            set { _studentID = value; }
        }
        public int Grade
        {
            get => _grade;
            set
            {
                _grade = value;
                _isPassed = (value >= 55); // מעדכן אוטומטית אם עבר או נכשל
            }
        }
        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        public Test()
        {

        }
        public Test(int subjectID, string tast_Subject, int teacherID, int studentID, int grade, bool isPassed, string comment)
        {
            this._subjectID = subjectID;
            this._test_Subject = tast_Subject;
            this._teacherID = teacherID;
            this._studentID = studentID;
            this._grade = grade;
            this._isPassed = isPassed;
            this._comment = comment;
        }
    }
}
