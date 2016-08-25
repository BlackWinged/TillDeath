using UnityEngine;
using System.Collections;

public class parentKiller : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.childCount < 1)
        {
            Destroy(gameObject);
        }
	}
}
