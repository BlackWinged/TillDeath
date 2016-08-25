using UnityEngine;
using System.Collections;

public class BlastoffScript : MonoBehaviour {
    public delegate void killParent();
    public event killParent onFinish;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
 
	}
    void destroy()
    {
        if (onFinish != null)
        {
            onFinish();
        }
        else
        {
        Destroy(gameObject);
        }
    }
}
