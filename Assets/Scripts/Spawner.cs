using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private GameObject objToSpawn;
    [SerializeField] int amountOfSpawnObjs = 5;
    [SerializeField] int allRounds;
    private List<GameObject> spawnedObjList;

    void Start()
    {
        spawnedObjList = new List<GameObject>();
        StartCoroutine(StartRounds(allRounds)); 
    }

    
    IEnumerator StartRounds(int rounds)
    {        
        yield return new WaitForSeconds(5f);
        while (rounds>0)
        {

            yield return StartCoroutine(Spawn(amountOfSpawnObjs));
            yield return new WaitForSeconds(5f); 
            rounds--;
        }
        Debug.Log("Finish");
    }

    IEnumerator Spawn(int num)
    {
        int i = 0;
        Transform spawnPoint;
        while (i<=num)
        {
            int rnd = Random.Range(0, points.Length-1);
            Debug.Log(rnd);
            spawnPoint = points[rnd];
            var obj = Instantiate(objToSpawn, spawnPoint);
            spawnedObjList.Add(obj);
            i++;
        }
        
        yield return new WaitForSeconds(10f);
        DestroySpawnedObjs();
    }

    private void DestroySpawnedObjs()
    {
        foreach (var item in spawnedObjList)
        {
            Destroy(item);
        }
    }    
}
