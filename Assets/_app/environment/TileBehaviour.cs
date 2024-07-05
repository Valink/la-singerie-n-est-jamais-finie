using UnityEngine;

public class TileBehaviour : MonoBehaviour
{
    [SerializeField] private TriggerBehaviour trigger;
    [SerializeField] private GameObject tilePrefab;
    [SerializeField] private Transform[] nextTilesOrigins;
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
        var nextTileOriginIndex = Random.Range(0, nextTilesOrigins.Length);
        var nextTile = Instantiate(tilePrefab, nextTilesOrigins[nextTileOriginIndex].position, nextTilesOrigins[nextTileOriginIndex].rotation);
        var ennemies = nextTile.GetComponentsInChildren<EnemyBehaviour>();
        foreach (var enemy in ennemies)
        {
            enemy.target = player.transform;
        }
        trigger.gameObject.SetActive(false);

        Destroy(nextTile,10f);
    }
}


