using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactEffect : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyImpact", 3f);
    }


    
    void destroyImpact()
    {
        Destroy(gameObject);
    }
        
    
}
