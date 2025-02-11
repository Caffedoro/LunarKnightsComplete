using Unity.VisualScripting;
using UnityEngine;


public class WaveSpawner : MonoBehaviour
{
    public float spawnTime = 1f;
    [SerializeField] private GameObject wave;

    private void Update() {
        if (Time.timeSinceLevelLoad >= spawnTime)  {
            Instantiate(wave);
            Destroy(gameObject);
        }

    }

}
