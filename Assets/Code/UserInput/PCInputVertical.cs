using System;
using UnityEngine;

public class PCInputVertical : IUserInputProxy
{
    public event Action<float> AxisOnChange = delegate(float f) { };

    public void GetAxis()
    {
        AxisOnChange.Invoke(Input.GetAxis(AxisManager.VERTICAL));
    }
}
