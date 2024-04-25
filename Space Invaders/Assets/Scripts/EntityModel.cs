using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable] //objetos dessa classe podem ser salvos no editor Unity
public class EntityModel
{
    [SerializeField]
    private Vector2 m_position;
    private bool m_isEntityAlive = true;

    public Vector2 Position {
        get {
            return m_position;
        }
        set {
            m_position = value;
        }
    }

    public bool IsEntityAlive { 
        get { 
            return m_isEntityAlive; 
        } 
        set { 
            m_isEntityAlive = value; 
        } 
    }
}
