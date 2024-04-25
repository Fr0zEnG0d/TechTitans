using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerModel : EntityModel
{
    [SerializeField]
    private int m_lives;

    public int Lives
    {
        get {
            return m_lives; 
        }
        set {
            m_lives = value;
        }
    }
}
