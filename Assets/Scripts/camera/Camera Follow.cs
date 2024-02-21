using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow: MonoBehaviour
{
    private Transform PlayerFollow;
    public float speed;
    public float OffSet;
   



    // Start is called before the first frame update
    void Start()
    {
        PlayerFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 newCamPos = new Vector3(PlayerFollow.position.x + OffSet, 0f, transform.position.z);
        transform.position = Vector3.Slerp(transform.position, newCamPos, speed * Time.deltaTime);

    }

  
}
