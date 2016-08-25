using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour
{
    public float maxVelocity;
    public float drag = 0.5f;
    public float forceAdd = 100f;
    public float stickTimer = 0.2f;
    public int jumpsAllowed = 3;

    public float castDistance = 1;
    public LayerMask groundMask;

    public Transform blastOff;
    public bool isJumpEnabled = true;

    private float Timer = 0.2f;
    private bool holding = false;
    private float gravFactor;
    private int jumpsUsed = 0;
    // Use this for initialization
    void Start()
    {
        gravFactor = GetComponent<Rigidbody2D>().gravityScale;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 direction = GetComponent<playerInput>().positions[0] - transform.position;
        direction = direction.normalized;
        if (!checkGrounding().Equals(Vector3.zero))
        {
            jumpsUsed = 0;
        }
        if (isJumpEnabled)
        {
            jumpHandle(direction);
        }
        motionHandle();
    }

    private void motionHandle()
    {
        if (checkGrounding().Equals(Vector3.up) && Timer >= 0)
        {
            Timer -= Time.deltaTime;
            GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = gravFactor;
        }
        if (GetComponent<playerInput>().touch)
        {
            if (checkGrounding().Equals(Vector3.down))
            {
                if (GetComponent<playerInput>().positions[0].x > transform.position.x)
                {
                    addMotionForce(Vector2.right);
                }
                if (GetComponent<playerInput>().positions[0].x < transform.position.x)
                {
                    addMotionForce(Vector2.left);
                }
                return;
            }
            if (checkGrounding().Equals(Vector3.left) || checkGrounding().Equals(Vector3.right))
            {
                if (GetComponent<playerInput>().positions[0].y > transform.position.y)
                {
                    addMotionForce(Vector2.up);
                }
                if (GetComponent<playerInput>().positions[0].y < transform.position.y)
                {
                    addMotionForce(Vector2.down);
                }
            }
            if (checkGrounding().Equals(Vector3.up))
            {
                Timer = stickTimer;
                if (GetComponent<playerInput>().positions[0].x > transform.position.x)
                {
                    addMotionForce(Vector2.right);
                }
                if (GetComponent<playerInput>().positions[0].x < transform.position.x)
                {
                    addMotionForce(Vector2.left);
                }
                return;
            }
        }
    }

    private void addMotionForce(Vector2 direction)
    {
        GetComponent<Rigidbody2D>().AddForce(direction * forceAdd);
        GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, maxVelocity);
    }
    private Vector3 jumpHandle(Vector3 direction)
    {
        if (GetComponent<playerInput>().touch)
        {
            if (!holding && jumpsUsed != jumpsAllowed)
            {
                GetComponent<Rigidbody2D>().velocity = direction * 10000;
                GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, maxVelocity);
                jumpsUsed++;
                if (GetComponent<playerInput>().positions[0].y < transform.position.y)
                {
                    Quaternion turn = new Quaternion();
                    turn.eulerAngles = new Vector3(0, 0, 180);
                    Instantiate(blastOff, transform.position, turn);
                }
                else
                {
                    Instantiate(blastOff, transform.position, new Quaternion());
                }
                holding = true;
            }
        }
        else
        {
            holding = false;
            //GetComponent<Rigidbody2D>().drag = drag;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            direction = GetComponent<playerInput>().positions[0] - transform.position;
            direction *= 10000;
            direction = Vector3.ClampMagnitude(direction, 1);
            direction = new Vector3(direction.x, direction.y, 0);
            GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(direction * 10000, maxVelocity);
            transform.Translate(direction * 10);
        }

        return direction;
    }

    Vector3 checkGrounding()
    {
        Debug.DrawLine(transform.position, transform.position + new Vector3(0, castDistance, 0));
        GetComponent<Rigidbody2D>().drag = drag;
        if (Physics2D.Raycast(transform.position, Vector3.down, castDistance, groundMask))
        {
            return Vector2.down;
        }

        if (Physics2D.Raycast(transform.position, Vector3.left, castDistance, groundMask))
        {
            return Vector2.left;
        }
        if (Physics2D.Raycast(transform.position, Vector3.right, castDistance, groundMask))
        {
            return Vector2.right;
        }
        if (Physics2D.Raycast(transform.position, Vector3.up, castDistance, groundMask))
        {
            return Vector2.up;
        }
        GetComponent<Rigidbody2D>().drag = 0;
        return Vector3.zero;
    }

    public int getJumpsUsed()
    {
        return jumpsUsed;
    }
}
