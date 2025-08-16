using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseColorPicker : MonoBehaviour
{
    public Image palette;
    public Image picker;
    public Color selectedColor;

    protected Vector2 sizeOfPalette;
    protected CircleCollider2D paletteCollider;

    protected virtual void SelectColor()
    {

    }

    public void MousePointerDown()
    {
        SelectColor();
    }

    public void MouseDrag()
    {
        SelectColor();
    }

    protected abstract Color GetColor();
}
