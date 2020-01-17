using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service {
  public class ME110 :Device {

    public delegate void Error(Device sender);
    public event Error OnError;

    public byte ModbusID { get; set; }
    public string Title { get; set; }
    public ushort StartAddressHolding { get { return 80; } }
    public ushort QuantityAddressHolding { get { return 38; } }
    public ushort StartAddressInput { get { return 0; } }
    public ushort QuantityAddressInput { get { return 0; } }

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
        Input1.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[1])[0],
                    BitConverter.GetBytes(resultHolding[1])[1],
                    BitConverter.GetBytes(resultHolding[0])[0],
                    BitConverter.GetBytes(resultHolding[0])[1]}, 0);
        Input2.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[3])[0],
                    BitConverter.GetBytes(resultHolding[3])[1],
                    BitConverter.GetBytes(resultHolding[2])[0],
                    BitConverter.GetBytes(resultHolding[2])[1]}, 0);
        Input3.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[5])[0],
                    BitConverter.GetBytes(resultHolding[5])[1],
                    BitConverter.GetBytes(resultHolding[4])[0],
                    BitConverter.GetBytes(resultHolding[4])[1]}, 0);
        Input4.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[7])[0],
                    BitConverter.GetBytes(resultHolding[7])[1],
                    BitConverter.GetBytes(resultHolding[6])[0],
                    BitConverter.GetBytes(resultHolding[6])[1]}, 0);
        Input5.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[9])[0],
                    BitConverter.GetBytes(resultHolding[9])[1],
                    BitConverter.GetBytes(resultHolding[8])[0],
                    BitConverter.GetBytes(resultHolding[8])[1]}, 0);
        Input6.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[11])[0],
                    BitConverter.GetBytes(resultHolding[11])[1],
                    BitConverter.GetBytes(resultHolding[10])[0],
                    BitConverter.GetBytes(resultHolding[10])[1]}, 0);
        Input7.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[37])[0],
                    BitConverter.GetBytes(resultHolding[37])[1],
                    BitConverter.GetBytes(resultHolding[36])[0],
                    BitConverter.GetBytes(resultHolding[36])[1]}, 0);
      }
    }

    public Tag Input1 { get; } = new Tag();
    public Tag Input2 { get; } = new Tag();
    public Tag Input3 { get; } = new Tag();
    public Tag Input4 { get; } = new Tag();
    public Tag Input5 { get; } = new Tag();
    public Tag Input6 { get; } = new Tag();
    public Tag Input7 { get; } = new Tag();

  }
}
