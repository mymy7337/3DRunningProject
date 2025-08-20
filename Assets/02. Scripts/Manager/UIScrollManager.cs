using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScrollManager : MonoBehaviour
{
    public void OnScroll(Vector2 normalizedPosition)
    {
        Debug.Log(normalizedPosition.y);
    }
}
