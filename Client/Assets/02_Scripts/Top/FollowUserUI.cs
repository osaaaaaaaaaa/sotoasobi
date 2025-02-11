//*********************************************************
// フォロイー/フォロワーのユーザー情報のUIスクリプト
// Author:Rui Enomoto
//*********************************************************
using Server.Model.Entity;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FollowUserUI : MonoBehaviour
{
    [SerializeField] Image iconImg;
    [SerializeField] Text userNameText;
    [SerializeField] Text rateText;
    [SerializeField] GameObject mutualFollowerIcon;
    [SerializeField] GameObject inserButton;
    [SerializeField] GameObject removeButton;
    FollowUIController controller;
    int targetUserId;

    public void SetupUI(FollowUIController followUIController, Sprite characterIcon, FollowingUser user, bool IsFollowing)
    {
        controller = followUIController;
        targetUserId = user.UserId;
        iconImg.sprite = characterIcon;
        userNameText.text = user.UserName;
        rateText.text = "レート：" + user.Rating;
        mutualFollowerIcon.SetActive(user.IsMutualFollow);
        inserButton.SetActive(!IsFollowing);
        inserButton.GetComponent<Button>().interactable = true;
        removeButton.SetActive(IsFollowing);
        removeButton.GetComponent<Button>().interactable = true;
    }

    public async void OnInsertButton()
    {
        inserButton.GetComponent<Button>().interactable = false;

        // フォロー登録処理
        bool isSucsess = await FollowModel.Instance.RegistFollowAsync(UserModel.Instance.UserId, targetUserId);
        removeButton.GetComponent<Button>().interactable = true;
        if (!isSucsess) return;

        inserButton.SetActive(false);
        removeButton.SetActive(true);
        removeButton.GetComponent<Button>().interactable = true;
    }

    public async void OnRemovebutton()
    {
        removeButton.GetComponent<Button>().interactable = false;

        // フォロー解除処理
        bool isSucsess = await FollowModel.Instance.RemoveFollowAsync(UserModel.Instance.UserId, targetUserId);
        inserButton.GetComponent<Button>().interactable = true;
        if (!isSucsess) return;

        removeButton.SetActive(false);
        inserButton.SetActive(true);

        FollowingUser removeUser = new FollowingUser();
        foreach (var followingUser in controller.FollowingUsers) 
        {
            if (followingUser.UserId == targetUserId)
            {
                removeUser = followingUser;
                break;
            }
        }
        controller.FollowingUsers.Remove(removeUser);
    }
}
