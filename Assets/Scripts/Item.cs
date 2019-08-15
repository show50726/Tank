using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int point = 0;
    public float restore = 0;
    public float RotateSpeed = 1f;
    public GameSystemManager GSM;
    public AudioSource audio;
    // Use this for initialization

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0f, RotateSpeed, 0f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Bullet")
        {
            Player p = other.GetComponent<Player>();
            if(p && restore > 0)
            {
                p.UpdateHealth(p.HealthPoint + restore);
            }
            GSM.UpdatePoint(point);
            audio.Play();
            Destroy(gameObject, 0.05f);
        }
    }
}