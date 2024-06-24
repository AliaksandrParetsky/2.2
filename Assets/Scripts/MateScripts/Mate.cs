using UnityEngine;
using UnityEngine.AI;

public abstract class Mate : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;

    private NavMeshAgent character;

    private NavMeshAgent agentMate;
    public NavMeshAgent AgentMate
    {
        get
        {
            if (agentMate == null)
            {
                agentMate = GetComponent<NavMeshAgent>();
            }
            return agentMate;
        }
    }

    private void Update()
    {
        if (character != null)
        {
            AgentMate.destination = PositionAdjustment();
        }
    }

    public void SetCharacter(NavMeshAgent player)
    {
        character = player;
    }   
    
    private Vector3 PositionAdjustment()
    {
        Vector3 offset = new Vector3(1.5f, 0.0f, 5.0f);
        
        return character.transform.position + offset;
    }

    private void SetActivTrue()
    {
        uiPanel.gameObject.SetActive(true);
    }

    public void SetActivFalse()
    {
        uiPanel.gameObject.SetActive(false);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgentMovement>(out var player))
        {
            SetActivTrue();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<NavMeshAgentMovement>(out var player))
        {
            SetActivFalse();
        }
    }
}
