using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Ability abilityOne;
    public Ability abilityTwo;
    public Ability abilityThree;
    float cooldownTime;
    float activeTime;

    enum AbilityOneState
    {
        //list of states for Ability One
        ready,
        active,
        cooldown
    }

    enum AbilityTwoState
    {
        //list of states for Ability Two
        ready,
        active,
        cooldown
    }

    enum AbilityThreeState
    {
        //list of states for Ability Three
        ready,
        active,
        cooldown
    }


    AbilityOneState state1 = AbilityOneState.ready;
    AbilityTwoState state2 = AbilityTwoState.ready;
    AbilityThreeState state3 = AbilityThreeState.ready;

    public int abilityOneLevel = 1;
    public int abilityTwoLevel = 1;
    public int abilityThreeLevel = 1;


    //key inputs to test abilities
    public KeyCode key1;
    public KeyCode key2;
    public KeyCode key3;
    void Update()
    {
        //Handles state for Ability 1
        switch (state1)
        {
            case AbilityOneState.ready:
                if (Input.GetKeyDown(key1))
                {
                    abilityOne.Activate(abilityOneLevel);
                    state1 = AbilityOneState.active;
                    activeTime = abilityOne.activeTime;
                    Debug.Log("Spawning Balloon");
                }
                break;
            case AbilityOneState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state1 = AbilityOneState.cooldown;
                    cooldownTime = abilityOne.cooldownTime;
                }
                break;
            case AbilityOneState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state1 = AbilityOneState.ready;
                }
                break;
        }
        //Handles state for Ability 2
        switch (state2)
        {
            case AbilityTwoState.ready:
                if (Input.GetKeyDown(key2))
                {
                    abilityTwo.Activate(abilityTwoLevel);
                    state2 = AbilityTwoState.active;
                    activeTime = abilityOne.activeTime;
                    Debug.Log("Spawning Pinata");
                }
                break;
            case AbilityTwoState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state2 = AbilityTwoState.cooldown;
                    cooldownTime = abilityOne.cooldownTime;
                }
                break;
            case AbilityTwoState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state2 = AbilityTwoState.ready;
                }
                break;
        }
        //Handles state for Ability 3
        switch (state3)
        {
            case AbilityThreeState.ready:
                if (Input.GetKeyDown(key3))
                {
                    abilityThree.Activate(abilityThreeLevel);
                    state3 = AbilityThreeState.active;
                    activeTime = abilityThree.activeTime;
                    Debug.Log("Spawning Water Gun");
                }
                break;
            case AbilityThreeState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state3 = AbilityThreeState.cooldown;
                    cooldownTime = abilityThree.cooldownTime;
                }
                break;
            case AbilityThreeState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state3 = AbilityThreeState.ready;
                }
                break;
        }

    }
}