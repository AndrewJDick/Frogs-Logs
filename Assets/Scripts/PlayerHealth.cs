using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public bool alive; 

	[SerializeField]
	private GameObject pickupPrefab;

	// Use this for initialization
	void Start () {
	
		alive = true;
	}
	
	void OnTriggerEnter(Collider other) {

		if (other.CompareTag ("Enemy") && (alive == true)) {
		
			alive = false;

			// Create the pickup particlues
			// Instantiate takes 3 arguments - 1) Prefab to create ; 2) position it should be created ; 3) the rotation
			// Quaternion.identity == no rotation
			Instantiate(pickupPrefab, transform.position, Quaternion.identity);
		}

	}

	
}
