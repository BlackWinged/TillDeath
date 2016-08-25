using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class enemySpawn : MonoBehaviour {
    public float spawnInterval = 10;
    public List<Transform> potentialEnemies;
    public BoxCollider2D spawnRect;

    private float timer = 0;
	// Use this for initialization
	void Start () {
        timer = spawnInterval;
	}
	
	// Update is called once per frame
	void Update () {
        checkForEnemy();
	}

    void checkForEnemy()
    {
        int pickEnemy = (int)Mathf.Floor(potentialEnemies.Count * Random.value);
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            float xCood = spawnRect.transform.position.x + Random.Range(spawnRect.bounds.extents.x * -1, spawnRect.bounds.extents.x);
            float yCood = spawnRect.transform.position.y + Random.Range(spawnRect.bounds.extents.y * -1, spawnRect.bounds.extents.y);
            Instantiate(potentialEnemies[pickEnemy], new Vector3(xCood, yCood, 0), new Quaternion(0, 0, 0, 0));
            timer = spawnInterval;
        }
    }
}
