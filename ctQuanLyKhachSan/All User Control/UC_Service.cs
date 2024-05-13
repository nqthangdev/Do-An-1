using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace ctQuanLyKhachSan.All_User_Control
{
    public partial class UC_Service : UserControl
    {
        Function fn = new Function();
        String query;
        public UC_Service()
        {
            InitializeComponent();
        }

        private void UC_Service_Load(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, rooms.roomNo from customer inner join rooms on customer.roomid = rooms.roomid where chekout = 'NO'";
            DataSet ds = fn.getData(query);
            GripViewTTin.DataSource = ds.Tables[0];
        }

        private void txtSearchRoom_TextChanged(object sender, EventArgs e)
        {
            query = "select customer.cid, customer.cname, customer.mobile, rooms.roomNo from customer inner join rooms on customer.roomid = rooms.roomid where roomNo like '" + txtSearchRoom.Text + "%' and chekout = 'NO'";
            DataSet ds = fn.getData(query);
            GripViewTTin.DataSource = ds.Tables[0];
        }

        private void GripViewTTin_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (GripViewTTin.Rows[e.RowIndex].Cells[e.RowIndex].Value != null)
            {
                txtCusName.Text = GripViewTTin.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
        }
    }
}
