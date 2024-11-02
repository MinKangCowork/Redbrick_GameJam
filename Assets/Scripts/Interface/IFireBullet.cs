using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFireBullet
{
    public float BulletDamage { get; set; }
    public float BulletSpeed { get; set; }
    public Transform FireTransform { get; set; }

    public void FireStart();

}

