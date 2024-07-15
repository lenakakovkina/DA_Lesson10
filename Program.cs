using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text.RegularExpressions;
using System.Xml.Linq;



int maxValueOfStudents = 6;
String separatorComma = ",";
bool existStudentWithBadMark=false;
bool studentExist=false;
Console.WriteLine($"Input student's name and mark in a format \"Name Surname: mark\". Use comma as separator. The max quantity of students is {maxValueOfStudents}");
String RawInput = Console.ReadLine();


string[] splitStudents = RawInput.Split(separatorComma);
List <string> namePerStudent = new List<string>();
List<int> markPerStudent = new List<int>();

foreach (string student in splitStudents)
{
    string marksOnly = Regex.Replace(student, ".*?:", "").Trim(); //Non-greedy matching (with ?) matches as little as possible
    markPerStudent.Add(int.Parse(marksOnly));
    string namesOnly = Regex.Replace(student, ":.*", "").Trim();
    namePerStudent.Add(namesOnly);
}


Console.WriteLine("\nList of students and their marks:");

for (int i = 0; i < namePerStudent.Count; i++)
{
  Console.WriteLine($"Student with name {namePerStudent[i]} has mark {markPerStudent[i]} ");
}

Console.WriteLine("\nList of students that have mark less than 5:");
    for (int i = 0; i < namePerStudent.Count; i++)
    {
        if (markPerStudent[i] < 5)
        {
            Console.WriteLine($"Student with name {namePerStudent[i]} has mark {markPerStudent[i]}");
            existStudentWithBadMark = true;
        }       
    }
    if (!existStudentWithBadMark)
    {
     Console.WriteLine("There is no students with mark less then 5");
    }



while (true)
{
    Console.WriteLine($"\nUpdate information for existed student or add new one.\nMake changes for ONLY one student per iteration and press enter \nName and mark should be in a format \"Name Surname: mark\".");
    String RawInputUpdated = Console.ReadLine();
    string namePerStudentUpdated = Regex.Replace(RawInputUpdated, ":.*", "");
    int markPerStudentUpdated = int.Parse(Regex.Replace(RawInputUpdated, ".*?:", ""));

    studentExist = false;
    for (int i = 0; i < namePerStudent.Count; i++)
    {
        if (namePerStudent[i].Equals(namePerStudentUpdated, StringComparison.OrdinalIgnoreCase))
        {
            markPerStudent[i] = markPerStudentUpdated;
            studentExist = true;
        }
        if (!studentExist && namePerStudent.Count < maxValueOfStudents)
        {
            namePerStudent.Add(namePerStudentUpdated);
            markPerStudent.Add(markPerStudentUpdated);
            break;
        }  
    }
    Console.WriteLine("\nUpdated list of students and their marks:");
    for (int i = 0; i < namePerStudent.Count; i++)
    {
     Console.WriteLine($"Student with name {namePerStudent[i]} has mark {markPerStudent[i]}");
    }
    Console.WriteLine("\nList of students that have mark less than 5:");
    for (int i = 0; i < namePerStudent.Count; i++)
    {
        if (markPerStudent[i] < 5)
        {
            Console.WriteLine($"Student with name {namePerStudent[i]} has mark {markPerStudent[i]}");
            existStudentWithBadMark = true;
        }
    }
    if (!existStudentWithBadMark)
    {
        Console.WriteLine("There is no students with mark less then 5");
    }

}
