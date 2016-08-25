using UnityEngine;
using System.Collections;

public class moveCamera : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = transform.position;
        newPos.x += Input.GetAxis("Horizontal");
        newPos.y += Input.GetAxis("Vertical");
        transform.position = newPos;
    }
}
