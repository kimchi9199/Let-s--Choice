using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace Project_Group_10
{
    class ButtonStart : Button
    {
        protected int bodersize = 0;
        private int boderradius = 40;
        private Color bodercolor = Color.PaleVioletRed;

        [Category("CUSTOM CONTROL")]
        public int BoderSize
        {
            get
            {
                return bodersize;
            }
            set
            {
                bodersize = value;
                this.Invalidate();
            }      
        }
        [Category("CUSTOM CONTROL")]
        public Color BoderColor
        {
            get
            {
                return bodercolor;
            }
            set
            {
                bodercolor = value;
                this.Invalidate();
            }
        }
        [Category("CUSTOM CONTROL")]
        public int Boderradius
        {
            get
            {
                return boderradius;
            } 
            set
            {
                boderradius = value;
                if (value <= this.Height)
                    boderradius = value;
                else
                    boderradius = this.Height;
                this.Invalidate();
            } 
        }
        [Category("CUSTOM CONTROL")]
        public Color BackgroundColor
        {
            get
            {
                return this.BackColor;
            }
            set
            {
                this.BackColor = value;
            }
        }
        [Category ("CUSTOM CONTROL") ]
        public Color TextColor
        {
            get
            {
                return this.ForeColor;
            }
            set
            {
                this.ForeColor = value;
            }
        }
        //Contructor
        public ButtonStart()
        {
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Size = new Size(150, 40);
            this.BackColor = Color.MediumSlateBlue;
            this.ForeColor = Color.White;
            this.Resize += new EventHandler(button_resize);
        }

        
        //methods
        protected GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF rectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF rectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (boderradius > 2) //round button
            {
                using (GraphicsPath pathSurface = GetFigurePath(rectSurface, boderradius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, boderradius - 1F))
                using (Pen penSurface = new Pen(this.Parent.BackColor, 2))
                using (Pen penBorder = new Pen(bodercolor, bodersize))
                {
                    penBorder.Alignment = PenAlignment.Inset;
                    //button surface
                    this.Region = new Region(pathSurface);
                    //draw surface border for HD result
                    pevent.Graphics.DrawPath(penSurface, pathSurface);

                    //button border
                    if (bodersize >= 1)
                        //draw control border
                        pevent.Graphics.DrawPath(penBorder, pathBorder);
                }
            }
            else //normal button
            {
                this.Region = new Region(rectSurface);
                if (bodersize >= 1)
                {
                    using (Pen penBorder = new Pen(bodercolor, bodersize))
                    {
                        penBorder.Alignment = PenAlignment.Inset;
                        pevent.Graphics.DrawRectangle(penBorder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }
        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }
        protected void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
                this.Invalidate();
        }
        private void button_resize(object sender, EventArgs e)
        {
            if (boderradius > this.Height)
                Boderradius = this.Height;
        }

    }
}
