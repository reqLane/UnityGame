using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Player player;
    public Camera mainCamera;

    private void Awake()
    {
        if(GameManager.instance != null) { 
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(this);
        setUndestroyableObjects();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void setUndestroyableObjects()
    {
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(mainCamera);
    }
}
