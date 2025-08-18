using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    public void ResetColor()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerManager.Instance.Player.customizer.ChangeColor(i, new Color(1, 1, 1));
        }
    }
}
