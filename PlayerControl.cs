using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{

    public float JumpSpeed = 5f;
    public float JumpForce = 3f;
    Rigidbody rigid;
    float Speed = 5f;
    public float p_speed = 5f;
    int count;
    public TextMeshProUGUI countText;
    public GameObject clearText;
    

    void SetCount()  // SetCount 함수생성
    {
        countText.text = "Score : " + count.ToString();
        // count라는 숫자를 더해줌 int타입을 써줄수없으니 String(ToString)으로 형변환
        // 점수가 일정점수이상 올라가면 Game Clear 텍스트 출력
        if(count >= 60)
        {
            clearText.SetActive(true);
        }
    }
    // public변수는 외부에서도 접근가능한 변수 유니티에서도 사용할수있게
    // 변수값을 바꿀시 유니티가 우선순위가 높아서 유니티에서 바꾼값으로 적용됌

    private void Awake()
    {
        rigid= GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0; // count 값 초기화
        SetCount();// 함수초기화
        clearText.SetActive(false); // 텍스트투명화

      
    }

    // Update is called once per frame
    void Update() // 프레임마다 한번씩 호출
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
       // Debug.Log("h: " + h);
       // Debug.Log("v: " + v);
        h = h * Speed * Time.deltaTime; // 거 속 시 
        v = v * Speed * Time.deltaTime; // 초단위로 호출해서 균일하게 호출되게

        transform.Translate(h * Vector3.right); // 좌우
        transform.Translate(v * Vector3.forward); // 전진
        Jump();

        //  거리 = 시간 x 속력 

    }

    private void OnCollisionEnter(Collision collision)
    // 충돌이 되었을때 아래 함수실행 (콜백함수) 아이템이
    {
        Debug.Log("충돌 감지!@!");
    }

    private void OnTriggerEnter(Collider other)
    // 아이템과 충돌되었을때 함수실행 other = 아이템
    {
        if(other.gameObject.CompareTag("item"))
        //아이템이라는 태그를 달고있는 게임오브젝트와 접촉했을때
        {   
           other.gameObject.SetActive(false); // 비활성화
            // 점수 업데이트
            count = count + 10;
            Debug.Log("Count : " + count); 
           SetCount(); // 함수호출
        }
        Debug.Log("트리거 감지");

        
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Vector3 jumpVelocity = Vector3.up * Mathf.Sqrt(JumpForce
            * -Physics.gravity.y);
            rigid.AddForce(jumpVelocity, ForceMode.VelocityChange);
        }
    }
 }
