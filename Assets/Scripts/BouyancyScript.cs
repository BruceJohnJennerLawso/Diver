using UnityEngine;
using System.Collections;

public class BouyancyScript : MonoBehaviour {

	public float radius = 1; //m

	//DEBUG TOOL: public Vector3 upthrustMonitor;

	private float mass; //kg
	private Rigidbody rigidBody;
	private float waterDensity = 1025; //kg/m^3

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody> ();
		mass = rigidbody.mass;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// Physics Update
	void FixedUpdate() {
		Vector3 bouyancy = findBouyancy ();
		rigidbody.AddForce (bouyancy);
	}

	// Calculates the bouyancy force the object is experiencing.
	// Assumes object is a sphere and water is at y=0
	// Separate to keep FixedUpdate clean.
	Vector3 findBouyancy() {
		float submergedRadius = (transform.position.y - radius) * -1; // * -1 so submerged radius is positive when underwater and negative when not.
		if (submergedRadius < 0) { // If we're above the water
			return new Vector3(0,0,0); // No upthrust, return 0.
		}
		if (submergedRadius > radius * 2) { // If we're totally below the water
			submergedRadius = radius * 2; // We can't get any more submerged than 2 * radius.
		}
		float submergedVolume = ((Mathf.PI * submergedRadius * submergedRadius) / 3) * ((3 * radius) - submergedRadius); // Just trust me with this.
		float localDensity;
		if (transform.position.y > 0) {
			localDensity = waterDensity;
		} else if (transform.position.y < -1000) {
			localDensity = waterDensity + 3;
		} else {
			localDensity = waterDensity + ( 3 * Mathf.Abs(transform.position.y/1000));
		}
		Vector3 upthrust = submergedVolume * localDensity * Physics.gravity * -1; // Gravity points down, upthrut points up.
		//DEBUG TOOL: upthrustMonitor = upthrust;
		return upthrust;
	}
}
