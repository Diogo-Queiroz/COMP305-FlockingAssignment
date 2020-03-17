using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Flocking : MonoBehaviour
{
    private List<Agent> _agents = new List<Agent>();
    private float _squareMaxSpeed;
    private float _squareNeighborRadiusSize;
    private float _squareDistance;
   
    private const float Density = 0.08f;

    public Agent agentPrefab;
    public Behaviour behaviour;
    public float SquareDistance => _squareDistance;

    [Range(10, 500)] public int startSize = 250;
    [Range(1f, 100f)] public float drive = 10f;
    [Range(1f, 100f)] public float maxSpeed = 5f;
    [Range(1f, 10f)] public float neighborRadiusSize = 1.5f;
    [Range(0f, 1f)] public float distanceMultiplier = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        _squareMaxSpeed = Mathf.Pow(maxSpeed, 2);
        _squareNeighborRadiusSize = Mathf.Pow(neighborRadiusSize, 2);
        _squareDistance = _squareNeighborRadiusSize * Mathf.Pow(distanceMultiplier, 2);

        for (var i = 0; i < startSize; i++)
        {
            var newAgent = Instantiate(
                agentPrefab,
                Random.insideUnitCircle * startSize * Density,
                Quaternion.Euler(Vector3.forward * Random.Range(0f, 360f)),
                transform
            );
            newAgent.name = "Agent" + i;
            _agents.Add(newAgent);
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (var i = 0; i < _agents.Count; i++)
        {
            var context = GetNearbyObjects(_agents[i]);

            // FOR DEMONISTRATION
            _agents[i].GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(
                Color.white, Color.red, context.Count / 6f
            );
            
            
            //var velocity = behaviour.CalculateMovement(
            //    _agents[i], context, this
            //);
            //velocity *= drive;
            //if (velocity.sqrMagnitude > _squareMaxSpeed)
            //    velocity = velocity.normalized * maxSpeed;
            //_agents[i].Move(velocity);
        }
    }

    private List<Transform> GetNearbyObjects(Agent agent)
    {
        var contextCollider2Ds = Physics2D.OverlapCircleAll(
            agent.transform.position,
            neighborRadiusSize
        );

        return contextCollider2Ds.Select(t => t.transform).ToList();
    }
}
