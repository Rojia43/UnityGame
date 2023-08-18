using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public RectTransform target; // Assign the target GameObject in the Inspector
    public LayerMask targetLayer;
    private GameObject lockedTarget = null;
    public float speed = 1.0f;

    private float visuality = 10f;

    void Update()
    {
        if (lockedTarget == null) return;
        Vector3 movement = lockedTarget.transform.position - transform.position;
        movement.x = (movement.x / Mathf.Abs(movement.x)) * speed * Time.deltaTime;
        movement.y = 0;
        transform.position += movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.transform != target) return;
        Vector2 direction = target.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, visuality, targetLayer);

        if (hit.collider != null && hit.collider.transform == target)
        {
            lockedTarget = hit.collider.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.transform != target) return;
        lockedTarget = null;
    }
}
