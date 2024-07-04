using Ilumisoft.HealthSystem;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private HealthComponent healthComponent;
    [SerializeField] private Animator animator;

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

}
