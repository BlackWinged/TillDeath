using UnityEngine;
using System.Collections;

public class ShootingGuyController : MonoBehaviour
{
    public Transform laser;
    public float shotInterval = 0.8f;
    public float maxShotSpeed;
    public LayerMask ground;

    private float Timer;
    private Transform player;
    private BoxCollider2D playerCollider;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerCollider = player.GetComponentInChildren<BoxCollider2D>();
    }

    void FixedUpdate()
    {
        Timer -= Time.deltaTime;

        if (Timer <= 0)
        {
            //if (Vector2.Distance(player.position, transform.position) < reactionDistance)
            //{
            fire();
            //}
            Timer = shotInterval;
        }
        if (GetComponent<BoxCollider2D>().IsTouchingLayers(ground))
        {
            death();
        }
    }

    void fire()
    {
        Transform shot = (Transform)Instantiate(laser);
        shot.position = transform.position;
        Vector2 velocity = calculateLeadingVelocity(2);
        shot.rotation = rightfaceRotate(velocity);
        shot.GetComponent<Rigidbody2D>().velocity = velocity * 300;
        shot.GetComponent<Rigidbody2D>().velocity = Vector2.ClampMagnitude(shot.GetComponent<Rigidbody2D>().velocity, maxShotSpeed);

    }

    Vector2 calculateLeadingVelocity(int iterations)
    {
        float timeFlight = 0;
        Vector2 target = (Vector2)player.position;
        for (int i = 0; i < iterations; i++)
        {
            timeFlight = Vector2.Distance(transform.position, target) / maxShotSpeed;
            target = target + (player.GetComponent<Rigidbody2D>().velocity * timeFlight);
        }
        target = (Vector2)player.position;
        target = target + (player.GetComponent<Rigidbody2D>().velocity * timeFlight);

        return target - (Vector2)transform.position;
    }

    Quaternion rightfaceRotate(Vector3 direction)
    {
        return Quaternion.LookRotation(Vector3.forward, direction) * Quaternion.Euler(0, 0, 90);
    }

    void death()
    {
        Destroy(gameObject);
    }

}
