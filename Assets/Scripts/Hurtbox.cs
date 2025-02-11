using Unity.VisualScripting;
using UnityEngine;

public class Hurtbox : MonoBehaviour
{
    [SerializeField] private GameObject belongsTo; // what object to kill when this things gets hit

    private void OnTriggerEnter2D(Collider2D other) { // when we hit something 
        // double check we're good
        if (other.CompareTag("Hitbox") == false) { return; }

        if (belongsTo.GetComponent<Player>())
        {
            belongsTo.GetComponent<Player>().Die();
        }
        else if (belongsTo.GetComponent<BaseEnemy>())
        {
            belongsTo.GetComponent<BaseEnemy>().Die();
        }
        else
        {
            Destroy(belongsTo);
        }


    }
}
