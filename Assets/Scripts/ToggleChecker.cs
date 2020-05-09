using UnityEngine.UI;
using UnityEngine;

public class ToggleChecker : MonoBehaviour
{
    public static bool TogglePosition = true;
    public Toggle toggle;
    void Start()
    {
        TogglePosition_();
    }
    void TogglePosition_()
    {
        if (TogglePosition)
        {
            toggle.isOn = true;
        }
        else if (!TogglePosition)
        {
            toggle.isOn = false;
        }
    }

}
