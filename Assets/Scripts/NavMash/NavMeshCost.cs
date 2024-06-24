using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent (typeof(Collider))]
[RequireComponent(typeof(NavMeshModifierVolume))]
public class NavMeshCost : MonoBehaviour
{
    private NavMeshModifierVolume volume;
    private float speedCorrectionWater = 3.0f;

    private void Awake()
    {
        volume = GetComponent<NavMeshModifierVolume>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent<NavMeshAgent>(out var agent))
        {
            if (volume.AffectsAgentType(agent.agentTypeID))
            {
                float costModifire = NavMesh.GetAreaCost(volume.area);

                agent.speed = (agent.speed / costModifire) * speedCorrectionWater;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgent>(out var agent))
        {
            if (volume.AffectsAgentType(agent.agentTypeID))
            {
                float costModifire = NavMesh.GetAreaCost(volume.area);

                agent.speed = (agent.speed * costModifire) / speedCorrectionWater;
            }
        }
    }
}
