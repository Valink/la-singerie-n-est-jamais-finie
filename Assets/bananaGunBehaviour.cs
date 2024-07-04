using UnityEngine;

public class bananaGunBehaviour : MonoBehaviour
{
    [SerializeField] private float bulletForce;
    [SerializeField] private Transform bulletOrigin;
    [SerializeField] private GameObject bulletPrefab;

    public void Shoot(){
        var bullet = Instantiate(bulletPrefab, bulletOrigin.position, bulletOrigin.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce, ForceMode.Impulse);

        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100, Color.red, 2f);

        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, 100)){
            Debug.Log(hit.transform.name);
            // if(hit.transform.tag == "Enemy"){
            //     hit.transform.GetComponent<EnemyBehaviour>().TakeDamage(10);
            // }
        }
        
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }
}
