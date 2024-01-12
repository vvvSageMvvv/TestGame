using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverScreen : MonoBehaviour
{


    public void setup()
    {
        gameObject.SetActive(true);

    }


    public void retry()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void menu()
    {

    }

}
