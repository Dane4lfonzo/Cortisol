using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    private PlayerInput Input;
    private Vector2 movement;
    [SerializeField] float movementSpeed;
    private Rigidbody2D myRigidbody;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Input = new PlayerInput();
        myRigidbody = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        myRigidbody.linearVelocity = movement * movementSpeed;
    }

    void OnEnable()
    {
        Input.Enable();

        Input.Gameplay.Movement.performed += OnMovement;
        Input.Gameplay.Movement.canceled += OnMovement;
    }

    void OnDisable()
    {
        Input.Disable();
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
