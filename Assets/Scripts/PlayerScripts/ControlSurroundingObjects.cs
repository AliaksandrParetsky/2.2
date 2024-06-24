using UnityEngine;
using UnityEngine.AI;

public class ControlSurroundingObjects : MonoBehaviour
{
    private NavMeshAgent agent;
    public NavMeshAgent Agent
    {
        get
        {
            if (agent == null)
            {
                agent = GetComponent<NavMeshAgent>();
            }
            return agent;
        }
    }

    private float radiusTrrigerZone = 7.0f;

    private void OnEnable()
    {
        MessageBroadcastSystem.AddListener(InputEvent.ADD_MATE, CheckObject);
    }

    private void OnDisable()
    {
        MessageBroadcastSystem.RemoveListener(InputEvent.ADD_MATE, CheckObject);
    }

    private void CheckObject()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radiusTrrigerZone);

        foreach (Collider collider in hitColliders)
        {
            if (collider.TryGetComponent<Mate>(out var mate))
            {
                mate.SetCharacter(Agent);
                mate.SetActivFalse();

                GameObject gameObject = mate.gameObject;
                gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
