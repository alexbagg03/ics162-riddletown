using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof (UnityEngine.AI.NavMeshAgent))]
    [RequireComponent(typeof (ThirdPersonCharacter))]
    public class AICharacterControl : MonoBehaviour
    {
        public UnityEngine.AI.NavMeshAgent agent { get; private set; }             // the navmesh agent required for the path finding
        public ThirdPersonCharacter character { get; private set; } // the character we are controlling
        public Transform target;                                    // target to aim for
        public int current_destination;

        private void Start()
        {
            // get the components on the object we need ( should not be null due to require component so no need to check )
            agent = GetComponentInChildren<UnityEngine.AI.NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();

	        agent.updateRotation = false;
	        agent.updatePosition = true;

            if (target != null)
                agent.SetDestination(target.GetChild(current_destination).transform.position);
        }


        private void Update()
        {
            if (target != null)
                agent.SetDestination(target.GetChild(current_destination).transform.position);

            if (agent.remainingDistance > agent.stoppingDistance)
                character.Move(agent.desiredVelocity, false, false);
            else
                character.Move(Vector3.zero, false, false);

            if(agent.remainingDistance <= agent.stoppingDistance)
            {
                current_destination++;

                if(current_destination >= target.childCount)
                {
                    current_destination = 0;
                }

                agent.SetDestination(target.GetChild(current_destination).transform.position);

            }
        }


        public void SetTarget(Transform target)
        {
            this.target = target;
        }
    }
}
