using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public List<GameObject> EnemiesList = new List<GameObject>();

    private float timeCount;
    public float SpawnTime;




    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;

        if (timeCount >= SpawnTime)
        {
            //istancia o inimigo
            SpawnEnemy();
            timeCount = 0;
        }
    }


    void SpawnEnemy()
    {
        Instantiate(EnemiesList[Random.Range(0,EnemiesList.Count)], transform.position + new Vector3(0,Random.Range(-2.5f,2.5f),0), transform.rotation);
    }
}
