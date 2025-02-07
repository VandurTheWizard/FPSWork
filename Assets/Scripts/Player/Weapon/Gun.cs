using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    public float cadencia = 1f;
    public int typeGun = 1;
    public int damage = 10;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Vector3 weaponPosition;

    [Header("Bullet Settings")]
    public float lifeBullet = 2f;
    public float speedBullet = 10f;

    private Animator animator;
    private bool canShot = true;

    void Start()
    {
        canShot = true;
        transform.localPosition = weaponPosition;
        animator = GetComponent<Animator>();
    }

    public bool Shot(){
        if(bulletPrefab != null && firePoint != null && canShot){
            GameObject bulletShot = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            animator.SetTrigger("Disparo");
            bulletShot.GetComponent<Bullet>().damage = damage;
            canShot = false;
            Invoke("PrepareShot", cadencia);

            return true;
        }
        return false;
    }

    private void PrepareShot(){
        canShot = true;
    }

}
