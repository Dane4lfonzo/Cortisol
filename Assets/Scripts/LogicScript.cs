using UnityEngine;

public class LogicScript : MonoBehaviour
{
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
}
