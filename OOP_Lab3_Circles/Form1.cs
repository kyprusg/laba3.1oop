using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_Lab3_Circles
{
    public partial class Form1 : Form
    {
        private MyStorage<CCircle> _storage = new MyStorage<CCircle>();

        private bool _selectAllIntersecting = false;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Лабораторная работа 3(часть1)";
            this.KeyPreview = true;
        }

        private void paintBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            bool isCtrlPressed = (Control.ModifierKeys & Keys.Control) == Keys.Control;

            bool hitAnyCircle = false;
            for(int i = 0; i < _storage.GetCount(); i++)
            {
                if(_storage.GetObject(i).IsPointInside(e.X, e.Y))
                {
                    hitAnyCircle = true;
                    break;
                }
            }

            if (hitAnyCircle)
            {
                if (!isCtrlPressed)
                {
                    ClearAllSelections();
                }
                for (int i = _storage.GetCount()-1; i>=0; i--)
                {
                    CCircle circle = _storage.GetObject(i);

                    if (circle.IsPointInside(e.X, e.Y))
                    {

                        if (isCtrlPressed)
                        {
                            circle.SetSelected(!circle.isSelected());
                        }
                        else
                        {
                            circle.SetSelected(true);
                        }
                        if (!_selectAllIntersecting)
                        {
                            break;
                        }
                    }
                }
            }
            else
            {
                if (!isCtrlPressed)
                {
                    ClearAllSelections();
                }
                CCircle newCircle = new CCircle(e.X, e.Y);
                newCircle.SetSelected(true);
                _storage.Add(newCircle);
            }
            paintBox.Invalidate();
        }

        private void paintBox_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < _storage.GetCount(); i++)
            {
                _storage.GetObject(i).draw(e.Graphics);
            }
        }

        private void paintBox_Resize(object sender, EventArgs e)
        {
            paintBox.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                for (int i = _storage.GetCount()-1;  i >= 0; i--)
                {
                    if (_storage.GetObject(i).isSelected())
                    {
                        _storage.RemoveAt(i);
                    }
                }
            }
            paintBox.Invalidate();
        }
        private void ClearAllSelections()
        {
            for (int i = 0; i < _storage.GetCount(); i++)
            {
                _storage.GetObject(i).SetSelected(false);
            }
        }
    }
}
