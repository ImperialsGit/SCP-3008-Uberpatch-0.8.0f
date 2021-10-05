using UnityEngine;
using System.IO;
//DELCLHOOKWORLDGENERATED
public class ItemDebug : MonoBehaviour
{
    int num, i;
    bool running, co, returned;
    void Awake()
    {
        if(GameObject.Find("ID"))
        {
            Destroy(gameObject);
            return;
        }
        gameObject.name = "ID";
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
            if(!co)
            {
                if(!running)
                {
                    co = true;
                    List();
                    StartCoroutine(KeyReg());
                }
            }
            else
            {
                co = false;
                StopAllCoroutines();
                running = false;
                returned = false;
                num = 0;
                i = 0;
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
        if(Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Keypad0))   {set('0');}
        else if(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))   {set('1');}
        else if(Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))   {set('2');}
        else if(Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))   {set('3');}
        else if(Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))   {set('4');}
        else if(Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))   {set('5');}
        else if(Input.GetKeyDown(KeyCode.Alpha6) || Input.GetKeyDown(KeyCode.Keypad6))   {set('6');}
        else if(Input.GetKeyDown(KeyCode.Alpha7) || Input.GetKeyDown(KeyCode.Keypad7))   {set('7');}
        else if(Input.GetKeyDown(KeyCode.Alpha8) || Input.GetKeyDown(KeyCode.Keypad8))   {set('8');}
        else if(Input.GetKeyDown(KeyCode.Alpha9) || Input.GetKeyDown(KeyCode.Keypad9))   {set('9');}
        else if(Input.GetKeyDown(KeyCode.Return))   {i = int.MaxValue; returned = true; yield break;}
        yield return new WaitForEndOfFrame();
        StartCoroutine(CheckKey());
        yield break;
    }
    void set(char input) => num = int.Parse(num.ToString() + input);
}