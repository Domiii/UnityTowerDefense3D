using UnityEngine;
using System.Collections;

public class GameInputManager : MonoBehaviour {
	public float CameraSensitivity = 30;
	public float CameraMaxZ = -10;
	public float CameraMinZ = -50;
	public float CameraMaxTilt = 60;
	public float CameraMinTilt = 10;

	Vector3 defaultCameraPos;
	Quaternion defaultCameraRotation;

	Transform CameraMount {
		get {
			Transform trans;
			if (Camera.main.transform.parent != null) {
				trans = Camera.main.transform.parent;
			} else {
				trans = Camera.main.transform;
			}
			return trans;
		}
	}

	Quaternion CameraRotation {
		get {
			return CameraMount.localRotation;
		}
		set {
			CameraMount.localRotation = value;
		}
	}

	void Start() {
		defaultCameraPos = Camera.main.transform.localPosition;
		defaultCameraRotation = CameraRotation;
	}

	void Update() {
		UpdateCameraZoom ();
		UpdateCameraTilt ();
		ResetCameraDefaults ();
	}

	void UpdateCameraZoom() {
		var dPos = Input.GetAxis ("Mouse ScrollWheel");
		if (dPos != 0) {
			dPos = dPos * CameraSensitivity * Time.deltaTime;
			var newPos = Camera.main.transform.localPosition;
			newPos.z = Mathf.Clamp (newPos.z + dPos, CameraMinZ, CameraMaxZ);
			Camera.main.transform.localPosition = newPos;
		}
	}

	void UpdateCameraTilt() {
		var dTilt = Input.GetAxis ("Vertical");
		if (dTilt != 0) {
			dTilt = dTilt * CameraSensitivity * Time.deltaTime;

			var localRotation = CameraRotation;
			var newAngles = localRotation.eulerAngles;
			newAngles.x = Mathf.Clamp (newAngles.x + dTilt, CameraMinTilt, CameraMaxTilt);
			localRotation.eulerAngles = newAngles;
			CameraRotation = localRotation;
		}
	}

	void ResetCameraDefaults() {
		if (Input.GetKeyDown(KeyCode.V)) {
			Camera.main.transform.localPosition = defaultCameraPos;
			CameraRotation = defaultCameraRotation;
		}
	}
}
