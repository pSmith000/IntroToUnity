using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementBehavior : MovementBehavior
{
    [SerializeField]
    private Transform _target;
    [SerializeField]
    private float _speed;

    public float Speed
    {
        get { return _speed; }
        set { _speed = value; }
    }

    public Transform Target
    {
        get { return _target; }
        set { _target = value; }
    }

    // Update is called once per frame
    public override void Update() 
    {
        Vector3 direction = _target.position - transform.position;
        Velocity = direction.normalized * Speed;

        base.Update();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == _target)
        {
            //Increase the enemy count if the target was a goal
            GoalBehavior goal = other.GetComponent<GoalBehavior>();
            if (goal)
                goal.EnemyCount++;
            //Destroy this enemy
            Destroy(gameObject);
        }
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
