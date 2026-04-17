using UnityEngine;

public class EnemyAiScript : MonoBehaviour
{
    public Transform player;
    public float detectRange = 8f;
    public LayerMask obstacleLayer;
    public LayerMask playerLayer;
    public float moveSpeed = 3f;
    private LogicScript Logic;

    private Rigidbody2D myRigidbody;
    private Vector2 movement;
    private bool canSeePlayer;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    void Update()
    {
        Detection();

        
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

    void FixedUpdate()
    {
        if (canSeePlayer)
        {
            myRigidbody.MovePosition(myRigidbody.position + movement * moveSpeed * Time.fixedDeltaTime);
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