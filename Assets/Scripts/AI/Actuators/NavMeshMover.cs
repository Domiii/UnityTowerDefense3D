using UnityEngine;
using System.Collections;

public class NavMeshMover : Actuator {
	NavMeshAgent agent;
	bool isMoving;
	bool startedMovingFlag;	// used for internal mini hack

	public bool HasArrived {
		get;
		private set;
	}

	public bool IsMoving {
		get { return !isMoving; }
	}

	void Awake() {
		agent = GetComponent<NavMeshAgent> ();
	}

	public Vector3 CurrentDestination {
		get { return agent.destination; }
		set {
			if (!isMoving) {
				// start moving!
				OnStartMove();
			}

			// update position
			agent.SetDestination (value);

			//print (string.Join(", ", new []{ agent.pathStatus.ToString (), agent.remainingDistance.ToString () }));
		}
	}

	void OnStartMove() {
		if (!isMoving) {
			HasArrived = false;
			startedMovingFlag = false;
			isMoving = true;
			agent.Resume ();
		}
	}

	public void StopMove() { 
		if (isMoving) {
			HasArrived = true;
			isMoving = false;
			agent.Stop ();
		}
	}

	void LateUpdate() {
		if (isMoving) {
			if (!startedMovingFlag) {
				// hackfix: during the first update cycle after assigning a target, remainingDistance is still 0!
				startedMovingFlag = true;
			} else {
				if (agent.remainingDistance <= agent.stoppingDistance) {
					// done!
					StopMove();
				}
			}
		}
	}
}
