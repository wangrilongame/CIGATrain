using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    public GameObject Floodlight;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Train"))
        {
            GameManager.Instance.ChangePassengerNumber(1);
            Instantiate(Floodlight, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
