using UnityEngine;

public class Player_Talk : MonoBehaviour
{

    private PlayerMovement playerMovement;

    public DialogueSO dialogueSO;
    
    

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();

    }
    void Update()
    {
        Freeze(); // Opti : maybe a better way would be to use OnEnable and OnDisable to activate playerMovement

        if(Input.GetButtonDown("Inbteract"))
        {
            if (DialogueSO.Instance)
            {
                
            }
        }
    
    }
    void Freeze()
    {
        // if (playerMovement.gameObject == true)
        playerMovement.gameObject.SetActive(false);
    }
}
