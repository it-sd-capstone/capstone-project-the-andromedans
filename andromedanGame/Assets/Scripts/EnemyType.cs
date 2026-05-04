using UnityEngine;

public class EnemyType : MonoBehaviour
{
    public enum EnemyTypeSelect
    {
        Projectile,
        TargetLock,
        Beam,
        Shotgun
    }
    public EnemyTypeSelect enemyType;
}
