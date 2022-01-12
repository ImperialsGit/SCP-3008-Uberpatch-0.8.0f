using UnityEngine;
//DELCLHOOKWORLDGENERATED
public class AllComponents : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            RaycastHit hit;
            if(Physics.Raycast(GameManager.s.FPCam.transform.position, GameManager.s.FPCam.transform.forward, out hit, 100))
            {
                foreach(Component C in hit.transform.GetComponents<Component>())
                {
                    TGLogger.Log(C.ToString());
                }
                TGLogger.Log("\r\n Children \r\n");
                foreach(Component C in hit.transform.GetComponentsInChildren<Component>())
                {
                    TGLogger.Log(C.ToString());
                }
            }
        }
    }
}