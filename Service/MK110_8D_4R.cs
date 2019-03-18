namespace Service {
  public class MK110_8D_4R : Device {

    public byte ModbusID { get; set; }
    public string Title { get; set; }
    public ushort StartAddressHolding { get { return 3; } }
    public ushort QuantityAddressHolding { get { return 3; } }
    public ushort StartAddressInput { get { return 3; } }
    public ushort QuantityAddressInput { get { return 3; } }
    public ushort[] ResultHolding { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public ushort[] ResultInput { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public string ErrorMessage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    private byte[] result;
    public byte[] Result {
      get { return result; }
      set {
        result = value;

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
