using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float speed = 1.0f;
    private void Update()
    {
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }   
    }
}
