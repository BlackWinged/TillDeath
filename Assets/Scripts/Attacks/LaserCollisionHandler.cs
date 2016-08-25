using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LaserCollisionHandler : MonoBehaviour
{
    public LayerMask Ground;
    public LayerMask Player;
    public float maxRange;
    public float forceAdd = 100f;
    public float maxVelocity = 15f;
    public float damage = 20;
    public float forceAmount = 500;

    private Vector3 positionOld;
    private float distance;
    private Transform player;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        positionOld = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        distance += Vector2.Distance(transform.position, positionOld);
        if (GetComponent<PolygonCollider2D>().IsTouchingLayers(Ground) || distance > maxRange)
        {
            Destroy(gameObject);
        }
        positionOld = transform.position;

        Vector3 direction = player.position - transform.position;
        GetComponent<Rigidbody2D>().drag = 0;
        GetComponent<Rigidbody2D>().AddForce(direction * forceAdd);
        GetComponent<Rigidbody2D>().velocity = Vector3.ClampMagnitude(GetComponent<Rigidbody2D>().velocity, maxVelocity);

        if (GetComponent<PolygonCollider2D>().IsTouchingLayers(Player))
        {
            if (GetComponent<PolygonCollider2D>().IsTouching(player.GetComponent<BoxCollider2D>()))
            {
                player.GetComponent<healthControl>().takeDamage(damage, GetComponent<Rigidbody2D>().velocity, forceAmount);

            }
            else
            {
                List<GameObject> enemies = new List<GameObject>();
                enemies.AddRange(GameObject.FindGameObjectsWithTag("EnemyWithArm"));
                foreach (GameObject enemy in enemies)
                {
                    if (GetComponent<PolygonCollider2D>().IsTouching(enemy.GetComponent<BoxCollider2D>()))
                    {
                        enemy.GetComponent<healthControl>().takeDamage(damage, GetComponent<Rigidbody2D>().velocity, forceAmount);
                    }
                }
            }
           death(gameObject);
        }

    }


    void death(GameObject e)
    {
        if (e.transform.parent != null)
        {
            death(e);
        }
        Destroy(e);
    }


}
