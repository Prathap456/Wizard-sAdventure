using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathzone : MonoBehaviour
{
    public Transform spawnPos;
    public int lives;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        lives-=1;
        if (lives == 0)
        {
            SceneManager.LoadScene(2);
        }
        else if (lives > 0)
        {
            collision.gameObject.transform.position = spawnPos.transform.position;
        }
    }
}
