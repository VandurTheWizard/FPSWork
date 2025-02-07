using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 20f;
    public int damage = 1;
    public float lifeTime = 2f;

    private void Start()
    {
        Invoke("DestroyBullet", lifeTime);
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    // Colisiones
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Structure")
        {
            Destroy(gameObject);
        }
    }

}
