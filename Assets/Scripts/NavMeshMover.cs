using UnityEngine;
using System.Collections;

[RequireComponent(typeof(NavMeshAgent))]
public class NavMeshMover : MonoBehaviour {
	Vector3 currentDestination;
	NavMeshAgent agent;

	void Start() {
		agent = GetComponent<NavMeshAgent> ();
	}

	public Vector3 CurrentDestination {
		get { return currentDestination; }
	}

	/// <summary>
	/// Start Move action
	/// </summary>
	void Move(Actions.Move action) {
		agent.SetDestination (currentDestination = action.Destination);
	}
}
