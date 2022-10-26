using PDF.EmployeePdf;
using PDF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PDF.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Page(Employee employee)
        {
            // oluşturuduğumuz employeereport dan nesne oluşturuyoruz
            EmployeeReport employeeReport = new EmployeeReport();
            byte[] abytes = employeeReport.ReportPdf(GetEmployees());

            return File(abytes,"application/pdf");
        }
        // tüm işçileri çekelim

        public List<Employee> GetEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee();

            for (int i = 0; i <1; i++)
            {
                employee = new Employee();
                employee.Name = "Ali";
                employee.Surname = "Aydın";
                employee.TcNo = "12312312312";
                employee.TelNo = "534534534";
                employee.Adres = "Adresi";
                //employee.Staj1 = true;
                employee.Staj2 = true;
                if (employee.Staj1 == true)
                {
                    employee.durum = "Staj1";
                }
                else if(employee.Staj2 == true)
                {
                    employee.durum = "Staj2";
                }
                employee.BaslamaT = DateTime.Now;
                employee.BitisT = DateTime.Now;
                employee.IsGunu = 30;
                employee.Gss = false;
                if (employee.Gss == true)
                {
                    employee.durum2 = "Evet";
                }
                else
                {
                    employee.durum2 = "Hayir";
                }
                employee.Yas = false;
                if (employee.Yas == true)
                {
                    employee.durum3 = "Evet";
                }
                else
                {
                    employee.durum3 = "Hayir";
                }
                employee.FirmaAdi = "A Firması";
                employee.Faaliyet = "Yazılım";
                employee.AdresFirma = "Firma Adresi";
                employee.TelFirma = "02120001212";
                employees.Add(employee);
            }
            
    
            return employees;
        }


        public ActionResult Index()
        {
            return View();
        }

    }

   
}