using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public GameObject player; // 플레이어 오브젝트 참조함
    Vector3 offset; // 카메라와 플레이어 사이의 거리변수 (3차원값)Vectro3

    // Start is called before the first frame update
    void Start()
    {

    offset = transform.position - player.transform.position;
        // 카메라와 플레이어의 거리 = 카메라의 거리 - 플레이어의 위치
        // transform.position 내 오브젝트의 위치   
       
       
    }

    // Update is called once per frame
    void LateUpdate() // LateUpdate는 Update중에서 가장마지막에 업데이트되도록함
    // 업데이트순서는 정해져있지않고 무작위로 설정됌
    {
        transform.position = player.transform.position + offset;
        // 카메라의 거리 = 플레이어위치 + 카메라와 플레이어의 거리
    }
}
