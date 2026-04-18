using UnityEngine;

public class PlayerRageTarget : MonoBehaviour
{
    [Header("Rage Mode")]
    public bool rageModeActive = false;

    [Header("Detection")]
    public float detectionRadius = 5f;     // change if needed
    public LayerMask workerLayer;          // set this to worker/enemy layer

    [Header("Rage Pull")]
    public float ragePullStrength = 2f;    // bigger = stronger pull
    public Transform currentTarget;        // shows nearest worker

    void Update()
    {
        if (!rageModeActive)
        {
            currentTarget = null;
            return;
        }

        FindNearestWorker();
        PullTowardsTarget();
    }

    void FindNearestWorker()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius, workerLayer);

        float closestDistance = Mathf.Infinity;
        Transform nearest = null;

        foreach (Collider2D hit in hits)
        {
            float distance = Vector2.Distance(transform.position, hit.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearest = hit.transform;
            }
        }

        currentTarget = nearest;

        if (currentTarget != null)
        {
            Debug.Log("Target found: " + currentTarget.name);
        }
    }

    void PullTowardsTarget()
    {
        if (currentTarget == null) return;

        // direction from player to nearest worker
        Vector2 direction = (currentTarget.position - transform.position).normalized;

        // pulls player toward worker
        transform.position += (Vector3)(direction * ragePullStrength * Time.deltaTime);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}