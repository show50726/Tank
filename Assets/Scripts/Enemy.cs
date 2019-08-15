using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float healthPoint = 150f;
    public float Maxhealthpoint = 150f;
    private Player p;
    public int Point = 50;
    public GameSystemManager GSM;
	// Use this for initialization
	void Start () {
        GameObject pl = GameObject.Find("Player");
        p = pl.GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void UpdateHealth(float health)
    {
        healthPoint = health;
        if (health <= 0) Death();
    }

    private void Death() {
        GSM.UpdatePoint(GSM.point + Point);
        GSM.EnemyCount--;
        Destroy(gameObject);
    }

}
