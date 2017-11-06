using CrudEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static CrudEntity.ModelContext;

namespace CrudEntity
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void btnPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picFace.Image = Image.FromFile(ofd.FileName);
                    Presidents obj = presidentBindingSource.Current as Presidents;
                    if (obj != null)
                        obj.ImagePhoto = ofd.FileName;
                }
            }
        }


        private void btnFlag_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    picFlag.Image = Image.FromFile(ofd.FileName);
                    Presidents obj = presidentBindingSource.Current as Presidents;
                    if (obj != null)
                        obj.ImagePhoto = ofd.FileName;
                }

            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            using (ModelContext db = new ModelContext())            {
                presidentBindingSource.DataSource = db.PresidentsList.ToList();
            }
            pContainer.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            picFace.Image = null;
            picFlag.Image = null;
            pContainer.Enabled = true;
            presidentBindingSource.Add(new Presidents() { ObjectState=1});
            presidentBindingSource.MoveLast();
            txtFullName.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pContainer.Enabled = true;
            txtFullName.Focus();
            Presidents obj = presidentBindingSource.Current as Presidents;
            if (obj != null)
                obj.ObjectState = 2;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pContainer.Enabled = false;
            presidentBindingSource.ResetBindings(false);
            Form1_Load(sender, e);
        }

        private void Grid(object sender, DataGridViewCellEventArgs e)
        {
            Presidents obj = presidentBindingSource.Current as Presidents;
            if (obj != null)
                picFace.Image = Image.FromFile(obj.ImagePhoto);
            if (obj != null)
                picFlag.Image = Image.FromFile(obj.ImagePhoto);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "Are you sure want to delete this record ?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) { }
            {
                using (ModelContext db = new ModelContext())
                {
                    Presidents obj = presidentBindingSource.Current as Presidents;
                    if (obj != null)
                    {
                        if (db.Entry<Presidents>(obj).State == System.Data.Entity.EntityState.Detached)
                            db.Set<Presidents>().Attach(obj);
                        db.Entry<Presidents>(obj).State = System.Data.Entity.EntityState.Deleted;
                        db.SaveChanges();
                        presidentBindingSource.RemoveCurrent();
                        pContainer.Enabled = false;
                        picFace.Image = null;
                        picFlag.Image = null;
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (ModelContext db = new ModelContext())
            {
                Presidents obj = presidentBindingSource.Current as Presidents;
                if(obj !=null)
                {
                    if (db.Entry<Presidents>(obj).State == System.Data.Entity.EntityState.Detached)
                        db.Set<Presidents>().Attach(obj);
                    if (obj.ObjectState == 1)
                        db.Entry<Presidents>(obj).State = System.Data.Entity.EntityState.Added;
                    else if (obj.ObjectState == 2)
                        db.Entry<Presidents>(obj).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                   dataGridView1.Refresh();
                    pContainer.Enabled = false;
                    obj.ObjectState = 0;
                           
                }
                }
            }
        }
    }
    
