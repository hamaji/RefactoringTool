using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using RDotNet;

namespace RefactoringTool
{
    public partial class RefactoringTable : Form
    {
        private string[] argumentValues; //Form1から受け取った引数
        public string ReturnValue;       //Form1に返す戻り値

        public RefactoringTable(params string[] argumentValues)
        {
            //Form1から受け取ったデータをForm2インスタンスのメンバに格納
            this.argumentValues = argumentValues;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //スキーマ取得
            //SqlConnection con
            //= new SqlConnection();
            //con.ConnectionString = "Data Source=HK-HP\\SQLEXPRESS;Initial Catalog=testDB;Integrated Security=True"; //接続情報を入れる
            //con.Open();

            ////クエリーの生成
            //SqlCommand sqlCom = new SqlCommand();

            ////クエリー送信先及びトランザクションの指定
            //sqlCom.Connection = con;
            ////sqlCom.Transaction = this.sqlTran;

            ////クエリー文の指定
            //sqlCom.CommandText = "SELECT * FROM listings_in_Amsterdam;";

            ////データテーブルを作成するためのアダプタ
            //SqlDataAdapter sqlAda = new SqlDataAdapter();
            //sqlAda.SelectCommand = sqlCom;

            //DataTable dsgrid = new DataTable();
            //dsgrid.Columns.Add("Column", typeof(string));
            //dsgrid.Columns.Add("NULL", typeof(string));
            ////dsにテーブルデータを代入
            //DataTable ds = new DataTable();
            //sqlAda.Fill(ds);
            //List<String> columnList = new List<string> ();
            //foreach (DataColumn clm in ds.Columns)
            //{
            //    columnList.Add(clm.ColumnName);
            //    string[] row = new string[] { clm.ColumnName, "10" };
            //    dsgrid.Rows.Add(row);
            //}


            //DataRow newCustomersRow = dsgrid.Tables["Customers"].NewRow();

            //newCustomersRow["CustomerID"] = "ALFKI";
            //newCustomersRow["CompanyName"] = "Alfreds Futterkiste";
            //dsgrid.
            //dataGridView1.DataSource = dsgrid;
            dataGridView1.Rows[15].DefaultCellStyle.BackColor = Color.Yellow;
        }

        private void RefactoringTable_Load(object sender, EventArgs e)
        {
            //スキーマ取得
            SqlConnection con
            = new SqlConnection();
            con.ConnectionString = "Data Source=HK-HP\\SQLEXPRESS;Initial Catalog=testDB;Integrated Security=True"; //接続情報を入れる
            con.Open();

            //クエリーの生成
            SqlCommand sqlCom = new SqlCommand();

            //クエリー送信先及びトランザクションの指定
            sqlCom.Connection = con;
            //sqlCom.Transaction = this.sqlTran;

            //クエリー文の指定
            sqlCom.CommandText = "SELECT * FROM "+ argumentValues[0] + " ORDER BY host_id,host_name,latitude,longitude,neighbourhood_group ,last_review;";

            //データテーブルを作成するためのアダプタ
            SqlDataAdapter sqlAda = new SqlDataAdapter();
            sqlAda.SelectCommand = sqlCom;

            DataTable dsgrid = new DataTable();
            dsgrid.Columns.Add("Column", typeof(string));
            dsgrid.Columns.Add("NULL", typeof(string));
            //dsにテーブルデータを代入
            DataTable ds = new DataTable();
            sqlAda.Fill(ds);
            List<String> columnList = new List<string>();
            foreach (DataColumn clm in ds.Columns)
            {
                columnList.Add(clm.ColumnName);

                //クエリーの生成
                SqlCommand nullCntCom = new SqlCommand();
                nullCntCom.Connection = con;
                nullCntCom.CommandText = "select count(*) From listings_in_Amsterdam Where host_id is null";

                string[] row = new string[] { clm.ColumnName, "5" };
                dsgrid.Rows.Add(row);
            }
            dsgrid.Rows[15]["NULL"] = "40";
             
            dataGridView1.DataSource = dsgrid;
            //dataGridView1.Rows[15].DefaultCellStyle.BackColor = Color.Yellow;
            dataGridView2.DataSource = ds;
        }

        private string clustering()
        {
            //Rの前準備
            var envPath = Environment.GetEnvironmentVariable("PATH");
            var rBinPath = @"C:\Program Files\R\R-3.2.3\bin\x64";
            //Environment.SetEnvironmentVariable("PATH", envPath + Path.PathSeparator + rBinPath);
            //using (REngine engine = REngine.CreateInstance("RDotNet"))
            //{
            //    engine.Initialize();

            //    double[] xs, ys;
            //    CreateNoisedSine(out xs, out ys);

            //    NumericVector x = engine.CreateNumericVector(xs);
            //    engine.SetSymbol("x", x);
            //    NumericVector y = engine.CreateNumericVector(ys);
            //    engine.SetSymbol("y", y);

            //    GenericVector response = engine.Evaluate("smooth.spline(x, y, df=5, all.knots=TRUE)").AsList();
            //    NumericVector smoothed = response["y"].AsNumeric();
            //}
            int i = 0;
            using (REngine engine = REngine.CreateInstance("RDotNet"))
            {
                engine.Initialize();

                engine.Evaluate("setwd('c:/work')");
                engine.Evaluate("getwd()").AsCharacter();
                engine.Evaluate("y <- read.csv('datasnull.csv')");
                engine.Evaluate("y").AsCharacter();
                engine.Evaluate("km =kmeans(y,2)");
                CharacterVector text = engine.Evaluate("km$cluster").AsCharacter();

                CharacterVector table = engine.Evaluate("table(km$cluster)").AsCharacter();

                string mins;
                if (int.Parse(table[0]) < int.Parse(table[1]))
                {
                    mins = "1";
                }
                else
                {
                    mins = "2";
                }
                foreach (string t in text)
                {
                    i++;
                    //richTextBox2.Text += i + "列目　" + t + "\n";

                    if (t == mins)
                    {
                        dataGridView1.Rows[i].DefaultCellStyle.ForeColor = Color.Red;
                    }
                }
                //CharacterVector table = engine.Evaluate("table(km$cluster)").AsCharacter();
                //richTextBox2.Text += "クラスタ1  " + table[0] + " クラスタ2　" + table[1] + "\n";
            }
            return null;
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            //セルの列を確認
            if (dgv.Columns[e.ColumnIndex].Name == "neighbourhood_group" || dgv.Columns[e.ColumnIndex].Name == "host_id")
            {
                 
                //セルの値により、背景色を変更する
                if (e.Value == System.DBNull.Value)
                {
                    e.CellStyle.BackColor = Color.Yellow;
                }
                
            }
        }

        static public string ShowMiniForm(string s)
        {

            RefactoringTable f = new RefactoringTable(s);
            f.ShowDialog();
            string receiveText = f.ReturnValue;
            f.Dispose();

            return receiveText;
        }
    }
}
