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

    public void CloseJournal()
    {
        gameObject.SetActive(false);
        stateMachine.SwitchState(walk);
    }

    public void OpenJournal()
    {
        gameObject.SetActive(true);
        stateMachine.SwitchState(journal);
    }
}
