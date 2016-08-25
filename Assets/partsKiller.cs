using UnityEngine;
using System.Collections;

public class partsKiller : MonoBehaviour {
    public float lifetimeDistance = 5f;

    private Vector2 oldPosition;
    private float distancePassed = 0;
	// Use this for initialization
	void Start () {
        oldPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        distancePassed += Vector2.Distance(oldPosition, transform.position);
        oldPosition = transform.position;
        if (distancePassed > lifetimeDistance)
        {
            Destroy(gameObject);
        }
	}
}
