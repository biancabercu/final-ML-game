using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundsound : MonoBehaviour
{
    // Start is called before the first frame update
    private static backgroundsound instance = null;
    public static backgroundsound Instance {
        get { return instance; }
    }
    void Awake () {
        if (instance != null && instance != this) {
            Destroy(this.gameObject);
            return;
        }
        else {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
