using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerDataList_SO", menuName = "Player/PlayerDataList")]
public class PlayerDataList_SO : ScriptableObject
{
    public List<PlayerDetails> playerDetailsList;
}
