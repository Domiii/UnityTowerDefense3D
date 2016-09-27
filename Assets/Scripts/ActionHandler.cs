using UnityEngine;
using System.Collections;

public class ActionHandler : MonoBehaviour {
	#region Action Management
	public GameAction LastAction {
		get;
		private set;
	}

	public void Dispatch<A>(A action)
		where A : GameAction
	{
		var lastActionName = LastAction != null ? LastAction.Name : null;
		action.PreviousActionName = lastActionName;

		// always first cancel current action
		//DoCancelCurrentAction ();

		if (action.HasActionChanged) {
			SendMessage ("Stop" + lastActionName, action, SendMessageOptions.DontRequireReceiver);
			SendMessage ("Start" + action.Name, action, SendMessageOptions.DontRequireReceiver);
		}

		SendMessage (action.Name, action, SendMessageOptions.DontRequireReceiver);

		LastAction = action;
	}

	public void StopCurrentAction() {
		Dispatch (Actions.Idle.Default);
	}
	#endregion
}

public abstract class GameAction
{
	public string PreviousActionName;

	public bool HasActionChanged {
		get {
			return PreviousActionName != Name;
		}
	}

	public abstract string Name { get; }
}


#region Actions
public static class Actions {
	public class Idle : GameAction {
		public static readonly Idle Default = new Idle();

		public override string Name { get { return "Idle"; } }
	}
	public class Attack : GameAction {
		public Unit Target;

		public override string Name { get { return "Attack"; } }
	}
	public class Move : GameAction {
		public Vector3 Destination;

		public override string Name { get { return "Move"; } }
	}
}
#endregion