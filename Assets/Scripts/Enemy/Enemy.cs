using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public int health;
    public float speed;
    public WayPoints path;
    private Transform target;
    private int currentWaypoint = 0;

    protected virtual void Start()
    {
        target = path.points[currentWaypoint];
    }
    protected virtual void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
            //animator.SetBool("isDead", true);
        }

        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    private void GetNextWaypoint()
    {
        currentWaypoint++;
        if (currentWaypoint >= path.points.Length)
        {
            currentWaypoint = 0;
        }
        target = path.points[currentWaypoint];
    }
}