using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    private const string ACTION_MAP = "Adele";
    private const string ACTION_MOVE = "Move";
    InputAction moveAction;
    public float walkSpeed = 1.0f; // pourquoi pas double : c'est 2fois l'espace mem. ! f pour éviter qu'il trans en double par défaut

    Rigidbody playerRigidbody; // déclaration d'un variable de type Rigidbody (private par defaut)
    Animator animator;
    bool IsWalking;
    void Awake(){
        moveAction = inputActions.FindActionMap(ACTION_MAP).FindAction(ACTION_MOVE);
    }

    void Start()
    {   
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void OnEnable()
    {
        inputActions.FindActionMap(ACTION_MAP).Enable();
    }

    void OnDisable()
    {
        inputActions.FindActionMap(ACTION_MAP).Enable();
    }

    // void FixedUpdate() // Update qui va à la même vitesse tout le temps
    // {
    //     Vector2 direction = moveAction.ReadValue<Vector2>(); // renvoie un vecteur2 (2d)
    //     // if(direction != Vector2.zero)
    //     // {
    //     //     animator.SetBool("IsWalking", true);
    //     // }
    //     // else
    //     // {
    //     //     animator.SetBool("IsWalking", false);
    //     // }
    //     float horizontal = direction.x;
    //     float vertical = direction.y;

    //     Vector3 movement = new(horizontal, 0f, vertical);
    //     movement.Normalize();

    //     Vector3 desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.fixedDeltaTime, 0f);

    //     Quaternion rotation = Quaternion.LookRotation(desiredForward);

    //     playerRigidbody.MoveRotation(rotation);

    //     playerRigidbody.MovePosition(playerRigidbody.position + movement * walkSpeed * Time.fixedDeltaTime); // on calcule le déplacement vie l'opération : positionactuelle + movement*rapidité*temps

    // }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveAmount = moveAction.ReadValue<Vector3>(); // recupérer l'entrée keyboard  moveAmount
        Debug.Log($"moveAmount {moveAmount}");
        Vector3 move = moveAmount * walkSpeed * Time.deltaTime;
        transform.position += move;
        //Vector3 move = new Vector3(moveAmount.x,0f,moveAmount.y) * walkSpeed * Time.deltaTime;
    }
}
