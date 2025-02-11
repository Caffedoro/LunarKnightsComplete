using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

[RequireComponent(typeof(PlayerInput))]
public class Player : MonoBehaviour
{
    private PlayerInput input; 
    private Vector2 direction = Vector2.zero;
    public UnityEvent death;

    [SerializeField] private float speed = 5f;

    [SerializeField] private float bulletMomentumInheritance = 0.3f;

    
    // Bullet shooting stuff
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float shotDelay = 0.2f;

    private float cooldown = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        input = GetComponent<PlayerInput>();

      
    }

    // Update is called once per frame
    void Update()
    {
        // Move based on the input
        transform.Translate(speed * direction * Time.deltaTime);


        // Update shooting cooldown
        if (cooldown > 0) { cooldown -= Time.deltaTime; }
    }


    

    void Shoot() {
        if (cooldown > 0) return;
        var go = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        var bullet = go.GetComponent<BaseBullet>();

        bullet.direction = (bullet.direction + (direction*bulletMomentumInheritance)).normalized;
        cooldown = shotDelay;
    }

    public void Die() {
        death.Invoke();
        Destroy(gameObject);
        

    }
    

    // ---------- Input system ---------- //
    void OnAttack() {
        Shoot();
        
    }

    public void OnMove(InputValue value) {
        direction = value.Get<Vector2>().normalized;

       
    }

  
}
