using System.Collections;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class BulletCircleSpawner : MonoBehaviour
{
    
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] int bulletsToSpawn = 12;
    [SerializeField] float radius = 1f;
    [SerializeField] float delay = 0.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (delay > 0){
            StartCoroutine(SpawnBulletsDelayed());
        } else {
            SpawnBullets();
        }
        
    }

    IEnumerator SpawnBulletsDelayed() {
        yield return new WaitForSeconds(delay);
        SpawnBullets();
    }

    void SpawnBullets() {
        for (var i = 0; i < bulletsToSpawn; i++) {
            var theta = (i/(float)bulletsToSpawn) * 2 * Mathf.PI + (transform.rotation.z * Mathf.Deg2Rad);
            var xx = Mathf.Cos(theta) * radius;
            var yy = Mathf.Sin(theta) * radius;

            var go = Instantiate(bulletPrefab, new Vector3(xx, yy, 0) + transform.position, Quaternion.identity);
            go.GetComponent<BaseBullet>().direction = new Vector2(xx, yy).normalized;
        }

        Destroy(this.gameObject);
    }


    void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);

        for (var i = 0; i < bulletsToSpawn; i++) {
            var theta = (i/(float)bulletsToSpawn) * 2 * Mathf.PI + (transform.rotation.z * Mathf.Deg2Rad);
            var xx = Mathf.Cos(theta) * radius;
            var yy = Mathf.Sin(theta) * radius;

            Gizmos.DrawSphere(new Vector3(xx, yy, 0) + transform.position, 0.1f);
        }
    }
}
