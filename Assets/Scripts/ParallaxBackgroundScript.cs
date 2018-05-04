using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackgroundScript : MonoBehaviour {

	// Background scroll speed can be set in Inspector with slider
	[Range(1f, 20f)]
	public float scrollSpeed = 1f;

	// Scroll offset value to repeat background
	public float scrollOffset;

	// Start position of background movement
	Vector2 startPosition;

	// New position of background
	float newPosition;

	// Initialization
	void Start () {
		// Get start position of background
		startPosition = transform.position;
	}
	
	// Update to be called per frame
	void Update () {
		// Calculate new backgrounds position repeating it depending on scrollOffset
		newPosition = Mathf.Repeat (Time.time * - scrollSpeed, scrollOffset);

		// Set new position
		transform.position = startPosition + Vector2.right * newPosition;
	}
}
