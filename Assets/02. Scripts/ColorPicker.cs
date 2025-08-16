using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorPicker : MonoBehaviour
{
    public ImageGradient imageGradient;

    public Image circlePalete;
    public Image picker;
    public Color selectedColor;

    private Vector2 sizeOfPalette;
    private CircleCollider2D paletteCollider;

    private void Start()
    {
        paletteCollider = circlePalete.GetComponent<CircleCollider2D>();

        sizeOfPalette = new Vector2(
            circlePalete.GetComponent<RectTransform>().rect.width,
            circlePalete.GetComponent <RectTransform>().rect.height);
    }

    private void selectColor()
    {
        Vector3 offest = Input.mousePosition - transform.position;
        Vector3 diff = Vector3.ClampMagnitude(offest, paletteCollider.radius);

        picker.transform.position = transform.position + diff;

        imageGradient.colorA = GetColor();
        imageGradient.GetComponent<Graphic>().SetVerticesDirty();
    }

    public void MousePointerDown()
    {
        selectColor();
    }

    public void MouseDrag()
    {
        selectColor();
    }

    private Color GetColor()
    {
        Vector2 circlePalettePosition = circlePalete.transform.position;
        Vector2 pickerPosition = picker.transform.position;

        Vector2 position = pickerPosition - circlePalettePosition + sizeOfPalette * 0.5f;
        Vector2 normalized = new Vector2(
            (position.x / (circlePalete.GetComponent<RectTransform>().rect.width)),
            (position.y / (circlePalete.GetComponent<RectTransform>().rect.height)));

        Texture2D texture = circlePalete.mainTexture as Texture2D;
        Color circularSelectedColor = texture.GetPixelBilinear(normalized.x, normalized.y);

        return circularSelectedColor;
    }
}
