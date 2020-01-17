using Service;
using System.Windows.Controls;

namespace SPAControls {
  public partial class TanksMini : UserControl {
    public TanksMini() {
      InitializeComponent();
    }

    public void StartUpdate() {
      Tank1L1.OnChangeValue += Tank1L_OnChangeValue;
      Tank1L2.OnChangeValue += Tank1L_OnChangeValue;

      Tank2L1.OnChangeValue += Tank2L_OnChangeValue;
      Tank2L2.OnChangeValue += Tank2L_OnChangeValue;
      Tank2L3.OnChangeValue += Tank2L_OnChangeValue;
      Tank2L4.OnChangeValue += Tank2L_OnChangeValue;
      Tank2L5.OnChangeValue += Tank2L_OnChangeValue;

      Tank3L1.OnChangeValue += Tank3L_OnChangeValue;
      Tank3L2.OnChangeValue += Tank3L_OnChangeValue;
      Tank3L3.OnChangeValue += Tank3L_OnChangeValue;
      Tank3L4.OnChangeValue += Tank3L_OnChangeValue;
      Tank3L5.OnChangeValue += Tank3L_OnChangeValue;

      Tank4L1.OnChangeValue += Tank4L_OnChangeValue;
      Tank4L2.OnChangeValue += Tank4L_OnChangeValue;
      Tank4L3.OnChangeValue += Tank4L_OnChangeValue;
      Tank4L5.OnChangeValue += Tank4L_OnChangeValue;

      Tank4L4.OnChangeValue += Tank4L_OnChangeValue;
      Tank5L1.OnChangeValue += Tank5L_OnChangeValue;
      Tank5L2.OnChangeValue += Tank5L_OnChangeValue;

      Tank6L1.OnChangeValue += Tank6L_OnChangeValue;
      Tank6L2.OnChangeValue += Tank6L_OnChangeValue;

      Tank7L1.OnChangeValue += Tank7L_OnChangeValue;
      Tank7L2.OnChangeValue += Tank7L_OnChangeValue;

      Tank8L1.OnChangeValue += Tank8L_OnChangeValue;
      Tank8L2.OnChangeValue += Tank8L_OnChangeValue;

      Tank1P.OnChangeValue += Tank1P_OnChangeValue;
      Tank2P.OnChangeValue += Tank2P_OnChangeValue;
      Tank3P.OnChangeValue += Tank3P_OnChangeValue;
      Tank4P.OnChangeValue += Tank4P_OnChangeValue;
      Tank5P.OnChangeValue += Tank5P_OnChangeValue;
      Tank6P.OnChangeValue += Tank6P_OnChangeValue;
      Tank7P.OnChangeValue += Tank7P_OnChangeValue;
      Tank8P.OnChangeValue += Tank8P_OnChangeValue;

      Tank1F.OnChangeValue += Tank1F_OnChangeValue;
      Tank2F.OnChangeValue += Tank2F_OnChangeValue;
      Tank3F.OnChangeValue += Tank3F_OnChangeValue;
      Tank4F.OnChangeValue += Tank4F_OnChangeValue;
      Tank5F.OnChangeValue += Tank5F_OnChangeValue;
      Tank6F.OnChangeValue += Tank6F_OnChangeValue;
      Tank7F.OnChangeValue += Tank7F_OnChangeValue;
      Tank8F.OnChangeValue += Tank8F_OnChangeValue;
    }

    private void Tank1L_OnChangeValue(Tag sender) {
      if (Tank1L1.Value == 1 && Tank1L2.Value == 1)
        elemTank1L.Value = 1;
      if (Tank1L1.Value == 0 && Tank1L2.Value == 1)
        elemTank1L.Value = 0;
      if (Tank1L1.Value == 1 && Tank1L2.Value == 0)
        elemTank1L.Value = 3;
      if (Tank1L1.Value == 0 && Tank1L2.Value == 0)
        elemTank1L.Value = 4;
    }
    private void Tank2L_OnChangeValue(Tag sender) {
      if (Tank2L1.Value == 1 && (Tank2L2.Value == 1 && Tank2L3.Value == 1) && (Tank2L4.Value == 1 && Tank2L5.Value == 1))
        elemTank2L.Value = 1;
      if (Tank2L1.Value == 0 && (Tank2L2.Value == 1 && Tank2L3.Value == 1) && (Tank2L4.Value == 1 && Tank2L5.Value == 1))
        elemTank2L.Value = 0;
      if (Tank2L1.Value == 1 && (Tank2L2.Value == 0 || Tank2L3.Value == 0) && (Tank2L4.Value == 1 && Tank2L5.Value == 1))
        elemTank2L.Value = 2;
      if (Tank2L1.Value == 1 && (Tank2L2.Value == 1 && Tank2L3.Value == 1) && (Tank2L4.Value == 0 || Tank2L5.Value == 0))
        elemTank2L.Value = 3;
      if (Tank2L1.Value == 0 && (Tank2L2.Value == 0 && Tank2L3.Value == 0) && (Tank2L4.Value == 0 || Tank2L5.Value == 0))
        elemTank2L.Value = 4;
    }
    private void Tank3L_OnChangeValue(Tag sender) {
      if (Tank3L1.Value == 1 && (Tank3L2.Value == 1 && Tank3L3.Value == 1) && (Tank3L4.Value == 1 && Tank3L5.Value == 1))
        elemTank3L.Value = 1;
      if (Tank3L1.Value == 0 && (Tank3L2.Value == 1 && Tank3L3.Value == 1) && (Tank3L4.Value == 1 && Tank3L5.Value == 1))
        elemTank3L.Value = 0;
      if (Tank3L1.Value == 1 && (Tank3L2.Value == 0 || Tank3L3.Value == 0) && (Tank3L4.Value == 1 && Tank3L5.Value == 1))
        elemTank3L.Value = 2;
      if (Tank3L1.Value == 1 && (Tank3L2.Value == 1 && Tank3L3.Value == 1) && (Tank3L4.Value == 0 || Tank3L5.Value == 0))
        elemTank3L.Value = 3;
      if (Tank3L1.Value == 0 && (Tank3L2.Value == 0 && Tank3L3.Value == 0) && (Tank3L4.Value == 0 || Tank3L5.Value == 0))
        elemTank3L.Value = 4;
    }
    private void Tank4L_OnChangeValue(Tag sender) {
      if (Tank4L1.Value == 1 && (Tank4L2.Value == 1 && Tank4L3.Value == 1) && (Tank4L4.Value == 1 && Tank4L5.Value == 1))
        elemTank4L.Value = 1;
      if (Tank4L1.Value == 0 && (Tank4L2.Value == 1 && Tank4L3.Value == 1) && (Tank4L4.Value == 1 && Tank4L5.Value == 1))
        elemTank4L.Value = 0;
      if (Tank4L1.Value == 1 && (Tank4L2.Value == 0 || Tank4L3.Value == 0) && (Tank4L4.Value == 1 && Tank4L5.Value == 1))
        elemTank4L.Value = 2;
      if (Tank4L1.Value == 1 && (Tank4L2.Value == 1 && Tank4L3.Value == 1) && (Tank4L4.Value == 0 || Tank4L5.Value == 0))
        elemTank4L.Value = 3;
      if (Tank4L1.Value == 0 && (Tank4L2.Value == 0 && Tank4L3.Value == 0) && (Tank4L4.Value == 0 || Tank4L5.Value == 0))
        elemTank4L.Value = 4;
    }
    private void Tank5L_OnChangeValue(Tag sender) {
      if (Tank5L1.Value == 1 && Tank5L2.Value == 1)
        elemTank5L.Value = 1;
      if (Tank5L1.Value == 0 && Tank5L2.Value == 1)
        elemTank5L.Value = 0;
      if (Tank5L1.Value == 1 && Tank5L2.Value == 0)
        elemTank5L.Value = 3;
      if (Tank5L1.Value == 0 && Tank5L2.Value == 0)
        elemTank5L.Value = 4;
    }
    private void Tank6L_OnChangeValue(Tag sender) {
      if (Tank6L1.Value == 1 && Tank6L2.Value == 1)
        elemTank6L.Value = 1;
      if (Tank6L1.Value == 0 && Tank6L2.Value == 1)
        elemTank6L.Value = 0;
      if (Tank6L1.Value == 1 && Tank6L2.Value == 0)
        elemTank6L.Value = 3;
      if (Tank6L1.Value == 0 && Tank6L2.Value == 0)
        elemTank6L.Value = 4;
    }
    private void Tank7L_OnChangeValue(Tag sender) {
      if (Tank7L1.Value == 1 && Tank7L2.Value == 1)
        elemTank7L.Value = 1;
      if (Tank7L1.Value == 0 && Tank7L2.Value == 1)
        elemTank7L.Value = 0;
      if (Tank7L1.Value == 1 && Tank7L2.Value == 0)
        elemTank7L.Value = 3;
      if (Tank7L1.Value == 0 && Tank7L2.Value == 0)
        elemTank7L.Value = 4;
    }
    private void Tank8L_OnChangeValue(Tag sender) {
      if (Tank8L1.Value == 1 && Tank8L2.Value == 1)
        elemTank8L.Value = 1;
      if (Tank8L1.Value == 0 && Tank8L2.Value == 1)
        elemTank8L.Value = 0;
      if (Tank8L1.Value == 1 && Tank8L2.Value == 0)
        elemTank8L.Value = 3;
      if (Tank8L1.Value == 0 && Tank8L2.Value == 0)
        elemTank8L.Value = 4;
    }

    private void Tank1P_OnChangeValue(Tag sender) => elemTank1P.Value = sender.Value;
    private void Tank2P_OnChangeValue(Tag sender) => elemTank2P.Value = sender.Value;
    private void Tank3P_OnChangeValue(Tag sender) => elemTank3P.Value = sender.Value;
    private void Tank4P_OnChangeValue(Tag sender) => elemTank4P.Value = sender.Value;
    private void Tank5P_OnChangeValue(Tag sender) => elemTank5P.Value = sender.Value;
    private void Tank6P_OnChangeValue(Tag sender) => elemTank6P.Value = sender.Value;
    private void Tank7P_OnChangeValue(Tag sender) => elemTank7P.Value = sender.Value;
    private void Tank8P_OnChangeValue(Tag sender) => elemTank8P.Value = sender.Value;

    private void Tank1F_OnChangeValue(Tag sender) => elemTank1F.Value = (int)sender.Value;
    private void Tank2F_OnChangeValue(Tag sender) => elemTank2F.Value = (int)sender.Value;
    private void Tank3F_OnChangeValue(Tag sender) => elemTank3F.Value = (int)sender.Value;
    private void Tank4F_OnChangeValue(Tag sender) => elemTank4F.Value = (int)sender.Value;
    private void Tank5F_OnChangeValue(Tag sender) => elemTank5F.Value = (int)sender.Value;
    private void Tank6F_OnChangeValue(Tag sender) => elemTank6F.Value = (int)sender.Value;
    private void Tank7F_OnChangeValue(Tag sender) => elemTank7F.Value = (int)sender.Value;
    private void Tank8F_OnChangeValue(Tag sender) => elemTank8F.Value = (int)sender.Value;

    public void StopUpdate() {
      Tank1L1.OnChangeValue -= Tank1L_OnChangeValue;
      Tank1L2.OnChangeValue -= Tank1L_OnChangeValue;

      Tank2L1.OnChangeValue -= Tank2L_OnChangeValue;
      Tank2L2.OnChangeValue -= Tank2L_OnChangeValue;
      Tank2L3.OnChangeValue -= Tank2L_OnChangeValue;
      Tank2L4.OnChangeValue -= Tank2L_OnChangeValue;
      Tank2L5.OnChangeValue -= Tank2L_OnChangeValue;

      Tank3L1.OnChangeValue -= Tank3L_OnChangeValue;
      Tank3L2.OnChangeValue -= Tank3L_OnChangeValue;
      Tank3L3.OnChangeValue -= Tank3L_OnChangeValue;
      Tank3L4.OnChangeValue -= Tank3L_OnChangeValue;
      Tank3L5.OnChangeValue -= Tank3L_OnChangeValue;

      Tank4L1.OnChangeValue -= Tank4L_OnChangeValue;
      Tank4L2.OnChangeValue -= Tank4L_OnChangeValue;
      Tank4L3.OnChangeValue -= Tank4L_OnChangeValue;
      Tank4L4.OnChangeValue -= Tank4L_OnChangeValue;
      Tank4L5.OnChangeValue -= Tank4L_OnChangeValue;

      Tank5L1.OnChangeValue -= Tank5L_OnChangeValue;
      Tank5L2.OnChangeValue -= Tank5L_OnChangeValue;

      Tank6L1.OnChangeValue -= Tank6L_OnChangeValue;
      Tank6L2.OnChangeValue -= Tank6L_OnChangeValue;

      Tank7L1.OnChangeValue -= Tank7L_OnChangeValue;
      Tank7L2.OnChangeValue -= Tank7L_OnChangeValue;

      Tank8L1.OnChangeValue -= Tank8L_OnChangeValue;
      Tank8L2.OnChangeValue -= Tank8L_OnChangeValue;

      Tank1P.OnChangeValue -= Tank1P_OnChangeValue;
      Tank2P.OnChangeValue -= Tank2P_OnChangeValue;
      Tank3P.OnChangeValue -= Tank3P_OnChangeValue;
      Tank4P.OnChangeValue -= Tank4P_OnChangeValue;
      Tank5P.OnChangeValue -= Tank5P_OnChangeValue;
      Tank6P.OnChangeValue -= Tank6P_OnChangeValue;
      Tank7P.OnChangeValue -= Tank7P_OnChangeValue;
      Tank8P.OnChangeValue -= Tank8P_OnChangeValue;

      Tank1F.OnChangeValue -= Tank1F_OnChangeValue;
      Tank2F.OnChangeValue -= Tank2F_OnChangeValue;
      Tank3F.OnChangeValue -= Tank3F_OnChangeValue;
      Tank4F.OnChangeValue -= Tank4F_OnChangeValue;
      Tank5F.OnChangeValue -= Tank5F_OnChangeValue;
      Tank6F.OnChangeValue -= Tank6F_OnChangeValue;
      Tank7F.OnChangeValue -= Tank7F_OnChangeValue;
      Tank8F.OnChangeValue -= Tank8F_OnChangeValue;
    }

    public Tag Tank1L1 { get; set; } = new Tag();
    public Tag Tank1L2 { get; set; } = new Tag();

    public Tag Tank2L1 { get; set; } = new Tag();
    public Tag Tank2L2 { get; set; } = new Tag();
    public Tag Tank2L3 { get; set; } = new Tag();
    public Tag Tank2L4 { get; set; } = new Tag();
    public Tag Tank2L5 { get; set; } = new Tag();

    public Tag Tank3L1 { get; set; } = new Tag();
    public Tag Tank3L2 { get; set; } = new Tag();
    public Tag Tank3L3 { get; set; } = new Tag();
    public Tag Tank3L4 { get; set; } = new Tag();
    public Tag Tank3L5 { get; set; } = new Tag();

    public Tag Tank4L1 { get; set; } = new Tag();
    public Tag Tank4L2 { get; set; } = new Tag();
    public Tag Tank4L3 { get; set; } = new Tag();
    public Tag Tank4L4 { get; set; } = new Tag();
    public Tag Tank4L5 { get; set; } = new Tag();

    public Tag Tank5L1 { get; set; } = new Tag();
    public Tag Tank5L2 { get; set; } = new Tag();

    public Tag Tank6L1 { get; set; } = new Tag();
    public Tag Tank6L2 { get; set; } = new Tag();

    public Tag Tank7L1 { get; set; } = new Tag();
    public Tag Tank7L2 { get; set; } = new Tag();

    public Tag Tank8L1 { get; set; } = new Tag();
    public Tag Tank8L2 { get; set; } = new Tag();

    public Tag Tank1P { get; set; } = new Tag();
    public Tag Tank2P { get; set; } = new Tag();
    public Tag Tank3P { get; set; } = new Tag();
    public Tag Tank4P { get; set; } = new Tag();
    public Tag Tank5P { get; set; } = new Tag();
    public Tag Tank6P { get; set; } = new Tag();
    public Tag Tank7P { get; set; } = new Tag();
    public Tag Tank8P { get; set; } = new Tag();

    public Tag Tank1F { get; set; } = new Tag();
    public Tag Tank2F { get; set; } = new Tag();
    public Tag Tank3F { get; set; } = new Tag();
    public Tag Tank4F { get; set; } = new Tag();
    public Tag Tank5F { get; set; } = new Tag();
    public Tag Tank6F { get; set; } = new Tag();
    public Tag Tank7F { get; set; } = new Tag();
    public Tag Tank8F { get; set; } = new Tag();

  }
}
