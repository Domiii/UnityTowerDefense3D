using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ActionHandler))]
public class PlayerControl : MonoBehaviour {
	public Vector3 currentDestination;

	ActionHandler actionHandler;

	void Start () 
	{
		actionHandler = GetComponent<ActionHandler> ();
	}

	void Update()
	{
		CheckClick ();
	}

	void CheckClick() {
		if (Input.GetMouseButtonDown (0))
		{
			HandleMouse (true);
		}
		else if (Input.GetMouseButton(0))
		{
			HandleMouse (false);
		}
	}

	void HandleMouse(bool clicked) {
		Ray screenRay = Camera.main.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;
		if (Physics.Raycast(screenRay, out hit))
		{
			HandleCursorRay (hit, clicked);
		}
	}

	void HandleCursorRay (RaycastHit hit, bool clicked)
	{
		if (clicked) {
			// clicking -> attack or move
			var go = hit.collider.gameObject;
			var unit = go.GetComponent<Unit> ();

			if (unit != null) {
				// clicked a unit -> attack if enemy
				actionHandler.Dispatch (new Actions.Attack {
					Target = unit
				});
			} else {
				// did not click on a unit -> just move
				actionHandler.Dispatch (new Actions.Move {
					Destination = hit.point
				});
			}
		}
		else {
			// dragging -> keep moving, if already moving
			if (actionHandler.LastAction is Actions.Move) {
				actionHandler.Dispatch (new Actions.Move {
					Destination = hit.point
				});
			}
		}
	}
}