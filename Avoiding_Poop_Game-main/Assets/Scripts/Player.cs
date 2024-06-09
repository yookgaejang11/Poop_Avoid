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
    void FixedUpdate()//������ ���� ����
    {
        
        
        float h = Input.GetAxis("Horizontal");//���� Ű �Է�
        if ((isTouchRight && h == 1) || (isTouchLeft && h == -1))
            h = 0;
        
        
        Vector3 curPosition = transform.position;
        Vector3 newPosition = transform.position + new Vector3(h, 0, 0) * Speed * Time.deltaTime;
        // ���ο� ��ġ�� ���� �Ѿ�� �ʴ��� üũ
        if (newPosition.x < -8.5f || newPosition.x > 8.5f)
            newPosition.x = lastValidPosition.x; // ���� ��ġ�� ���ư�
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
