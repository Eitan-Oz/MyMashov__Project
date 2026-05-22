using DAL;
using Model.person.student;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace MyTeacherMashov
{
    public partial class TeacherStudentsWindow : Window
    {
        private BaseDal dal;
        private string loggedInTeacherID;

        // Constructor receives the logged in Teacher's ID
        public TeacherStudentsWindow(string teacherID)
        {
            InitializeComponent();
            dal = new BaseDal(); // Initializes the connection from BaseDal.cs
            this.loggedInTeacherID = teacherID;

            // Automatically load students when the window opens
            LoadTeacherStudents();
        }

        private void LoadTeacherStudents()
        {
            try
            {
                // 1. עדכון שאילתת ה-SQL כדי שתשלוף גם את עמודת המגדר (Students.Gender)
                string sql = "SELECT Students.PersonalID, Students.FirstName, Students.LastName, " +
                             "Students.PhoneNumber, Students.Password, Students.Gender, Students.ClassID " +
                             "FROM Students " +
                             "INNER JOIN StudentTeachersRel ON Students.PersonalID = StudentTeachersRel.StudentID " +
                             $"WHERE StudentTeachersRel.TeacherID = '{loggedInTeacherID}'";

                // שימוש במתודה המקורית מה-BaseDal שלך כדי לקבל את הטבלה
                DataTable dt = dal.ExecuteSelectAllQuery(sql);

                List<Student> studentsList = new List<Student>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        // שליפת מחרוזת המגדר והמרתה לתו בודד (char) כפי שהבנאי דורש
                        string genderStr = row["Gender"].ToString();
                        char gender = string.IsNullOrEmpty(genderStr) ? 'M' : genderStr[0]; // ברירת מחדל 'M' אם ריק

                        // 2. יצירת אובייקט הסטודנט עם כל 7 הפרמטרים בדיוק לפי סדר הבנאי שלך
                        Student student = new Student(
                            row["PersonalID"].ToString(),
                            row["FirstName"].ToString(),
                            row["LastName"].ToString(),
                            row["PhoneNumber"].ToString(),
                            row["Password"].ToString(),
                            gender,                             // נשלח כ-char
                            Convert.ToInt32(row["ClassID"])     // נשלח כ-int
                        );
                        studentsList.Add(student);
                    }
                }

                // חיבור הרשימה המלאה ל-DataGrid בתצוגה
                dgStudents.ItemsSource = studentsList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading students list: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}