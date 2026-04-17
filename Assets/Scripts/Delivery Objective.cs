using UnityEngine;

public class PaperDeliveryZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPaperCollector collector = other.GetComponent<PlayerPaperCollector>();

        if (collector != null)
        {
            collector.DeliverPapers();
        }
    }
}