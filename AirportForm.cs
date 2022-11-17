using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using UserStory_Airport.models;

namespace UserStory_Airport
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public DbContextOptions<ApplicationContext> op;
       

        
        public Form1()
        {   
            InitializeComponent();
            op = Helper.Option();
            
            
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = ReadDB(op);
            
        }
        

        private void About_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Программа студентки группы ИП-20-3 Пшеничниковой М.В.", "Airпорт",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void AddTool_Click(object sender, EventArgs e)
        {
            FlightsForm infoForm = new FlightsForm();
            
            if (infoForm.ShowDialog(this) == DialogResult.OK)
            {
                CreateDB(op, infoForm.Flights);
              
                InfoStatCal();
                dataGridView1.DataSource = ReadDB(op);
            }
        }


        private void DeleteTool_Click(object sender, EventArgs e)
        {
            Reisi id = (Reisi)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            if(MessageBox.Show($"Вы действительно хотите удалить запись рейса {id.nomer_reisa}?",
                "Удаление записи", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                RemoveDB(op, id);
                InfoStatCal();
                dataGridView1.DataSource = ReadDB(op);
            }
            
        }

        private void ChangeTool_Click(object sender, EventArgs e)
        {
            Reisi id = (Reisi)dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].DataBoundItem;
            FlightsForm infoForm = new FlightsForm(id);
            if (infoForm.ShowDialog(this) == DialogResult.OK)
            {
                id.nomer_reisa = infoForm.Flights.nomer_reisa;
                id.type = infoForm.Flights.type;
                id.prib_time = infoForm.Flights.prib_time;
                id.passagiers_count = infoForm.Flights.passagiers_count;
                id.ppassagiers__price = infoForm.Flights.ppassagiers__price;
                id.ek_count = infoForm.Flights.ek_count;
                id.ek_price = infoForm.Flights.ek_price;
                id.procent = infoForm.Flights.procent;

                UpdateDB(op, id);
               
                InfoStatCal();
                dataGridView1.DataSource = ReadDB(op);
            }
        }


        private void FlightsDGV_SelectionChanged(object sender, EventArgs e)
        {
            pravka_delete.Enabled = dataGridView1.SelectedRows.Count > 0;
            pravka_change.Enabled = dataGridView1.SelectedRows.Count > 0;
            Delete.Enabled = dataGridView1.SelectedRows.Count > 0;
            Change.Enabled = dataGridView1.SelectedRows.Count > 0;
        }


        private void InfoStatCal()
        {
            reisi_count.Text = $"Количество рейсов {ReadDB(op).Count}";
            allpas.Text = $"Всего пассажиров {ReadDB(op).Sum(x => x.passagiers_count)}";
            allek.Text = $"Всего экипажа {ReadDB(op).Sum(x => x.ek_count)}";
            allmoney.Text = $"Общая сумма {ReadDB(op).Sum(x => x.allmoney)}";
        }

        
        
        private static void CreateDB(DbContextOptions<ApplicationContext> options, Reisi reisi)
        {
            using (var db = new ApplicationContext(options))
            {

                reisi.ID = Guid.NewGuid();
                db.AirportDB.Add(reisi);
                db.SaveChanges();
            }
        }
        private static void RemoveDB(DbContextOptions<ApplicationContext> options, Reisi reisi)
        {
            using (var db = new ApplicationContext(options))
            {
                var tourse = db.AirportDB.FirstOrDefault(u => u.ID == reisi.ID);
                if (tourse != null)
                {
                    db.AirportDB.Remove(tourse);
                    db.SaveChanges();
                }

            }
        }
        private static void UpdateDB(DbContextOptions<ApplicationContext> options, Reisi reisi)
        {
            using (var db = new ApplicationContext(options))
            {
                var tourse = db.AirportDB.FirstOrDefault(u => u.ID == reisi.ID);
                if (tourse != null)
                {
                    tourse.nomer_reisa=reisi.nomer_reisa ;
                    tourse.type = reisi.type;
                    tourse.prib_time=reisi.prib_time;
                    tourse.passagiers_count=reisi.passagiers_count;
                    tourse.ppassagiers__price=reisi.ppassagiers__price;
                    tourse.ek_count=reisi.ek_count;
                    tourse.ek_price=reisi.ek_price;
                    tourse.procent = reisi.procent;
                    tourse.allmoney = reisi.allmoney;
                    db.SaveChanges();
                }
            }
        }
        private static List<Reisi> ReadDB(DbContextOptions<ApplicationContext> options)
        {
            using (ApplicationContext db = new ApplicationContext(options))
            {
                return db.AirportDB
                    .OrderByDescending(x => x.ID)
                    .ToList();
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
