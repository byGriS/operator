using Service;
using System.Windows.Controls;

namespace SPAControls {
  public partial class TanksMini : UserControl {
    public TanksMini() {
      InitializeComponent();
    }

    public void StartUpdate() {
      Tank1L.OnChangeValue += Tank1L_OnChangeValue;
      Tank2L.OnChangeValue += Tank2L_OnChangeValue;
      Tank3L.OnChangeValue += Tank3L_OnChangeValue;
      Tank4L.OnChangeValue += Tank4L_OnChangeValue;
      Tank5L.OnChangeValue += Tank5L_OnChangeValue;
      Tank6L.OnChangeValue += Tank6L_OnChangeValue;
      Tank7L.OnChangeValue += Tank7L_OnChangeValue;
      Tank8L.OnChangeValue += Tank8L_OnChangeValue;

      Tank1L.OnChangeValue += Tank1P_OnChangeValue;
      Tank2L.OnChangeValue += Tank2P_OnChangeValue;
      Tank3L.OnChangeValue += Tank3P_OnChangeValue;
      Tank4L.OnChangeValue += Tank4P_OnChangeValue;
      Tank5L.OnChangeValue += Tank5P_OnChangeValue;
      Tank6L.OnChangeValue += Tank6P_OnChangeValue;
      Tank7L.OnChangeValue += Tank7P_OnChangeValue;
      Tank8L.OnChangeValue += Tank8P_OnChangeValue;

      Tank1F.OnChangeValue += Tank1F_OnChangeValue;
      Tank2F.OnChangeValue += Tank2F_OnChangeValue;
      Tank3F.OnChangeValue += Tank3F_OnChangeValue;
      Tank4F.OnChangeValue += Tank4F_OnChangeValue;
      Tank5F.OnChangeValue += Tank5F_OnChangeValue;
      Tank6F.OnChangeValue += Tank6F_OnChangeValue;
      Tank7F.OnChangeValue += Tank7F_OnChangeValue;
      Tank8F.OnChangeValue += Tank8F_OnChangeValue;
    }

    private void Tank1L_OnChangeValue(Tag sender) => elemTank1L.Value = (int)sender.Value;
    private void Tank2L_OnChangeValue(Tag sender) => elemTank2L.Value = (int)sender.Value;
    private void Tank3L_OnChangeValue(Tag sender) => elemTank3L.Value = (int)sender.Value;
    private void Tank4L_OnChangeValue(Tag sender) => elemTank4L.Value = (int)sender.Value;
    private void Tank5L_OnChangeValue(Tag sender) => elemTank5L.Value = (int)sender.Value;
    private void Tank6L_OnChangeValue(Tag sender) => elemTank6L.Value = (int)sender.Value;
    private void Tank7L_OnChangeValue(Tag sender) => elemTank7L.Value = (int)sender.Value;
    private void Tank8L_OnChangeValue(Tag sender) => elemTank8L.Value = (int)sender.Value;

    private void Tank1P_OnChangeValue(Tag sender) => elemTank1P.Value = (int)sender.Value;
    private void Tank2P_OnChangeValue(Tag sender) => elemTank2P.Value = (int)sender.Value;
    private void Tank3P_OnChangeValue(Tag sender) => elemTank3P.Value = (int)sender.Value;
    private void Tank4P_OnChangeValue(Tag sender) => elemTank4P.Value = (int)sender.Value;
    private void Tank5P_OnChangeValue(Tag sender) => elemTank5P.Value = (int)sender.Value;
    private void Tank6P_OnChangeValue(Tag sender) => elemTank6P.Value = (int)sender.Value;
    private void Tank7P_OnChangeValue(Tag sender) => elemTank7P.Value = (int)sender.Value;
    private void Tank8P_OnChangeValue(Tag sender) => elemTank8P.Value = (int)sender.Value;

    private void Tank1F_OnChangeValue(Tag sender) => elemTank1F.Value = (int)sender.Value;
    private void Tank2F_OnChangeValue(Tag sender) => elemTank2F.Value = (int)sender.Value;
    private void Tank3F_OnChangeValue(Tag sender) => elemTank3F.Value = (int)sender.Value;
    private void Tank4F_OnChangeValue(Tag sender) => elemTank4F.Value = (int)sender.Value;
    private void Tank5F_OnChangeValue(Tag sender) => elemTank5F.Value = (int)sender.Value;
    private void Tank6F_OnChangeValue(Tag sender) => elemTank6F.Value = (int)sender.Value;
    private void Tank7F_OnChangeValue(Tag sender) => elemTank7F.Value = (int)sender.Value;
    private void Tank8F_OnChangeValue(Tag sender) => elemTank8F.Value = (int)sender.Value;

    public void StopUpdate() {
      Tank1L.OnChangeValue -= Tank1L_OnChangeValue;
      Tank2L.OnChangeValue -= Tank2L_OnChangeValue;
      Tank3L.OnChangeValue -= Tank3L_OnChangeValue;
      Tank4L.OnChangeValue -= Tank4L_OnChangeValue;
      Tank5L.OnChangeValue -= Tank5L_OnChangeValue;
      Tank6L.OnChangeValue -= Tank6L_OnChangeValue;
      Tank7L.OnChangeValue -= Tank7L_OnChangeValue;
      Tank8L.OnChangeValue -= Tank8L_OnChangeValue;

      Tank1L.OnChangeValue -= Tank1P_OnChangeValue;
      Tank2L.OnChangeValue -= Tank2P_OnChangeValue;
      Tank3L.OnChangeValue -= Tank3P_OnChangeValue;
      Tank4L.OnChangeValue -= Tank4P_OnChangeValue;
      Tank5L.OnChangeValue -= Tank5P_OnChangeValue;
      Tank6L.OnChangeValue -= Tank6P_OnChangeValue;
      Tank7L.OnChangeValue -= Tank7P_OnChangeValue;
      Tank8L.OnChangeValue -= Tank8P_OnChangeValue;

      Tank1F.OnChangeValue -= Tank1F_OnChangeValue;
      Tank2F.OnChangeValue -= Tank2F_OnChangeValue;
      Tank3F.OnChangeValue -= Tank3F_OnChangeValue;
      Tank4F.OnChangeValue -= Tank4F_OnChangeValue;
      Tank5F.OnChangeValue -= Tank5F_OnChangeValue;
      Tank6F.OnChangeValue -= Tank6F_OnChangeValue;
      Tank7F.OnChangeValue -= Tank7F_OnChangeValue;
      Tank8F.OnChangeValue -= Tank8F_OnChangeValue;
    }

    public Tag Tank1L { get; set; } = new Tag();
    public Tag Tank2L { get; set; } = new Tag();
    public Tag Tank3L { get; set; } = new Tag();
    public Tag Tank4L { get; set; } = new Tag();
    public Tag Tank5L { get; set; } = new Tag();
    public Tag Tank6L { get; set; } = new Tag();
    public Tag Tank7L { get; set; } = new Tag();
    public Tag Tank8L { get; set; } = new Tag();

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
