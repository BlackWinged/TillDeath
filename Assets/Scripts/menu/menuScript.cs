using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class menuScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void startArcade()
    {
        SceneManager.LoadScene("fight");
    }

    public void startStory()
    {
        SceneManager.LoadScene("begin");
    }

    public void startTatsumaki()
    {
        SceneManager.LoadScene("tatsumaki");
    }
}
