using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;

    private float followSharpness = 0.1f;

    private void LateUpdate()
    {
        float blend = 1.0f - Mathf.Pow(1.0f - followSharpness, Time.deltaTime * 30.0f);

        transform.position = Vector3.Lerp(transform.position, player.transform.position + offset, blend);
    }
}
