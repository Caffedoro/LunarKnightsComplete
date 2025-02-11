using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float lifetime = 3f;
    public Vector2 direction = Vector2.down;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, lifetime); // don't last more than 10 seconds
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement() {
        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }
    
    void Hit() { 
        Destroy(gameObject);
        // sfx, explosion animation, etc etc. 
    }
    

    private void OnTriggerEnter2D(Collider2D other) { // when we hit something 
        // double check we're good
        if (other.CompareTag("Hurtbox") == false) { return; }

        Hit();
    }
}
