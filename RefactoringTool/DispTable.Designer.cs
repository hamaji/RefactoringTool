namespace RefactoringTool
{
    partial class DispTable
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnDispTable = new System.Windows.Forms.Button();
            this.btnMove = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ListTable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMoveColumn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ListTable)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDispTable
            // 
            this.btnDispTable.Location = new System.Drawing.Point(23, 12);
            this.btnDispTable.Name = "btnDispTable";
            this.btnDispTable.Size = new System.Drawing.Size(75, 23);
            this.btnDispTable.TabIndex = 0;
            this.btnDispTable.Text = "データベース選択";
            this.btnDispTable.UseVisualStyleBackColor = true;
            this.btnDispTable.Click += new System.EventHandler(this.btnDispTable_Click);
            // 
            // btnMove
            // 
            this.btnMove.Location = new System.Drawing.Point(319, 415);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(155, 23);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = "NULLクラスタリング";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 50);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(166, 374);
            this.treeView1.TabIndex = 4;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // ListTable
            // 
            this.ListTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListTable.Location = new System.Drawing.Point(225, 52);
            this.ListTable.Name = "ListTable";
            this.ListTable.RowTemplate.Height = 21;
            this.ListTable.Size = new System.Drawing.Size(437, 363);
            this.ListTable.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(231, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "テーブル一覧";
            // 
            // btnMoveColumn
            // 
            this.btnMoveColumn.Location = new System.Drawing.Point(507, 415);
            this.btnMoveColumn.Name = "btnMoveColumn";
            this.btnMoveColumn.Size = new System.Drawing.Size(155, 23);
            this.btnMoveColumn.TabIndex = 7;
            this.btnMoveColumn.Text = "カラム名クラスタリング";
            this.btnMoveColumn.UseVisualStyleBackColor = true;
            this.btnMoveColumn.Click += new System.EventHandler(this.btnMoveColumn_Click);
            // 
            // DispTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 450);
            this.Controls.Add(this.btnMoveColumn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListTable);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnDispTable);
            this.Name = "DispTable";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DispTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ListTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDispTable;
        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView ListTable;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMoveColumn;
    }
}

