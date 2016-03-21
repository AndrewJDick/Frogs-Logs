using UnityEngine;
using System.Collections;

public class FlyPickup : MonoBehaviour {

	[SerializeField]
	private GameObject pickupPrefab;

	void OnTriggerEnter(Collider other) {

		// If the collider (other) is tagged with 'Player', then execute this code
		if(other.CompareTag ("Player")) {

			// add the pickup particles 
			// Quaternion.identity adds no rotation.
			Instantiate (pickupPrefab, transform.position, Quaternion.identity);

			// Decrement the total number of flies
			FlySpawner.totalFlies--;

			// Update the score
			ScoreCounter.score ++;

			Destroy(gameObject);
		}
	}
}
