using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    // 英雄 无效的 费用：8
    // Kerrigan, Queen of Blades
    // 刀锋女王凯瑞甘
    // [x]<b>Battlecry:</b> Summon two 2/5 Hive Queens. Deal 3 damage to all enemies.
    // <b>战吼：</b>召唤两个 2/5 的巢群虫后。对所有敌人造成 3 点伤害。

    class Sim_SC_004 : SimTemplate
    {
        private static readonly CardDB.Card hiveQueen = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.SC_003); 

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            // 召唤两个 2/5 的巢群虫后
            if (p.ownMinions.Count < 7) p.callKid(hiveQueen, own.zonepos, own.own);
            if (p.ownMinions.Count < 7) p.callKid(hiveQueen, own.zonepos, own.own);

            // 对所有敌人造成 3 点伤害
            p.allMinionOfASideGetDamage(!own.own, 3); // 伤害所有敌方随从
            p.minionGetDamageOrHeal(own.own ? p.enemyHero : p.ownHero, 3); // 伤害敌方英雄
        }
    }
}