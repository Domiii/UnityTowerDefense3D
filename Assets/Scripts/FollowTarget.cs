using UnityEngine;
using System.Collections;

/// <summary>
/// Keeps initial position offset to target unconditionally
/// </summary>
public class FollowTarget : MonoBehaviour {
	public Transform target;
	Vector3 posOffset;

	void Start() {
		posOffset = transform.position - target.transform.position;
	}

	void Update () {
		if (target == null) {
			// do nothing
			return;
		}

		transform.position = target.transform.position + posOffset;
	}
}
