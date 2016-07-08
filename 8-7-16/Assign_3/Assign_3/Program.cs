using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assign_3
{
    class Program
    {
       

        class Employee
        {
            //manager mgr = new manager();
            string emp_id;
            public static int leaves = 3;
            public void set_emp(string id)
            {
                emp_id = id;
            }
            public bool reduce()
            {
                leaves--;
                if (leaves < 0)
                {
                    return false;
                }
                return true;

            }
            public void Req_Leaves(string id)
            {
                if (leaves > 0)
                {
                    manager.add_emp(id);
                    Console.Write("\nNumber Of Leaves Left : " + leaves + "\n");
                }
                else
                    Console.Write("\nOOPS! NO LEAVES LEFT!\n");
                
            }
        }
        public static class manager
        {   
            public static List<string> req_buff = new List<string>();
            public static void add_emp(string id)
            {
                req_buff.Add(id);
            }
            public static void response()
            {
                bool b;
                Employee e = new Employee();
                Random r = new Random();
                if (!req_buff.Any())
                    Console.Write("\nNO REQUESTS PENDING!!\n");
                else {
                    foreach (var i in req_buff)
                    {
                        Console.Write("\nEmployee - " + i + " : ");
                        if (r.Next() % 2 == 0)
                        {
                            b = e.reduce();
                            if (b == false)
                                Console.Write("\nCannot Approve\n");
                            else 
                                Console.Write("Approved\n");
                        }
                        else
                        {
                            Console.Write("Rejected\n");
                        }
              
                    }
                    req_buff.Clear();
                }
                
            }
        }
        static void Main(string[] args)
        {
            Employee[] e = new Employee[10];
            for(int i = 0; i < 10; i++){
                e[i] = new Employee();
                e[i].set_emp("10"+Convert.ToString(i));
            }
            bool flag = true;
            string c;
            do
            {
                string s, s1;
                Console.Write("\n Do you want to enter as employee/manager ?");
                c = Console.ReadLine();
                if (c == "Employee")
                {
                    Console.WriteLine("\nEnter the employee_id : ");
                    s = Console.ReadLine();
                    int n = Convert.ToInt32(s) % 100;
                    e[n].Req_Leaves(s);
                   
                    
                }
                else { 
                    manager.response();
                }
                Console.WriteLine("\nContinue ?? ");
                s1 = Console.ReadLine();
                if (s1 == "yes")
                        flag = true;
                    else flag = false;
                
                
            } while (flag == true);
            Console.ReadLine();
            }

    }
}
