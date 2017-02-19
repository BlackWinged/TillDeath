using UnityEngine;
using System.Collections;

public class PunchControl : MonoBehaviour
{
    public LayerMask punchables;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (GetComponent<BoxCollider2D>().IsTouchingLayers(punchables))
        {
            Transform hitObject = coll.transform;
            ContactPoint2D[] hitPoints = coll.contacts;
            Vector2 targetPoint = hitPoints[0].point;

            targetPoint = hitObject.InverseTransformPoint(targetPoint);
            hitObject.GetComponent<Rigidbody2D>().AddForceAtPosition(GetComponent<Rigidbody2D>().velocity * 20, targetPoint, ForceMode2D.Impulse);
        }

    }
}
