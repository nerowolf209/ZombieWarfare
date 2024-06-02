using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{

    [SerializeField] private PartyMemberInfo[] allMembers;
    [SerializeField] private List<PartyMember> currentParty;
    [SerializeField] private PartyMemberInfo defaultPartyMember;

    private Vector3 playerPosition;
    private static GameObject instance;

    private void Awake()
    {
        if(instance!=null){
            Destroy(this.gameObject);
        } else {
            instance = this.gameObject;
            AddMemberToPartyByName(defaultPartyMember.MemberName);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void AddMemberToPartyByName(string memberName)
    {
        for (int i = 0; i < allMembers.Length; i++)
        {
            if (allMembers[i].MemberName == memberName)
            {   
                PartyMember newPartyMember = new PartyMember();
                newPartyMember.MemberName = allMembers[i].MemberName;
                newPartyMember.Level = allMembers[i].StartingLevel;
                newPartyMember.CurrHealth = allMembers[i].BaseHealth;
                newPartyMember.MaxHealth = newPartyMember.CurrHealth;
                newPartyMember.Strength = allMembers[i].BaseStr;
                newPartyMember.Speed = allMembers[i].BaseSpeed;
                newPartyMember.MemberOverworldVisualPrefab = allMembers[i].MemberOverworldVisualPrefab;
            }
        }
    }

    public void SaveHealth(int partyMember, int health){
        currentParty[partyMember].CurrHealth = health;
    }

    public void SetCurrentPosition(Vector3 position){
        playerPosition = position;
    }

    public Vector3 GetPosition(){
        return playerPosition;
    }
}


[System.Serializable]
public class PartyMember
{
    public string MemberName;
    public int Level;
    public int CurrHealth;
    public int MaxHealth;
    public int Strength;
    public int Speed;
    public int CurrExp;
    public int MaxExp;
    public GameObject MemberOverworldVisualPrefab;
}