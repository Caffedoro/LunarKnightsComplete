using UnityEngine;


public class BaseEnemy : MonoBehaviour
{
    
    [SerializeField] bool aimAtPlayer = false;
    [SerializeField] Vector2 direction = Vector2.down;
    private GameObject player;

    [SerializeField] private float speed = 3f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shotDelay = 0.2f;

    
    [SerializeField] private float lifetime = 5f;

    private float spawnTime;
    private float cooldown = 0;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (cooldown > 0) {
            cooldown -= Time.deltaTime;
        } else {
            Shoot();
        }
        
        if (Time.time >= spawnTime + lifetime) {
            Destroy(this.gameObject);
        }
    }


    public void Die() {
        Destroy(this.gameObject, 0.2f);
    }

    void Shoot() {
        GameObject go = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        cooldown = shotDelay;

        player = GameObject.FindWithTag("Player");
        if (aimAtPlayer && player != null) {
            
            var bullet = go.GetComponent<BaseBullet>();
            bullet.direction = (player.transform.position- transform.position).normalized;
        }
    }

    void Move() {
        transform.Translate(direction.normalized * speed * Time.deltaTime);
    }


}
