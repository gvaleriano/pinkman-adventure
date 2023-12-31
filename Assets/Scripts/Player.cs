using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    //public Variables
    [Header("Attributes")]
    public float speed;
    public float jumpForce;
    public int life;
    public int numberMelons;
    public int numberKiwi;
    public int numberMushroom;
    public int numberSlime;

    //Unity Variables
    [Header("Components")]
    public Rigidbody2D rigid;
    public Animator animations;
    public SpriteRenderer sprite;

    //Text Variables
    [Header("UI")]
    public TextMeshProUGUI melonText;
    public TextMeshProUGUI mushText;
    public TextMeshProUGUI kiwiText;
    public TextMeshProUGUI slimeText;
    public TextMeshProUGUI lifeText;
    public GameObject gameOver;
    public GameObject level1Ui;
    public GameObject level2Ui;


    //Private variables
    private Vector2 direction;
    private bool isGrounded;
    private bool recovery;
    private bool isDead;
    // Start is called before the first frame update
    void Start()
    {
        gameOver.SetActive(false);
        lifeText.text = "- " + life.ToString();
        Time.timeScale = 1;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        Jump();
        PlayerAnimations();
    }

    void FixedUpdate()
    {
        Movement();
        VerifyLevel();
    }

    //Player walk
    void Movement()
    {
        rigid.velocity = new Vector2(direction.x * speed, rigid.velocity.y);
    }

    void VerifyLevel()
    {
        if(SceneManager.GetActiveScene().name == "Level2")
        {
            kiwiText.enabled = true;
            melonText.enabled = false;
        }
    }

    //Player jump
    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            animations.SetInteger("transition", 2);
            rigid.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            isGrounded = false;
        }
        
    }

    //Player die
    void Death()
    {
        if(life <= 0)
        {
            gameOver.SetActive(true);
            Time.timeScale = 0;
            isDead = true;
        }
    }

    //Animations
    void PlayerAnimations()
    {
        //If player moving any direction
        if (direction.x > 0)
        {
            if(isGrounded == true)
            {
                animations.SetInteger("transition", 1);
            }
            
            transform.eulerAngles = new Vector2(0, 0);
        }

        if(direction.x < 0)
        {
            if (isGrounded == true)
            {
                animations.SetInteger("transition", 1);
            }
            transform.eulerAngles = new Vector2(0, 180);
        }

        // If player static
        if (direction.x == 0 && isGrounded == true)
        {
            animations.SetInteger("transition", 0);
        }
    }

    //Player Hit
    public void Hit()
    {
        if(recovery == false)
        {
            StartCoroutine(Flick());
        }
        
        //Debug.Log("Working!");
    }

    //Hit routine
    IEnumerator Flick()
    {
        recovery = true;
        life--;
        Death();
        lifeText.text = "- " + life.ToString();
        for (var i = 0; i < 6; i++)
        {
            if(i%2 == 0)
            {
                sprite.color = new Color(1, 0.4f, 0.4f, 0);
                yield return new WaitForSeconds(0.2f);
            }
            else
            {
                sprite.color = new Color(1, 0.4f, 0.4f, 1);
                yield return new WaitForSeconds(0.2f);
            }
            
        }
        sprite.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.2f);

        recovery = false;
    }

    public void CollectObjects(string objCollected)
    {
        if(objCollected == "Melon") {
            numberMelons++;
            melonText.text = "x " + numberMelons.ToString();
        }

        if (objCollected == "Kiwi")
        {
            numberKiwi++;
            kiwiText.text = "x " + numberKiwi.ToString();
        }

        if (objCollected == "Mushroom")
        {
            numberMushroom++;
            mushText.text = "x " + numberMushroom.ToString();
        }

        if (objCollected == "Slime")
        {
            numberSlime++;
            slimeText.text = "x " + numberSlime.ToString();
        }
    }

    public void RestartGame()
    {
        if (isDead)
        {
            Destroy(gameObject);
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene("Level1");
        
    }

    public void setUi(string level)
    {
        if(level == "Level1")
        {
            level1Ui.SetActive(true);
            level2Ui.SetActive(false);
            lifeText.color = new Color32(149, 86, 37, 255);
        }
        else if(level == "Level2")
        {
            level1Ui.SetActive(false);
            level2Ui.SetActive(true);
            lifeText.color = new Color32(38, 159, 123, 255);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isGrounded = true;
        }
    }
}
