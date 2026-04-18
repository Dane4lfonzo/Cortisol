using UnityEngine;

public class CompanionLockOn : MonoBehaviour
{
    [Header("Lock-On Settings")]
    public float lockRange = 6f;
    public LayerMask targetLayer;
    public KeyCode lockKey = KeyCode.Tab;

    [Header("Current Target")]
    public Transform currentTarget;

    [Header("Reticle")]
    public GameObject reticleObject;

    void Update()
    {
        // 🔁 While holding key → keep locking
        if (Input.GetKey(lockKey))
        {
            FindNearestTarget();
        }

        // ❌ When key released → clear target
        if (Input.GetKeyUp(lockKey))
        {
            currentTarget = null;
        }

        UpdateReticle();
    }

    void FindNearestTarget()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, lockRange, targetLayer);

        float closestDistance = Mathf.Infinity;
        Transform nearest = null;

        foreach (Collider2D hit in hits)
        {
            // 🚫 Ignore self
            if (hit.transform == transform)
                continue;

            float distance = Vector2.Distance(transform.position, hit.transform.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                nearest = hit.transform;
            }
        }

        currentTarget = nearest;
    }

    void UpdateReticle()
    {
        if (reticleObject == null) return;

        if (currentTarget != null)
        {
            reticleObject.SetActive(true);

            // 🔧 Adjust Y offset if needed
            reticleObject.transform.position = currentTarget.position + new Vector3(0f, 1f, 0f);
        }
        else
        {
            // 🔥 THIS IS WHAT YOU WERE MISSING
            reticleObject.SetActive(false);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, lockRange);
    }
}