using UnityEngine;
using System.Collections;

public class flightControl : MonoBehaviour {
    public float flightForceModifier = 10;
    public float friction = 5;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
        if (GetComponent<playerInput>().touch)
        {
            GetComponent<Rigidbody2D>().drag = 1;
            Vector2 target = GetComponent<playerInput>().positions[0] - transform.position;
            target = target.normalized;

            GetComponent<Rigidbody2D>().AddForce((Vector3)target * flightForceModifier);
        } else
        {
            GetComponent<Rigidbody2D>().drag = friction;
        }

	}
}
