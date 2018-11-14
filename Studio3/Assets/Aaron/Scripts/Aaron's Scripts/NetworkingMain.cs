using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkingMain : MonoBehaviourPunCallbacks
{
    MenuManager menuManager;
    public InputField userInputField;
    public InputField roomInputField;
    PlayersManager pM;
    string roomName;
    
    void Start()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        menuManager = FindObjectOfType<MenuManager>();
        pM = FindObjectOfType<PlayersManager>();
    }

    void Update()
    {

    }

    public void SelectPlayer1()
    {
        pM.color = 1;
    }
    
    public void SelectPlayer2()
    {
        pM.color = 2;
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Successfully connected to server.");
        PhotonNetwork.JoinRandomRoom(null, 0);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;
        roomOptions.MaxPlayers = 4;

        TypedLobby typedLobby = new TypedLobby();
        typedLobby.Name = "Lobby 1";
        typedLobby.Type = LobbyType.Default;

        roomName = roomInputField.text;
        PhotonNetwork.CreateRoom(roomName, roomOptions, typedLobby);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        PhotonNetwork.JoinRoom(roomName);

    }

    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("Created Room");
    }

    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print("Joined Lobby");
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        print(PhotonNetwork.LocalPlayer.NickName + " has joined the room");
        if (PhotonNetwork.CurrentRoom.PlayerCount == 1)
        {
            pM.id = 1;
            PhotonNetwork.LoadLevel(1);
        }
        if (PhotonNetwork.CurrentRoom.PlayerCount == 2)
        {
            pM.id = 2;
            PhotonNetwork.LoadLevel(1);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print(newPlayer.NickName + " has joined the room");
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        base.OnPlayerLeftRoom(otherPlayer);
        menuManager.YouWin();
        Invoke("LeaveRoom", 1);
        print(otherPlayer.NickName + " has left the room");
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        print(PhotonNetwork.LocalPlayer.NickName + " has left the Room");
        PhotonNetwork.Disconnect();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);
        PhotonNetwork.LoadLevel(0);
    }

    public override void OnLeftLobby()
    {
        base.OnLeftLobby();
    }

    public void ConnectToServer()
    {
        PhotonNetwork.NickName = userInputField.text;
        PhotonNetwork.ConnectUsingSettings();
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
    }
}
