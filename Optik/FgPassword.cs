using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace Optik
{
    internal class FgPassword
    {
        public int Id { get; set; }
        public string question { get; set; }
        public List<FgPassword> Fill()
        {
            List<FgPassword> questionList = new List<FgPassword>();
            DataTable questionTable = ConnectionDal.ExecuteDataTable("select * from Question");
            for (int i = 0; i < questionTable.Rows.Count; i++)
            {
                FgPassword item = new FgPassword()
                {
                    Id = Convert.ToInt32(questionTable.Rows[i][0]),
                    question = questionTable.Rows[i][1].ToString()
                };
                questionList.Add(item);
            }
            return questionList;
        }
        public string Update(string email,string question, string answer, string password)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@email",SqlDbType.NVarChar),
                new SqlParameter("@question",SqlDbType.NVarChar),
                new SqlParameter("@answer",SqlDbType.NVarChar),
                new SqlParameter("@password", SqlDbType.NVarChar)
            };
            parameters[0].Value = email;
            parameters[1].Value = question;
            parameters[2].Value = answer;
            parameters[3].Value = password;

            return Convert.ToString(ConnectionDal.ExecuteScalar(
                "update Users set password=@password where answer=@answer and question=@question and email=@email", parameters));
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