using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallMovementController : MonoBehaviour
{
    [SerializeField] private float ballSpeed;
    private bool isTouch = false, isPause = false;
    Rigidbody rb;
    private float horizontal, vertical;
    private float jumpValue = 0f;
    public float rotationSpeed;
    Vector3 startPos, endPos;
    public Slider slider;
    private int coin;
    public Text text, lastCoin, level;
    public Sprite pause, play;
    public Button button;
    public Canvas game, finish;
    void Start()
    {
        startPos = transform.position;
        endPos = GameObject.FindGameObjectWithTag("Finish").transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        text.text = coin.ToString();
        slider.value = (transform.position.z-startPos.z) / (endPos.z - startPos.z);
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
         transform.Translate(new Vector3(0f, jumpValue, vertical * ballSpeed * Time.deltaTime),Space.Self);
        //Vector3 newPos = rb.position + transform.TransformDirection(new Vector3(0f, jumpValue, vertical * ballSpeed * Time.deltaTime));
        //rb.MovePosition(newPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Jump")
        {
            rb.AddForce(new Vector3(0,300,150));
        }
        if (other.tag == "Finish")
        {
            ballSpeed = 0;
            level.text = SceneManager.GetActiveScene().name;
            game.enabled = false;
            finish.gameObject.SetActive(true);
            lastCoin.text = coin.ToString() + " Coin Collected";
        }
        if (other.tag == "Coin")
        {
            coin += 10;
            Destroy(other.gameObject);
        }
    }   

    public void GamePause()
    {
        if (!isPause)
        {
            Time.timeScale = 0;
            button.image.sprite = pause;
        }

        else
        {
            Time.timeScale = 1;
            button.image.sprite = play;
        }
  

        isPause = !isPause;
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Butona týklandý");
    }

}
//if(vertical == 0f && horizontal == 0f)
//{
//    transform.rotation = Quaternion.Euler(Vector3.zero);
//}
//else if(horizontal != 0)
//{
//    transform.rotation = Quaternion.Euler(Vector3.up * horizontal * Time.deltaTime * 100f);
//}

