using System;

namespace Service {
  public class TRM138 : Device {

    public delegate void Error(Device sender);
    public event Error OnError;

    public byte ModbusID { get; set; }
    public string Title { get; set; }
    public ushort StartAddressHolding { get { return 12; } }
    public ushort QuantityAddressHolding { get { return 0; } }
    public ushort StartAddressInput { get { return 1; } }
    public ushort QuantityAddressInput { get { return 40; } }

    private string errorMessage = "";
    public string ErrorMessage {
      get { return errorMessage; }
      set {
        if (errorMessage != value) {
          errorMessage = value;
          if (value != "")
            OnError?.Invoke(this);
        }
      }
    }

    private ushort[] resultInput;
    public ushort[] ResultInput {
      get { return resultInput; }
      set {
        resultInput = value;
        Input1.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[1])[0],
                    BitConverter.GetBytes(resultInput[1])[1],
                    BitConverter.GetBytes(resultInput[0])[0],
                    BitConverter.GetBytes(resultInput[0])[1]}, 0);
        Input2.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[3])[0],
                    BitConverter.GetBytes(resultInput[3])[1],
                    BitConverter.GetBytes(resultInput[2])[0],
                    BitConverter.GetBytes(resultInput[2])[1]}, 0);
        Input3.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[5])[0],
                    BitConverter.GetBytes(resultInput[5])[1],
                    BitConverter.GetBytes(resultInput[4])[0],
                    BitConverter.GetBytes(resultInput[4])[1]}, 0);
        Input4.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[7])[0],
                    BitConverter.GetBytes(resultInput[7])[1],
                    BitConverter.GetBytes(resultInput[6])[0],
                    BitConverter.GetBytes(resultInput[6])[1]}, 0);
        Input5.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[9])[0],
                    BitConverter.GetBytes(resultInput[9])[1],
                    BitConverter.GetBytes(resultInput[8])[0],
                    BitConverter.GetBytes(resultInput[8])[1]}, 0);
        Input6.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[11])[0],
                    BitConverter.GetBytes(resultInput[11])[1],
                    BitConverter.GetBytes(resultInput[10])[0],
                    BitConverter.GetBytes(resultInput[10])[1]}, 0);
        Input7.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[13])[0],
                    BitConverter.GetBytes(resultInput[13])[1],
                    BitConverter.GetBytes(resultInput[12])[0],
                    BitConverter.GetBytes(resultInput[12])[1]}, 0);
        Input8.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[15])[0],
                    BitConverter.GetBytes(resultInput[15])[1],
                    BitConverter.GetBytes(resultInput[14])[0],
                    BitConverter.GetBytes(resultInput[14])[1]}, 0);
      }
    }

    public float DotMove(ushort input1, ushort input2) {
      return (float)(input2 / Math.Pow(10, input1));
    }

    private ushort[] resultHolding;
    public ushort[] ResultHolding {
      get { return resultHolding; }
      set {
        resultHolding = value;

        Set1.Value = DotMove(resultHolding[0], resultHolding[1]);
        Set2.Value = DotMove(resultHolding[4], resultHolding[5]);
        Set3.Value = DotMove(resultHolding[8], resultHolding[9]);
        Set4.Value = DotMove(resultHolding[12], resultHolding[13]);
        Set5.Value = DotMove(resultHolding[16], resultHolding[17]);
        Set6.Value = DotMove(resultHolding[20], resultHolding[21]);
        Set7.Value = DotMove(resultHolding[24], resultHolding[25]);
        Set8.Value = DotMove(resultHolding[28], resultHolding[29]);

        Hysteresis1.Value = DotMove(resultHolding[0], resultHolding[1]);
        Hysteresis2.Value = DotMove(resultHolding[4], resultHolding[5]);
        Hysteresis3.Value = DotMove(resultHolding[8], resultHolding[9]);
        Hysteresis4.Value = DotMove(resultHolding[12], resultHolding[13]);
        Hysteresis5.Value = DotMove(resultHolding[16], resultHolding[17]);
        Hysteresis6.Value = DotMove(resultHolding[20], resultHolding[21]);
        Hysteresis7.Value = DotMove(resultHolding[24], resultHolding[25]);
        Hysteresis8.Value = DotMove(resultHolding[28], resultHolding[29]);
      }
    }

    public Tag Input1 { get; } = new Tag();
    public Tag Input2 { get; } = new Tag();
    public Tag Input3 { get; } = new Tag();
    public Tag Input4 { get; } = new Tag();
    public Tag Input5 { get; } = new Tag();
    public Tag Input6 { get; } = new Tag();
    public Tag Input7 { get; } = new Tag();
    public Tag Input8 { get; } = new Tag();

    public Tag Set1 { get; } = new Tag();
    public Tag Set2 { get; } = new Tag();
    public Tag Set3 { get; } = new Tag();
    public Tag Set4 { get; } = new Tag();
    public Tag Set5 { get; } = new Tag();
    public Tag Set6 { get; } = new Tag();
    public Tag Set7 { get; } = new Tag();
    public Tag Set8 { get; } = new Tag();

    public Tag Hysteresis1 { get; } = new Tag();
    public Tag Hysteresis2 { get; } = new Tag();
    public Tag Hysteresis3 { get; } = new Tag();
    public Tag Hysteresis4 { get; } = new Tag();
    public Tag Hysteresis5 { get; } = new Tag();
    public Tag Hysteresis6 { get; } = new Tag();
    public Tag Hysteresis7 { get; } = new Tag();
    public Tag Hysteresis8 { get; } = new Tag();
  }
}
