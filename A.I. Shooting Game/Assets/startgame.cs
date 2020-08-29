using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class startgame : MonoBehaviour
{
    // Start is called before the first frame update
    public Button startgamebutton;
    public void startgamefunction() {
        SceneManager.LoadScene(1);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
