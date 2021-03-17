using UnityEngine;
public class GodMode : MonoBehaviour
{
    //CLHOOKWORLDGENERATED
    //HOOK:WORLDGENERATED
    bool godMode;
    private void Start()
    {
        if(GameObject.Find("godmode"))
        {
            Destroy(gameObject);
            return;
        }
        gameObject.name = "godmode";
        TGLogger.Log("GODMODE HAS INSTANTIATED");
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.O))
        {
            godMode = !godMode;
            Messages.s.Show(godMode ? "GodMode enabled, leave mortality behind!" : "GodMode disabled, you are now mortal", true);
        }
        else if(Input.GetKeyDown(KeyCode.M))
        {
            DayNightManager.s.countdown = DayNightManager.s.OpenTime();
            DayNightManager.s.Day();
        }
        if(godMode)
        {
            PlayerData.s.HP = PlayerData.s.maxHP;
            PlayerData.s.sat = 100;
            PlayerData.s.energy = 100;
            PlayerData.s.sanity = 100; 
        }
    }
}