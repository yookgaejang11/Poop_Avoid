using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public int score;
    public bool isTouchTop;
    public bool isTouchLeft;
    public bool isTouchRight;
    public bool isTouchBottom;
    public int Speed;
    Rigidbody2D rigid;
    private Vector3 lastValidPosition;
    public GameManager manager;
    public int jumpPower;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
        lastValidPosition = transform.position;
       
    }

    // Update is called once per frame

    private void Update()
    {

        
    }
    void FixedUpdate()//프레임 직접 지정
    {
        
        
        float h = Input.GetAxis("Horizontal");//수평 키 입력
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;
        
        
        Vector3 curPosition = transform.position;
        Vector3 newPosition = transform.position + new Vector3(h, 0, 0) * Speed * Time.deltaTime;
        // 새로운 위치가 벽을 넘어가지 않는지 체크
        if (newPosition.x < -8.5f || newPosition.x > 8.5f)
            newPosition.x = lastValidPosition.x; // 이전 위치로 돌아감
        transform.position = newPosition;
        lastValidPosition = transform.position;

        if (Input.GetButtonDown("Jump") && isTouchBottom == true)
        {
            
            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);

        }
    }
    void OnTriggerEnter2D(Collider2D collision) { 
        if(collision.gameObject.CompareTag("Border"))
        {
            switch (collision.gameObject.name)
            {
                case "Left":
                    isTouchLeft = true;
                    break;
                case "Right":
                    isTouchRight = true;
                    break;
                case "Top":
                    isTouchTop = true;
                    break;
                case "Bottom":
                    isTouchBottom = true;
                    break;

            }
        }
        else if(collision.gameObject.CompareTag("Poop"))
        {
            gameObject.SetActive(false);
            
        }

        if (!gameObject.activeSelf)
        {
            manager.GameOver();
        }




        
    }

 
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Border"))
        {
            switch (collision.gameObject.name)
            { 
                case "Left":
                    isTouchLeft = false;
                    break;
                case "Right":
                    isTouchRight = false;
                    break;
                case "Top":
                    isTouchTop = false;
                    break;
                case "Bottom":
                    isTouchBottom = false;
                    break;
            }
        }
    }


}
