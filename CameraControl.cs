using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player; // �÷��̾� ������Ʈ ������
    Vector3 offset; // ī�޶�� �÷��̾� ������ �Ÿ����� (3������)Vectro3

    // Start is called before the first frame update
    void Start()
    {

    offset = transform.position - player.transform.position;
        // ī�޶�� �÷��̾��� �Ÿ� = ī�޶��� �Ÿ� - �÷��̾��� ��ġ
        // transform.position �� ������Ʈ�� ��ġ   
       
       
    }

    // Update is called once per frame
    void LateUpdate() // LateUpdate�� Update�߿��� ���帶������ ������Ʈ�ǵ�����
    // ������Ʈ������ �����������ʰ� �������� ������
    {
        transform.position = player.transform.position + offset;
        // ī�޶��� �Ÿ� = �÷��̾���ġ + ī�޶�� �÷��̾��� �Ÿ�
    }
}
