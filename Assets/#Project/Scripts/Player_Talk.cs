using UnityEngine;

public class Player_Talk : MonoBehaviour
{

    private PlayerMovement playerMovement;
    private Player_Journal player_Journal;


    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void OnEnable()
    {
        Freeze(); // Opti : maybe a better way would be to use OnEnable and OnDisable to activate playerMovement
        player_Journal = GetComponent<Player_Journal>();
        player_Journal.openJournalButton.SetActive(true);
    }

    protected void Freeze()
    {
        playerMovement.enabled = false;
    }
}
