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
        Freeze();
    }
    void Freeze()
    {
        // if (playerMovement.gameObject == true)
        playerMovement.gameObject.SetActive(false);
    }
}
