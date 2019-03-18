namespace Service {
  public interface Device {
    string Title { get; set; }
    byte ModbusID { get; set; }
    ushort StartAddressHolding { get; }
    ushort QuantityAddressHolding { get; }
    ushort StartAddressInput { get; }
    ushort QuantityAddressInput { get; }
    ushort[] ResultHolding { get; set; }
    ushort[] ResultInput { get; set; }
    string ErrorMessage { get; set; }
  }
}
