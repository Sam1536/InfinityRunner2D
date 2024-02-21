using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : EnemyGlobal
{
    public GameObject prefabBomb;
    public Transform bombPoint;

    public float throwTime;
    private float throwCount;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        throwCount += Time.deltaTime;

        if (throwCount >= throwTime)
        {
            //arremessa a bomba
            Instantiate(prefabBomb, bombPoint.position,bombPoint.rotation);
            throwCount = 0f;
        }
    }
}
