using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEditor.XR;
using System.Runtime.InteropServices;
using System.Xml.Linq;
// using Unity.Android.Gradle;
using System.Runtime.ExceptionServices;
using UnityEngine.PlayerLoop;
using JetBrains.Annotations;

public class DialogueManager : MonoBehaviour
{

    public static DialogueManager Instance; // dispo pour les states

    [Header("UI References")]
    public Image portrait;
    public TMP_Text actorName;
    public TMP_Text dialogueText;
    public bool activeDialogue;

    private DialogueSO currentDialogue;
    public Button[] choiceButtons;
    private int dialogueIndex = 0;

    [SerializeField] private PlayerStateMachine stateMachine;
    private PlayerStateMachine.PlayerStates walk;
    private TalkableNPC currentNPC;

    private void Awake() // check wether Instance already exists at awake / or destroy.
    {
        gameObject.SetActive(false); // désactiver le dialogueCanvas
        if (Instance == null)
            Instance = this; // Instance variable contains this one
        else 
            Destroy(gameObject); // pour supprimer s'il n'y a pas d'instance

        foreach(Button button in choiceButtons)
        {
            button.gameObject.SetActive(false); // hide buttons at first
        }
    }


    public void StartDialogue(DialogueSO dialogueSO, TalkableNPC npc)
    {
        currentNPC = npc;
        currentDialogue = dialogueSO;
        activeDialogue = true;
        ShowDialogue();
    }

    private void ShowDialogue() // cette méthode est appelée pour chaque ligne du dialogueSO que StartDialogue vient de passer en paramêtre.
    {
        if(dialogueIndex < currentDialogue.lines.Length) // vérifier s'il reste une ligne à afficher avant les options
        {
            gameObject.SetActive(true); // activer le dialogueCanvas (c'est déjà fait au deuxième passage)
            DialogueLine line = currentDialogue.lines[dialogueIndex];
            portrait.sprite = line.speaker.portrait; 
            actorName.text = line.speaker.actorName;
            dialogueText.text = line.text;
            dialogueIndex++;
        }
        else
        {
            ShowChoices();
        }
    }

    private void ShowChoices()
    {
        if(currentDialogue.options.Length > 0) // si y'a des options ?
        {
            Debug.Log($"nb d'options de ce dial : {currentDialogue.options.Length}");
            for (int i = 0; i < currentDialogue.options.Length; i++) // Pour chaque options, la right et la false 
            {
                DialogueOption thisOption = currentDialogue.options[i]; // stocker l'option en question (type, ligne, nextdialogue, clue)
                string optionClue = thisOption.clue;
                choiceButtons[i].GetComponentInChildren<TMP_Text>().text = thisOption.optionText;
                choiceButtons[i].gameObject.SetActive(true);
                choiceButtons[i].onClick.RemoveAllListeners();
                choiceButtons[i].onClick.AddListener(() => ChooseOption(thisOption.nextDialogue, optionClue));
            }
        }
        else // il n'y a pas d'options. 
        {
            //Rien 
        }
    }

    private void ChooseOption(DialogueSO followUpDialogue, string optionClue)
    {
        if(followUpDialogue == null) // il n'y a pas de dialogueSO dans cette option de dialogue
        {
            // TO DO : Nothing
        }
        else
        {
            string clueForCard = optionClue;
            InitializeDialogue();
            StartDialogue(followUpDialogue, currentNPC);
            //Debug.Log("Il n'y a pas/plus d'options à ce dialogue..");
            if (currentNPC.alreadyReadDialogue == false)
            {
                choiceButtons[0].GetComponentInChildren<TMP_Text>().text = "Fermer le dialogue";
                choiceButtons[0].gameObject.SetActive(true);
                choiceButtons[1].gameObject.SetActive(false);
                choiceButtons[0].onClick.RemoveAllListeners();
                choiceButtons[0].onClick.AddListener(() => EndDialogue(clueForCard));
            }
        }
        
    }

    private void InitializeDialogue()
    {
        dialogueIndex = 0;
    }

    private void EndDialogue(string clueForCard)
    {
        choiceButtons[0].gameObject.SetActive(false);
        dialogueIndex = 0;
        activeDialogue = false;
        gameObject.SetActive(false); // désactiver le dialogueCanvas
        walk = PlayerStateMachine.PlayerStates.Walk; // Je stocke l'état "Walk" de la States enum dans walk.
        stateMachine.SwitchState(walk);
        if (currentNPC.alreadyReadDialogue == false)
            JournalManager.Instance.CreateCard(clueForCard);
        currentNPC.alreadyReadDialogue = true;
    }
}
