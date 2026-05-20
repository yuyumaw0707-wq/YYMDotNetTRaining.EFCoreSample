using System;
using System.Linq;
using YYMDotNetTraining.EFCore.DataAccess;

namespace YYMDotNetTraining.EFCore.ConsoleApp
{
    public class EfCoreCrudService
    {
        // Read all data from the database
        public void Read()
        {
            using var context = new AppDbContext();
            Console.WriteLine("--- Reading data using EF Core ---");
            var students = context.TblStudents.Where(x => x.DeleteFlag == 0).ToList();

            if (!students.Any())
            {
                Console.WriteLine("No students found.");
                return;
            }

            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.StudentId}, No: {student.StudentNo}, Name: {student.StudentName}");
            }
        }

        // Edit data by ID
        public void Edit(int studentId)
        {
            using var context = new AppDbContext();
            var student = context.TblStudents
                .FirstOrDefault(s => s.StudentId == studentId && s.DeleteFlag == 0);

            if (student is null)
            {
                Console.WriteLine($"Student with ID {studentId} not found.");
                return;
            }

            Console.WriteLine("--- Editing Student ---");
            Console.WriteLine($"ID: {student.StudentId}");
            Console.WriteLine($"Student No: {student.StudentNo}");
            Console.WriteLine($"Student Name: {student.StudentName}");
            Console.WriteLine("-----------------------");
        }

        // Create new data
        public void Create(string studentNo, string studentName, string fatherName, DateTime dateOfBirth, string gender, string address, string mobileNo)
        {
            using var context = new AppDbContext();
            var student = new TblStudent
            {
                StudentNo = studentNo,
                StudentName = studentName,
                FatherName = fatherName,
                DateOfBirth = dateOfBirth,
                Gender = gender,
                Address = address,
                MobileNo = mobileNo,
                DeleteFlag = 0
            };

            context.TblStudents.Add(student);
            int result = context.SaveChanges();

            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        // Update data by ID
        public void Update(int studentId, string studentName, string address)
        {
            using var context = new AppDbContext();
            var student = context.TblStudents
                .FirstOrDefault(s => s.StudentId == studentId && s.DeleteFlag == 0);

            if (student is null)
            {
                Console.WriteLine($"Student with ID {studentId} not found for updating.");
                return;
            }

            student.StudentName = studentName;
            student.Address = address;
            int result = context.SaveChanges();

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        // Delete data by ID (Soft Delete)
        public void Delete(int studentId)
        {
            using var context = new AppDbContext();
            var student = context.TblStudents.FirstOrDefault(s => s.StudentId == studentId);

            if (student is null)
            {
                Console.WriteLine($"Student with ID {studentId} not found for deleting.");
                return;
            }

            student.DeleteFlag = 1; // Set the flag to 1 for soft delete
            int result = context.SaveChanges();

            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }
}
