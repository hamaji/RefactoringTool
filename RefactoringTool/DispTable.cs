using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RefactoringTool
{
    public partial class DispTable : Form
    {
        public DispTable()
        {
            InitializeComponent();
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            //RefactoringTable frm = new RefactoringTable();
            //frm.Show();
            //Form2に送るテキスト
            string sendText = (string)ListTable.CurrentCell.Value;

            //Form2から送られてきたテキストを受け取る。
            string receiveText = RefactoringTable.ShowMiniForm(sendText);　//Form2を開く

        }

        private void DispTable_Load(object sender, EventArgs e)
        {

            TreeNode treeNodeSQLEXPRESS = new TreeNode("SQLEXPRESS");
            TreeNode[] treeInstance = { treeNodeSQLEXPRESS };
            TreeNode treeNodeHKHP = new TreeNode("HK-HP", treeInstance);
            

            TreeNode[] treeDatabases = { treeNodeHKHP };
            TreeNode treeDatabase = new TreeNode("データベース", treeDatabases);

            //TreeNode treeNodeDrink = new TreeNode("HK-HP");

            TreeNode[] treeNodeRoot = { treeDatabase };
            treeView1.Nodes.AddRange(treeNodeRoot);

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMoveColumn_Click(object sender, EventArgs e)
        {
            ColumnNameClustering frm = new ColumnNameClustering();
            frm.Show();
        }

        private void btnDispTable_Click(object sender, EventArgs e)
        {
            //スキーマ取得
            System.Data.SqlClient.SqlConnection con
            = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = "Data Source=HK-HP\\SQLEXPRESS;Initial Catalog=testDB;Integrated Security=True"; //接続情報を入れる
            con.Open();


            DataTable dt = con.GetSchema("Tables");

            //foreach (DataRow row in dt.Rows)
            {
                ListTable.DataSource = dt;
            }


            con.Close();
        }

        private int counter = 0;
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (counter > 0)
            {
                if (e.Node.Level == 2)
                {
                    var st = e.Node.Text;
                    TreeNode treeNodeNew =
                      new TreeNode("追加" + counter.ToString());
                    //e.Node.Nodes.Add(treeNodeNew);

                    System.Data.SqlClient.SqlConnection con= new System.Data.SqlClient.SqlConnection();
                    con.ConnectionString = "Data Source=HK-HP\\SQLEXPRESS;Initial Catalog=testDB;Integrated Security=True"; //接続情報を入れる
                    con.Open();
                    
                    DataTable dt = con.GetSchema("Tables");
                    string[] selectColumns = new string[] { "TABLE_NAME" };
                    DataTable selectTable = dt.DefaultView.ToTable("selectTable", false, selectColumns);
                    //dt.DefaultView()
                    ListTable.DataSource = selectTable;
                    
                    con.Close();
                }
            }
            counter++;
        }
    }
}
