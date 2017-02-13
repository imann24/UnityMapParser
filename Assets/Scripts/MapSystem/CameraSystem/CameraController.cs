/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour 
{
    #region Static Accessors

    public static CameraController Get
    {
        get 
        {
            return _mostRecentInstance;
        }
    }

    #endregion

    static CameraController _mostRecentInstance;

    #region Instance Accessors

    public bool HasFocus
    {
        get 
        {
            return currentFocus != null;
        }
    }

    public bool FocusLocked
    {
        get;
        private set;
    }

    #endregion

    public Transform currentFocus;

	// Use this for initialization
	void Awake() 
	{
        _mostRecentInstance = this;
	}

    void Update()
    {
        if(HasFocus)
        {
            trackFocus();
        }
    }

    void trackFocus()
    {
        if(HasFocus)
        {
            Vector3 newPos = currentFocus.position;
            // Don't adjust the z-depth (because it's a 2D system):
            newPos.z = transform.position.z;
            transform.position = newPos;
        }
    }

    public bool RequestFocus(Transform obj)
    {
        if(FocusLocked)   
        {
            return false;
        }
        else 
        {
            currentFocus = obj;
            return true;
        }
    }

    public void LockFocus(Transform focus)
    {
        if(focus == this.currentFocus)
        {
            FocusLocked = true;
        }
    }

    public void ReleaseFocus(Transform focus)
    {
        if(focus == this.currentFocus)
        {
            FocusLocked = false;
        }
    }
}
