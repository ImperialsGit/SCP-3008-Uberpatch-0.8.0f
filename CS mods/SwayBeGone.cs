using UnityEngine;
//CLHOOKWORLDGENERATED
public class SwayBeGone : MonoBehaviour
{
    private void Awake()
    {
        if(GameObject.Find("SWAYBEGONE"))
        {
            Destroy(gameObject);
            return;
        }
        gameObject.name = "SWAYBEGONE";
    }
    private void Start()
    {
        GameManager.s.FPCam.BobInputVelocityScale = 0;
        GameManager.s.FPCam.ShakeSpeed = 0;
        GameManager.s.FPCam.BobStepThreshold = 0;
        Messages.s.Show("Stopped being drunk");
        Destroy(gameObject);
        return;
    }
}