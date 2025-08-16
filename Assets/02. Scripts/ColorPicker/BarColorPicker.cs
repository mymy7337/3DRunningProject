using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarColorPicker : BaseColorPicker
{
    public Image image;

    private void Start()
    {
        sizeOfPalette = new Vector2(palette.GetComponent<RectTransform>().rect.width, 0);
    }
    protected override void SelectColor()
    {
        Vector3 offest = Input.mousePosition - transform.position;
        Vector3 diff = new Vector3(Mathf.Clamp(offest.x, -499, 499), 0);

        picker.transform.position = transform.position + diff;

        image.color = GetColor();
        //PlayerManager.Instance.Player.customizer.ChangeColor(0, GetColor());
    }

    protected override Color GetColor()
    {
        Vector2 palettePosition = palette.transform.position;
        Vector2 pickerPosition = picker.transform.position;

        Vector2 position = pickerPosition - palettePosition + sizeOfPalette * 0.5f;
        Vector2 normalized = new Vector2(
            (position.x / (palette.GetComponent<RectTransform>().rect.width)), 0);
        Debug.Log(position);
        Debug.Log(normalized);

        var grad = palette.GetComponent<ImageGradient>();
        if (grad != null)
            return Color.Lerp(grad.colorB, grad.colorA, normalized.x);

        return Color.white;
    }
}
