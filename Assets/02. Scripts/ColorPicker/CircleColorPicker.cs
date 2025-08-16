using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleColorPicker : BaseColorPicker
{
    public ImageGradient imageGradient;

    private void Start()
    {
        paletteCollider = palette.GetComponent<CircleCollider2D>();

        sizeOfPalette = new Vector2(
            palette.GetComponent<RectTransform>().rect.width,
            palette.GetComponent <RectTransform>().rect.height);
    }

    protected override void SelectColor()
    {
        Vector3 offest = Input.mousePosition - transform.position;
        Vector3 diff = Vector3.ClampMagnitude(offest, paletteCollider.radius);

        picker.transform.position = transform.position + diff;

        imageGradient.colorA = GetColor();
        imageGradient.GetComponent<Graphic>().SetVerticesDirty();
    }

    protected override Color GetColor()
    {
        Vector2 circlePalettePosition = palette.transform.position;
        Vector2 pickerPosition = picker.transform.position;

        Vector2 position = pickerPosition - circlePalettePosition + sizeOfPalette * 0.5f;
        Debug.Log(position);
        Vector2 normalized = new Vector2(
            (position.x / (palette.GetComponent<RectTransform>().rect.width)),
            (position.y / (palette.GetComponent<RectTransform>().rect.height)));
        Debug.Log(normalized);

        Texture2D texture = palette.mainTexture as Texture2D;
        Color circularSelectedColor = texture.GetPixelBilinear(normalized.x, normalized.y);
        Debug.Log(circularSelectedColor);
        return circularSelectedColor;
    }
}
