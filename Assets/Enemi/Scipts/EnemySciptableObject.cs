using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(menuName ="Enemy/DataEnemi")]
public class EnemySciptableObject : ScriptableObject
{
   [Header("Info")]
   public int ID;
   public string EnemyName;
   public Sprite EnemySprite;
   public EnemyRank EnemyRank;
   [Header("Stats")]
   public List<EnemyStats> enemyStats;
}

public enum EnemyRank
{
    Commun,
    Rare,
    Epique,
    Legendaire
}
[System.Serializable]
public class EnemyStats
{
    public StatType type;
    public int value;
    public bool heritage;
}