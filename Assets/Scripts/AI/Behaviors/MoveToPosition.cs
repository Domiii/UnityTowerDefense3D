using UnityEngine;
using System.Collections;

namespace Behaviors {
	/// <summary>
	/// Move to destination, don't let anything distract you from that.
	/// </summary>
	[RequireComponent(typeof(NavMeshMover))]
	public class MoveToPosition : AIBehavior {
		NavMeshMover mover;

		#region Public
		public Vector3 CurrentDestination {
			get { 
				return mover.CurrentDestination;
			}
		}

		public void StartBehavior(Vector3 pos) {
			mover.CurrentDestination = pos;
		}
		#endregion

		void Awake () {
			mover = GetComponent<NavMeshMover> ();
			print (mover);
		}

		void Update () {
			if (mover.HasArrived) {
				StopBehavior ();
			}
		}

		/// <summary>
		/// Called when finished moving.
		/// </summary>
		protected override void Cleanup() {
			mover.StopMove ();
		}
	}
}