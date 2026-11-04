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
    public float turnSpeed = 1.0f;
    Rigidbody playerRigidbody; // déclaration d'un variable de type Rigidbody (private par defaut)
    Animator animator;
    bool IsWalking;
    void Awake()
    {
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


    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 moveAmount = moveAction.ReadValue<Vector3>(); // recupérer l'entrée keyboard moveAmount
        Vector3 move = moveAmount * walkSpeed * Time.deltaTime;

        if (moveAmount.magnitude > 0.1f)
        {
            transform.position += move;
            Quaternion targetRotation = Quaternion.LookRotation(moveAmount);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            
        }
    }
}
