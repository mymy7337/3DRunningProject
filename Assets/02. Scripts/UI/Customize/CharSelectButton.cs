using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelectButton : MonoBehaviour
{
    public int characterIndex;

    public void selectCharacter()
    {
        CustomizeDataManager.Instance.characterVisual.characterIndex = characterIndex;
        PlayerManager.Instance.Player.customizer.ChangerCharacter(characterIndex);
    }
}
