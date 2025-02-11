﻿//*********************************************************
// クライアント・サーバーでシェアしたい定数の情報
// Author:Rui Enomoto
//*********************************************************
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Interfaces.Model.Entity
{
    public class ConstantManager
    {
        #region レーティング関係
        public static int DefaultRating { get; private set; } = 1000;
        public static int MaxRating { get; private set; } = 99999;
        #endregion

        // フォロー上限値
        public static int followingCntMax { get; private set; } = 20;

        // ガチョウが入った木箱の最大HP
        public static int propGooseHp { get; private set; } = 100;

        // 最大参加可能人数
        public static int userMaxCnt { get; private set; } = 4;
    }
}
