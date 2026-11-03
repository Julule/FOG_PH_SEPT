using UnityEngine;
using TMPro;

public class ClueCard : MonoBehaviour
{
    [SerializeField] private TMP_Text clueText;
    public void FillCard(string clue)
    {
        //clueText.text = data.cardName;
        clueText.text = clue;
    }
}
