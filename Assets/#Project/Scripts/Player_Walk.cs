using UnityEngine;

public class Player_Walk : MonoBehaviour
{
    
    private PlayerMovement playerMovement;
    private Player_Talk player_Talk;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void OnEnable()
    {
        UnFreeze();
        player_Talk = GetComponent<Player_Journal>();
        player_Talk.openJournalButton.SetActive(true);
    }
    void UnFreeze()
    {
        playerMovement.enabled = true;
    }
}
