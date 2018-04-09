using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCrates : MonoBehaviour
{
    public GameObject cratePrefab;
    public int numToSpawn = 10;
    public float spawnRadius = 10.0f;


	void Start ()
    {
	    for(int i = 0; i < numToSpawn; i++)
        {
            Vector3 spawnPos = Random.insideUnitSphere * spawnRadius;
            spawnPos.z = 0;
            GameObject newcrate = Instantiate(cratePrefab, spawnPos, Quaternion.identity);
            newcrate.name = "crate_" + i.ToString();
            GetComponent<RotateLevel>().levelObjects.Add(newcrate);
        }
	}
}
