using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnrockSet : MonoBehaviour
{
    public GameObject[] ui;
    private void Start()
    {
        CustomizeDataManager.Instance.Load();
        Unrock();
    }
    public void Unrock()
    {
        for (int i = 0; i < CustomizeDataManager.Instance.characterVisual.characterData.Length; i++)
        {
            if (CustomizeDataManager.Instance.characterVisual.characterData[i].isAqcuire)
            {
                ui[i].SetActive(false);
            }
        }
    }
}
