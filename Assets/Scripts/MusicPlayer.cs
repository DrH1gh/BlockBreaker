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
            GameObject.DontDestroyOnLoad(gameObject); //gameObject = instance of the music player, e chiar tot obiectul pe care e pus scriptu (tot ce apare in ispector)
        }
    }

    // Use this for initialization
    void Start() {
        Debug.Log("Music Player Start" + GetInstanceID());
        #region old
        /* VAR 1
        if (musicplayerCount < 1)
        {
            GameObject.DontDestroyOnLoad(gameObject); //gameObject = instance of the music player, e chiar tot obiectul pe care e pus scriptu (tot ce apare in ispector)
        }
        musicplayerCount += 1;
        */
        #endregion
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
