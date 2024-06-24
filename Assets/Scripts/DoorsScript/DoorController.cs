using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Vector3 doorPos;

    private bool open;

    private void OnEnable()
    {
        MessageBroadcastSystem.AddListener(DoorsEvent.OPEN, Open);
        MessageBroadcastSystem.AddListener(DoorsEvent.CLOSE, Close);
    }

    private void OnDisable()
    {
        MessageBroadcastSystem.RemoveListener(DoorsEvent.OPEN, Open);
        MessageBroadcastSystem.RemoveListener(DoorsEvent.CLOSE, Close);
    }

    private void Open()
    {
        if (!open)
        {
            Vector3 pos = transform.position + doorPos;
            transform.position = pos;
            open = true;
        }
    }

    private void Close()
    {
        if (open)
        {
            Vector3 pos = transform.position - doorPos;
            transform.position = pos;
            open = false;
        }
    }
}
