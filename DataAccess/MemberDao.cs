using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class MemberDao { 
 private readonly string _connectionString;

    public MemberDao()
            {
            DbContext context = new DbContext();
            _connectionString = context.GetConnectionString();
        }

            public List<Member> GetAllMembers()
            {
                List<Member> members = new List<Member>();
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "SELECT * FROM Member";
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Member member = new Member();
                        member.MemberId = Convert.ToInt32(reader["MemberId"]);
         
                        member.Email = Convert.ToString(reader["Email"]);
                    member.CompanyName = Convert.ToString(reader["CompanyName"]);
                    member.City = Convert.ToString(reader["City"]);
                    member.Country = Convert.ToString(reader["Country"]);
                    member.Password = Convert.ToString(reader["Password"]);
                    members.Add(member);
                    }
                    reader.Close();
                }
                return members;
            }

            public Member GetMemberById(int id)
            {
                Member member = null;
                using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                    string query = "SELECT * FROM Member WHERE MemberId=@Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        member = new Member();
                    member.MemberId = Convert.ToInt32(reader["MemberId"]);

                    member.Email = Convert.ToString(reader["Email"]);
                    member.CompanyName = Convert.ToString(reader["CompanyName"]);
                    member.City = Convert.ToString(reader["City"]);
                    member.Country = Convert.ToString(reader["Country"]);
                    member.Password = Convert.ToString(reader["Password"]);
                }
                    reader.Close();
                }
                return member;
            }

            public void AddMember(Member member)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                    string query = "INSERT INTO Member ( Email,CompanyName,City,Country,Password) VALUES ( @Email,@CompanyName ,@City ,@Country ,@Pass)";
                    SqlCommand command = new SqlCommand(query, connection);
            
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@CompanyName", member.CompanyName);
                command.Parameters.AddWithValue("@City", member.City);
                command.Parameters.AddWithValue("@Country", member.Country);
                command.Parameters.AddWithValue("@Pass", member.Password);
                connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void UpdateMember(Member member)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                    string query = "UPDATE Member SET CompanyName=@CompanyName, Email=@Email ,City= @City , Country= @Country, Password= @Pass WHERE MemberId=@MemberId";
                    SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@MemberId", member.MemberId);
                command.Parameters.AddWithValue("@Email", member.Email);
                command.Parameters.AddWithValue("@CompanyName", member.CompanyName);
                command.Parameters.AddWithValue("@City", member.City);
                command.Parameters.AddWithValue("@Country", member.Country);
                command.Parameters.AddWithValue("@Pass", member.Password);
                connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void DeleteMember(int id)
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    string query = "DELETE FROM Member WHERE MemberId=@Id";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", id);
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        public Member Authenticate(string email, string password)
        {
            Member member = null;
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT * FROM Member WHERE Email=@Email AND Password=@Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    member = new Member();
                    member.MemberId = Convert.ToInt32(reader["MemberId"]);

                    member.Email = Convert.ToString(reader["Email"]);
                    member.CompanyName = Convert.ToString(reader["CompanyName"]);
                    member.City = Convert.ToString(reader["City"]);
                    member.Country = Convert.ToString(reader["Country"]);
                    member.Password = Convert.ToString(reader["Password"]);
                }
                reader.Close();
            }
            return member;
        }
    }
    }

