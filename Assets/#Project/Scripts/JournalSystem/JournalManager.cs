using System.Collections.Generic;
using UnityEngine;


public class JournalManager : MonoBehaviour
{
    public static JournalManager Instance { get; private set; }

    [SerializeField] private PlayerStateMachine stateMachine;
    private PlayerStateMachine.PlayerStates journal;
    private PlayerStateMachine.PlayerStates walk;
    private PlayerStateMachine.PlayerStates accusation;
    [SerializeField] private GameObject page1Content;
    [SerializeField] private GameObject page2Content;
    //[SerializeField] private GameObject closeButton;
    public AudioSource uiAudio;
    public AudioClip closeClip;
    List<GameObject> journalPages = new();
    [SerializeField] private Transform gridParent; // l'objet qui porte le GridLayoutGroup
    [SerializeField] private ClueCard cardPrefab;
    private GameObject currentpage;
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        journalPages.Add(page1Content);
        journalPages.Add(page2Content);

        journal = PlayerStateMachine.PlayerStates.Journal;
        walk = PlayerStateMachine.PlayerStates.Walk;
        accusation = PlayerStateMachine.PlayerStates.Accusation;

        gameObject.SetActive(false);
        //currentpage = page1Content;
        foreach(GameObject page in journalPages)
        {
            page.SetActive(false);
        }
    }
    public void OpenJournal(GameObject targetPage) // méthode propre au manager, le state en comporte une autre.
    {
        stateMachine.SwitchState(journal);
        foreach (GameObject page in journalPages)
        {
            if (page == targetPage){
                page.SetActive(true);
                currentpage = page;
            }
            else
            {
                page.SetActive(false);
            }
        }
    }

    public void CloseJournal()
    {
        uiAudio.PlayOneShot(closeClip);
        gameObject.SetActive(false);
        stateMachine.SwitchState(walk);
    }


    public void TurnPage() // Afficher le contenu tantôt d'une page, tantôt de l'autre
    {
        if (currentpage == page1Content) // vers page2
        {
            page1Content.SetActive(false);
            page2Content.SetActive(true);
            currentpage = page2Content;
        }
        else if (currentpage == page2Content) // vers page1
        {
            page1Content.SetActive(true);
            page2Content.SetActive(false);
            currentpage = page1Content;
        }
    }

    public void CreateCard(string clue)
    {
        Debug.Log($"CreateCard : {clue}");
        string thisclue = clue;
        ClueCard card = Instantiate(cardPrefab, gridParent);
        card.FillCard(thisclue);
    }

    public void AccusationTrigger()
    {
        stateMachine.SwitchState(accusation);
    }

}
