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

    //private LogicScript Logic;
        private float chatDuration = 3;
    private float chatTimer;
    private bool isChatting = false;
        private float triggerCooldown = 2;
    private float triggerTimer;
    private bool beginTriggerCooldown = false;

    void Awake()
    {
        Input = new PlayerInput();
        //Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        myRigidbody = GetComponent<Rigidbody2D>();
        spriteAnim = GetComponent<SpriteRenderer>();
        playerAnim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        MovementAnimations();
        TriggerCooldown();

        if (isChatting)
        {
            YouHaveToChat();
        } 
    }

    void FixedUpdate()
    {
        if (!isChatting)
        {
            myRigidbody.linearVelocity = movement * movementSpeed;  
        }
        else
        {
            myRigidbody.linearVelocity = Vector2.zero;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && !beginTriggerCooldown)
        {
            isChatting = true;
            beginTriggerCooldown = true;
        }
    }

    void YouHaveToChat()
    {
        chatTimer += Time.deltaTime;

        if (chatTimer <= chatDuration)
        {
            float newY = transform.position.y + Mathf.Cos(Time.time * bopSpeed) * bopHeight;
            
            transform.position = new Vector2(transform.position.x, newY);
        }
        else
        {
            chatTimer = 0;
            isChatting = false;
        }
    }

    void TriggerCooldown()
    {
        if (beginTriggerCooldown && !isChatting)
        {
            triggerTimer += Time.deltaTime;

            if (triggerTimer >= triggerCooldown)
            {
                beginTriggerCooldown = false;
                triggerTimer = 0;
            }
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

    void MovementAnimations()
    {
        playerAnim.SetFloat("MoveSpeed", myRigidbody.linearVelocity.magnitude);
        playerAnim.SetFloat("MoveX", myRigidbody.linearVelocityX);
        playerAnim.SetFloat("MoveY", myRigidbody.linearVelocityY);
    }

}
