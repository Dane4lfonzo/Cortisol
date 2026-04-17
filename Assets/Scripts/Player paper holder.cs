using UnityEngine;

public class PlayerPaperCollector : MonoBehaviour
{
    public int papersHeld = 0;
    public int papersDelivered = 0;

    public void PickUpPaper(int amount)
    {
        papersHeld += amount;
        Debug.Log("Picked up paper. Held: " + papersHeld);
    }

    public void DeliverPapers()
    {
        if (papersHeld > 0)
        {
            papersDelivered += papersHeld;
            Debug.Log("Delivered " + papersHeld + " papers. Total delivered: " + papersDelivered);
            papersHeld = 0;
        }
        else
        {
            Debug.Log("No papers to deliver.");
        }
    }
}