using UnityEngine;

public class JournalManager : MonoBehaviour
{

    [SerializeField] private PlayerStateMachine stateMachine;
    private PlayerStateMachine.PlayerStates journal;
    private PlayerStateMachine.PlayerStates walk;
    [SerializeField] private GameObject page1Content;
    [SerializeField] private GameObject page2Content;

    private GameObject currentpage ;
    void Awake()
    {
        journal = PlayerStateMachine.PlayerStates.Journal;
        walk = PlayerStateMachine.PlayerStates.Walk;
        gameObject.SetActive(false);
        currentpage = page1Content;
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
        TurnPage();
    }

    public void TurnPage()
    {
        if (currentpage == page1Content)
        {
            page1Content.SetActive(false);
            page2Content.SetActive(true);
            currentpage = page2Content;
        }
        else if (currentpage == page2Content)
        {
            page1Content.SetActive(true);
            page2Content.SetActive(false);
            currentpage = page1Content;
        }
    }
}
