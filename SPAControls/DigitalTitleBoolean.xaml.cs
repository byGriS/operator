﻿using System;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace SPAControls {
  public partial class DigitalTitleBoolean : UserControl, INotifyPropertyChanged {
    public DigitalTitleBoolean() {
      InitializeComponent();
      this.DataContext = this;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged(string prop = "") {
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public string Title { get; set; }
    public int SPAFontSize { get; set; }
    public float Min { get; set; }
    public float Max { get; set; }
    public bool NotMinuse { get; set; }


    private float value = 0;

    public float Value {
      get { return value; }
      set {
        this.value = (float)Math.Round(value, 1);
        if (NotMinuse)
        if (this.value < 0) this.value = 0;
        if (value < Min)
          ellipse.Fill = new SolidColorBrush(Colors.Red);
        else {
          if (value > Max)
            ellipse.Fill = new SolidColorBrush(Colors.Red);
          else
            ellipse.Fill = new SolidColorBrush(Colors.LightGray);
        }
        OnPropertyChanged("Value");
      }
    }
  }
}
