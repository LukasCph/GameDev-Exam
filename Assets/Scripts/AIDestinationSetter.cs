using UnityEngine;
using System.Collections;

namespace Pathfinding
{
    [UniqueComponent(tag = "ai.destination")]
    public class AIDestinationSetter : VersionedMonoBehaviour
    {
        IAstarAI ai;
        Camera cam;

        public void Start()
        {
            //Cache the Main Camera
            cam = Camera.main;
            useGUILayout = false;
        }

        void OnEnable()
        {
            ai = GetComponent<IAstarAI>();
        }

        // Handles onClick
        public void OnGUI()
        {
            if (cam != null)
            {
                UpdateTargetPosition();
            }
        }

        public void UpdateTargetPosition()
        {
            Vector3 newPosition = Vector3.zero;
            bool positionFound = false;

            newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            newPosition.z = 0;
            positionFound = true;

            if (positionFound && newPosition != ai.destination)
            {
                if (ai != null) ai.destination = newPosition;
            }
			
			if (ai.destination.x < cam.transform.position.x){
				transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1,1,1));
                Debug.Log("Player is RIGHT");

			} else if (ai.destination.x > cam.transform.position.x){
				transform.localScale = Vector3.Scale(transform.localScale, new Vector3(-1,1,1));
                Debug.Log("Player is LEFT");
			}

        }
    }
}