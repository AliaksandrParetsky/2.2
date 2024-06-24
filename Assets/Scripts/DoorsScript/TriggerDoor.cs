using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgentMovement>(out var player))
        {
            MessageBroadcastSystem.Broadcast(DoorsEvent.OPEN);
            MessageBroadcastSystem.Broadcast(DoorsEvent.BAKE);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgentMovement>(out var player))
        {
            MessageBroadcastSystem.Broadcast(DoorsEvent.CLOSE);
            MessageBroadcastSystem.Broadcast(DoorsEvent.BAKE);
        }
    }
}
