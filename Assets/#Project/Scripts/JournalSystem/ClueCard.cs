using UnityEngine;
using TMPro;

public class ClueCard : MonoBehaviour
{
    private TMP_Text clueText;


    public void FillCard(string clue)
    {
        //clueText.text = data.cardName;

        clueText = GetComponentInChildren<TMP_Text>();
        clueText.text = clue;

        //Debug.Log($"clue à afficher : {clueText.text}");
    }
}
