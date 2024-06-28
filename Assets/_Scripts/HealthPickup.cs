using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public int healthRestore = 20;
    public Vector3 spinRotation = new Vector3(0, 180, 0);

    AudioSource pickupSound;

    private void Awake()
    {
        pickupSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable)
        {
           damageable.Heal(healthRestore);                       
               if(pickupSound) AudioSource.PlayClipAtPoint(pickupSound.clip, gameObject.transform.position, pickupSound.volume);

            Destroy(gameObject);            
        }
    }

    private void Update()
    {
        transform.eulerAngles += spinRotation * Time.deltaTime;
    }
}
