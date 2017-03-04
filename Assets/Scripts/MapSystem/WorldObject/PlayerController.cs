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
        
    bool isClimbing
    {
        get
        {
            return currentClimbingTarget;
        }
    }

    Rigidbody2D rigibody;
    CameraController m_camera;
    MapTuning tuning;

    MapTileBehaviour currentClimbingTarget;

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

    void OnTriggerEnter2D(Collider2D collider)
    {
        MapTileBehaviour tile;
        if(checkForTileCollideEvent(collider, out tile))
        {
            handleEnterCollideWithTile(tile);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        MapTileBehaviour tile;
        if(checkForTileCollideEvent(collider, out tile))
        {
            handleExitCollideWithTile(tile);
        }
    }

    bool checkForTileCollideEvent(Collider2D collider, out MapTileBehaviour tile)
    {
        if(tile = GetComponent<MapTileBehaviour>())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void handleEnterCollideWithTile(MapTileBehaviour tile)
    {
        if(tile.GetTile.IsClimbable)
        {
            handleEnterClimbableTile(tile);
        }
    }

    void handleExitCollideWithTile(MapTileBehaviour tile)
    {
        if(tile.GetTile.IsClimbable)
        {
            handleExitClimbableTile(tile);
        }
    }

    void handleEnterClimbableTile(MapTileBehaviour tile)
    {
        currentClimbingTarget = tile;
    }

    void handleExitClimbableTile(MapTileBehaviour tile)
    {
        if(currentClimbingTarget == tile)
        {
            currentClimbingTarget = null;
        }
    }

    Vector2 getMoveVector()
    {
        float vertMove = Input.GetAxis(VERT);
        if(isClimbing)
        {
            vertMove = getClimbingVertVelocity(vertMove);
        }
        else
        {
            vertMove = getJumpingVertVelocity(vertMove);
        }
        return new Vector2(Input.GetAxis(HOR) * speed, vertMove);
    }
        
    float getClimbingVertVelocity(float vertMove)
    {
        return vertMove;
    }

    float getJumpingVertVelocity(float vertMove)
    {
        if(canJump && vertMove > 0)
        {
            vertMove = jump;
        }
        else
        {
            vertMove = 0;
        }
        return vertMove;
    }

}
