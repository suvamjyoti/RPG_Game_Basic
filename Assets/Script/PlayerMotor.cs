using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    //NavMesh component
    NavMeshAgent agent;     //taget to follow
    Transform target;       //refrence to our Agent
    
    void Awake()
    {
        // assigning a instance of NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
    }

    void Update(){
        if(target){
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }

    internal void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    internal void followTarget(Interactable newTarget){
        agent.stoppingDistance = newTarget.radius * 0.8f;
        agent.updateRotation = false;
        target = newTarget.transform;
        
    }

    internal void StopFollowingTarget(){
        agent.stoppingDistance = 0f;
        agent.updateRotation = true;
        target = null;
        
    }

    private void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0f,direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation,Time.deltaTime*5f);  
    } 

}
