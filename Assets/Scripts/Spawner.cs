using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject MobSpawner;

    public void SpawnItem()
    {
        if (MobSpawner != null)
        {
            Instantiate(MobSpawner, new Vector2(5.74f, -2.35f), Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("You Forgot an item in a MobSpawner!");
        }
    }

}//END