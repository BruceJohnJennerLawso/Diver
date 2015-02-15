using UnityEngine;
using System.Collections;

public class BouyancyScript : MonoBehaviour {

	public float radius = 1; //m (Units)

	public Vector3 upthrustMonitor;

	private float mass;
	private Rigidbody rigidBody;
	private float waterDensity = 1000; //kg/m^3

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
		float submergedRadius = (transform.position.y - radius) * -1;
		if (submergedRadius < 0) {
			return new Vector3(0,0,0);
		}
		if (submergedRadius > radius * 2) {
			submergedRadius = radius * 2;
		}
		float submergedVolume = ((Mathf.PI * submergedRadius * submergedRadius) / 3) * ((3 * radius) - submergedRadius);
		Vector3 weight = mass * Physics.gravity;
		Vector3 upthrust = submergedVolume * waterDensity * Physics.gravity;
		upthrustMonitor = upthrust;
		return weight - upthrust;
	}
}
