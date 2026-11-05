using UnityEngine;


public class JournalManager : MonoBehaviour
{
    public static JournalManager Instance { get; private set; }

    [SerializeField] private PlayerStateMachine stateMachine;
    private PlayerStateMachine.PlayerStates journal;
    private PlayerStateMachine.PlayerStates walk;
    [SerializeField] private GameObject page1Content;
    [SerializeField] private GameObject page2Content;
    [SerializeField] private Transform gridParent; // l'objet qui porte le GridLayoutGroup
    [SerializeField] private ClueCard cardPrefab;
    private GameObject currentpage;
    void Awake()
    {
        journal = PlayerStateMachine.PlayerStates.Journal;
        walk = PlayerStateMachine.PlayerStates.Walk;
        gameObject.SetActive(false);
        currentpage = page1Content;

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void CloseJournal()
    {
        gameObject.SetActive(false);
        stateMachine.SwitchState(walk);
    }

    public void OpenJournal()
    {
        stateMachine.SwitchState(journal);
        TurnPage();
    }

    public void TurnPage() // Afficher le contenu tantôt d'une page, tantôt de l'autre
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

    public void CreateCard(string clue)
    {
        ClueCard card = Instantiate(cardPrefab, gridParent);
        card.FillCard(clue);
    }

}
