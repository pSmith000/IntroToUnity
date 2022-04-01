using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    [SerializeField]
    private float _health;
    [SerializeField]
    private bool _isAlive;
    [SerializeField]
    private bool _destroyOnDeath;

    public float Health
    {
        get { return _health; }
    }

    public bool IsAlive
    {
        get { return _isAlive; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public virtual float TakeDamage(float damageAmount)
    {
        _health -= damageAmount;

        return damageAmount;
    }

    public virtual void onDeath()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (_health < 0 && IsAlive)
            onDeath();

        _isAlive = _health > 0;

        if (!IsAlive && _destroyOnDeath)
            Destroy(gameObject);
    }
}
