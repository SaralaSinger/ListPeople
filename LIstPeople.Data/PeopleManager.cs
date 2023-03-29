using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace LIstPeople.Data
{
    public class PeopleManager
    {
        private string _connectionString;
        public PeopleManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddPerson(Person p)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO People VALUES (@firstName, @lastName, @age) ";
            cmd.Parameters.AddWithValue("@firstName", p.FirstName);
            cmd.Parameters.AddWithValue("@lastName", p.LastName);
            cmd.Parameters.AddWithValue("@age", p.Age);
            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }
        public void AddManyPeople(List<Person> ppl)
        {
            foreach(var p in ppl)
            {
                AddPerson(p);
            }
        }

        public List<Person> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM People ";
            var list = new List<Person>();
            connection.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(new Person
                {
                    Id = (int)reader["Id"],
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"],
                });
            }
            connection.Close();
            return list;
        }

    }
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
