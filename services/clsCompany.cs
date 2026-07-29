using ConsoleApp4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4.Services
{
    internal class clsCompany
    {
        public Queue<clsEmployee> onboarding=new Queue<clsEmployee>();
        public Stack<clsEmployee> actionHistory=new Stack<clsEmployee>();
        public List<clsEmployee> activeEmployees=new List<clsEmployee>();
        public Dictionary<int, string> departments=new Dictionary<int, string>();
        public HashSet<string> uniqueSkills=new HashSet<string>();

        public bool IDIsFound(int id )
        {
            foreach (clsEmployee emp in activeEmployees)
            {
                if (emp.ID == id)
                {
                    return true;
                }
            }
             foreach (clsEmployee emp in onboarding)
    {
        if (emp.ID == id)
            return true;
    }

            return false;
        }

        public bool departmentNameIsFound(string departmentName)
        {
          return   departments.ContainsValue(departmentName);
            //foreach(KeyValuePair<int,string> department in departments)
            //{
            //    if(department.Value == departmentName)
            //    {
            //        return true;
            //    }
            //}
            //return false;
        }

        public bool depatrmentIDIsFound(int departmentID)
        {
            return departments.ContainsKey(departmentID);
        }
        public bool addOnboardingEmployee(clsEmployee newEmp)
        {
            if (IDIsFound(newEmp.ID))
                return false;

            onboarding.Enqueue(newEmp);
            actionHistory.Push(newEmp);
            return true;
        }

        public bool addActionEmployee()
        {
            if (onboarding.Count > 0)
            {
                clsEmployee employee = onboarding.Dequeue();
                activeEmployees.Add(employee);
                return true;
            }

            return false;
        }

        public bool addDepartment(int ID, string name)
        {
            if (!departments.ContainsKey(ID))
            {
                departments[ID] = name;
                return true;
            }
            return false;
        }

        public void addSkill(clsEmployee emp)
        {
            uniqueSkills.Add(emp.uniqueSkill);
        }

        public clsEmployee searchEmployeeByID(int ID)
        {
            foreach (clsEmployee employee in activeEmployees)
            {
                if (employee.ID == ID)
                {
                    return employee;
                }
            }
            return null;
        }

        public clsEmployee searchEmployeeByName(string name)
        {
            foreach(clsEmployee employee in activeEmployees)
            {
                if(employee.name== name)
                {
                    return (employee);
                }
            }
            return null;
        }

        private int _getDepartmentIDByName(string departmentName)
        {
            
            foreach(KeyValuePair<int,string>item in departments)
            {
                if(item.Value== departmentName)
                {
                    return  item.Key;
                }
            }
            return -1;
        }

        public bool printAllEmployeeByDepartment(string department)
        {
            int departmentID = _getDepartmentIDByName(department);
            if (departmentID == -1)
                return false;
            if (_hasEmployee(department))
            {
                foreach (clsEmployee employee in activeEmployees)
                {
                    if (employee.departmentID == departmentID)
                    {
                        employee.Print();
                    }
                }
                return true;    
            }
            return false;
         
        }

        public double calcSalaryAverage()
        {
            double sum = 0;
            foreach(clsEmployee employee in activeEmployees)
            {
                sum += employee.salary;
            }
            if(activeEmployees.Count ==0)
            {
                return 0;
            }
            return sum / activeEmployees.Count;
        }

        private  Dictionary<int,int> _getNumberOfEmployeeInEachDepartment()
        {
            Dictionary<int, int> numOfEmployees=new Dictionary<int, int>();
            foreach(clsEmployee employee in activeEmployees)
            {
                if (numOfEmployees.ContainsKey(employee.departmentID))
                {
                    numOfEmployees[employee.departmentID]++;
                }
                else
                {
                    numOfEmployees[employee.departmentID] = 1;
                }
            }
            return numOfEmployees;
        }

        private bool _hasEmployee(string departmentName)
        {
            int departmentID=_getDepartmentIDByName(departmentName);
            foreach (clsEmployee employee in activeEmployees)
            {
               if(employee.departmentID==departmentID)
                {
                    return true;
                }
            }
            return false;
        }
        public void numOfEmployeesInEachDepartmentReport()
        {
            Dictionary<int, int> numOfEmployees=_getNumberOfEmployeeInEachDepartment();
            foreach(KeyValuePair<int,string> item in departments)
            {
                if (numOfEmployees.ContainsKey(item.Key))
                {
                    Console.WriteLine($"{item.Value}: {numOfEmployees[item.Key]}");
                }
                else
                {
                    Console.WriteLine($"{item.Value}: 0");
                }
            }
        }

        public void printActionHistory()
        {
           Stack <clsEmployee>tempEmpsActions = new Stack<clsEmployee>();
            while(actionHistory.Count > 0)
            {
                clsEmployee emp=actionHistory.Pop();
                emp.Print();
                Console.WriteLine("=========================================");
                tempEmpsActions.Push(emp);
            }

            while(tempEmpsActions.Count > 0)
            {
                clsEmployee temp=tempEmpsActions.Pop();
                actionHistory.Push(temp);
            }
        }

        public void printUniqueSkills()
        {
            foreach(string item in  uniqueSkills)
            {
                Console.WriteLine(item);
            }
        }
    }
}
