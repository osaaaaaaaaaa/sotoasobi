﻿//*********************************************************
// クライアント・サーバーでシェアしたいenum情報
// Author:Rui Enomoto
//*********************************************************
using MessagePack;
using Server.Model.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interfaces.Model.Entity
{
    public class EnumManager
    {
        public enum Character_ID
        {
            OriginalHiyoko = 1,
            ChickenHiyoko,
            BrackHiyoko,
            StarHiyoko,
            GoldHiyoko,
        }

        public enum SCENE_ID
        {
            RelayGame = 0,
            FinalGame_Hay,
            FinalGame_Goose,
            FinalGame_Chicken,
        }
        public static int finalStatageTypeMax = 3;

        /// <summary>
        /// カントリーリレーのエリアID
        /// </summary>
        public enum RELAY_AREA_ID
        {
            Area1_Mud,
            Area2_Hay,
            Area3_Cow,
            Area4_Plant,
            Area5_Goose,
            Area6_Chicken
        }
        public static RELAY_AREA_ID FirstAreaId = RELAY_AREA_ID.Area1_Mud;
        public static RELAY_AREA_ID MiddleAreaMinId = RELAY_AREA_ID.Area2_Hay;
        public static RELAY_AREA_ID MiddleAreaMaxId = RELAY_AREA_ID.Area5_Goose;
        public static RELAY_AREA_ID LastAreaId { get; private set; } = RELAY_AREA_ID.Area6_Chicken;

        /// <summary>
        /// カントリーリレーのコース選択
        /// </summary>
        public enum SELECT_RELAY_AREA_ID
        {
            Course_Random,
            Course_Hay,
            Course_Cow,
            Course_Plant,
            Course_Goose
        }

        /// <summary>
        /// 最終競技のステージ選択
        /// </summary>
        public enum SELECT_FINALGAME_AREA_ID
        {
            Stage_Random,
            Stage_Hay,
            Stage_Goose,
            Stage_Chicken
        }

        public enum ITEM_ID
        {
            None = 0,
            ItemBox,
            Coin,
            Pepper,
        }

        public enum ITEM_EFFECT_TIME
        {
            Pepper = 7,
        }

        public enum SPAWN_OBJECT_ID
        {
            Hay = 0,
        }

        public enum ANIMAL_GIMMICK_ID
        {
            Bull = 0,
            Chicken,
        }
    }
}
