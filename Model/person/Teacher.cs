using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.person
{
    public class Teacher : Personal_Info
    {
        private int subjectID;
        private bool isClassTeacher;
        public List<string> StudentIDs=new List<string>();

        public bool IsClassTeacher
        {
            get => isClassTeacher; set => isClassTeacher = value;
        }

        public int SubjectID
        {
            get => subjectID; set => subjectID = value;
        }

        public Teacher()
        {
        }

        public Teacher(string teacherID,string Fname, string Lname, string phoneNumber, address.Address address, string password, int subjectID, bool isClassTeacher)
            : base(teacherID,Fname, Lname, phoneNumber, address, password)
        {
            this.SubjectID = subjectID;
            this.IsClassTeacher = isClassTeacher;

        }

        public void AddStudent(string studentID)
        {
            StudentIDs.Add(studentID);
        }
        public void RemoveStudent(string studentID)
        {
            StudentIDs.Remove(studentID);
        }

        public override string ToString()
        {
            return base.ToString() + $"SubjectID: {SubjectID}, IsClassTeacher: {IsClassTeacher}";

        }
    }
}
