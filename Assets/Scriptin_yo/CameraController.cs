using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 
{	// ANSI-C FUUUUUUUUUUUUUUUU
	public float forceValue;
	public float torqueValue;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{	float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

//		Vector3 Movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		Vector3 Movement = new Vector3 (0.0f, 0.0f, moveVertical);
		rigidbody.AddRelativeForce (Movement*forceValue*Time.deltaTime);
		//bwahahaha
		Vector3 Rotation = new Vector3 (0, moveHorizontal, 0);
		rigidbody.AddTorque (Rotation*torqueValue*Time.deltaTime);
		// lets find a vector3 value foist
	}
	// FixedUpdate called before physics frames
	// guess synchronizing physics with graphics eventually
	// becomes a nono
	void FixedUpdate () 
	{	
		
	}
}
