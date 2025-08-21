using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    [SerializeField] private BarColorPicker barColor;
    [SerializeField] private CircleColorPicker circleColor;

    public void ResetColor()
    {
        for (int i = 0; i < CustomizeDataManager.Instance.characterVisual.characterData[CustomizeDataManager.Instance.characterVisual.characterIndex].colors.Count; i++)
        {
            PlayerManager.Instance.Player.customizer.ChangeColor(i, new Color(1, 1, 1));
            CustomizeDataManager.Instance.characterVisual.pickerData[CustomizeDataManager.Instance.characterVisual.characterIndex].barPos[i] = Vector3.zero;
            CustomizeDataManager.Instance.characterVisual.pickerData[CustomizeDataManager.Instance.characterVisual.characterIndex].circlePos[i] = Vector3.zero;
        }

        CustomizeDataManager.Instance.Save();

        barColor.SetPickerPosition();
        circleColor.SetPickerPosition();
    }
}
