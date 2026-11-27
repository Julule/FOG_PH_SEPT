using TMPro;
using UnityEngine;

public class Player_Talk : MonoBehaviour
{

    private PlayerMovement playerMovement;
    [SerializeField] public GameObject openJournalButton;

    public AudioSource stateSource;


    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void OnEnable()
    {
        Freeze(); 
        openJournalButton.gameObject.SetActive(false);
        stateSource.Play();
    }

    void OnDisable()
    {
        stateSource.Stop();
    }

    protected void Freeze()
    {
        playerMovement.enabled = false;
    }
}
