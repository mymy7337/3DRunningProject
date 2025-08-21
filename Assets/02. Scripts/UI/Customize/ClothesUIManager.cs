using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class ClothesUIManager : MonoBehaviour
{
    public GameObject archer;
    public GameObject knight;
    public GameObject merchant;
    public GameObject ninja;
    public GameObject student;


    public bool isOpen;
    public void ControllUI()
    {
        isOpen = !isOpen;
        switch(CustomizeDataManager.Instance.characterVisual.characterIndex)
        {
            case 0:
                archer.SetActive(isOpen);
                break;
            case 1:
                knight.SetActive(isOpen);
                break;
            case 2:
                merchant.SetActive(isOpen);
                break;
            case 3:
                ninja.SetActive(isOpen);
                break;
            case 4:
                student.SetActive(isOpen);
                break;
        }
    }
}
