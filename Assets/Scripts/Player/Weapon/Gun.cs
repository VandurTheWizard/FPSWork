using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    public int typeGun = 1;
    public float damage = 10f;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Vector3 weaponPosition;

    [Header("Bullet Settings")]
    public float lifeBullet = 2f;
    public float speedBullet = 10f;

    void Start()
    {
        transform.localPosition = weaponPosition;
    }

    public bool Shot(){
        if(bulletPrefab != null && firePoint != null){
            GameObject bulletShot = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            // Se le dan los datos a la bala

            return true;
        }
        return false;
    }

}
