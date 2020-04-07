using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//参考　https://www.urablog.xyz/entry/2016/09/18/233112
public class DemoNetwork : MonoBehaviour
{
    [SerializeField]
    private string m_resourcePath = "";
    [SerializeField]
    private float m_randomCircle = 4.0f;

    private const string ROOM_NAME = "RoomA";

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(null);
    }

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom(ROOM_NAME, new RoomOptions(), TypedLobby.Default);
    }

    //どうやら入室までにラグがあるようだ。
    public void SpawnObject()
    {
        PhotonNetwork.Instantiate(m_resourcePath, GetRandomPosition(), Quaternion.identity, 0);
    }

    private Vector3 GetRandomPosition()
    {
        var rand = Random.insideUnitCircle * m_randomCircle;
        return rand;
    }
}
