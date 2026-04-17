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
    [SerializeField] float bopSpeed = 20;
    [SerializeField] float bopHeight = 0.003f;

    private LogicScript Logic;
    [SerializeField] float talkHopInterval;
    [SerializeField] float talkDuration;
    private float talkTimer;

    void Awake()
    {
        Input = new PlayerInput();
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myRigidbody = GetComponent<Rigidbody2D>();
        spriteAnim = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        MovementAnimations();
        FlipAnim();

        if (Logic.GetSocialColleague())
        {
            YouHaveToChat();
        }  
    }

    void FixedUpdate()
    {
        if (!Logic.GetSocialColleague())
        {
            myRigidbody.linearVelocity = movement * movementSpeed;  
        }
        else
        {
            myRigidbody.linearVelocity = Vector2.zero;
        }
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

    void YouHaveToChat()
    {
        float newY = transform.position.y + Mathf.Cos(Time.time * bopSpeed) * bopHeight;
        
         transform.position = new Vector2(transform.position.x, newY);
    }

}
