using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform camerPos;

    private void Update()
    {
        transform.position = camerPos.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            if (collision.transform.position.x > 0)
            {
                collision.transform.position = new Vector2(-2.8f, collision.transform.position.y);
            }
            else
            {
                collision.transform.position = new Vector2(2.8f, collision.transform.position.y);
            }
        }
    }
}
