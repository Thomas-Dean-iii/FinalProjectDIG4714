using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class PlayerAbilities : MonoBehaviour
{
    public Ability abilityOne;
    public Ability abilityTwo;
    public Ability abilityThree;
    float A1cooldownTime;
    float A1activeTime;
    float A2cooldownTime;
    float A2activeTime;
    float A3cooldownTime;
    float A3activeTime; 
    private int abilityOneLevel = 1;
    private int abilityTwoLevel = 1;
    private int abilityThreeLevel = 1;
    enum AbilityOneState
    {
        //list of states for Ability One
        inactive,
        active,
        cooldown
    }

    enum AbilityTwoState
    {
        //list of states for Ability Two
        inactive,
        active,
        cooldown
    }

    enum AbilityThreeState
    {
        //list of states for Ability Three
        inactive,
        active,
        cooldown
    }

    AbilityOneState state1 = AbilityOneState.inactive;
    AbilityTwoState state2 = AbilityTwoState.inactive;
    AbilityThreeState state3 = AbilityThreeState.inactive;

    void Update()
    {
        //Handles state for Ability 1
        switch (state1)
        {
            case AbilityOneState.active:
                if (A1activeTime > 0)
                {
                    A1activeTime -= Time.deltaTime;
                }
                else
                {
                    abilityOne.Deactivate(abilityOneLevel);
                    state1 = AbilityOneState.cooldown;
                    A1cooldownTime = abilityOne.cooldownTime;
                }
                break;
            case AbilityOneState.cooldown:
                if (A1cooldownTime > 0)
                {
                    A1cooldownTime -= Time.deltaTime;
                }
                else
                {
                    abilityOne.Activate(abilityOneLevel);
                    state1 = AbilityOneState.active;
                    A1activeTime = abilityOne.activeTime;
                }
                break;
            case AbilityOneState.inactive:
                if (abilityOneLevel > 0)
                {
                    state1 = AbilityOneState.active; ;
                }
                break;

        }
        //Handles state for Ability 2
        switch (state2)
        {
            case AbilityTwoState.active:
                if (A2activeTime > 0)
                {
                    A2activeTime -= Time.deltaTime;
                }
                else
                {
                    state2 = AbilityTwoState.cooldown;
                    A2cooldownTime = abilityTwo.cooldownTime;
                }
                break;
            case AbilityTwoState.cooldown:
                if (A2cooldownTime > 0)
                {
                    A2cooldownTime -= Time.deltaTime;
                }
                else
                {
                    abilityTwo.Activate(abilityTwoLevel);
                    state2 = AbilityTwoState.active;
                    A2activeTime = abilityTwo.activeTime;
                }
                break;
            case AbilityTwoState.inactive:
                if (abilityTwoLevel > 0)
                {
                    state2 = AbilityTwoState.active;
                }
                break;
        }
        //Handles state for Ability 3
        switch (state3)
        {
            case AbilityThreeState.active:
                if (A3activeTime > 0)
                {
                    A3activeTime -= Time.deltaTime;
                }
                else
                {
                    abilityThree.Deactivate(abilityThreeLevel);
                    state3 = AbilityThreeState.cooldown;
                    A3cooldownTime = abilityThree.cooldownTime;
                }
                break;
            case AbilityThreeState.cooldown:
                if (A3cooldownTime > 0)
                {
                    A3cooldownTime -= Time.deltaTime;
                }
                else
                {
                    abilityThree.Activate(abilityThreeLevel);
                    state3 = AbilityThreeState.active;
                    A3activeTime = abilityThree.activeTime;
                }
                break;
            case AbilityThreeState.inactive:
                if (abilityThreeLevel > 0)
                {
                    state3 = AbilityThreeState.active;
                }
                break;
        }

    }
}