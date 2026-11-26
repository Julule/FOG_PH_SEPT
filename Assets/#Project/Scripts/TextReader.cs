using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextReader : MonoBehaviour
{

    [SerializeField] List<TMP_Text> allTexts = new();
    private int i = 0;

    void Awake()
    {
        foreach (TMP_Text text in allTexts)
        {
            text.gameObject.SetActive(false);
        }
    }

    public void DisplayOneText()
    {
        if (i < allTexts.Count)
        {
            Debug.Log(i);
            Debug.Log(allTexts.Count);
            allTexts[i].gameObject.SetActive(true); // TODO : ajouter typewriter
            i++; 
        }
    }

}
