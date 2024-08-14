using pictureform.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pictureform
{
    public partial class picanto : Form
    {
        public picanto()
        {
            InitializeComponent();
        }
        public bool check=false;
        public bool valid;
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Select the Picture";
            ofd.Filter = "Image File (*.png;*.jpg;*.bmp;*.gif)|*.png;*.jpg;*.bmp;*.gif";
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox.Image =new Bitmap( ofd.FileName);
                check = true;
            }
            else
            {
                check = false;
            }
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                student stu = new student();
                stu.name=namebox.Text;
                stu.photo = savephoto();
                db insert = new db();
                insert.insertpic(stu);
                reloaddata();
                namebox.Clear();
                namebox.Focus();
                pictureBox.Image = Resources.no_image_icon_23505;
                check=false;
                
            }
            
        }

        private bool isvalid()
        {
            valid = true;
            if (namebox.Text == string.Empty)
            {
                MessageBox.Show("Please Enter Your Name","Missing Information",MessageBoxButtons.OK, MessageBoxIcon.Error);
                namebox.Focus();
                valid = false;
            }else if (check == false)
            {
                MessageBox.Show("Please Enter Your Picture", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                valid = false;
            }
            return valid;
        }

        private byte[] savephoto()
        {
            MemoryStream ms= new MemoryStream();
            pictureBox.Image.Save(ms,pictureBox.Image.RawFormat);
            return ms.GetBuffer();
        }

        private void picanto_Load(object sender, EventArgs e)
        {
            namebox.Clear();
            namebox.Focus();
            reloaddata();
        }

        private void reloaddata()
        {
            db db = new db();
            DataTable dt= new DataTable();
            dt = db.GetData();
            dataGridView.DataSource = dt;
            dataGridView.MultiSelect = false;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AllowUserToAddRows = false;
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            dataGridView.Columns["picture"].Width= 70;
            for(int i = 0; i < dataGridView.Columns.Count; i++)
            {
                if (dataGridView.Columns[i] is DataGridViewImageColumn)
                {
                    ((DataGridViewImageColumn)dataGridView.Columns[i]).ImageLayout = DataGridViewImageCellLayout.Zoom;
                }


            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && dataGridView.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow dr = dataGridView.SelectedRows[0];

                // Get the cell value and cast it to an Image if it's of type Image
                // Assuming the cell value at index 3 is an Image type
                if (dr.Cells[3].Value is byte[])
                {
                    byte[] imageBytes = (byte[])dr.Cells[3].Value;
                    pics fi = new pics();
                    fi.pictureBoxzoom.Image = getphoto(imageBytes);
                    fi.ShowDialog();


                }
                else
                {
                    // Handle the case where the cell value is not an image
                    MessageBox.Show("The selected cell does not contain an image.");
                }
            }
        }

        private Image getphoto(byte[] photo)
        {
            MemoryStream ms=new MemoryStream(photo);
            return Image.FromStream(ms);
        }
    }
}
