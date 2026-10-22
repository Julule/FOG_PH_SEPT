using UnityEngine;

public class Player_Talk : MonoBehaviour
{

    private PlayerMovement playerMovement;


    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

    }
    void Update()
    {
        Freeze(); // Opti : maybe a better way would be to use OnEnable and OnDisable to activate playerMovement
        // button.onClick.AddListener(() => DialogueManager.Instance.StartDialogue(dialogueSO));
    }


    void Freeze()
    {
        // if (playerMovement.gameObject == true)
        playerMovement.gameObject.SetActive(false);
    }
}
