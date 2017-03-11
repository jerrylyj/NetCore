using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShangBao.Model;
using ShangBao.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Threading;

namespace ShangBao.Controllers
{
    [Produces("application/json")]
    [Route("api/User")]
    public class UserController : Controller
    {
        // GET: api/User
        [HttpGet]
        public IEnumerable<User> Get()
        {
            //return new string[] { "value1", "value2" };
            var list = new List<User>();
            using (var db = new DataContext())
            {
                list = (from e in db.Users
                            where e.Age == 66
                            select e).Skip(10 * 0).Take(10).ToList();

            }
            return list;
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/User
        [HttpPost]
        public User Post([FromBody]string value)
        {
            var db = new DataContext();
            User u = new User();
            u.Age = new Random().Next(0, 100);
            u.CreateTime = DateTime.Now;
            u.Id = Guid.NewGuid().ToString();
            u.Name = GenerateRandom(10);
            u.UpdateTime = DateTime.Now;
            db.Users.Add(u);
            var count = db.SaveChanges();
            return u;
            /**
            using (var db = new DataContext())
            {
                User u = new User();
                u.Age = new Random().Next(0, 100);
                u.CreateTime = DateTime.Now;
                //u.Id = 1;
                u.Name = GenerateRandom(10);
                u.UpdateTime = DateTime.Now;
                db.Users.Add(u);
                var count = db.SaveChanges();
                Console.WriteLine("{0} records saved to database", count);
                Console.WriteLine();
                Console.WriteLine("All users in database:");
                //foreach (var user in db.Users)
                //{
                //    Console.WriteLine(" - {0}", user.Name);
                //}
            }
    **/

        }

        // PUT: api/User/5
        [HttpPost]
        [HttpPost, Route("post1")]
        public void Post1()
        {
            string connectionString = "Server=localhost;database=efcore;uid=root;pwd=root;";

            MySqlConnection connection = new MySqlConnection
            {
                ConnectionString = connectionString
            };
            connection.Open();
            String a = String.Format("insert into users values('{0}',{1},'{2}','{3}','{4}');",Guid.NewGuid().ToString(),22,DateTime.Now.ToString("yyyy-MM-dd HH:mm"),"AA", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
            MySqlCommand command = new MySqlCommand(a, connection);
            command.ExecuteNonQuery();
            connection.Close();
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private char[] constant =
        {
            'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
            'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };
        public string GenerateRandom(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(52);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(52)]);
            }
            return newRandom.ToString();
        }
    }
}
