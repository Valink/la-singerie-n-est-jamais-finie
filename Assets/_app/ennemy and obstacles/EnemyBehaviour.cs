using System;
using System.Collections;
using System.Runtime.Serialization.Formatters;
using System.Threading;
using System.Threading.Tasks;
using Ilumisoft.HealthSystem;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private Animator animator;
    [SerializeField] public Transform target;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletOrigin;
    [SerializeField] private float force;

    public void Start()
    {
        InvokeRepeating(nameof(Shoot), 0, 1.9f);
    }

    public void OnEnable()
    {
        healthComponent.OnHealthEmpty += TriggerDying;
    }

    public void OnDisable()
    {
        healthComponent.OnHealthEmpty -= TriggerDying;
    }

    public void TriggerDying()
    {
        animator.SetBool("isDying", true);
        Destroy(gameObject, 2.5f);
    }
    
    private void Update()
    {
        transform.LookAt(target, Vector3.up);  
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0); 
        bulletOrigin.LookAt(target, Vector3.up);
    }

    private async Task Shoot()
    {   
        animator.SetBool("isAttacking", true);

        await Task.Delay(500);

        var bullet = Instantiate(bulletPrefab, bulletOrigin.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bulletOrigin.forward * force, ForceMode.Impulse);
        Destroy(bullet, 2f);
        
        animator.SetBool("isAttacking", false);
    }
}
