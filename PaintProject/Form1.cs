using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PaintProject

{

    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
            bool drawing;
            int historyCounter;
            GraphicsPath currentPath;
            Point oldLocation;
            Pen currentPen;
            drawing = false; //Переменная, ответственная за рисование
            currentPen = new Pen(Color.Black); //Инициализация пера с черным цветом
            Color historyColor;
            List<Image> History;
            
        }

        private void picDrawingSurface_MouseDown(object sender, MouseEventArgs e)
        {
            List<Image> History = new List<Image>();
            bool drawing;
            GraphicsPath currentPath;
            Point oldLocation;
            Pen currentPen;
            drawing = false; //Переменная, ответственная за рисование
            currentPen = new Pen(Color.Black); //Инициализация пера с черным цветом

            if (picDrawingSurface.Image == null)
            {
                MessageBox.Show("Сначала создайте новый файл!");
                return;
                if (picDrawingSurface.Image == null)
                {
                    MessageBox.Show("Сначала создайте новый файл!");
                    return;
                }
                if (e.Button == MouseButtons.Left)
                {
                    drawing = true;
                    oldLocation = e.Location;
                    currentPath = new GraphicsPath();
                }


            }


        }

        private void saveDlg_FileOk(object sender, CancelEventArgs e)
        {
            SaveFileDialog SaveDlg = new SaveFileDialog();
            SaveDlg.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNGImage | *.png";
            SaveDlg.Title = "Save an Image File";
            SaveDlg.FilterIndex = 4; //По умолчанию будет выбрано последнее расширение*.png
            SaveDlg.ShowDialog();

            if (SaveDlg.FileName != "") //Если введено не пустое имя
            {
                System.IO.FileStream fs = (System.IO.FileStream)SaveDlg.OpenFile();
                switch (SaveDlg.FilterIndex)
                {
                    case 1:
                        this.picDrawingSurface.Image.Save(fs,
                        ImageFormat.Jpeg);
                        break;
                    case 2:
                        this.picDrawingSurface.Image.Save(fs,
                        ImageFormat.Bmp);
                        break;
                    case 3:
                        this.picDrawingSurface.Image.Save(fs,
                        ImageFormat.Gif);
                        break;
                    case 4:
                        this.picDrawingSurface.Image.Save(fs,
                        ImageFormat.Png);
                        break;
                }
                fs.Close();



            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (picDrawingSurface.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение передсозданием нового рисунка ? ", "Предупреждение",
                MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: saveMenu_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
            }
            Graphics g = Graphics.FromImage(picDrawingSurface.Image);
            g.Clear(Color.White);
            g.DrawImage(picDrawingSurface.Image, 0, 0, 750, 500);
        }

        private void saveMenu_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Bitmap pic = new Bitmap(750, 500);
            picDrawingSurface.Image = pic;
            if (picDrawingSurface.Image != null)
            {
                var result = MessageBox.Show("Сохранить текущее изображение передсозданием нового рисунка ? ", "Предупреждение",
                MessageBoxButtons.YesNoCancel);
                switch (result)
                {
                    case DialogResult.No: break;
                    case DialogResult.Yes: saveMenu_Click(sender, e); break;
                    case DialogResult.Cancel: return;
                }
            }
            List<Image> History = new List<Image>();
            int historyCounter;
            History.Clear();
            historyCounter = 0;
            picDrawingSurface.Image = pic;
            History.Add(new Bitmap(picDrawingSurface.Image));

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog OP = new OpenFileDialog();
            OP.Filter = "JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|PNGImage | *.png";
            OP.Title = "Open an Image File";
            OP.FilterIndex = 1; //По умолчанию будет выбрано первое расширение *.jpg

            if (OP.ShowDialog() != DialogResult.Cancel)
                picDrawingSurface.Load(OP.FileName);
            picDrawingSurface.AutoSize = true;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



        private void picDrawingSurface_MouseUp(object sender, MouseEventArgs e)
        {
            bool drawing;
            GraphicsPath currentPath;
            drawing = false;
            currentPath = new GraphicsPath();
            List<Image> History = new List<Image>();
            int historyCounter;
            History.Clear();
            historyCounter = 0;
            try
            {
                currentPath.Dispose();
            }
            catch { };

            History.RemoveRange(historyCounter + 1, History.Count - historyCounter - 1);
            History.Add(new Bitmap(picDrawingSurface.Image));
            if (historyCounter + 1 < 10) historyCounter++;
            if (History.Count - 1 == 10) History.RemoveAt(0);
            drawing = false;
            try
            {
                currentPath.Dispose();
            }
            catch { };

        }

        private void picDrawingSurface_MouseMove(object sender, MouseEventArgs e)
        {
            bool drawing;
            GraphicsPath currentPath;
            Point oldLocation;
            Pen currentPen;
            drawing = false; //Переменная, ответственная за рисование
            currentPen = new Pen(Color.Black); //Инициализация пера с черным цветом
            if (drawing)
            {
                Graphics g = Graphics.FromImage(picDrawingSurface.Image);
                oldLocation = e.Location;
                g.Dispose();
                picDrawingSurface.Invalidate();
            }

        }

        

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Image> History = new List<Image>();
            int historyCounter;
            History.Clear();
            historyCounter = 0;
            if (History.Count != 0 && historyCounter != 0)
            {
                picDrawingSurface.Image = new Bitmap(History[--historyCounter]);
            }
            else MessageBox.Show("История пуста");
        }

        private void renoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Image> History = new List<Image>();
            int historyCounter;
            History.Clear();
            historyCounter = 0;
            if (historyCounter < History.Count - 1)
            {
                picDrawingSurface.Image = new Bitmap(History[++historyCounter]);
            }
            else MessageBox.Show("История пуста");
        }

    }


}

