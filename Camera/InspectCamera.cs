using UnityEngine;
using System.Collections;

public class InspectCamera : MonoBehaviour {
	
	public Transform target;
	public float distance;
	
	public float xSpeed = 250.0f;
	public float ySpeed = 120.0f;
	
	public float yMaxLimit = 80;
	public float yMinLimit = -20;
	
	public float x = 0.0f;
	public float y = 0.0f;
	
	public float zoomInLimit = 2.0f;
	public float zmmonOutLimit = 1.0f;
	
	private float initialFOV;
	
	// Use this for initialization
	void Start () {
		
		Vector3 angles = transform.eulerAngles;
		
	    x = angles.y;
	    y = angles.x;
	
		// Make the rigid body not change rotation
	   	if (rigidbody)
			rigidbody.freezeRotation = true;
		
		initialFOV = camera.fieldOfView;
		InspectTarget(true);
	}
	
	void LateUpdate()
	{
		InspectTarget(false);
	}
	
	/**
	 * 
	 * 
	 * */
	void InspectTarget(bool force)
	{
		//Debug.Log("LastUpdate");
		if( target && ( Input.GetMouseButton(1) || force ) )
		{
			//float delta = Input.GetMouseButton("Mouse ScrollWheel");
			float delta = Input.GetAxis("Mouse ScrollWheel");
			//Debug.Log( delta );
			if( delta != 0)
			{
				float zoom = camera.fieldOfView + ( delta * 1000 * Time.deltaTime );
//				Debug.Log( zoom );
				camera.fieldOfView = Mathf.Clamp( zoom , initialFOV / zoomInLimit , initialFOV / zmmonOutLimit );
			}
			else if( Input.GetKey( KeyCode.RightShift ) || Input.GetKey( KeyCode.LeftShift ) )
			{
				
			}
			else 
			{
				x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
				y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
			}
			y = ClampAngle( y , yMinLimit , yMaxLimit );
			//bool rotation = Quaternion.Equals(y, x, 0);
			Quaternion rotation = Quaternion.Euler(y, x, 0);
			Vector3 position = rotation * new Vector3(0.0f,0.0f,-distance) + target.position;
			transform.rotation = rotation;
			transform.position = position;
		}
	}
	
	public static float ClampAngle(float angle, float min, float max) {
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp(angle, min, max);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
