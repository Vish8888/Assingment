using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MVCCore.Models;
using NuGet.Protocol.Plugins;
using System.Data;
using System.Data.SqlClient;

namespace MVCCore.Controllers
{

    public class LoginController : Controller
    {
        SqlConnection conn = new SqlConnection("Data Source=VISHAL_CHIMKAR\\SQLEXPRESS;Initial Catalog=MVCCore;Integrated Security=True");

        public IActionResult Index()
        {
            List<LoginModel> model = new List<LoginModel>();
            //SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand("Usp_Listuser", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                model.Add(new LoginModel()
                {
                    Id = (int)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = (string)reader["LastName"],
                    Emailed = (string)reader["Emailed"],
                    Password = (string)reader["Password"],
                    UserRole = (string)reader["UserRole"],
                    IsActive = (string)reader["IsActive"],
                });
            }

            conn.Close();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(LoginModel model)
        {
            string Comtxt = $"insert into LoginUser values('{model.FirstName}','{model.LastName}','{model.Emailed}','{model.Password}','{model.UserRole}','{model.IsActive}')";
            SqlCommand cmd = new SqlCommand(Comtxt, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                TempData["Comtxt"] = "Record Inserted Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            LoginModel model = new LoginModel();
            SqlCommand cmd = new SqlCommand($"select * from LoginUser where Id ={id}", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                model = new LoginModel()
                {

                    FirstName = reader["FirstName"].ToString().ToUpper(),
                    LastName = (string)reader["LastName"],
                    Emailed = (string)reader["Emailed"],
                    Password = (string)reader["Password"],
                    UserRole = (string)reader["UserRole"],
                    IsActive = (string)reader["IsActive"],
                };
            }
            conn.Close();
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(LoginModel model)
        {
            string cmdtxt = $"update LoginUser set FirstName= '{model.FirstName}',LastName='{model.LastName}',Emailed='{model.Emailed}',Password='{model.Password}',UserRole='{model.UserRole}',IsActive='{model.IsActive}'where Id={model.Id}";
            SqlCommand cmd = new SqlCommand(cmdtxt, conn);
            conn.Open();
            int count = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                return RedirectToAction("Index");
            }


            return View();
        }

        public IActionResult Details(int id)
        {
       
            LoginModel model = new LoginModel();
            SqlCommand cmd = new SqlCommand($"select * from LoginUser where Id ={id}", conn);
               
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                model = new LoginModel()
                {

                    Id = (int)reader["Id"],
                    FirstName = reader["FirstName"].ToString().ToUpper(),
                    LastName = (string)reader["LastName"],
                    Emailed = (string)reader["Emailed"],
                    Password = (string)reader["Password"],
                    UserRole = (string)reader["UserRole"],
                    IsActive = (string)reader["IsActive"],
                };
            }
            string Name1 = model.FirstName;
            ViewBag.Name = Name1;
            conn.Close();
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            LoginModel model = new LoginModel();
            SqlCommand cmd = new SqlCommand($"select * from LoginUser where Id ={id}", conn);
            conn.Open();

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                model = new LoginModel()
                {

                    FirstName = reader["FirstName"].ToString().ToUpper(),
                    LastName = (string)reader["LastName"],
                    Emailed = (string)reader["Emailed"],
                    Password = (string)reader["Password"],
                    UserRole = (string)reader["UserRole"],
                    IsActive = (string)reader["IsActive"],
                };
            }
            conn.Close();
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(LoginModel model)
        {
            SqlCommand cmd = new SqlCommand("Usp_Deleteuser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", model.Id);
            conn.Open();

            int count = cmd.ExecuteNonQuery();

            if (count > 0)
            {
               
                return RedirectToAction("Index");
            }
            return View();
        }


    }
}
