
using UnityEngine;
using UnityEngine.SceneManagement;
public class Goal : MonoBehaviour
{
    public int changelevel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("sceneChange", 3f);
        }
    }
    void sceneChange()
    {
        SceneManager.LoadScene(changelevel);
    }
}
