using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLoadingProgressBar
{
    public partial class LoadingProgressBar : Control
    {
        int MinValue = 0;// ProgressBar için en küçük değer
        int MaxValue = 250;//ProgressBar için en büyük değer
        int ProgressBarValue = 0;// Mevcut ilerleme
        Color ProgressColor = Color.White;// ProgressBar'ın ilerleme rengi
        

        public LoadingProgressBar()
        {
            InitializeComponent();
           
            timer1.Interval = 10;

        }
        private bool guncelle = false;

        public bool Guncelleme
        {
            get => guncelle;
            set
            {
                guncelle = value;
              
                timer1.Enabled = guncelle;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        //protected override void OnResize(EventArgs e)
        //{
            
        //    this.Invalidate();
        //}

        /// <summary>
        /// Ekrana çizdimek istediğimiz nesneleri, Control sınıfındaki OnPaint metodunu override ederek bu metot içerisinde belirli metotları çağırarak çizdiririz.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs pe)
        {
           
            SolidBrush brush = new SolidBrush(ProgressColor);
            float percent = (float)(ProgressBarValue - MinValue) / (float)(MaxValue - MinValue);
            Rectangle rect = this.ClientRectangle;

            // ProgressBar'ın çizileceği alan hesaplaması
            rect.Width = (int)((float)rect.Width * percent);

            // Oluşturduğumuz dikdörtgen biçimindeki ProgressBar'ın içini doldurur.
            pe.Graphics.FillRectangle(brush, rect);

            // Oluşturmak istediğimiz kontrolün etrafına üç boyutlu bir kenarlık çizdirir.
            
            int PenWidth = (int)Pens.White.Width;

            pe.Graphics.DrawLine(Pens.DarkGray,new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top));
            pe.Graphics.DrawLine(Pens.DarkGray, new Point(this.ClientRectangle.Left, this.ClientRectangle.Top),new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth));
            pe.Graphics.DrawLine(Pens.White,new Point(this.ClientRectangle.Left, this.ClientRectangle.Height - PenWidth),new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));
            pe.Graphics.DrawLine(Pens.White, new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Top),new Point(this.ClientRectangle.Width - PenWidth, this.ClientRectangle.Height - PenWidth));

            //ProgressBar içine text yazdırır.
            pe.Graphics.DrawString(this.Text="YÜKLENİYOR", this.Font, new SolidBrush(ForeColor), 10, 10);

            // Temizler
            brush.Dispose();
            pe.Graphics.Dispose();

        }
        //minimum özelliği kontrol edilir
        public int Minimum
        {
            get
            {
                return MinValue;
            }

            set
            {
                // Negatif bir değer girildiğinde min değeri 0'a eşitler
                if (value < 0)
                {
                    MinValue = 0;
                }

                // Min değerin max degerden büyük olmaması için kontrol yapar
                if (value > MaxValue)
                {
                    MinValue = value;
                    MinValue = value;
                }

                // İlerleme değerinin min max değer aralığında olduğunu kontrol eder
                if (ProgressBarValue < MinValue)
                {
                    ProgressBarValue = MinValue;
                }

           
                this.Invalidate();
            }
        }

        public int Maximum
        {
            get
            {
                return MaxValue;
            }

            set
            {
                // Max değerin min degerden küçük olmaması için kontrol yapar
                if (value < MinValue)
                {
                    MinValue = value;
                }

                MaxValue = value;

                // İlerleme değerinin min max değer aralığında olduğunu kontrol eder
                if (ProgressBarValue > MaxValue)
                {
                    ProgressBarValue = MaxValue;
                }

               
                this.Invalidate();
            }
        }

        public int Value
        {
            get
            {
                return ProgressBarValue;
            }

            set
            {
                int oldValue = ProgressBarValue;

                // ilerleme değerinin aralıkta olup olmadığını kontrol eder
                if (value < MinValue)
                {
                    ProgressBarValue = MinValue;
                }
                else if (value > MaxValue)
                {
                    ProgressBarValue = MaxValue;
                }
                else
                {
                    ProgressBarValue = value;
                }

                // İlerlenecek alanın güncellemesi yapılır
                Rectangle newValueRect = this.ClientRectangle;
                Rectangle oldValueRect = this.ClientRectangle;

                float percent; //tek değişken kullanarak işimizi halledebiliriz iki değişkene ihtiyaç yok

                // Anlık ilerleme değerinin dikdörtgendeki alanını bulur
                percent = (float)(ProgressBarValue - MinValue) / (float)(MaxValue - MinValue);
                newValueRect.Width = (int)((float)newValueRect.Width * percent);

                // Eski ilerleme degerinin dikdörtgendeki alanını bulur.
                percent = (float)(oldValue - MinValue) / (float)(MaxValue - MinValue);
                oldValueRect.Width = (int)((float)oldValueRect.Width * percent);

                Rectangle updateRect = new Rectangle();

                // ProgressBar'daki ilerlenmesi gereken alanı update eder 
                if (newValueRect.Width > oldValueRect.Width)
                {
                    updateRect.X = oldValueRect.Size.Width;
                    updateRect.Width = newValueRect.Width - oldValueRect.Width;
                }
                else
                {
                    updateRect.X = newValueRect.Size.Width;
                    updateRect.Width = oldValueRect.Width - newValueRect.Width;
                }

                updateRect.Height = this.Height;

                
                this.Invalidate(updateRect);
            }
        }

        public Color ProgressBarColor
        {
            get
            {
                return ProgressColor;
            }

            set
            {
                ProgressColor = value;


                this.Invalidate();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            ForeColor = Color.FromArgb(Value, 100, Value);
             Value++;
            
        }

     
    }

}
