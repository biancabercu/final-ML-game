using UnityEngine.UI;
using UnityEngine;

public class scor : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    // Start is called before the first frame update
    void Start()
    {
        score=0;
    }

    // Update is called once per frame
    void Update()
    {
        score++;
        // Debug.Log(score);
        scoreText.text=score.ToString();
    }
}
