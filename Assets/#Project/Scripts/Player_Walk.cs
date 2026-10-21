using UnityEngine;

public class Player_Walk : MonoBehaviour
{
    
    private PlayerMovement playerMovement;

    void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    void Update()
    {
        UnFreeze();
    }
    void UnFreeze()
    {
        // if (playerMovement.gameObject == false)
        playerMovement.gameObject.SetActive(true);
    }
}
