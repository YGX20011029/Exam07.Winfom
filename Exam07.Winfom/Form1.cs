using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Exam07.Winfom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        DALModel dAL = new DALModel();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void GEtGen()
        {
            var city = dAL.Getgen(0);
            foreach (var item in city)
            {
                TreeNode node = new TreeNode();
                node.Text = item.Name;
                node.Tag = item.Id;

                GEtjie(item.Id, node);
                node.Nodes.Add(node);
            }
        }


        public void GEtjie(int id, TreeNode node)
        {
            var qu = dAL.Getgen(id);
            foreach (var item in qu)
            {
                TreeNode snode = new TreeNode();
                snode.Text = item.Name;
                snode.Tag = item.Id;
                GEtjie(item.Id, snode);
                treeView1.Nodes.Add(node);
            }
        }
    }
}
