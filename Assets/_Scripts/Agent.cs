using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Agent : MonoBehaviour
{
    Collider2D agenteCollider2D;
    public Collider2D AgenteCollider2D
    {
        get { return agenteCollider2D; }
    }

    // Start is called before the first frame update
    void Start()
    {
        agenteCollider2D = GetComponent<Collider2D>();
    }

    public void Move(Vector2 velocity)
    {
        transform.up = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }
}
