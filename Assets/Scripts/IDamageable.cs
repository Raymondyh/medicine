using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    // 将受到伤害的函数抽象成一个接口，以便根据不同的对象改变目标单位
    public void TakeDamage(int damage);
}
