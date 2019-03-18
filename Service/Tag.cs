namespace Service {
  public class Tag {

    public delegate void ChangeValue(Tag sender);
    public event ChangeValue OnChangeValue;
    public delegate void ChangeSet(Tag sender);
    public event ChangeSet OnChangeSet;
    public delegate void ChangeHysteresis(Tag sender);
    public event ChangeHysteresis OnChangeHysteresis;

    private float value = 0;
    public float Value {
      get { return value; }
      set {
        this.value = value;
        OnChangeValue?.Invoke(this);
      }
    }

    private float set = 0;
    public float Set {
      get { return set; }
      set {
        set = value;
        OnChangeSet?.Invoke(this);
      }
    }

    private float hysteresis = 0;
    public float Hysteresis {
      get { return hysteresis; }
      set {
        hysteresis = value;
        OnChangeHysteresis?.Invoke(this);
      }
    }
  }
}
