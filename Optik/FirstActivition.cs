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
    internal class FirstActivition
    {
        public int Id { get; set; }
        public string question { get; set; }
        public List<FirstActivition> Fill()
        {
            List<FirstActivition> questionList = new List<FirstActivition>();
            DataTable questionTable = ConnectionDal.ExecuteDataTable("select * from Question");
            for (int i = 0; i < questionTable.Rows.Count; i++)
            {
                FirstActivition item = new FirstActivition()
                {
                    Id = Convert.ToInt32(questionTable.Rows[i][0]),
                    question = questionTable.Rows[i][1].ToString()
                };
                questionList.Add(item);
            }
            return questionList;
        }
        public string Update(string email, string password, string question, string answer)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@email", SqlDbType.VarChar),
                new SqlParameter("@password", SqlDbType.VarChar),
                new SqlParameter("@question",SqlDbType.VarChar),
                new SqlParameter("@answer",SqlDbType.VarChar)
            };
            parameters[0].Value = email;
            parameters[1].Value = password;
            parameters[2].Value = question;
            parameters[3].Value = answer;

            return Convert.ToString(ConnectionDal.ExecuteNonQuery(
                "update Users set FirstActivition=1,question=@question,answer=@answer,password=@password where email=@email", parameters));
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