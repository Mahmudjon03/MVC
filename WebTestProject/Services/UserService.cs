using System.Data;
using System.Data.SqlClient;
using WebTestProject.Models;
using WorkWithExcel;

namespace WebTestProject.Services
{
    public class UserService : DataContext
    {
        public List<Employee> GetEmployee()
        {
            var sql = "select * from Employee ";
            var employees = new List<Employee>();
            using (var objectSql = Exec(sql, new SqlParameter[]{}, TypeReturn.DataTable, TypeCommand.SqlQuery))
            {
                var dataTable = objectSql.DataTable;
                if (dataTable.Rows.Count != 0)
                {
                    employees = (from DataRow dataRow in dataTable.Rows
                                 select new Employee()
                                 {
                                     Id = (int)dataRow["Id"],
                                     fName = dataRow["fname"].ToString() ?? "",
                                     lName = dataRow["lname"].ToString() ?? ""
                                 }).ToList();

                }
            }
            return employees;
        }

        public string AddEmployee(Employee model)
        {
            var sql = $"insert into Employee  values('{model.fName}','{model.lName}',2); ";
            foreach(var i in model.Works)
            {
                sql += $"insert into Works values('{i.Name}',(select Id from Employee where fname = '{model.fName}'));";
            }
            sql += "  select 'Success' as result ;";
            string result;
            using(var objectSql = Exec(sql,new SqlParameter[] {}, TypeReturn.DataTable, TypeCommand.SqlQuery))
            {
                var dataTable = objectSql.DataTable;
                DataRow dataRow = dataTable.Rows[0];
             

                result = dataRow["result"].ToString();
            }
            return result;
        }

    }
}
