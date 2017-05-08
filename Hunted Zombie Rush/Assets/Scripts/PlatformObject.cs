using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformObject : MonoBehaviour {

    [SerializeField] private float objectSpeed = 1;
    [SerializeField] private float resetPosition = 4.6f;
    [SerializeField] private float startPosition = -131.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	protected virtual void Update () {

        if (!GameManager.instance.GameOver) {

            transform.Translate(Vector3.right * (objectSpeed * Time.deltaTime));

            if (transform.localPosition.x >= resetPosition) {
                Vector3 newPosition = new Vector3(startPosition, transform.position.y, transform.position.z);
                transform.position = newPosition;
            }
        }
	}
}