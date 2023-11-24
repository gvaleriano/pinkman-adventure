using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform point;
    // Start is called before the first frame update
    void Start()
    {
        // FindObjectOfType<Player>().transform.position = point.position;
        FindObjectOfType<Player>().transform.position = point.position;
        FindObjectOfType<Player>().setUi(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void restart()
    {
        FindObjectOfType<Player>().RestartGame();
    }
}
