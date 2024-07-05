using Ilumisoft.HealthSystem;
using UnityEngine;

public class BananaGunBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletForce;
    [SerializeField] private Transform bulletOrigin;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private AudioSource audioSource;


    public void Shoot(){
        var bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce, ForceMode.Impulse);

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100, Color.red, 2f);
        audioSource.Play();
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100)){
            var healthComponent = hit.transform.GetComponent<HealthComponent>();
            if(healthComponent){
                healthComponent.ApplyDamage(1);
            }
        }

        Destroy(bullet, 2f);
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
}
