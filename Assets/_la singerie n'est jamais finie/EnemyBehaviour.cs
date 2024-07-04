using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private HealthManagerBehaviour healthManager;
    [SerializeField] private Animator animator;

    public void OnEnable()
    {
        healthManager.onHealthChange += CheckIfDead;
    }

    public void OnDisable()
    {
        healthManager.onHealthChange -= CheckIfDead;
    }

    public void CheckIfDead(float healthBetween0And1)
    {
        if (healthBetween0And1 <= 0)
        {
            animator.SetBool("isDying", true);
            Destroy(gameObject, 2.5f);
        }
    }

}
