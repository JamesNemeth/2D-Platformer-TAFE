using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ogre : Enemy
{
    public Vector3 enemyPosition;

    public GameObject ogrePrefab;
    public bool allowSpawn = true;

    protected override void Start()
    {
        // Allows this script to use the everything in the Start function in Enemy
        base.Start();

        // Gets the ogre prefab from the assests
        ogrePrefab = Resources.Load<GameObject>("Prefabs/Ogre");
    }
    protected override void Update()
    {
        // Allows this script to use the everything in the Update function in Enemy
        base.Update();

        // Calls on the EnemyPos Function
        EnemyPos();

        if (health <= 0)
        {
            if (allowSpawn)
            {
                // Spawns a new Ogre and makes it contuine on its way points
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
        // Makes the cloned ogre spawn on the original ogre
        enemyPosition = transform.position;
    }
}

