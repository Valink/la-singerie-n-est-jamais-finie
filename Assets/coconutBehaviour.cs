using UnityEngine;

public class coconutBehaviour : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player") {
            Destroy(gameObject);
        }
    }
}
