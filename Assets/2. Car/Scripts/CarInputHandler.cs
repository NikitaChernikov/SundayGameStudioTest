using UnityEngine;

public class CarInputHandler : MonoBehaviour
{
    private int _verticalInput;
    private int _horizontalInput;
    private bool _isBreak;

    public int VerticalInput
    {
        set { _verticalInput = value; }
        get { return _verticalInput; }
    }

    public int HorizontalInput
    {
        set { _horizontalInput = value; }
        get { return _horizontalInput; }
    }

    public bool BreakState
    {
        set { _isBreak = value; }
        get { return _isBreak; }
    }
    
}
