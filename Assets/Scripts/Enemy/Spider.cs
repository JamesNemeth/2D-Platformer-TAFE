using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy
{

    public override void Update()
    {
        base.Update();

        transform.Rotate(new Vector3(0f, 0f, 100f) * Time.deltaTime);
    }
}
