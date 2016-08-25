using UnityEngine;
using System.Collections;

public class TriggerControl : MonoBehaviour
{
    public LayerMask triggerable;
    public Animator anim;
    public bool isSingleFire = false;

    private bool hasEntered = false;
    private bool hasFired = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasFired)
        {
            if (GetComponent<BoxCollider2D>().IsTouchingLayers(triggerable))
            {
                if (!hasEntered)
                {
                    activateAnimation();
                    hasEntered = true;
                    if (isSingleFire)
                    {
                        hasFired = true;
                    }
                }
            }
            else
            {
                hasEntered = false;
            }
        }
    }

    void activateAnimation()
    {
        if (anim != null)
        {
            anim.SetTrigger("Start");
        }
    }
}
