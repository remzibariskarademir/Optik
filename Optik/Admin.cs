using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Optik
{
    internal class Admin
    {
        public int UId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string phone { get; set; } 
        public List<Admin> Fill()
        {
            List<Admin> userList = new List<Admin>();
            DataTable userTable = ConnectionDal.ExecuteDataTable("select Uıd,name,surname,password,email,phone from Users where active=1");
            for (int i = 0; i < userTable.Rows.Count; i++)
            {
                Admin item = new Admin()
                {
                    UId = Convert.ToInt32(userTable.Rows[i][0]),
                    name = userTable.Rows[i][1].ToString(),
                    surname = userTable.Rows[i][2].ToString(),
                    password = userTable.Rows[i][3].ToString(),
                    email = userTable.Rows[i][4].ToString(),
                    phone = userTable.Rows[i][5].ToString()
                };
                userList.Add(item);
            }
            return userList;
        }
        public List<Admin> PasifFill()
        {
            List<Admin> userList = new List<Admin>();
            DataTable userTable = ConnectionDal.ExecuteDataTable("select Uıd,name,surname,password,email,phone from Users where active=0");
            for (int i = 0; i < userTable.Rows.Count; i++)
            {
                Admin item = new Admin()
                {
                    UId = Convert.ToInt32(userTable.Rows[i][0]),
                    name = userTable.Rows[i][1].ToString(),
                    surname = userTable.Rows[i][2].ToString(),
                    password = userTable.Rows[i][3].ToString(),
                    email = userTable.Rows[i][4].ToString(),
                    phone = userTable.Rows[i][5].ToString()
                };
                userList.Add(item);
            }
            return userList;
        }
        public string Add(string name,string surname,string email,string phone)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@name",SqlDbType.VarChar),
                new SqlParameter("@surname",SqlDbType.VarChar),
                new SqlParameter("@email", SqlDbType.VarChar),
                new SqlParameter("@phone",SqlDbType.VarChar)
            };
            parameters[0].Value = name;
            parameters[1].Value = surname;
            parameters[2].Value = email;
            parameters[3].Value = phone;

            return Convert.ToString(ConnectionDal.ExecuteNonQuery(
                "insert into Users (name,surname,password,email,phone,statusId,FirstActivition,active) values(@name,@surname,'81dc9bdb52d04dc20036dbd8313ed055',@email,@phone,2,0,1)", parameters));
        }
        private void ExecuteState(int execute)
        {
            if (execute != -1)
                MessageBox.Show("İşleminiz başarılı bir şekilde gerçekleşmiştir.", "İşleminiz Tamamlandı",
                    MessageBoxButtons.OK, MessageBoxIcon.None);
            else
                MessageBox.Show("İşleminiz sırasında bir hata oluştu lütfen tekrar deneyiniz.", "HATA!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public void Delete(string UId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UId", SqlDbType.Int)
            };
            parameters[0].Value = UId;
            int execute = ConnectionDal.ExecuteNonQuery("update Users set active=0 where UId=@UId", parameters);
            ExecuteState(execute);
        }
        public string Update(string UId,string name, string surname, string email, string phone)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@UId",SqlDbType.Int),
                new SqlParameter("@name",SqlDbType.VarChar),
                new SqlParameter("@surname",SqlDbType.VarChar),
                new SqlParameter("@email", SqlDbType.VarChar),
                new SqlParameter("@phone",SqlDbType.VarChar)
            };
            parameters[0].Value = UId;
            parameters[1].Value = name;
            parameters[2].Value = surname;
            parameters[3].Value = email;
            parameters[4].Value = phone;

            return Convert.ToString(ConnectionDal.ExecuteNonQuery(
                "update Users set name=@name,surname=@surname,email=@email,phone=@phone,statusId=2,FirstActivition=1 where UId=@UId", parameters));
        }
    }
}