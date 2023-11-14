using _4kurs.Classes;
using System.ComponentModel;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;


namespace _4kurs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BindingList<HotelRoom> data1 = new BindingList<HotelRoom>();
        BindingList<Booking> data2 = new BindingList<Booking>();

        public void DataGridRefresh1()
        {
            data1.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                var a = db.hotelroom.FromSqlRaw("SELECT * FROM HotelRoom").ToList();
                for (int i = 0; i < a.Count(); i++)
                {
                    data1.Add(a[i]);
                    dataGridView1.DataSource = data1;
                }
            }
        }

        public void DataGridRefresh2()
        {
            data2.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                var a = db.booking.FromSqlRaw("SELECT * FROM Booking").ToList();
                for (int i = 0; i < a.Count(); i++)
                {
                    data2.Add(a[i]);
                    dataGridView2.DataSource = data2;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                DataGridRefresh1();
            }

            if (tabControl1.SelectedIndex == 1)
            {
                DataGridRefresh2();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = data1;
            dataGridView2.DataSource = data2;

            DataGridRefresh1();
        }

        private void HotelRoombutton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        HotelRoom a = new HotelRoom(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), HotelRoomtextBox2.Text, Convert.ToInt32(HotelRoomtextBox3.Text), Convert.ToDouble(HotelRoomtextBox4.Text));

                        db.hotelroom.Update(a);
                        db.SaveChanges();
                        DataGridRefresh1();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HotelRoombutton2_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (dataGridView1.CurrentRow != null)
                    {
                        HotelRoom a = new HotelRoom(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), dataGridView1.CurrentRow.Cells[1].Value.ToString(), Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value), Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value));
                        db.hotelroom.Remove(a);
                        db.SaveChanges();
                        DataGridRefresh1();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HotelRoombutton3_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    HotelRoom a = new HotelRoom(Convert.ToInt32(HotelRoomtextBox1.Text), HotelRoomtextBox2.Text, Convert.ToInt32(HotelRoomtextBox3.Text), Convert.ToDouble(HotelRoomtextBox4.Text));

                    db.hotelroom.Add(a);
                    db.SaveChanges();
                    HotelRoomtextBox1.Text = "";
                    HotelRoomtextBox2.Text = "";
                    HotelRoomtextBox3.Text = "";
                    HotelRoomtextBox4.Text = "";
                    DataGridRefresh1();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bookingbutton1_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (dataGridView2.CurrentRow != null)
                    {
                        Booking a = new Booking(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value), Convert.ToInt32(BookingtextBox2.Text), Convert.ToInt32(BookingtextBox3.Text));

                        db.booking.Update(a);
                        db.SaveChanges();
                        DataGridRefresh2();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bookingbutton2_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (dataGridView2.CurrentRow != null)
                    {
                        Booking a = new Booking(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value), Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value), Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value));

                        db.booking.Remove(a);
                        db.SaveChanges();
                        DataGridRefresh2();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bookingbutton3_Click(object sender, EventArgs e)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Booking a = new Booking(Convert.ToInt32(BookingtextBox1.Text), Convert.ToInt32(BookingtextBox2.Text), Convert.ToInt32(BookingtextBox3.Text));

                    db.booking.Add(a);
                    db.SaveChanges();
                    BookingtextBox1.Text = "";
                    BookingtextBox2.Text = "";
                    BookingtextBox3.Text = "";
                    DataGridRefresh2();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void HotelRoombutton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow != null)
                {
                    HotelRoom a = new HotelRoom(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value), dataGridView1.CurrentRow.Cells[1].Value.ToString(), Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value), Convert.ToDouble(dataGridView1.CurrentRow.Cells[3].Value));
                    HotelRoomtextBox5.Text = Convert.ToString(HotelRoom.CostPerPerson(a));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bookingbutton4_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {
                    HotelRoom b = new HotelRoom();
                    Booking a = new Booking(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value), Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value), Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value));
                    for (int i = 0; i <= dataGridView1.RowCount; i++)
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == a.room_id)
                        {
                            HotelRoom c = new HotelRoom(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), dataGridView1.Rows[i].Cells[1].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value));
                            b = c;
                            break;
                        }
                    }
                    BookingtextBox4.Text = Convert.ToString((b.cost * a.duration) / b.size);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bookingbutton5_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.CurrentRow != null)
                {
                    HotelRoom b = new HotelRoom();
                    Booking a = new Booking(Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value), Convert.ToInt32(dataGridView2.CurrentRow.Cells[1].Value), Convert.ToInt32(dataGridView2.CurrentRow.Cells[2].Value));
                    for (int i = 0; i <= dataGridView1.RowCount; i++)
                    {
                        if (Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value) == a.room_id)
                        {
                            HotelRoom c = new HotelRoom(Convert.ToInt32(dataGridView1.Rows[i].Cells[0].Value), dataGridView1.Rows[i].Cells[1].Value.ToString(), Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value), Convert.ToDouble(dataGridView1.Rows[i].Cells[3].Value));
                            b = c;
                            break;
                        }
                    }
                    BookingtextBox5.Text = Convert.ToString(b.cost * a.duration);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Bookingbutton6_Click(object sender, EventArgs e)
        {
            try
            {
                Booking[] bks = new Booking[100];
                Random random = new Random();
                for (int i = 0; i < bks.Length; i++)
                {
                    bks[i] = new Booking(i + 1, random.Next(1, 31), random.Next(1, 10));
                }
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.booking.AddRange(bks);
                    db.SaveChanges();
                }
                DataGridRefresh2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Bookingbutton7_Click(object sender, EventArgs e)
        {
            try
            {
                Booking[] bks = new Booking[dataGridView2.RowCount];
                Random random = new Random();
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    bks[i] = new Booking(Convert.ToInt32(dataGridView2.Rows[i].Cells[0].Value), Convert.ToInt32(dataGridView2.Rows[i].Cells[1].Value), Convert.ToInt32(dataGridView2.Rows[i].Cells[2].Value));
                }
                using (ApplicationContext db = new ApplicationContext())
                {
                    db.booking.RemoveRange(bks);
                    db.SaveChanges();
                }
                DataGridRefresh2();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HotelRoombutton5_Click(object sender, EventArgs e)
        {
            data1.Clear();
            using (ApplicationContext db = new ApplicationContext())
            {
                var a = db.hotelroom.FromSqlRaw("SELECT * FROM HotelRoom ORDER BY cost DESC").ToList();
                for (int i = 0; i < a.Count(); i++)
                {
                    data1.Add(a[i]);
                    dataGridView1.DataSource = data1;
                }
            }
        }
    }
}