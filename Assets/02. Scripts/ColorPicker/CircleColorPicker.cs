using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CircleColorPicker : BaseColorPicker
{
    public ImageGradient imageGradient;

    [SerializeField] private BarColorPicker barColorPicker;

    private void Start()
    {
        sizeOfPalette = new Vector2(
            palette.GetComponent<RectTransform>().rect.width,
            palette.GetComponent <RectTransform>().rect.height);
    }

    protected override void SelectColor()
    {
        Vector3 offest = Input.mousePosition - transform.position;
        Vector3 diff = Vector3.ClampMagnitude(offest, 165);

        picker.transform.position = transform.position + diff;

        imageGradient.colorA = GetColor();
        imageGradient.GetComponent<Graphic>().SetVerticesDirty();

        CustomizeDataManager.Instance.characterVisual.pickerData[CustomizeDataManager.Instance.characterVisual.characterIndex].circlePos[CustomizeDataManager.Instance.characterVisual.pickerData[CustomizeDataManager.Instance.characterVisual.characterIndex].index] = picker.transform.localPosition;
        CustomizeDataManager.Instance.Save();

        barColorPicker.RefreshApply();
    }

    protected override Color GetColor()
    {
        Vector2 circlePalettePosition = palette.transform.position;
        Vector2 pickerPosition = picker.transform.position;

        Vector2 position = pickerPosition - circlePalettePosition + sizeOfPalette * 0.5f;

        Vector2 normalized = new Vector2(
            (position.x / (palette.GetComponent<RectTransform>().rect.width)),
            (position.y / (palette.GetComponent<RectTransform>().rect.height)));

        Texture2D texture = palette.mainTexture as Texture2D;
        Color circularSelectedColor = texture.GetPixelBilinear(normalized.x, normalized.y);

        return circularSelectedColor;
    }

    public override void SetPickerPosition()
    {
        CustomizeDataManager.Instance.Load();
        picker.transform.localPosition = CustomizeDataManager.Instance.characterVisual.pickerData[CustomizeDataManager.Instance.characterVisual.characterIndex].circlePos[CustomizeDataManager.Instance.characterVisual.pickerData[CustomizeDataManager.Instance.characterVisual.characterIndex].index];
    }
}
