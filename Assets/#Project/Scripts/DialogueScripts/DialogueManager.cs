using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager Instance;

    [Header("UI References")]
    public Image portrait;
    public TMP_Text actorName;
    public TMP_Text dialogueText;
    public bool activeDialogue;

    private DialogueSO currentDialogue;
    private int dialogueIndex;

    private void Awake() // check wether Instance already exists at awake / or destroy.
    {
        if (Instance == null)
            Instance = this; // Instance variable contains this one, s it's availabke to the Player_Talk state
        else 
            Destroy(gameObject);
    }

    private void Start()
    {
    }

    public void StartDialogue(DialogueSO dialogueSO)
    {
        currentDialogue = dialogueSO;
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
