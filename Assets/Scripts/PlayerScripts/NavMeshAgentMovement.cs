using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(ControlSurroundingObjects))]
public class NavMeshAgentMovement : MonoBehaviour
{
    private Camera cam;
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

    
    private float timeToDestroy = 1.0f;

    private void Start()
    {
        cam = Camera.main;
    }

    private void OnEnable()
    {
        MessageBroadcastSystem<Vector3>.AddListener(InputEvent.MOVING_TO, OnMovingTo);
    }

    private void OnMovingTo(Vector3 mousePos)
    {
        Ray ray = cam.ScreenPointToRay(mousePos);

        if (Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            GameObject hitObj = hitInfo.transform.gameObject;

            if(hitObj.layer == 7 || hitObj.layer == 8)
            {
                PointIndicator(hitInfo.point);

                Agent.SetDestination(hitInfo.point);
            }
        }
    }

    private void PointIndicator(Vector3 mousePos)
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);

        sphere.gameObject.GetComponent<Renderer>().material.color = Color.green;

        sphere.gameObject.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);

        sphere.transform.position = mousePos;

        Destroy(sphere, timeToDestroy);
    }

    private void OnDisable()
    {
        MessageBroadcastSystem<Vector3>.RemoveListener(InputEvent.MOVING_TO, OnMovingTo);
    }
}
