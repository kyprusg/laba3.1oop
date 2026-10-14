using System;
using System.Collections.Generic;
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
    }
}
