using UnityEngine;

public class SpawnerTriggerBehaviour : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private SpawnerBehaviour spawner;

    void OnTriggerEnter(Collider other)
    {
        spawner.Spawn();

        // animator.SetBool("isAttacking", true);
        // animator.SetBool("isDying", true);
    }
}


