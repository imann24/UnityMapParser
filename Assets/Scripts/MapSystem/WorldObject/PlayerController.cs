/*
 * Author(s): Isaiah Mann
 * Description: [to be added]
 * Usage: [no notes]
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : Controller 
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

    [SerializeField]
    float gravityScale = 2;

    Rigidbody2D rigibody;
    MapController map;
    CameraController cam;

    MapTileBehaviour currentClimbingTarget;
    MapUnitBehaviour player;

    public void Setup(MapController map)
    {
        this.map = map;
    }

	// Use this for initialization
	protected override void Awake()
    {
        base.Awake ();
        rigibody = GetComponent<Rigidbody2D>();	
        rigibody.freezeRotation = true;
        player = GetComponent<MapUnitBehaviour>();
	}

    void Start()
    {
        tuning = MapTuning.Get;
        rigibody.gravityScale = tuning.PlayerGravityScale;
        rigibody.drag = tuning.PlayerGravityScale;
        cam = CameraController.Get;
        if(cam.RequestFocus(transform))
        {
            cam.LockFocus(transform);
        }
    }

    void Update()
    {
        rigibody.gravityScale = isClimbing ? 0 : gravityScale;
        rigibody.AddForce(getMoveVector());
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        MapObjectBehaviour obj;
        if(checkForMapObjCollideEvent(collider, out obj))
        {
            if(checkForPortalCollideEvent(obj))
            {
                handlePortalCollider(obj);
            }
            if(obj is MapTileBehaviour)
            {
                handleEnterCollideWithTile(obj as MapTileBehaviour);
            }
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        MapObjectBehaviour obj;
        if(checkForMapObjCollideEvent(collider, out obj))
        {
            if(obj is MapTileBehaviour)
            {
                handleExitCollideWithTile(obj as MapTileBehaviour);
            }
        }
    }

    bool checkForMapObjCollideEvent(Collider2D collider, out MapObjectBehaviour obj)
    {
        if(obj = collider.GetComponent<MapObjectBehaviour>())
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool checkForPortalCollideEvent(MapObjectBehaviour obj)
    {
        return obj.Descriptor.IsPortal;
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
        
    void handlePortalCollider(MapObjectBehaviour obj)
    {
        map.HandlePortalEnter(player, obj);
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
        return vertMove * speed;
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
