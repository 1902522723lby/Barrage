﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//涡轮圆形一波36*12
public class ZZWeaponShotgun6 : IWeapon
{
    public override void Init()
    {
        attackSpeed = 0.1f;
        base.Init();
    }

    private const int V = 3;


    //射击方法，需要重写
    public override void Fire()
    {

        BarrageGame.Instance.getBarrageUtil().StartCoroutine(ZZShotgun());



    }
    IEnumerator ZZShotgun()
    {

        Vector3[] bulletsPos = new Vector3[20];
        float distance = 0;
        Vector3 vec = new Vector3(0, 0, 1);

        for (int a = 0; a < 1; a++)
        {
            for (int i = 0; i < 12; i++)
            {
                bulletsPos[i] = shooter.GetPos()+Quaternion.AngleAxis(28 * i, Vector3.up) * vec*distance;
                distance += 4;
            }
            
            for (int i = 0; i < 12; i++)
            {
                
                for (int j = -8; j < 29; j++)
                {

                    GameObject bullet2 = BulletUtil.LoadBullet(shooter.GetBulletName());

                    bullet2.transform.position = bulletsPos[i];

                    bullet2.transform.forward = Quaternion.AngleAxis(10 * j, Vector3.up) * vec;
                    IBullet bulletInfo2 = bullet2.GetComponent<IBullet>();
                    bulletInfo2.shooter = shooter;
                    bulletInfo2.Fire();
                    bulletInfo2.speed = 1.5f;
                }
                yield return new WaitForSeconds(0.1f);
            }
        }
    }

    ////朝某个方向
    //public override void Fire(Vector3 vec)
    //{
    //    //从对象池里取出子弹
    //    GameObject bullet = BulletUtil.LoadBullet(shooter.bulletName);

    //    //将取出的子弹的位置设置为射击者的位置
    //    bullet.transform.position = shooter.GetPos();
    //    //使子弹的forward向量等于射击者到目标的向量,也就是说让子弹正面朝向目标
    //    bullet.transform.forward = vec;
    //    //将子弹的攻击者设置为射击者
    //    bullet.GetComponent<IBullet>().shooter = shooter;
    //    //调用子弹的发射函数。可在子弹的发射函数中设置发射延迟或者启动一个新的函数或协程。
    //    bullet.GetComponent<IBullet>().Fire();

    //}
}
