using System.Collections.Generic;

namespace Model.person.student
{
    public class Student : Personal_Info
    {

        private char _gender;
        private int _classID;
        private List<string> teacherIDs = new List<string>();


        public List<string> TeacherIDs
        {
            get => teacherIDs; set => teacherIDs = value;
        }

        public int ClassID
        {
            get => _classID; set => _classID = value;
        }


        public char Gender
        {
            get => _gender; set => _gender = value;
        }

        public Student()
        {

        }
        public Student(string studentID, string Fname, string Lname, string phoneNumber, Address address, string password, char gender, int classID)
            : base(studentID, Fname, Lname, phoneNumber, address, password)
        {

            this.Gender = gender;
            this.ClassID = classID;
        }


        public void AddTeacher(string teacherID)
        {
            TeacherIDs.Add(teacherID);
        }

        public void RemoveTeacher(string teacherID)
        {
            TeacherIDs.Remove(teacherID);
        }

        public override string ToString()
        {
            return base.ToString() + $"Gender: {Gender}";
        }
    }
}
