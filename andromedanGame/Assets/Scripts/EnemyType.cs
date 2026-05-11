using UnityEngine;

public class EnemyType : MonoBehaviour
{
    public enum EnemyTypeSelect
    {
        Projectile,
        TargetLock,
        Beam,
        Shotgun,
        Rocket
    }
    public EnemyTypeSelect enemyType;
}
