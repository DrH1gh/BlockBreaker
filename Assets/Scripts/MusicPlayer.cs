using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

    //STATICS  
    //var 1
    static int musicplayerCount = 0;
    //var 2
    static MusicPlayer instance = null;

    //AWAKE -> START -> UPDATE
    //https://docs.unity3d.com/Manual/ExecutionOrder.html
    void Awake()
    {
        Debug.Log("Music Player Awake" + GetInstanceID());
        //VAR 2
        if (instance != null)
        {
            Destroy(gameObject); //gameObject self destroy
            print("Destroing music duplicated!");
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        Debug.Log("Music Player Start" + GetInstanceID());
        
    }
	
}
