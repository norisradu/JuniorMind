﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Catalog
{
    [TestClass]
    public class CatalogTests
    {
        [TestMethod]
        public void ShouldCalculateGeneralAverageGradeOfOneStudent()
        {
            Assert.AreEqual(7, CalculateTheAverageGradeForOneStudent(new Student("Ion", new Class[] {
                new Class("Math", new double[] { 5, 6, 4 }),
                new Class("Biology", new double[] { 7, 6, 8 }),
                new Class("Chemistry", new double[] { 5, 7, 6 }),
                new Class("English", new double[] { 9, 10, 8 }),
                new Class("French", new double[] { 10, 8 }),
                new Class("Informatics", new double[] { 4, 6, 6, 4 }),
                new Class("Physics", new double[] { 7, 9 }),
                new Class("Spanish", new double[] { 9, 9 }),
                new Class("History", new double[] { 8, 10 }),
                new Class("Sports", new double[] { 10, 10 }),
                new Class("Economy", new double[] { 9, 1, 5 })})));
        }
        [TestMethod]
        public void ShouldReturnAverage()
        {
            Assert.AreEqual(3, CalculateTheAverageGradeForOneStudent(new Student("Ion", new Class[] {
                new Class("Math", new double[] { 1, 2, 3 }),
                new Class("Biology", new double[] { 2, 3, 4 }),
                new Class("Chemistry", new double[] { 3, 4, 5 }) })));
        }
        [TestMethod]
        public void ShouldSortStudentsDependingOnGeneralAverageGrade()
        {
            Assert.AreEqual(new NameAndGeneralAverageGrade("Andrei", 8), Sort(new Student[] { new Student("Raul", new Class[]
           {
                new Class("Math", new double[] { 5, 6, 4 }),
                new Class("Biology", new double[] { 7, 6, 8 }),
                new Class("Chemistry", new double[] { 5, 7, 6 })
           }), new Student("Catalin", new Class[]
           {
                new Class("English", new double[] { 9, 10, 8 }),
                new Class("French", new double[] { 10, 8 }),
                new Class("Informatics", new double[] { 4, 6, 6, 4 })
           }), new Student("Andrei", new Class[]
           {
               new Class("Physics", new double[] { 7, 9 }),
                new Class("Spanish", new double[] { 9, 9 }),
                new Class("History", new double[] { 8, 10 }),
                new Class("Sports", new double[] { 10, 10 }),
                new Class("Economy", new double[] { 9, 1, 5 })
           })}));
        }
        [TestMethod]
        public void ShouldReturnTheStudentWithTheNameCloserToTheLeftSide()
        {
            Assert.AreEqual("Andrei", CompareTwoNames("Raul", "Andrei"));
            Assert.AreEqual("Mircea", CompareTwoNames("Mircea", "Tiberiu"));
            Assert.AreEqual("Andreea", CompareTwoNames("Andrei", "Andreea"));
            Assert.AreEqual("Mariana", CompareTwoNames("Mariana", "Marinel"));
            Assert.AreEqual("Mariana", CompareTwoNames("Marinel", "Mariana"));
        }
        
        public struct Student
        {
            public string name;
            public Class[] classes;

            public Student(string name, Class[] classes)
            {
                this.name = name;
                this.classes = classes;
            }
        }

        public struct Class
        {
            public string name;
            public double[] grades;

            public Class(string name, double[] grades)
            {
                this.name = name;
                this.grades = grades;
            }
        }

        public struct NameAndGeneralAverageGrade
        {
            public string name;
            public int generalAverageGrade;

            public NameAndGeneralAverageGrade(string name, int generalAverageGrade)
            {
                this.name = name;
                this.generalAverageGrade = generalAverageGrade;
            }
        }

        /*public static SortAlphabetically(Student[] students)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if ()
            }
        }*/

        public static NameAndGeneralAverageGrade Sort(Student[] students)
        { 
            for (int i = 0; i < students.Length - 1; i++)
            {
                int maximum = i;
                for (int j = i + 1; j < students.Length; j++)
                {
                    if (CalculateTheAverageGradeForOneStudent(students[j]) > CalculateTheAverageGradeForOneStudent(students[maximum]))
                        maximum = j;
                }
                if (maximum != i)
                    Swap(ref students[i], ref students[maximum]);
            }
            int bestGeneralAverageGrade = CalculateTheAverageGradeForOneStudent(students[0]);
            return new NameAndGeneralAverageGrade(students[0].name, bestGeneralAverageGrade);
        }

        static int CalculateTheAverageGradeForOneStudent(Student student)
        {
            double totalGrade = 0;
            for (int i = 0; i < student.classes.Length; i++)
            {
                double domainGrade = CalculateDomainGrade(student.classes[i]);
                totalGrade += domainGrade;
            }
            return (int)totalGrade / student.classes.Length;
        }

        static double CalculateDomainGrade(Class domain)
        {
            double result = 0;
            for (int i = 0; i < domain.grades.Length; i++)
            {
                result += domain.grades[i];
            }
            result /= domain.grades.Length;
            return result;
        }

        static string CompareTwoNames(string first, string second)
        {
            for (int i = 0; i < first.Length; i++)
            {
                if (second[i] < first[i])
                    return second;
                else if (first[i] < second[i])
                    return first;
                continue;
            }
            return first;
        }

        static void Swap(ref Student first, ref Student second)
        {
            Student temp = first;
            first = second;
            second = temp;
        }
    }
}