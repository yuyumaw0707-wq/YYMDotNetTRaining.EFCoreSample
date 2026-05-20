using System;
using YYMDotNetTraining.EFCore.ConsoleApp;

namespace YYMDotNetTraining.EFCore.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new EfCoreCrudService();

            // 1. Read all students at the beginning
            Console.WriteLine("--- Reading all students initially ---");
            service.Read();
            Console.WriteLine("----------------------------------\n");

            // 2. Create a new student
            Console.WriteLine("--- Creating a new student ---");
            service.Create(
                "S11223",
                "Ba Kyaw",
                "U Mya",
                new DateTime(2002, 5, 20),
                "M",
                "Yangon",
                "09111222333"
            );
            service.Read(); // Read again to show the new student
            Console.WriteLine("------------------------------\n");

            // 3. Edit a specific student's data
            int studentIdToEdit = 11; // make sure this ID exists in DB
            Console.WriteLine($"--- Fetching student with ID {studentIdToEdit} for editing ---");
            service.Edit(studentIdToEdit);
            Console.WriteLine("-----------------------------------------------------------\n");

            // 4. Update that student's data
            Console.WriteLine($"--- Updating student with ID {studentIdToEdit} ---");
            service.Update(studentIdToEdit, "Ba Ba", "Mandalay");
            service.Read(); // Read again to show the updated data
            Console.WriteLine("------------------------------------------\n");

            // 5. Delete that student
            Console.WriteLine($"--- Deleting student with ID {studentIdToEdit} ---");
            service.Delete(studentIdToEdit);
            service.Read(); // Read again, the student should be gone (soft-deleted)
            Console.WriteLine("------------------------------------------\n");

            Console.ReadLine();
        }
    }
}
