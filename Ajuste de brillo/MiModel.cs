using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Ajuste_de_brillo
{
    class MiModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int _valorSlider;

        public int ValorSlider
        {
            get { return _valorSlider; }
            set
            {
                _valorSlider = value;
                if(PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ValorSlider"));

            }
        }
    }
}
