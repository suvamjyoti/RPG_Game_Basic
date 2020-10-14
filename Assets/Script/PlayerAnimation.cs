using UnityEngine;
using UnityEngine.AI;

using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    
    NavMeshAgent agent;
    Animator animator;

    private void Start() {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update() {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("Blend",speedPercent,0.1f,Time.deltaTime);    
    }

}