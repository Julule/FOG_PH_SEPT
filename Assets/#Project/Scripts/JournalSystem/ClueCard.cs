using UnityEngine;
using TMPro;

public class ClueCard : MonoBehaviour
{
    private TMP_Text clueText;

    public void FillCard(string clue)
    {
        clueText = GetComponentInChildren<TMP_Text>();
        clueText.text = clue;
    }
}
