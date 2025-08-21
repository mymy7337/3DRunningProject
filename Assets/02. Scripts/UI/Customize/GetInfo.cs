using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetInfo : MonoBehaviour
{
    public BarColorPicker barColorPicker;
    public CircleColorPicker circleColorPicker;

    public int index;

    public void ChangeIndex()
    {
        CustomizeDataManager.Instance.Load();
        barColorPicker.rendererIndex = index;
        CustomizeDataManager.Instance.characterVisual.pickerData[CustomizeDataManager.Instance.characterVisual.characterIndex].index = index;
        CustomizeDataManager.Instance.Save();
        barColorPicker.SetPickerPosition();
        circleColorPicker.SetPickerPosition();
    }
}
