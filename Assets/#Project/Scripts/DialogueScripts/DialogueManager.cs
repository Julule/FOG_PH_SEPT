using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager Instance; // dispo pour les states

    [Header("UI References")]
    public Image portrait;
    public TMP_Text actorName;
    public TMP_Text dialogueText;
    public bool activeDialogue;

    private DialogueSO currentDialogue;
    private int dialogueIndex = 0;

    [SerializeField] private PlayerStateMachine stateMachine;
    private PlayerStateMachine.PlayerStates walk;

    private void Awake() // check wether Instance already exists at awake / or destroy.
    {
        gameObject.SetActive(false); // désactiver le dialogueCanvas
        if (Instance == null)
            Instance = this; // Instance variable contains this one
        else 
            Destroy(gameObject); // pour supprimer s'il n'y a pas d'instance
    }

    public void StartDialogue(DialogueSO dialogueSO)
    {
        currentDialogue = dialogueSO;
        //dialogueIndex = 0;
        activeDialogue = true;
        ShowDialogue();
    }
    private void ShowDialogue() // cette méthode est appelée pour chaque ligne du dialogueSO que StartDialogue vient de passer en paramêtre.
    {
        if(dialogueIndex < currentDialogue.lines.Length) // vérifier si notre ligne actuelle est la dernière du dialogue
        {
            Debug.Log($"ligne{dialogueIndex} sur {currentDialogue.lines.Length}");
            gameObject.SetActive(true); // activer le dialogueCanvas
            DialogueLine line = currentDialogue.lines[dialogueIndex];
            portrait.sprite = line.speaker.portrait;
            actorName.text = line.speaker.actorName;
            dialogueText.text = line.text;
            dialogueIndex++;
            Debug.Log($"ligne{dialogueIndex} sur {currentDialogue.lines.Length}");
        }
        else
        {
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        dialogueIndex = 0;
        activeDialogue = false;
        gameObject.SetActive(false); // désactiver le dialogueCanvas
        walk = PlayerStateMachine.PlayerStates.Walk; // Je stocke l'état "Walk" de la States enum dans walk.
        stateMachine.SwitchState(walk);
    }
}
