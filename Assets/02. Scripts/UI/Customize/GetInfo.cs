using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInfo : MonoBehaviour
{
    public BarColorPicker barColorPicker;

    public int index;

    public void ChangeIndex()
    {
        barColorPicker.rendererIndex = index;
    }
}
