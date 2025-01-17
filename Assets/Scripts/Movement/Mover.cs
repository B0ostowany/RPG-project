using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RPG.Saving;
using RPG.Attributes;
using RPG.Core;

namespace RPG.Movement
{
    public class Mover : MonoBehaviour,IAction, ISaveable
    {
        [SerializeField] Transform target;
        [SerializeField] float maxSpeed=6f;

        NavMeshAgent navMeshAgent;
        Stamina stamina;
        Health health;
        private void Awake()
        {
            health = GetComponent<Health>();
            navMeshAgent = GetComponent<NavMeshAgent>();
            stamina = GetComponent<Stamina>();
        }
        

        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();
            UpdateAnimator();
        }

        public void StartMoveAction(Vector3 desitnation, float speedFraction, bool isExhausted)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            if (isExhausted)
            {
                MoveTo(desitnation, speedFraction*0.5f);
            }
            else
            {
                MoveTo(desitnation, speedFraction);
            }
        }
        public void MoveTo(Vector3 destination,float speedFraction)
        {
            
            navMeshAgent.destination = destination;
            navMeshAgent.speed = maxSpeed*Mathf.Clamp01(speedFraction);
            navMeshAgent.isStopped = false;
        }

        public void Cancel()
        {
            
            navMeshAgent.isStopped = true;
        }

        
        private void UpdateAnimator()
        {
           
            Vector3 velocity = navMeshAgent.velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }

        public object CaptureState()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data["position"] = new SerializableVector3(transform.position);
            data["rotation"] = new SerializableVector3 (transform.eulerAngles);
            return data;
        }

        public void RestoreState(object state)
        {
            Dictionary<string, object> data = (Dictionary<string, object>)state;
            GetComponent<NavMeshAgent>().enabled = false;
            transform.position=((SerializableVector3) data["position"]).ToVector();
            transform.eulerAngles=((SerializableVector3) data["rotation"]).ToVector();
            GetComponent<NavMeshAgent>().enabled=true;
        }
    }
}


