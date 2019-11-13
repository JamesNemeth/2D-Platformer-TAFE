using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : Enemy
{
    public Vector3 enemyPosition;

    public GameObject ogrePrefab;
    public bool allowSpawn = true;

    public override void Start()
    {
        base.Start();
        ogrePrefab = Resources.Load<GameObject>("Prefabs/Ogre");
    }

    public override void Update()
    {
        base.Update();

        EnemyPos();

        if (health <= 0)
        {
            if (allowSpawn)
            {
                GameObject clone = Instantiate(ogrePrefab, enemyPosition, Quaternion.identity);
                Ogre newOgre = clone.GetComponent<Ogre>();
                newOgre.path = path;
                newOgre.allowSpawn = false;
            }
            Destroy(gameObject);
        }

    }
    public void EnemyPos()
    {
        enemyPosition = transform.position;
    }
}

