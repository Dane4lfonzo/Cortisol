using UnityEngine;

public class LogicScript : MonoBehaviour
{
    private float socialCountdown = 2;
    public bool forcedToSocialize = false;
    public void SocialColleague(bool setbool)
    {
        forcedToSocialize = setbool;
    }

    public bool GetSocialColleague()
    {
        if (forcedToSocialize)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public float GetSocialCountdown()
    {
        return socialCountdown;
    }
}
