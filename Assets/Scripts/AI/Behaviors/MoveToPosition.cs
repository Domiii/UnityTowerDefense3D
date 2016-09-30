using UnityEngine;
using System.Collections;

namespace Behaviors {
	/// <summary>
	/// Move to destination, don't let anything distract you from that.
	/// </summary>
	[RequireComponent(typeof(MoveToPoint))]
	public class MoveToPosition : AIBehavior {
		MoveToPoint mover;

		void Awake () {
			mover = GetComponent<MoveToPoint> ();
		}

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