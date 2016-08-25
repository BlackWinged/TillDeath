using UnityEngine;
using System.Collections;

public class smashHandler : MonoBehaviour
{
    public Transform her;
    public Transform him;
    public Transform herPosition;
    public Transform himPosition;
    public LayerMask collideable;

    public float coolDownInterval = 0.3f;
    private bool hasEntered = false;
    private Vector2 oldPos;
    // Use this for initialization
    void Start()
    {
        oldPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        stabilize();
        testFire();
    }



    void stabilize()
    {
        Vector2 directionOfHer = herPosition.position - her.position;
        Vector2 directionOfHim = himPosition.position - him.position;
        Vector2 posDifference = (Vector2)transform.position - oldPos;
        oldPos = transform.position;

        her.GetComponent<Rigidbody2D>().AddForce((directionOfHer * 20) + randomInterference(), ForceMode2D.Force);
        him.GetComponent<Rigidbody2D>().AddForce((directionOfHim * 20) + randomInterference(), ForceMode2D.Force);
        her.transform.position += (Vector3)posDifference;
        him.transform.position += (Vector3)posDifference;
    }

    void testFire()
    {
        RaycastHit2D hit = Physics2D.BoxCast(her.position, new Vector2(0.5f, 0.5f), 0, him.position - her.position, Vector2.Distance(her.position, him.position), collideable);
        if (hit.transform != null)
        {
            if (!hasEntered)
            {
                hasEntered = true;
                Vector2 directionOfHer = her.position - him.position;
                Vector2 directionOfHim = him.position - her.position;

                him.GetComponent<Rigidbody2D>().AddForce(directionOfHer * 30, ForceMode2D.Impulse);
                her.GetComponent<Rigidbody2D>().AddForce(directionOfHim * 30, ForceMode2D.Impulse);
            }
        }
        else
        {
            hasEntered = false;
        }
    }


    Vector2 randomInterference()
    {
        return Random.insideUnitCircle;
    }
}
