using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyManager : MonoBehaviour
{

    // TODO: Add later on for allMembers
    //[SerializeField] private PartyMemberInfo[] allMembers;
    [SerializeField] private List<PartyMember> currentParty;
    // TODO: add later for setting the party member
    //[SerializeField] private PartyMemberInfo defaulPartyMember;

    private Vector3 playerPosition;

    public void AddMemberToPartyByName(string memberName)
    {

    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}


[System.Serializable]
public class PartyMember
{
    public string MemberName;
    public int StartingLevel;
    public int BaseHealth;
    public int BaseStr;
    public int BaseSpeed;
    public GameObject MemberOverworldVisualPrefab; // Displayed in overworld scene
}