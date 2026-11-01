using UnityEngine;

public class JournalManager : MonoBehaviour
{

    [SerializeField] private PlayerStateMachine stateMachine;
    private PlayerStateMachine.PlayerStates journal;
    private PlayerStateMachine.PlayerStates walk;
    void Awake()
    {
        journal = PlayerStateMachine.PlayerStates.Journal;
        walk = PlayerStateMachine.PlayerStates.Walk;
        gameObject.SetActive(false);
    }
    void Update()
    {
        
    }

    void PinNewClue()
    {
        stateMachine.SwitchState(journal);
    }

    public void CloseJournal()
    {
        gameObject.SetActive(false);
        stateMachine.SwitchState(walk);
    }
}
