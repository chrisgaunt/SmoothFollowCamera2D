using UnityEngine;
using System.Collections;

public class SmoothCamera2D : MonoBehaviour {

	public Transform target;

	public float dampTime = 8f;
	
	public bool limitPositionsX = false;
	public float minPositionX = 0f;
	public float maxPositionX = 0f;
	
	public bool limitPositionsY = false;
	public float minPositionY = 0f;
	public float maxPositionY = 0f;

	void Update () {
		if (target) {
			Vector3 fromPosition = transform.position;
			Vector3 toPosition = target.position;
			
			if (limitPositionsX) {
				toPosition.x = Mathf.Clamp(target.position.x, minPositionX, maxPositionX);
			}
			
			if (limitPositionsY) {
				toPosition.y = Mathf.Clamp(target.position.y, minPositionY, maxPositionY);
			}
			
			toPosition.z = transform.position.z;
			
			transform.position -= (fromPosition - toPosition) * dampTime * Time.deltaTime;
		}
	}
}