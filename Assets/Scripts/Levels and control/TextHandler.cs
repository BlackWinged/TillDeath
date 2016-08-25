using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TextHandler : MonoBehaviour {
    public Text text;
    public BoxCollider2D playerCollider;
    public List<GameObject> disableObjects;
    public List<GameObject> enableObjects;
    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        BoxCollider2D test = GetComponent<BoxCollider2D>();
        if (GetComponent<BoxCollider2D>().IsTouching(playerCollider))
        {
            text.GetComponent<Text>().enabled = true;
            enableObjectsFunction();
            disableObjectsFunction();
        }
    }

    void enableObjectsFunction()
    {
        foreach (GameObject obj in enableObjects)
        {
            obj.SetActive(true);
        }
    }

    void disableObjectsFunction()
    {
        foreach (GameObject obj in disableObjects)
        {
            obj.SetActive(false);
        }
    }
}
