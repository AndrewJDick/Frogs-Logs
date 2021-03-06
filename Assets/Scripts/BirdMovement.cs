﻿using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {

	// Set up a field in Unity that allows us to assign the Player pre-fab as the target.
	[SerializeField]
	private Transform target;

	private NavMeshAgent birdAgent;
	private Animator birdAnimator; 


	// Use this for initialization	
	void Start () {
		birdAgent = GetComponent<NavMeshAgent> ();
		birdAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		//set the bird's destination
		birdAgent.SetDestination(target.position);

		//measure the magnitude of the nav mesh agent's velocity
		float speed = birdAgent.velocity.magnitude; 

		// pass the velocity to the animator component 
		birdAnimator.SetFloat ("Speed", speed);
	
	}
}
