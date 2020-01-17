using System;
using System.Collections;

namespace Service {
  public class UPES : Device {
    public delegate void Error(Device sender);
    public event Error OnError;

    public byte ModbusID { get; set; }
    public string Title { get; set; }
    public ushort StartAddressHolding { get { return 166; } }
    public ushort QuantityAddressHolding { get { return 4; } }
    public ushort StartAddressInput { get { return 0; } }
    public ushort QuantityAddressInput { get { return 0; } }
    public ushort[] ResultInput { get; set; }

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
    //81371 91825
    //89602317744 виктор
   //@esp.com.ru

    private ushort[] resultHolding;
    public ushort[] ResultHolding {
      get { return resultHolding; }
      set {
        resultHolding = value;
        BitArray trigger1 = new BitArray(BitConverter.GetBytes(resultHolding[0]));
        BitArray trigger2 = new BitArray(BitConverter.GetBytes(resultHolding[1]));
        BitArray error = new BitArray(BitConverter.GetBytes(resultHolding[3]));

        Channel16.Value = error[0] ? 3 : (trigger2[0] ? 2 : (trigger1[0] ? 1 : 0));
        Channel15.Value = error[1] ? 3 : (trigger2[1] ? 2 : (trigger1[1] ? 1 : 0));
        Channel14.Value = error[2] ? 3 : (trigger2[2] ? 2 : (trigger1[2] ? 1 : 0));
        Channel13.Value = error[3] ? 3 : (trigger2[3] ? 2 : (trigger1[3] ? 1 : 0));
        Channel12.Value = error[4] ? 3 : (trigger2[4] ? 2 : (trigger1[4] ? 1 : 0));
        Channel11.Value = error[5] ? 3 : (trigger2[5] ? 2 : (trigger1[5] ? 1 : 0));
        Channel10.Value = error[6] ? 3 : (trigger2[6] ? 2 : (trigger1[6] ? 1 : 0));
        Channel9.Value = error[7] ? 3 : (trigger2[7] ? 2 : (trigger1[7] ? 1 : 0));
        Channel8.Value = error[8] ? 3 : (trigger2[8] ? 2 : (trigger1[8] ? 1 : 0));
        Channel7.Value = error[9] ? 3 : (trigger2[9] ? 2 : (trigger1[9] ? 1 : 0));
        Channel6.Value = error[10] ? 3 : (trigger2[10] ? 2 : (trigger1[10] ? 1 : 0));
        Channel5.Value = error[11] ? 3 : (trigger2[11] ? 2 : (trigger1[11] ? 1 : 0));
        Channel4.Value = error[12] ? 3 : (trigger2[12] ? 2 : (trigger1[12] ? 1 : 0));
        Channel3.Value = error[13] ? 3 : (trigger2[13] ? 2 : (trigger1[13] ? 1 : 0));
        Channel2.Value = error[14] ? 3 : (trigger2[14] ? 2 : (trigger1[14] ? 1 : 0));
        Channel1.Value = error[15] ? 3 : (trigger2[15] ? 2 : (trigger1[15] ? 1 : 0));
      }
    }

    public Tag Channel1 { get; set; } = new Tag();
    public Tag Channel2 { get; set; } = new Tag();
    public Tag Channel3 { get; set; } = new Tag();
    public Tag Channel4 { get; set; } = new Tag();
    public Tag Channel5 { get; set; } = new Tag();
    public Tag Channel6 { get; set; } = new Tag();
    public Tag Channel7 { get; set; } = new Tag();
    public Tag Channel8 { get; set; } = new Tag();
    public Tag Channel9 { get; set; } = new Tag();
    public Tag Channel10 { get; set; } = new Tag();
    public Tag Channel11 { get; set; } = new Tag();
    public Tag Channel12 { get; set; } = new Tag();
    public Tag Channel13 { get; set; } = new Tag();
    public Tag Channel14 { get; set; } = new Tag();
    public Tag Channel15 { get; set; } = new Tag();
    public Tag Channel16 { get; set; } = new Tag();
  }
}
