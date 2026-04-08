using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class LocalMultiplayerManager : MonoBehaviour
{
    public List<Sprite> playerSprites;
    public List<PlayerInput> players;
    public AnimationCurve SqueezeCurve;
    public float squeezeSpeed = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlayerJoin(PlayerInput player)
    {
        players.Add(player);

        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        sr.sprite = playerSprites[player.playerIndex];

        LocalMultiplayerController controller = player.GetComponent<LocalMultiplayerController>();
        controller.manager = this;
    }

    public void PlayerAttacking(PlayerInput attackingPlayer)
    {
        for (int i = 0; i < players.Count; i++)
        {
            if (attackingPlayer == players[i]) continue;
            
            if (Vector2.Distance(attackingPlayer.transform.position, players[i].transform.position) < 0.5f)
            {
                Debug.Log("Player " + attackingPlayer.playerIndex + " hit player " + players[i].playerIndex + ".");
                if (Squeeze(i) != null)
                {
                    StopCoroutine(Squeeze(i));
                }
                StartCoroutine(Squeeze(i));
            }
        }
    }

    IEnumerator Squeeze(int i)
    {
        float t = 0;
        while (t < 1)
        {
            t += squeezeSpeed * Time.deltaTime;
            players[i].transform.localScale = Vector3.one * SqueezeCurve.Evaluate(t);
            yield return null;
        }
    }
}
