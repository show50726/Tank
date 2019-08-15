using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float HealthPoint = 100f;
    public float MaxHealthPoint = 100f;
    public float Score = 0f;
    public SimpleHealthBar healthBar;
    public float colDamage = 20f;
    public float hitDamage = 15f;
    
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPoint <= 0) Death();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            UpdateHealth(HealthPoint - colDamage);
        }

     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            UpdateHealth(HealthPoint - hitDamage);
        }
    }


    public void UpdateHealth(float h)
    {
        HealthPoint = h;
        healthBar.UpdateBar(h, MaxHealthPoint);
    }

    public bool isDeath() {
        if (HealthPoint > 0) return false;
        return true;
    }

    private void Death()
    {
        Destroy(gameObject);
    }

}
