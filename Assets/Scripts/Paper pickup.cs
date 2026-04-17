using UnityEngine;

public class PaperPickup : MonoBehaviour
{
    public int paperValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerPaperCollector collector = other.GetComponent<PlayerPaperCollector>();

        if (collector != null)
        {
            collector.PickUpPaper(paperValue);
            Destroy(gameObject);
        }
    }
}