using TMPro;
using UnityEngine;

public class DialogueLinker : MonoBehaviour
{

    [SerializeField] private PlayerStateMachine stateMachine;
    private PlayerStateMachine.PlayerStates talk;
    public DialogueSO dialogueSO; // to give the right Dialogue
    public DialogueSO stopdialogueSO; // to give the right Dialogue
    private TalkableNPC talkableNPC; // pour stocker le NPC concerné et le désactiver après le dialogue

    public TMP_Text talkButtonTMP;
    public string talkButtonText;

    private void Awake()
    {
        talkableNPC = GetComponentInParent<TalkableNPC>();
    }

    public void TalkButton(TMP_Text talkButtonTMP)
    {

        talkButtonTMP = GetComponentInChildren<TMP_Text>();
        if(talkableNPC.alreadyReadDialogue == false)
        {
            talkButtonTMP.text = ">>";
            talk = PlayerStateMachine.PlayerStates.Talk;
            stateMachine.SwitchState(talk);
            DialogueManager.Instance.StartDialogue(dialogueSO, talkableNPC);
        }

        else if(talkableNPC.alreadyReadDialogue == true)
        {
            talkButtonTMP.text = ">>";
            talk = PlayerStateMachine.PlayerStates.Talk;
            stateMachine.SwitchState(talk);
            DialogueManager.Instance.StartDialogue(stopdialogueSO, talkableNPC);
        }
    }

}
