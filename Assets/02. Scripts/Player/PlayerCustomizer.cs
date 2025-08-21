using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class PlayerCustomizer : MonoBehaviour
{
    public GameObject[] characters;

    public Materials materials;

    private GameObject character;

    public ClothesUIManager clothesUIManager;

    private void Awake()
    {
        CustomizeDataManager.Instance.Load();

        character = Instantiate(characters[CustomizeDataManager.Instance.characterVisual.characterIndex], this.transform);
        materials = character.GetComponent<Materials>();
        SetColor();
    }

    public void ChangerCharacter(int characterIndex)
    {
        if (CustomizeDataManager.Instance.characterVisual.characterData[characterIndex].isAqcuire)
        {
            clothesUIManager.archer.SetActive(false);
            clothesUIManager.knight.SetActive(false);
            clothesUIManager.merchant.SetActive(false);
            clothesUIManager.ninja.SetActive(false);
            clothesUIManager.student.SetActive(false);
            clothesUIManager.isOpen = false;
            Destroy(character);
            character = Instantiate(characters[characterIndex], this.transform);
            materials = character.GetComponent<Materials>();
            PlayerManager.Instance.Player.animationController.ResetAnimator(character.GetComponentInChildren<Animator>());
            CustomizeDataManager.Instance.characterVisual.characterIndex = characterIndex;
            CustomizeDataManager.Instance.Save();
            SetColor();
        }
    }

    private void SetColor()
    {
        for(int i = 0; i < materials.renderers.Length; i++)
        {
            CustomizeDataManager.Instance.Load();
            materials.renderers[i].material.SetColor("_Color", CustomizeDataManager.Instance.characterVisual.characterData[CustomizeDataManager.Instance.characterVisual.characterIndex].colors[i]);
        }
    }

    public void ChangeColor(int idx, Color albedo)
    {
        Material material = materials.renderers[idx].material;

        material.SetColor("_Color", albedo);

        CustomizeDataManager.Instance.characterVisual.characterData[CustomizeDataManager.Instance.characterVisual.characterIndex].colors[idx] = albedo;
        CustomizeDataManager.Instance.Save();
    }
}