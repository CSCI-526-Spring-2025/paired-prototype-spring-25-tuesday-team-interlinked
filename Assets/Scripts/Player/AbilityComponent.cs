using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityComponent : MonoBehaviour
{
    public AbilityScriptable m_ability;

    private void Start()
    {
        SingletonMaster.Instance.EventManager.LinkEvent.AddListener(OnLinked);
        SingletonMaster.Instance.EventManager.UnlinkEvent.AddListener(OnUnlinked);
    }

    private void OnDisable()
    {
        SingletonMaster.Instance.EventManager.LinkEvent.RemoveListener(OnLinked);
        SingletonMaster.Instance.EventManager.UnlinkEvent.RemoveListener(OnUnlinked);
    }
    
    private void OnUnlinked(GameObject obj)
    {
        if (obj == gameObject)
        {
            m_ability.m_enabled = false;
        }
    }

    private void OnLinked(GameObject obj)
    {
        if (obj == gameObject)
        {
            m_ability.m_enabled = true;
        }
    }
}
