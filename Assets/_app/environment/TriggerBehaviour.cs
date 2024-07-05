using UnityEngine;

public class TriggerBehaviour : MonoBehaviour
{
    public delegate void TriggerAction();
    public event TriggerAction OnTrigger;

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")){
            OnTrigger?.Invoke();
        }
    }
}
