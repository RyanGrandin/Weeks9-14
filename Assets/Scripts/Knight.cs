using UnityEngine;
using UnityEngine.InputSystem;
using Unity.Cinemachine;
using UnityEngine.Tilemaps;
using UnityEngine.Rendering;

public class Knight : MonoBehaviour
{
    //public AudioSource SFX;
    Vector2 movement;
    public float speed = 3;
    public CinemachineImpulseSource impulseSource;
    public Animator animator;
    public SpriteRenderer sr;
    public Tilemap tilemap;
    public Tile crackedTile;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3)movement * speed * Time.deltaTime;
        animator.SetFloat("movement", movement.magnitude);
        if (movement.x < 0)
        {
            sr.flipX = true;
        }
        if (movement.x > 0)
        {
            sr.flipX = false;
        }
    }

    public void Footstep()
    {
        Vector3Int cellPos = tilemap.WorldToCell(transform.position);
        TileBase tileStepped = tilemap.GetTile(cellPos);

        //SFX.Play();
        impulseSource.GenerateImpulse();

        if (tileStepped.name == "TX Tileset Grass Pavement 0")
        {
            tilemap.SetTile(cellPos, crackedTile);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }
}
