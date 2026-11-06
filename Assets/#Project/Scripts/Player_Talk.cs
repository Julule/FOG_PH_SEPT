using UnityEngine;

public class Player_Talk : MonoBehaviour
{

    private PlayerMovement playerMovement;
    [SerializeField] public GameObject openJournalButton;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void OnEnable()
    {
        Freeze(); 
        openJournalButton.gameObject.SetActive(false);
    }

    protected void Freeze()
    {
        playerMovement.enabled = false;
    }
}
