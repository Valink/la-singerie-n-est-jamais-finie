using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    [SerializeField] private TriggerBehaviour trigger;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform nextGroundOrigin;
    [SerializeField] public GameObject player;

    private void OnEnable()
    {
        trigger.OnTrigger += SpawnNextTile;
    }

    private void OnDisable()
    {
        trigger.OnTrigger -= SpawnNextTile;
    }

    private void SpawnNextTile()
    {
        
        var nextTile = Instantiate(tilePrefab, nextGroundOrigin.position, nextGroundOrigin.rotation);
        var ennemies = nextTile.GetComponentsInChildren<EnemyBehaviour>();
        foreach (var enemy in ennemies)
        {
            enemy.target = player.transform;
        }
        trigger.gameObject.SetActive(false);
    }
}


