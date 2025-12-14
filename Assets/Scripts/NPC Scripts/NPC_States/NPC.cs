using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public enum NPCState{ Default, Idle, Patrol, Wander, Talk}
    public NPCState currentState = NPCState.Wander;
    private NPCState defaultState;

    public NPC_Patrol patrol;
    public NPC_Wander wander;
    public NPC_Talk talk;

    // Start is called before the first frame update
    void Start()
    {
        defaultState = currentState;
        SwitchState(currentState);
        
    }

    public void SwitchState(NPCState newState)
    {
        currentState = newState;

        wander.enabled = (newState == NPCState.Wander);
        patrol.enabled = (newState == NPCState.Patrol);
        talk.enabled = (newState == NPCState.Talk);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SwitchState(NPCState.Talk);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            SwitchState(defaultState);
        }
    }

}
