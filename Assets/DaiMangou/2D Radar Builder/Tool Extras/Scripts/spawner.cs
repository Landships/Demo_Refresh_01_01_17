﻿using UnityEngine;
using System.Collections;

public class spawner : MonoBehaviour
{

    public Transform ObjectToSpawn;
    public float spawnTime = 2f;
    public float SpawnLimit, spawncount;

    IEnumerator Start()
    {

        while (true)
        {
            while(spawncount< SpawnLimit)
                yield return StartCoroutine(dropBomb());

       yield return null;
        }



    }

    IEnumerator dropBomb()
    {
        yield return new WaitForSeconds(spawnTime);
        
             Transform.Instantiate(ObjectToSpawn, new Vector3(Random.Range(-250, 80), 200, Random.Range(-80, 320)), Quaternion.identity);
             spawncount += 1;
    }


}
