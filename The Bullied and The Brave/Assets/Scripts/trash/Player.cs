using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Player : MonoBehaviourPun
{
    public PlayerDataList_SO playerDataList_SO;
    public PlayerDetails playerDetails;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public PlayerDetails GetPlayerDetails(int ID)
    {
        return playerDataList_SO.playerDetailsList.Find(i => i.playerID == ID);
    }

    public void Init(int ID)
    {
        playerDetails = GetPlayerDetails(ID);
    }
}
