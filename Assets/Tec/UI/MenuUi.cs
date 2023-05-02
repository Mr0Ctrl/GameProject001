using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUi : MonoBehaviour
{

    public int point = 0;
    TextMeshProUGUI board;

    public void Start()
    {
       board = GameObject.Find("Board").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        board.text = $"Point  :{point,+3}";
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("game over");
        Application.Quit();
    }

    public void PauseGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1 );
    }
}
