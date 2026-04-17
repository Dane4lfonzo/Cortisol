using UnityEngine;

public class EnemyAiScript : MonoBehaviour
{
    private GameObject PlayerObject;
    public Transform player;
    public float detectRange = 8f;
    public LayerMask obstacleLayer;
    public LayerMask playerLayer;
    public float moveSpeed = 3f;
    //private LogicScript Logic;
    private Rigidbody2D myRigidbody;
    private Vector2 movement;
    private bool canSeePlayer;

    private float triggerCooldown = 2;
    private float triggerTimer;
    private bool beginTriggerCooldown = false;
    [SerializeField] float bopSpeed = 20;
    [SerializeField] float bopHeight = 0.003f;
    private float chatDuration = 3;
    private float chatTimer;
    private bool isChatting = false;
    private int enemyCollisionLayer;


    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        //Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        PlayerObject = GameObject.Find("Player");
        player = PlayerObject.transform;
    }

    void Update()
    {
        Detection();
        TriggerCooldown();

        if (isChatting)
        {
            YouHaveToChat();
        }
    }

    void FixedUpdate()
    {
        if (canSeePlayer && !isChatting)
        {
            myRigidbody.MovePosition(myRigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3 && !beginTriggerCooldown)
        {
            isChatting = true;
            beginTriggerCooldown = true;
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

    void YouHaveToChat()
    {
        chatTimer += Time.deltaTime;

        if (chatTimer <= chatDuration)
        {
            float newY = transform.position.y - Mathf.Cos(Time.time * bopSpeed) * bopHeight;
            
            transform.position = new Vector2(transform.position.x, newY);
        }
        else
        {
            chatTimer = 0;
            isChatting = false;
        }
    }

    void Detection()
    {
        if (player == null)
        {
            movement = Vector2.zero;
            canSeePlayer = false;
            return;
        }

        Vector2 enemyPos = transform.position;
        Vector2 playerPos = player.position;

        float distanceToPlayer = Vector2.Distance(enemyPos, playerPos);

        if (distanceToPlayer <= detectRange)
        {
            Vector2 direction = (playerPos - enemyPos).normalized;

            RaycastHit2D hit = Physics2D.Raycast(
                enemyPos,
                direction,
                distanceToPlayer,
                obstacleLayer | playerLayer
            );

            if (hit.collider != null && ((1 << hit.collider.gameObject.layer) & playerLayer) != 0)
            {
                canSeePlayer = true;
                movement = direction;
            }
            else
            {
                canSeePlayer = false;
                movement = Vector2.zero;
            }
        }
        else
        {
            canSeePlayer = false;
            movement = Vector2.zero;
        }   
    }



    void OnDrawGizmosSelected()
    {
        if (player == null) return;
        Gizmos.color = canSeePlayer ? Color.green : Color.red;
        Gizmos.DrawLine(transform.position, player.position);
        Gizmos.DrawWireSphere(transform.position, detectRange);
    }
}