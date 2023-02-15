using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.IO;

namespace Optik
{
    internal class User
    {
        public int Id { get; set; }
        public string bookletname { get; set; }
        public string exType { get; set; }
        public string depname { get; set; }
        public int trueCount { get; set; } = 0;
        public int empthyCount { get; set; } = 0;
        public int falseCount { get; set; } = 0;
        public int wrongCount { get; set; } = 0;
        public string number { get; set; }
        public string lessname { get; set; }
        public string extype { get; set; }
        public string department { get; set; }
        public string alltext { get; set; }

        public List<User> Fill()
        {
            List<User> bookletList = new List<User>();
            DataTable bookletTable = ConnectionDal.ExecuteDataTable("select * from booklettype");
            for (int i = 0; i < bookletTable.Rows.Count; i++)
            {
                User item = new User()
                {
                    Id = Convert.ToInt32(bookletTable.Rows[i][0]),
                    bookletname = bookletTable.Rows[i][1].ToString()
                };
                bookletList.Add(item);
            }
            return bookletList;
        }
        public List<User> Fillex()
        {
            List<User> ExamList = new List<User>();
            DataTable ExamTable = ConnectionDal.ExecuteDataTable("select * from ExamTypes");
            for (int i = 0; i < ExamTable.Rows.Count; i++)
            {
                User item = new User()
                {
                    Id = Convert.ToInt32(ExamTable.Rows[i][0]),
                    exType = ExamTable.Rows[i][1].ToString()
                };
                ExamList.Add(item);
            }
            return ExamList;
        }
        public List<User> Filldep()
        {
            List<User> departmentList = new List<User>();
            DataTable departmentTable = ConnectionDal.ExecuteDataTable("select * from department");
            for (int i = 0; i < departmentTable.Rows.Count; i++)
            {
                User item = new User()
                {
                    Id = Convert.ToInt32(departmentTable.Rows[i][0]),
                    depname = departmentTable.Rows[i][1].ToString()
                };
                departmentList.Add(item);
            }
            return departmentList;
        }
        public static List<User> textList = new List<User>();
        public List<User> Read()
        {
            textList.Clear();
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "txt Dosyaları (*.txt)|*.txt";
            file.Title = "Metin Dosyası Seçiniz..";
            if (file.ShowDialog() == DialogResult.OK)
            {
                foreach (string line in System.IO.File.ReadLines(file.FileName))
                {
                    User item = new User()
                    {
                        alltext = line.TrimStart().ToString()
                    };
                    textList.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Seçim Yapmadınız.");
            }
            return textList;
        }
        public static List<string> output = new List<string>();
        public void Hesapla(string txtdepartment,string txtextype,string txtlessname,int qnumber, string txtanswer1 = null, string txtanswer2 = null, string txtanswer3 = null, string txtanswer4 = null)
        {
            output.Clear();
            output.Add("Bölüm       	          \tDers Adı    \tSınav Türü      \tÖğrenci Numarası   \tPuanı   \tDoğru Sayısı   \tYanlış Sayısı   \tBoş Sayısı     Yanlış İşaretleme\t");
            foreach (var item in textList)
            {
                char[] charArray = item.alltext.ToCharArray();
                string[] substrings = item.alltext.Split(' ');
                number = substrings[0];
                char[] charArray2;
                if (charArray[11] == 'A')
                {
                    charArray2 = txtanswer1.ToCharArray();
                }
                else if (charArray[11] == 'B')
                {
                    charArray2 = txtanswer2.ToCharArray();
                }
                else if (charArray[11] == 'C')
                {
                    charArray2 = txtanswer3.ToCharArray();
                }
                else if (charArray[11] == 'D')
                {
                    charArray2 = txtanswer4.ToCharArray();
                }
                else
                {
                    charArray2 = txtanswer1.ToCharArray();
                }
                for (int i = 0; i < qnumber; i++)
                {
                    if (charArray[i + 12] == charArray2[i])
                    {
                        trueCount++;
                    }
                    else if (charArray[i + 12] == ' ')
                    {
                        empthyCount++;
                    }
                    else if (charArray[i + 12] != charArray2[i])
                    {
                        falseCount++;
                    }
                    else if (charArray[i + 12] == '*')
                    {
                        wrongCount++;
                    }
                }
                lessname = txtlessname;
                extype = txtextype;
                department = txtdepartment;
                double multiplier = 100 / qnumber;
                double puan = trueCount * multiplier;
                output.Add($"{department}       {lessname}          {extype}                {number}            {puan}            {trueCount}                 {falseCount}                    {empthyCount}                   {wrongCount}");
                multiplier = 0;
                puan = 0;
                trueCount = 0;
                empthyCount = 0;
                falseCount = 0;
                wrongCount = 0;
            }
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            saveDialog.RestoreDirectory = true;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveDialog.FileName, output);
            }
        }
        public void Hesaplae(string txtdepartment, string txtextype, string txtlessname, int qnumber, string txtanswer1 = null, string txtanswer2 = null, string txtanswer3 = null, string txtanswer4 = null)
        {
            output.Clear();
            output.Add("Bolum,Ders Adi,Sinav Turu,Ogrenci Numarasi,Puani,Dogru Sayisi,Yanlis Sayisi,Bos Sayisi,Yanlis İsaretleme");
            foreach (var item in textList)
            {
                char[] charArray = item.alltext.ToCharArray();
                string[] substrings = item.alltext.Split(' ');
                number = substrings[0];
                char[] charArray2;
                if (charArray[11] == 'A')
                {
                    charArray2 = txtanswer1.ToCharArray();
                }
                else if (charArray[11] == 'B')
                {
                    charArray2 = txtanswer2.ToCharArray();
                }
                else if (charArray[11] == 'C')
                {
                    charArray2 = txtanswer3.ToCharArray();
                }
                else if (charArray[11] == 'D')
                {
                    charArray2 = txtanswer4.ToCharArray();
                }
                else
                {
                    charArray2 = txtanswer1.ToCharArray();
                }
                for (int i = 0; i < qnumber; i++)
                {
                    if (charArray[i + 12] == charArray2[i])
                    {
                        trueCount++;
                    }
                    else if (charArray[i + 12] == ' ')
                    {
                        empthyCount++;
                    }
                    else if (charArray[i + 12] != charArray2[i])
                    {
                        falseCount++;
                    }
                    else if (charArray[i + 12] == '*')
                    {
                        wrongCount++;
                    }
                }
                lessname = txtlessname;
                extype = txtextype;
                department = txtdepartment;
                double multiplier = 100 / qnumber;
                double puan = trueCount * multiplier;
                output.Add($"{department},{lessname},{extype},{number},{puan},{trueCount},{falseCount},{empthyCount},{wrongCount}");
                multiplier = 0;
                puan = 0;
                trueCount = 0;
                empthyCount = 0;
                falseCount = 0;
                wrongCount = 0;
            }
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "xlsx Dosyaları (*.csv)|*.csv|Tüm Dosyalar(*.*)|*.*";
            saveDialog.FilterIndex = 1;
            saveDialog.RestoreDirectory = true;
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllLines(saveDialog.FileName, output);
            }
        }
    }
}