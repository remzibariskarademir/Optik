using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Optik
{
    internal class Login
    {
        public int Loginn(string email, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@email", SqlDbType.NVarChar),
                new SqlParameter("@password",SqlDbType.NVarChar)
            };
            parameters[0].Value = email;
            parameters[1].Value = password;
            return Convert.ToInt32(ConnectionDal.ExecuteScalar(
                "select statusId from Users where email=@email and password=@password", parameters));
        }
        public int LoginFA(string email, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@email", SqlDbType.NVarChar),
                new SqlParameter("@password",SqlDbType.NVarChar)
            };
            parameters[0].Value = email;
            parameters[1].Value = password;
            return Convert.ToInt32(ConnectionDal.ExecuteScalar(
                "select FirstActivition from Users where email=@email and password=@password", parameters));
        }
        public string MD5Hash(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] dizi = Encoding.UTF8.GetBytes(text);
            dizi = md5.ComputeHash(dizi);
            StringBuilder sb = new StringBuilder();
            foreach (byte ba in dizi)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }
            return sb.ToString();
        }
    }
}
