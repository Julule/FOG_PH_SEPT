using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private InputActionAsset inputActions;
    private const string ACTION_MAPADELE = "Adele";
    private const string ACTION_MOVE = "Move";
    private const string ACTION_MAPCAMERA = "Camera";
    private const string ACTION_LOOK = "Look";
    private InputAction moveAction;
    protected InputAction cameraRotation;
    public float walkSpeed = 1.0f; // pourquoi pas double : c'est 2fois l'espace mem. ! f pour éviter qu'il trans en double par défaut
    public float turnSpeed = 1.0f;
    Rigidbody playerRigidbody; // déclaration d'un variable de type Rigidbody (private par defaut)
    Animator animator;
    bool IsWalking;
    protected float verticalRotate;
    protected float lateralRotate;
    [SerializeField] protected int cameraSpeed = 100;

    void Awake()
    {
        moveAction = inputActions.FindActionMap(ACTION_MAPADELE).FindAction(ACTION_MOVE);
        cameraRotation = inputActions.FindActionMap(ACTION_MAPCAMERA).FindAction(ACTION_LOOK);
    
    }

    void Start()
    {   
        playerRigidbody = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
    }

    void OnEnable()
    {
        inputActions.FindActionMap(ACTION_MAPADELE).Enable();
        inputActions.FindActionMap(ACTION_MAPCAMERA).Enable();
    }

    void OnDisable()
    {
        inputActions.FindActionMap(ACTION_MAPADELE).Disable();
        inputActions.FindActionMap(ACTION_MAPCAMERA).Disable();
    }


    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 moveAmount = moveAction.ReadValue<Vector2>(); // recupérer l'entrée keyboard moveAmount
        Vector3 move = (transform.right * moveAmount.x + transform.forward * moveAmount.y) * walkSpeed * Time.deltaTime;
        transform.position += move;

        // ici on modifie juste la direction vers droite et gauche du player, dont caméra hérite
        Vector2 rotateAmount = cameraRotation.ReadValue<Vector2>();
        // rotate = Mathf.Clamp(rotate - rotateAmount.y * cameraSpeed * Time.deltaTime, -89f, 89f);
        lateralRotate = lateralRotate - rotateAmount.x * cameraSpeed * Time.deltaTime;
        transform.localRotation = Quaternion.Euler(0f, lateralRotate, 0f); // On utilise Euler pour multiplier rotate
    }
}
