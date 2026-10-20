using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [Header("UI References")]
    public Image portrait;
    public TMP_Text actorName;
    public TMP_Text dialogueText;

    public DialogueSO currentDialogue;
    private int dialogueIndex;

    private void Start()
    {
        ShowDialogue();
    }
    private void ShowDialogue()
    {
        DialogueLine line = currentDialogue.lines[dialogueIndex];

        portrait.sprite = line.speaker.portrait;
        actorName.text = line.speaker.actorName;

        dialogueText.text = line.text;

        dialogueIndex++;
    }

}
