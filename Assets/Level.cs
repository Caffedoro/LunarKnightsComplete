
using UnityEngine;
using System.Collections;



/*
// how to learn any language
// (read the docs)

// function calls and parameters

// variables/object types -- "simple" vs "object" variables
// - value types don't have fields
// - value type vs referrence type

// assignments vs conditions

// misc conventions

// scope/context; private vs public vs local, what gets run where, etc

// null

// "plug & play" (type safety)
*/

public class Level : MonoBehaviour
{
    [SerializeField] private GameObject[] waves;

    [SerializeField] float delayMax = 10f;
    [SerializeField] float delayMin = 5f;


    private void Start()
    {

        StartCoroutine(SpawnCoroutine());
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(delayMin, delayMax));
        SpawnRandomWave();
    }

    public void SpawnRandomWave()
    {

        StartCoroutine(SpawnCoroutine());
        var index = UnityEngine.Random.Range(0, waves.Length);

        Instantiate(waves[index], transform.position, Quaternion.identity);
    }
}
