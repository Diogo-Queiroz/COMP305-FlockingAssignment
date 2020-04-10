using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Agent : MonoBehaviour
{
    Flocking agentFlocking;
    public Flocking AgentFlocking => agentFlocking;

    Collider2D agenteCollider2D;
    public Collider2D AgenteCollider2D => agenteCollider2D;

    public void Init(Flocking flocking)
    {
        agentFlocking = flocking;
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
