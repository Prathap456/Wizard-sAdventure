using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform playerTransform;

    [SerializeField]
    public float xoffset;
   // public float yoffset;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;    
    }

    // Update is called once per frame

    private void LateUpdate()
    {

        //we store current cam pos in this var
        Vector3 temp = transform.position;

        //we set cams x pos to equal to player pos x
        temp.x = playerTransform.position.x;
       // temp.y = playerTransform.position.y;
        temp.x += xoffset;
       // temp.y += yoffset;

        //we set cams temp pos to cams current pos
        transform.position = temp;
    }
    void Update()
    {
        
    }
}
