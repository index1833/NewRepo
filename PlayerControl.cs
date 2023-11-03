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
    

    void SetCount()  // SetCount �Լ�����
    {
        countText.text = "Score : " + count.ToString();
        // count��� ���ڸ� ������ intŸ���� ���ټ������� String(ToString)���� ����ȯ
        // ������ ���������̻� �ö󰡸� Game Clear �ؽ�Ʈ ���
        if(count >= 60)
        {
            clearText.SetActive(true);
        }
    }
    // public������ �ܺο����� ���ٰ����� ���� ����Ƽ������ ����Ҽ��ְ�
    // �������� �ٲܽ� ����Ƽ�� �켱������ ���Ƽ� ����Ƽ���� �ٲ۰����� �����

    private void Awake()
    {
        rigid= GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        count = 0; // count �� �ʱ�ȭ
        SetCount();// �Լ��ʱ�ȭ
        clearText.SetActive(false); // �ؽ�Ʈ����ȭ

      
    }

    // Update is called once per frame
    void Update() // �����Ӹ��� �ѹ��� ȣ��
    {
        
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
       // Debug.Log("h: " + h);
       // Debug.Log("v: " + v);
        h = h * Speed * Time.deltaTime; // �� �� �� 
        v = v * Speed * Time.deltaTime; // �ʴ����� ȣ���ؼ� �����ϰ� ȣ��ǰ�

        transform.Translate(h * Vector3.right); // �¿�
        transform.Translate(v * Vector3.forward); // ����
        Jump();

        //  �Ÿ� = �ð� x �ӷ� 

    }

    private void OnCollisionEnter(Collision collision)
    // �浹�� �Ǿ����� �Ʒ� �Լ����� (�ݹ��Լ�) ��������
    {
        Debug.Log("�浹 ����!@!");
    }

    private void OnTriggerEnter(Collider other)
    // �����۰� �浹�Ǿ����� �Լ����� other = ������
    {
        if(other.gameObject.CompareTag("item"))
        //�������̶�� �±׸� �ް��ִ� ���ӿ�����Ʈ�� ����������
        {   
           other.gameObject.SetActive(false); // ��Ȱ��ȭ
            // ���� ������Ʈ
            count = count + 10;
            Debug.Log("Count : " + count); 
           SetCount(); // �Լ�ȣ��
        }
        Debug.Log("Ʈ���� ����");

        
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
