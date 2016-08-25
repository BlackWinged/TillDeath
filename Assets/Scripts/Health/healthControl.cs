using UnityEngine;
using System.Collections;

public class healthControl : MonoBehaviour {

    public float hp = 100;
    public bool usesDefaultDeath = true;
    private Vector2 force;
    private bool isDamaged = false;
    private int damageFrameCount = 3;
    private int FrameCount = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	if (isDamaged)
        {
            if (FrameCount < damageFrameCount)
            {
                FrameCount++;
                GetComponent<Rigidbody2D>().AddForce(force);
            } else
            {
                isDamaged = false;
                FrameCount = 0;
            }
        }
	}

    public void takeDamage(float dmg)
    {
        hp -= dmg;
        if (hp<=0 && usesDefaultDeath)
        {
            death(gameObject);
        }
    }

    public void takeDamageWithForce(float dmg, Vector2 direction, float amount)
    {
        takeDamage(dmg);
        direction = direction.normalized;
        force = direction * amount;
        isDamaged = true;
        
    }

    public void takeDamage(float dmg, Vector2 direction, float amount)
    {
        takeDamage(dmg);
        direction = direction.normalized;
        GetComponent<Rigidbody2D>().velocity = direction * amount;
    }

    public float getHpForMeter()
    {
        PolygonCollider2D test = new PolygonCollider2D();
        return hp / 100;
    }

    public void heal(float heal)
    {
        if (hp < 100)
        {
            hp += heal;
            if (hp > 100)
            {
                hp = 100;
            }
        }
    }

    void death(GameObject e)
    {
        if (e.transform.parent != null)
        {
            death(e.transform.parent.gameObject);
        }
        Destroy(e);
    }
}
