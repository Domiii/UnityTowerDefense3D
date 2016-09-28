using UnityEngine;
using System.Collections;

public class NavMeshMover : Actuator {
	NavMeshAgent agent;
	bool startedMoving;

	public bool HasArrived {
		get;
		private set;
	}

	void Awake() {
		agent = GetComponent<NavMeshAgent> ();
		agent.updatePosition = false;
	}

	public Vector3 CurrentDestination {
		get { return agent.destination; }
		set {
			if (!agent.updatePosition) {
				// start moving!
				agent.updatePosition = true;
				HasArrived = false;
				startedMoving = false;
			}

			// update position
			agent.SetDestination (value);

			//print (string.Join(", ", new []{ agent.pathStatus.ToString (), agent.remainingDistance.ToString () }));
		}
	}

	public void StopMove() { 
		if (agent.updatePosition) {
			agent.updatePosition = false;
			HasArrived = true;
		}
	}

	void LateUpdate() {
		if (agent.updatePosition) {
			if (!startedMoving) {
				// hackfix: during the first update cycle after assigning a target, remainingDistance is still 0!
				startedMoving = true;
			} else {
				if (agent.remainingDistance <= agent.stoppingDistance) {
					// done!
					StopMove();
				}
			}
		}
	}
}
