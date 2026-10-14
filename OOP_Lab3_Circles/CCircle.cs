using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab3_Circles
{
    internal class CCircle
    {
        private int _x;
        private int _y;
        private const int _radius = 35;
        private bool _isSelected;

        public CCircle(int x, int y)
        {
            _x = x;
            _y = y;
            _isSelected = false;
        }

        public bool isSelected()
        {
            return _isSelected;
        }
        public void SetSelected(bool selected)
        {
            _isSelected = selected;
        }

        public void draw(Graphics g)
        {
            Brush fillBrush = _isSelected ? Brushes.Red : Brushes.White;

            Pen borderPen = new Pen(Color.Black, 2);

            int leftX = _x - _radius;
            int leftY = _y - _radius;
            int diameter = _radius * 2;

            g.FillEllipse(fillBrush, leftX, leftY,diameter,diameter);
            g.DrawEllipse(borderPen, leftX, leftY, diameter,diameter);
        }

        public bool IsPointInside(int px, int py)
        {
            int dx = px - _x;
            int dy = py - _y;
            return (dx*dx + dy*dy) <= _radius * _radius;
        }
    }
}
