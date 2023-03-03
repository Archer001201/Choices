using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Launcher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        //调用Photon Server Settings
        PhotonNetwork.ConnectUsingSettings();
    }

    //检测是否连接到游戏服务器
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        //创建房间
        PhotonNetwork.JoinOrCreateRoom("IAT 222 Team 2-4", new Photon.Realtime.RoomOptions() { MaxPlayers = 2}, default);
    }

    //加入房间生成角色
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
            PhotonNetwork.Instantiate("Player_1", new Vector3(0, 0, 0), Quaternion.identity, 0);
        else if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
            PhotonNetwork.Instantiate("Player_2", new Vector3(5, 0, 0), Quaternion.identity, 0);
    }
}
