using System;
using UnityEngine;
//HOOK:WORLDGENERATED
//CLHOOKWORLDGENERATED
public class StaffPreventer : MonoBehaviour
{
	private void Awake()
	{
        TGLogger.Log("Now Preventing Staff");
        StartCoroutine(awaitSS());
	}
    System.Collections.IEnumerator awaitSS()
    {
        yield return new WaitUntil(() => StaffSpawner.s != null);
        StaffSpawner.s.gameObject.SetActive(false);
        StaffSpawner.s.StopCoroutine("Spawn");
        StaffSpawner.s.StopCoroutine("WaitForGenAndSpawn");
        yield break;
    }
}