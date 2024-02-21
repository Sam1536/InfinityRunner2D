using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatforms : MonoBehaviour
{
    public List<GameObject> platforms = new List<GameObject>(); // lista dos Prefabs da  plataformas 
    private List<Transform> currentPlatforms = new List<Transform>();// lista da plataformas gerada na cena
    private Transform player; 
    private Transform CurrentPlatformPoint;
    private int platformIndex;

    public float OffSet; 


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        for (int i = 0; i < platforms.Count; i++)
        {
           Transform p = Instantiate(platforms[i], new Vector2(i * 30, -4.3f), transform.rotation).transform;
            currentPlatforms.Add(p);
            OffSet += 30f;
        }
        
        CurrentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platforms>().finalPoint;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float distances = player.position.x - CurrentPlatformPoint.position.x; //salvando a diferença do player e do finalpoint da plataforma atual 

        if (distances >= 1)//se o distances for maior que 1, recicla a plataforma(ou seja, envia para frente) 
        {
            Recycle(currentPlatforms[platformIndex].gameObject);
            platformIndex++;

            if (platformIndex > currentPlatforms.Count -1)
            {
                platformIndex = 0;
            }

            CurrentPlatformPoint = currentPlatforms[platformIndex].GetComponent<Platforms>().finalPoint;

           
        }
    }

    public void Recycle(GameObject Platform)
    {
        Platform.transform.position = new Vector2(OffSet,-4.3f);
        if (Platform.GetComponent<Platforms>().SpawnOBJ != null)
        {

            Platform.GetComponent<Platforms>().SpawnOBJ.Spawn();
        }

        OffSet += 30f;
    }
}
