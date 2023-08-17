using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "New Passive Item Database", menuName = "Passive Item Database")]
public class PassiveItemDatabase : ScriptableObject
{
    public List<PassiveItem> items;
}
