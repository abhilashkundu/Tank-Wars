using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAndSceneControllerAndTankChecker : MonoBehaviour
{
    public static int GreenScore;
    public static int RedScore;
    public  int Temp_GreenScore;
    public  int Temp_RedScore;
    private static int numberOfScenes;
/*
    [SerializeField] TankDestroyScript t_ank;
    [SerializeField] TankDestroyScript1 t_ank1;*/


    private static string[] scenes = { "platform1", "platform2", "platform3" };
    static List<int> ScenesPlayed = new List<int>();
    private int i = 10;


    /* private void OnAwake()
     {
         t_ank = GameObject.FindGameObjectWithTag("Tank1").GetComponent<TankDestroyScript>();
         t_ank1 = GameObject.FindGameObjectWithTag("Tank2").GetComponent<TankDestroyScript1>();
     }*/
    /*void Update()
    {
        if (t_ank1.Win1 == true)
        {
            GreenScore += 1;
            LoadNextScene();
        }
        if (t_ank.Win == true)
        {
            RedScore += 1;
            LoadNextScene();
        }
    }*/
    private void Start()
    {
        Temp_GreenScore = GreenScore;
         Temp_RedScore = RedScore;
    }

    void LoadNextScene()
    {
        if (numberOfScenes == 0)
        {
            SceneManager.LoadScene("Exit");
        }
        else
        {
            for (int j = 0; j < scenes.Length; j++)
            {
                bool isPresent = ScenesPlayed.Contains(j);
                if (!isPresent)
                {
                    print("in loop" + j);
                    ScenesPlayed.Add(j);
                    SceneManager.LoadScene(scenes[j]);
                    return;
                }
            }
        }
    }





    public void onStart()
    {
        GreenScore = 0;
        RedScore = 0;
        numberOfScenes = 3;
        i = Random.Range(0, 3);
        print("In start " + i);
        ScenesPlayed.Add(i);
        SceneManager.LoadScene(scenes[i]);
    }

    // Update is called once per frame
    public void onExit()
    {
        Application.Quit();
    }

    public void onMenu()
    {
        i = 0;
        ScenesPlayed.Clear();
        SceneManager.LoadScene("MainMenu");
    }

    public void win(int w)
    {
        switch(w)
        {
            case 1:
                {
                    GreenScore += 1;
                    numberOfScenes -= 1;
                    print("no. of scene left : " + numberOfScenes);
                    LoadNextScene();
                    break;
                }
            case 2:
                {
                    RedScore += 1;
                    numberOfScenes -= 1;
                    print("no. of scene left : " + numberOfScenes);
                    LoadNextScene();
                    break;
                }
        }
    }
}