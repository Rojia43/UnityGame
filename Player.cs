using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector3 playerPosition;
    public GameObject ground;
    private bool jumping = false;
    private float health = 100.0f;
    [SerializeField]private float colorOffest = 0.1f;

    private void Awake()
    {
        playerPosition = new Vector3();
        gameObject.GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0.15f);
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A)) 
        {
            playerPosition = transform.position;
            playerPosition.x -= 5 * Time.deltaTime;
            transform.position = playerPosition;
        }
        if (Input.GetKey(KeyCode.D))
        {
            playerPosition = transform.position;
            playerPosition.x += 5 * Time.deltaTime;
            transform.position = playerPosition;
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (jumping == false)
            {
                jumping = true;
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject == ground) jumping = false;
    }
}
