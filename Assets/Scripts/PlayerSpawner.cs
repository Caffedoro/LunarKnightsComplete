using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] private int lives;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lives = 3;
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {

    }

   void SpawnPlayer()
    {
       lives -= 1;
        if (lives > 0)
        {
            var go = Instantiate(playerPrefab);

            var player = go.GetComponent<Player>();

            player.death.AddListener(StartDelayedSpawn);
        }
        else
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    void StartDelayedSpawn()
    {
        StartCoroutine(ReviveDelay());
    }
    IEnumerator ReviveDelay()
    {
        yield return new WaitForSeconds(3);
        SpawnPlayer();
    }

}
