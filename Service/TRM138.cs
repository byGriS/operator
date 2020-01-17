using System;

namespace Service {
  public class TRM138 : Device {

    public delegate void Error(Device sender);
    public event Error OnError;

    public byte ModbusID { get; set; }
    public string Title { get; set; }
    public ushort StartAddressHolding { get { return 16; } }
    public ushort QuantityAddressHolding { get { return 48; } }
    public ushort StartAddressInput { get { return 67; } }
    public ushort QuantityAddressInput { get { return 37; } }

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
                    BitConverter.GetBytes(resultInput[6])[0],
                    BitConverter.GetBytes(resultInput[6])[1],
                    BitConverter.GetBytes(resultInput[5])[0],
                    BitConverter.GetBytes(resultInput[5])[1]}, 0);
        Input3.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[11])[0],
                    BitConverter.GetBytes(resultInput[11])[1],
                    BitConverter.GetBytes(resultInput[10])[0],
                    BitConverter.GetBytes(resultInput[10])[1]}, 0);
        Input4.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[16])[0],
                    BitConverter.GetBytes(resultInput[16])[1],
                    BitConverter.GetBytes(resultInput[15])[0],
                    BitConverter.GetBytes(resultInput[15])[1]}, 0);
        Input5.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[21])[0],
                    BitConverter.GetBytes(resultInput[21])[1],
                    BitConverter.GetBytes(resultInput[20])[0],
                    BitConverter.GetBytes(resultInput[20])[1]}, 0);
        Input6.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[26])[0],
                    BitConverter.GetBytes(resultInput[26])[1],
                    BitConverter.GetBytes(resultInput[25])[0],
                    BitConverter.GetBytes(resultInput[25])[1]}, 0);
        Input7.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[31])[0],
                    BitConverter.GetBytes(resultInput[31])[1],
                    BitConverter.GetBytes(resultInput[30])[0],
                    BitConverter.GetBytes(resultInput[30])[1]}, 0);
        Input8.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultInput[36])[0],
                    BitConverter.GetBytes(resultInput[36])[1],
                    BitConverter.GetBytes(resultInput[35])[0],
                    BitConverter.GetBytes(resultInput[35])[1]}, 0);
      }
    }

    public float DotMove(ushort input2, ushort input1) {
      return (float)(input2 / Math.Pow(10, input1));
    }

    private ushort[] resultHolding;
    public ushort[] ResultHolding {
      get { return resultHolding; }
      set {
        resultHolding = value;

        Input1.Set = DotMove(resultHolding[1], resultHolding[0]);
        Input2.Set = DotMove(resultHolding[5], resultHolding[4]);
        Input3.Set = DotMove(resultHolding[9], resultHolding[8]);
        Input4.Set = DotMove(resultHolding[13], resultHolding[12]);
        Input5.Set = DotMove(resultHolding[17], resultHolding[16]);
        Input6.Set = DotMove(resultHolding[21], resultHolding[20]);
        Input7.Set = DotMove(resultHolding[25], resultHolding[24]);
        Input8.Set = DotMove(resultHolding[29], resultHolding[28]);

        Input1.Hysteresis = DotMove(resultHolding[33], resultHolding[32]);
        Input2.Hysteresis = DotMove(resultHolding[35], resultHolding[34]);
        Input3.Hysteresis = DotMove(resultHolding[37], resultHolding[36]);
        Input4.Hysteresis = DotMove(resultHolding[39], resultHolding[38]);
        Input5.Hysteresis = DotMove(resultHolding[41], resultHolding[40]);
        Input6.Hysteresis = DotMove(resultHolding[43], resultHolding[42]);
        Input7.Hysteresis = DotMove(resultHolding[45], resultHolding[44]);
        Input8.Hysteresis = DotMove(resultHolding[47], resultHolding[46]);
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
   
  }
}
