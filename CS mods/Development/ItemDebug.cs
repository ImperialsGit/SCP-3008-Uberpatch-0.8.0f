using UnityEngine;
using System.IO;
//DELCLHOOKWORLDGENERATED
//HOOK:WORLDGENERATED
public class ItemDebug : MonoBehaviour
{
    public static ItemDebug ID;
    int num, i;
    bool running, co, returned;
    void Awake()
    {
        if(ID != null)
        {
            Destroy(gameObject);
            return;
        }
        gameObject.name = "ID";
        ID = this;
        TGLogger.Log("Instanced ItemDebug!");
    }
    void List()
    {
        TGLogger.Log("Refreshing item list!");
        foreach(ItemSO I in ItemDataManager.s.items)
        {
            TGLogger.Log(ItemDataManager.s.items.IndexOf(I).ToString() + " " + I.itemName);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.RightControl))
        {
            if(co)
            {
                co = false;
                StopAllCoroutines();
                running = false;
                returned = false;
                num = 0;
                i = 0;
            }
            else
            {
                if(!running)
                {
                    ID.co = true;
                    ID.List();
                    ID.StartCoroutine(KeyReg());
                }
            }
        }
    }
    System.Collections.IEnumerator KeyReg()
    {
        running = true;
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Minus));
        StartCoroutine(CheckKey());
        yield return new WaitUntil(() => returned);
        if(i == int.MaxValue && num < ItemDataManager.s.items.Capacity)
        {
            TGLogger.Log(ItemDataManager.s.items[num].itemName);
            Inventory.s.Add(ItemDataManager.s.items[num]);
            i = 0;
            num = 0;
            returned = false;
            running = false;
            StartCoroutine(KeyReg());
            yield break;
        }
        else
        {
            TGLogger.Log("bad return value, this is bad!");
            yield break;
        }
    }
    System.Collections.IEnumerator CheckKey()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0)) set(0);
        else if(Input.GetKeyDown(KeyCode.Alpha1)) set(1);
        else if(Input.GetKeyDown(KeyCode.Alpha2)) set(2);
        else if(Input.GetKeyDown(KeyCode.Alpha3)) set(3);
        else if(Input.GetKeyDown(KeyCode.Alpha4)) set(4);
        else if(Input.GetKeyDown(KeyCode.Alpha5)) set(5);
        else if(Input.GetKeyDown(KeyCode.Alpha6)) set(6);
        else if(Input.GetKeyDown(KeyCode.Alpha7)) set(7);
        else if(Input.GetKeyDown(KeyCode.Alpha8)) set(8);
        else if(Input.GetKeyDown(KeyCode.Alpha9)) set(9);
        else if(Input.GetKeyDown(KeyCode.Return))   {i = int.MaxValue; returned = true; yield break;}
        yield return new WaitForEndOfFrame();
        StartCoroutine(CheckKey());
        yield break;
    }
    void set(int input) => num = (num*10) + input;
}