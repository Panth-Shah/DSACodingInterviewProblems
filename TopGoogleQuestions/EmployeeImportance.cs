using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopGoogleQuestions
{
    public class Employee
    {
        public int id;
        public int importance;
        public IList<int> subordinates;
    }
    public class EmployeeImportance
    {
        Dictionary<int, Employee> employeeMap = new Dictionary<int, Employee>();

        public int GetImportance(IList<Employee> employees, int id)
        {
            //Build directed graph
            foreach (Employee employee in employees)
            {
                employeeMap.TryAdd(employee.id, new Employee());
                employeeMap[employee.id] = employee;
            }
            return dfs(id);
        }

        public int dfs(int employeeId)
        {
            Employee employee = employeeMap[employeeId];
            int ans = employee.importance;
            foreach (int subId in employee.subordinates)
            {
                ans += dfs(subId);
            }

            return ans;
        }
    }
}
