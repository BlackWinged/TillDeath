using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class playerHealthControl : MonoBehaviour
{
    public Slider hpMeter;
    public float healPerSecondPercentage = 25;
    public float damageCooldown = 2;
    public bool isHpEnabled;
    public bool isHealConstant = true;

    private float lastHp;
    private float damageTimer = 0;
    // Use this for initialization
    void Start()
    {
        lastHp = GetComponent<healthControl>().getHpForMeter();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHpEnabled)
        {
            float buff = GetComponent<healthControl>().getHpForMeter();
            float hpForMeter = GetComponent<healthControl>().getHpForMeter();
            hpMeter.value = Mathf.Lerp(hpMeter.value, buff, 5 * Time.deltaTime);
            Debug.LogWarning("lastHp: " + lastHp);
            Debug.LogWarning("hpForMeter: " + GetComponent<healthControl>().getHpForMeter());
            if (Mathf.Round(lastHp * 100) /100 > Mathf.Round(hpForMeter * 100) / 100)
            {
                Debug.LogWarning("timer reset!");
                damageTimer = damageCooldown;
            }
            if (damageTimer <= 0)
            {
                healRegulator();
            }
            else
            {
                damageTimer -= Time.deltaTime;
            Debug.LogWarning(damageTimer);
            }
            if (GetComponent<healthControl>().getHpForMeter() <= 0)
            {
                SceneManager.LoadScene("mainmenu");
            }
            lastHp = GetComponent<healthControl>().getHpForMeter();
        }
    }

    void healRegulator()
    {
        float healingFactor = healPerSecondPercentage * Time.deltaTime;
        if (!isHealConstant)
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude > 0.3)
            {
                healingFactor = healPerSecondPercentage / 3 / Time.deltaTime;
            }
            if (GetComponent<playerControl>().getJumpsUsed() > 1)
            {
                healingFactor = 0;
            }
        }
        GetComponent<healthControl>().heal(healingFactor);
    }
}
