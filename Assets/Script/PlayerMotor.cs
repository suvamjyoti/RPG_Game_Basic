using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    //NavMesh component
    NavMeshAgent agent;
    
    void Awake()
    {
        // assigning a instance of NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    internal void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }
}
