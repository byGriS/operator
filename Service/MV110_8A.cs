using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service {
  public class MV110_8A : Device {
    public delegate void Error(Device sender);
    public event Error OnError;

    public byte ModbusID { get; set; }
    public string Title { get; set; }
    public ushort StartAddressHolding { get { return 4; } }
    public ushort QuantityAddressHolding { get { return 44; } }
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

    public float DotMove(ushort input1, ushort input2) {
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
                    BitConverter.GetBytes(resultHolding[7])[0],
                    BitConverter.GetBytes(resultHolding[7])[1],
                    BitConverter.GetBytes(resultHolding[6])[0],
                    BitConverter.GetBytes(resultHolding[6])[1]}, 0);
        Input3.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[13])[0],
                    BitConverter.GetBytes(resultHolding[13])[1],
                    BitConverter.GetBytes(resultHolding[12])[0],
                    BitConverter.GetBytes(resultHolding[12])[1]}, 0);
        Input4.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[19])[0],
                    BitConverter.GetBytes(resultHolding[19])[1],
                    BitConverter.GetBytes(resultHolding[18])[0],
                    BitConverter.GetBytes(resultHolding[18])[1]}, 0);
        Input5.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[25])[0],
                    BitConverter.GetBytes(resultHolding[25])[1],
                    BitConverter.GetBytes(resultHolding[24])[0],
                    BitConverter.GetBytes(resultHolding[24])[1]}, 0);
        Input6.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[31])[0],
                    BitConverter.GetBytes(resultHolding[31])[1],
                    BitConverter.GetBytes(resultHolding[30])[0],
                    BitConverter.GetBytes(resultHolding[30])[1]}, 0);
        Input7.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[37])[0],
                    BitConverter.GetBytes(resultHolding[37])[1],
                    BitConverter.GetBytes(resultHolding[36])[0],
                    BitConverter.GetBytes(resultHolding[36])[1]}, 0);
        Input8.Value = BitConverter.ToSingle(new byte[] {
                    BitConverter.GetBytes(resultHolding[43])[0],
                    BitConverter.GetBytes(resultHolding[43])[1],
                    BitConverter.GetBytes(resultHolding[42])[0],
                    BitConverter.GetBytes(resultHolding[42])[1]}, 0);
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
