using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{

    protected override void Update()
    {
        // Allows this script to use the everything in the Update function in Enemy
        base.Update();

        // Constantly rotates the spider on the z axis
        transform.Rotate(new Vector3(0f, 0f, 100f) * Time.deltaTime);

    }
}
