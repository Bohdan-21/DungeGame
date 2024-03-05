using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Scripts.AI
{
    public class SimpleAI : MonoBehaviour
    {
        public NavMeshAgent navMeshAgent;

        private void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Input.mousePosition;

                Ray ray = Camera.main.ScreenPointToRay(mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    navMeshAgent.SetDestination(hit.point);

                    Debug.Log("Set Destination:" + hit.point.ToString());
                }
            }
        }
    }
}