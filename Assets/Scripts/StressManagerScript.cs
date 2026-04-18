using UnityEngine;

public class StressManagerScript : MonoBehaviour
{
    private float stressCount;
    
    public void AddStress(float stressToAdd)
    {
        stressCount += stressToAdd;
    }

    public float GetStressCount()
    {
        return stressCount;
    }

}
