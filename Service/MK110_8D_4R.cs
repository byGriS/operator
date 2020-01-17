using System;

namespace Service {
  public class MK110_8D_4R : Device {
    public delegate void Error(Device sender);
    public event Error OnError;

    public byte ModbusID { get; set; }
    public string Title { get; set; }
    public ushort StartAddressHolding { get { return 51; } }
    public ushort QuantityAddressHolding { get { return 1; } }
    public ushort StartAddressInput { get { return 0; } }
    public ushort QuantityAddressInput { get { return 0; } }
    public ushort[] ResultInput { get; set; }// => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private string errorMessage = "";
    private int errorCounter = 0;
    public string ErrorMessage {
      get { return errorMessage; }
      set {
        errorMessage = value;
        if (errorMessage != "") {
          errorCounter++;
          if (errorCounter == 5)
            OnError?.Invoke(this);
        }
        if (errorMessage == "") {
          errorCounter = 0;
        }
      }
    }


    private ushort[] resultHolding;
    public ushort[] ResultHolding {
      get { return resultHolding; }
      set {
        resultHolding = value;
        string bitMask = Convert.ToString(resultHolding[0], 2);
        int countSym = bitMask.Length;
        for(int i = 0; i < 8-countSym; i++) {
          bitMask = "0" + bitMask;
        }
        DI1.Value = Convert.ToSingle(bitMask.Substring(7, 1));
        DI2.Value = Convert.ToSingle(bitMask.Substring(6, 1));
        DI3.Value = Convert.ToSingle(bitMask.Substring(5, 1));
        DI4.Value = Convert.ToSingle(bitMask.Substring(4, 1));
        DI5.Value = Convert.ToSingle(bitMask.Substring(3, 1));
        DI6.Value = Convert.ToSingle(bitMask.Substring(2, 1));
        DI7.Value = Convert.ToSingle(bitMask.Substring(1, 1));
        DI8.Value = Convert.ToSingle(bitMask.Substring(0, 1));
      }
    }

    public Tag DI1 { get; set; } = new Tag();
    public Tag DI2 { get; set; } = new Tag();
    public Tag DI3 { get; set; } = new Tag();
    public Tag DI4 { get; set; } = new Tag();
    public Tag DI5 { get; set; } = new Tag();
    public Tag DI6 { get; set; } = new Tag();
    public Tag DI7 { get; set; } = new Tag();
    public Tag DI8 { get; set; } = new Tag();
  }
}
