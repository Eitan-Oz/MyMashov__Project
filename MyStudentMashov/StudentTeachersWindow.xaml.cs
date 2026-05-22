using DAL;
using Model.person; // To access the Teacher model class
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace MyStudentMashov
{
    public partial class StudentTeachersWindow : Window
    {
        private DAL.BaseDal dal;
        private string loggedInStudentID;

        // Constructor receives the logged in Student's ID
        public StudentTeachersWindow(string studentID)
        {
            InitializeComponent();
            dal = new BaseDal();
            this.loggedInStudentID = studentID;

            // Load teachers automatically when window opens
            LoadStudentTeachers();
        }

        private void LoadStudentTeachers()
        {
            try
            {
                // SQL query to fetch all teachers related to this specific student
                string sql = "SELECT Teachers.PersonalID, Teachers.FirstName, Teachers.LastName, " +
                             "Teachers.PhoneNumber, Teachers.Password, Teachers.SubjectID, Teachers.IsClassTeacher " +
                             "FROM Teachers " +
                             "INNER JOIN StudentTeachersRel ON Teachers.PersonalID = StudentTeachersRel.TeacherID " +
                             $"WHERE StudentTeachersRel.StudentID = '{loggedInStudentID}'";

                // תיקון: שימוש במתודה המקורית מה-BaseDal שלך
                DataTable dt = dal.ExecuteSelectAllQuery(sql);

                List<Teacher> teachersList = new List<Teacher>();

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        // Mapping database rows into your Teacher model object
                        Teacher teacher = new Teacher(
                            row["PersonalID"].ToString(),
                            row["FirstName"].ToString(),
                            row["LastName"].ToString(),
                            row["PhoneNumber"].ToString(),
                            row["Password"].ToString(),
                            Convert.ToInt32(row["SubjectID"]),
                            Convert.ToBoolean(row["IsClassTeacher"])
                        );
                        teachersList.Add(teacher);
                    }
                }

                // Binding the list to the Grid view inside the UI
                dgTeachers.ItemsSource = teachersList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading teachers list: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}