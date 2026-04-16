using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementScript : MonoBehaviour
{
    private PlayerInput Input;
    private Vector2 movement;
    [SerializeField] float movementSpeed;
    private Rigidbody2D myRigidbody;
    private SpriteRenderer spriteAnim;
    private Animator playerAnim;

    private bool doTest = false;
    private float subtractValue;

    void Awake()
    {
        Input = new PlayerInput();
        myRigidbody = GetComponent<Rigidbody2D>();
        spriteAnim = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovementAnimations();
        FlipAnim();

        TestMovementChallenge();
    }

    void FixedUpdate()
    {
        myRigidbody.linearVelocity = movement * (movementSpeed + subtractValue);
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

    void FlipAnim()
    {
        if (movement.x > 0)
        {
            spriteAnim.flipX = false;
        }
        else if (movement.y > 0 && movement.x == 0)
        {
            spriteAnim.flipX = false;
        }
        else if (movement.y < 0 && movement.x == 0)
        {
            spriteAnim.flipX = false;
        }
        else if (movement.x < 0)
        {
            spriteAnim.flipX = true;
        }
    }

    void MovementAnimations()
    {
        playerAnim.SetFloat("MoveSpeed", myRigidbody.linearVelocity.magnitude);
        playerAnim.SetFloat("MoveX", myRigidbody.linearVelocityX);
        playerAnim.SetFloat("MoveY", myRigidbody.linearVelocityY);
    }

    void TestMovementChallenge()
    {
        if (Keyboard.current.jKey.wasReleasedThisFrame && !doTest)
        {
            doTest = true;
        }

        else if (Keyboard.current.jKey.wasReleasedThisFrame && doTest)
        {
            doTest = false;
        }

        if (doTest)
        {
            subtractValue = -2;
        }
        else
        {
            subtractValue = 0;
        }


    }
}
