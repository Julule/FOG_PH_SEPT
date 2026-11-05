using UnityEngine;

public class Player_Walk : MonoBehaviour
{
    
    private PlayerMovement playerMovement;
    private Player_Journal player_Journal;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void OnEnable()
    {
        UnFreeze();
        player_Journal = GetComponent<Player_Journal>();
        player_Journal.openJournalButton.SetActive(true);
    }
    void UnFreeze()
    {
        playerMovement.enabled = true;
    }
}
