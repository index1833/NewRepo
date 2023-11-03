using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public void ReStartGame() //public Button에 연결되는 전역함수 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //실행파일로 만듬
    }

    public void CloseGame()
    {
    
     Application.Quit();
    
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
