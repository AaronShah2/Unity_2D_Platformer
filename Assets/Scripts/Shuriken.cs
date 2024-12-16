using UnityEngine;

public class Shuriken : MonoBehaviour
{
    public int maxAmmo;
    public Transform firePoint;
    public GameObject shurikenPrefab;

    private int currentAmmo;

    void Start(){
        currentAmmo = maxAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && currentAmmo > 0){
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(shurikenPrefab, firePoint.position, firePoint.rotation);
        currentAmmo--;
    }
}
