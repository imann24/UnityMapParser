/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour 
{
    const string HOR = "Horizontal";
    const string VERT = "Vertical";

    float speed
    {
        get
        {
            return tuning.CharacterMoveSpeed;
        }
    }

    float jump
    {
        get
        {
            return tuning.CharacterJumpSpeed;
        }
    }

    bool canJump
    {
        get
        {
            return rigibody.IsTouchingLayers() && rigibody.velocity.y <= 0;
        }
    }

    Rigidbody2D rigibody;
    CameraController m_camera;
    MapTuning tuning;

	// Use this for initialization
	void Awake() 
	{
        rigibody = GetComponent<Rigidbody2D>();	
        rigibody.freezeRotation = true;
	}

    void Start()
    {
        tuning = MapTuning.Get;
        rigibody.gravityScale = tuning.PlayerGravityScale;
        rigibody.drag = tuning.PlayerGravityScale;
        m_camera = CameraController.Get;
        if(m_camera.RequestFocus(transform))
        {
            m_camera.LockFocus(transform);
        }
    }

    void Update()
    {
        rigibody.AddForce(getMoveVector());
    }

    Vector2 getMoveVector()
    {
        float vertMove = Input.GetAxis(VERT);
        if(canJump && vertMove > 0)
        {
            vertMove = jump;
        }
        else
        {
            vertMove = 0;
        }
        return new Vector2(Input.GetAxis(HOR) * speed, vertMove);
    }

}
