using UnityEngine;

public class Player_Walk : MonoBehaviour
{
    
    private PlayerMovement playerMovement;
    private Player_Talk player_Talk;

    [SerializeField] AudioSource stateSource;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void OnEnable()
    {
        UnFreeze();
        player_Talk = GetComponent<Player_Journal>();
        player_Talk.openJournalButton.SetActive(true);
        stateSource.Play();
    }

    void OnDisable()
    {
        stateSource.Stop();
    }
    void UnFreeze()
    {
        playerMovement.enabled = true;
    }
}
