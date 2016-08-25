using UnityEngine;
using System.Collections;

public class RammerController : MonoBehaviour
{
    public float smoothing = 3;
    public float setTorque = 3;
    public float forceAdd = 3;
    public float maxVelocity = 3;
    private Transform player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.position - transform.position;
        float angleDiff = transform.rotation.eulerAngles.z - rightfaceRotate(direction).eulerAngles.z;
        transform.rotation = Quaternion.Lerp(transform.rotation, rightfaceRotate(direction), Time.deltaTime * smoothing);

        GetComponent<Rigidbody2D>().AddForce(direction * forceAdd);
       // GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, maxVelocity);

        //  GetComponent<Rigidbody2D>().velocity = transform.right * 3;
    }

    Quaternion rightfaceRotate(Vector3 direction)
    {
        return Quaternion.LookRotation(Vector3.forward, direction) * Quaternion.Euler(0, 0, 90);
    }

}
