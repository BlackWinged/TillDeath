using UnityEngine;
using System.Collections;

public class fallingEnemyHandler : MonoBehaviour {
    public GameObject deathObject;
    private int touchCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
             Instantiate(deathObject, transform.position, transform.rotation);
            Destroy(gameObject);
        
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        touchCount--;
    }

}
