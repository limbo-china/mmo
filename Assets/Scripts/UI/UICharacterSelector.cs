using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSelector : MonoBehaviour
{

    public Button[] buttonChars;
    public GameObject[] characters;

    int currentCharIndex = 0;

    void Start()
    {
        this.Init();   
    }
    void OnClickButtonChars(int index)
    {
        currentCharIndex = index;

        this.UpdatePreview();
    } 

    void Init()
    {
        UpdatePreview();
        for (int i =0; i<buttonChars.Length; i++)
        {
            int t = i;
            buttonChars[i].onClick.AddListener(() => OnClickButtonChars(t));
        }
    }
    void UpdatePreview()
    {
        for (int i = 0; i < characters.Length; i++)
        {
            if( i == currentCharIndex)
            {
                characters[i].SetActive(true);
            }
            else
            {
                characters[i].SetActive(false);
            }
        }
    }
    

}
