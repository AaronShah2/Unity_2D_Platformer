using UnityEngine;

public class ShurikenFire : MonoBehaviour
{

    public float speed = 20f;
    public Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D collision){
        Debug.Log(collision.gameObject.name);
        if(collision.gameObject.CompareTag("Wall")){
            Destroy(gameObject);
            // Destroy(collision.gameObject);
        }
    }
}
