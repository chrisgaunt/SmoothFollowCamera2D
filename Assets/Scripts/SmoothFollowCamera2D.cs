using UnityEngine;
using System.Collections;

public class SmoothFollowCamera2D : MonoBehaviour {

	public Transform target;
	private Vector3 velocity = Vector3.zero;

	public float smoothTime = 0.15f;
	public float maxVerticalPos = 0f;
	public float minVerticalPos = 0f;
	public float maxHorizontalPos = 0f;
	public float minHorizontalPos = 0f;

	void Update () {
		if (target) {
			Vector3 targetPosition = target.position;
			
			if (minHorizontalPos != 0f && maxHorizontalPos != 0f) {
				targetPosition.x = Mathf.Clamp(target.position.x, minHorizontalPos, maxHorizontalPos);
			} else if (minHorizontalPos != 0f) {
				targetPosition.x = Mathf.Clamp(target.position.x, minHorizontalPos, target.position.x);
			} else if (maxHorizontalPos != 0f) {
				targetPosition.x = Mathf.Clamp(target.position.x, target.position.x, maxHorizontalPos);
			}
			
			if (minVerticalPos != 0f && maxVerticalPos != 0f) {
				targetPosition.y = Mathf.Clamp(target.position.y, minVerticalPos, maxVerticalPos);
			} else if (minVerticalPos != 0f) {
				targetPosition.y = Mathf.Clamp(target.position.y, minVerticalPos, target.position.y);
			} else if (maxVerticalPos != 0f) {
				targetPosition.y = Mathf.Clamp(target.position.y, target.position.y, maxVerticalPos);
			}
			
			targetPosition.z = transform.position.z;

			transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
		}
	}
}