using System;

using UnityEngine;

public class BikeDriver : MonoBehaviour
{
    public Action OnDie { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Rideable"))
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
            OnDie?.Invoke();
        }
    }
}
