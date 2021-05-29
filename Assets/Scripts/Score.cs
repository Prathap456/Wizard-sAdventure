using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Score : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI scoreText;
    public PlayerController pc;
    // Start is called before the first frame update



    private void LateUpdate()
    {
        
        changeScore(pc.score);
    }
    void changeScore(int value)
    {
        scoreText.text = "Score: " + value.ToString();
    }
    
}
