using UnityEngine;
using System.Collections;

public class handScript : MonoBehaviour {
    private Animator handAnimator;
    private float currentBlend = 0.0f;
    private VRTK.VRTK_ControllerEvents controller_events;
    private VRTK.VRTK_InteractTouch touch_events;

    // Use this for initialization
    void Start () {
        handAnimator = GetComponent<Animator>();
        controller_events = transform.parent.GetComponent<VRTK.VRTK_ControllerEvents>();


    }

    // Update is called once per frame
    void Update () {
        if (controller_events.triggerClicked)
        {
            handAnimator.SetFloat("handBlend", 1.0f, 0.1f, Time.deltaTime);
        }
        else if (touch_events.GetTouchedObject() != null)
        {
            handAnimator.SetFloat("handBlend", 0.5f, 0.1f, Time.deltaTime);
        }
        else
        {
            handAnimator.SetFloat("handBlend", 0.0f, 0.1f, Time.deltaTime);
        }

    }




    public void hapticFeedBack()
    {
        //SteamVR_Controller.Input(deviceIndex).TriggerHapticPulse(250);
    }
}
