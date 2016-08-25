using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MurderTentacleHandler : MonoBehaviour
{
    public float dps = 20;
    public float forceAmount = 300;
    public LayerMask canDamage;

    private Transform player;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GetComponent<BoxCollider2D>().IsTouchingLayers(canDamage))
        {
            player.GetComponent<healthControl>().takeDamageWithForce(dps * Time.deltaTime, GetComponent<Rigidbody2D>().velocity, forceAmount);
        }
    }


}
