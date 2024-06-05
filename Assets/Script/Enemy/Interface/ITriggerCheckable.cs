using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerCheckable
{
    bool isAggroPlayer { get; set; }
    bool isAttackRangeCheck { get; set; }
    void SetAggroStatus (bool IsAggroPlayer);
    void SetAttackCheck (bool IsAttackCheck);
}
