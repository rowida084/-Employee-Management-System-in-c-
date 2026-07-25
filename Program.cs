using ConsoleApp4.Models;
using ConsoleApp4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{

    internal class Program
    {
        private enum enOption { enaddEmployeeOnboarding=1,enaddDeparment =3,enProcessNextEmployee=2,
        enSearchEmpByID=4,enSearchEmpByName=5,enPrintEmps=6,enCalcSalaryAvrage=7,
        enEmpsReport=8,enPrintActionHistory=9,enPrintUniqueSkills=10}

      static  private clsEmployee _readEmployee(clsCompany company)
        {
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();
          
                Console.Write("Enter ID : ");
              int  id = int.Parse(Console.ReadLine());
            
            while (company.IDIsFound(id))
            {
                Console.WriteLine("This ID is Already Exists!");
                Console.Write("Enter ID : ");
                 id = int.Parse(Console.ReadLine());
            }


            Console.Write("Enter DepartmentID : ");
            int departmentID= int.Parse(Console.ReadLine());
            Console.Write("Unique Skill : ");
            string uniqueSkill= Console.ReadLine();
            Console.Write("Enter Salary : ");
            double salary=double.Parse(Console.ReadLine());
            clsEmployee emp=new clsEmployee(name,id,departmentID,salary,uniqueSkill);
            return emp;
        }

        static void SeedData(clsCompany company)
        {
            company.addDepartment(1, "HR");
            company.addDepartment(2, "IT");
            company.addDepartment(3, "Finance");

            clsEmployee emp1 = new clsEmployee(
                "Ahmed",
                101,
                2,
                8000,
                "C#");

            clsEmployee emp2 = new clsEmployee(
                "Sara",
                102,
                1,
                7000,
                "Communication");

            clsEmployee emp3 = new clsEmployee(
                "Omar",
                103,
                3,
                9500,
                "Excel");

            company.addOnboardingEmployee(emp1);
            company.addOnboardingEmployee(emp2);
            company.addOnboardingEmployee(emp3);

            company.addSkill(emp1);
            company.addSkill(emp2);
            company.addSkill(emp3);

            company.addActionEmployee();
            company.addActionEmployee();
            company.addActionEmployee();
        }
        static private void _mainMenuPerformance(enOption choice,clsCompany company)
        {
            switch(choice)
            {
                case enOption.enaddEmployeeOnboarding:
                    {
                        clsEmployee emp = _readEmployee(company);
                        if (company.addOnboardingEmployee(emp))
                        {
                            company.addSkill(emp);
                            Console.WriteLine("This Employee Is Added Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("This ID Is Already Exist!");
                        }
                            break;
                    }

                    case enOption.enaddDeparment:
                    {
                        Console.Write("Enter Department Name : ");
                        string departmentName = Console.ReadLine();
                        while(company.departmentNameIsFound(departmentName))
                        {
                            Console.WriteLine("This Name Of Department is Already Exists!");
                            Console.Write("Enter Another Department Name : ");
                            departmentName = Console.ReadLine();
                        }
                        Console.Write("Enter Department ID : ");
                        int id = int.Parse(Console.ReadLine());
                        while(company.depatrmentIDIsFound(id))
                        {
                            Console.WriteLine("This ID Of Department is Already Exists!");
                            Console.Write("Enter Department ID : ");
                            id = int.Parse(Console.ReadLine());
                        }

                        if (company.addDepartment(id,departmentName))
                        {
                            Console.WriteLine("Department Added Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("This Department Already Exists!");
                        }
                        Console.WriteLine();
                            break;
                    }

                    case enOption.enProcessNextEmployee:
                    {
                        if (company.addActionEmployee())
                        {
                            Console.WriteLine("Employee Added Successfully!");
                        }
                        else
                        {
                            Console.WriteLine("Employee Failed To Be Added!");
                        }
                        Console.WriteLine();
                            break;
                    }

                    case enOption.enSearchEmpByID:
                    {
                        Console.Write("Enter Employee ID : ");
                        int id = int.Parse(Console.ReadLine());
                       clsEmployee emp= company.searchEmployeeByID(id);
                        if (emp != null)
                        {
                            emp.Print();
                        }
                        else
                        {
                            Console.WriteLine("This Employee Does Not Exist!");
                        }
                        Console.WriteLine();
                        break;
                    }

                    case enOption.enSearchEmpByName:
                    {
                        Console.Write("Enter Employee Name : ");
                        string empName = Console.ReadLine();
                        clsEmployee emp = company.searchEmployeeByName(empName);
                        if (emp != null)
                        {
                            emp.Print();
                        }
                        else
                        {
                            Console.WriteLine("This Employee Does Not Exist!");
                        }
                        Console.WriteLine();
                            break;
                    }

                    case enOption.enPrintEmps:
                    {
                        Console.Write("Enter Department Name : ");
                        string  departmentName = Console.ReadLine();
                      
                       if( !company.printAllEmployeeByDepartment(departmentName))
                            Console.WriteLine("This Department Does Not Have Any Employee");
                        Console.WriteLine();
                        break;
                    }

                    case enOption.enCalcSalaryAvrage:
                    {
                        Console.WriteLine($"Salary Average : {company.calcSalaryAverage()}");
                        Console.WriteLine();
                        break;
                    }

                    case enOption.enEmpsReport:
                    {
                        company.numOfEmployeesInEachDepartmentReport();
                        Console.WriteLine();
                        break;
                    }

                    case enOption.enPrintActionHistory:
                    {
                        company.printActionHistory();
                        Console.WriteLine();
                        break;
                    }
                    case enOption.enPrintUniqueSkills:
                    {
                        company.printUniqueSkills();
                        Console.WriteLine();
                        break;
                    }
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }
        static void Main(string[] args)
        {
            clsCompany company= new clsCompany();
            SeedData(company);
            int choice;
            do
            {
                Console.WriteLine("========== Company Management ==========");
                Console.WriteLine("1. Add Employee To Onboarding");
                Console.WriteLine("2. Process Next Employee");
                Console.WriteLine("3. Add Department");
                Console.WriteLine("4. Search Employee By ID");
                Console.WriteLine("5. Search Employee By Name");
                Console.WriteLine("6. Print Employees By Department");
                Console.WriteLine("7. Calculate Salary Average");
                Console.WriteLine("8. Employees Report By Department");
                Console.WriteLine("9. Print Action History");
                Console.WriteLine("10.Print Unique Skills");
                Console.WriteLine("0. Exit");
                Console.WriteLine();
                Console.Write("\nEnter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine();
                Console.WriteLine();
                _mainMenuPerformance((enOption)choice,company);
            } while (choice != 0);
          
        }
    }
}
