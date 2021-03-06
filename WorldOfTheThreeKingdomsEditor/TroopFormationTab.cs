﻿using GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WorldOfTheThreeKingdomsEditor
{
    class TroopFormationTab : BaseTab<Military>
    {
		public string Lang_TroopFormationID_CHS = "编号";
		public string Lang_TroopFormationID_Desc_CHS = "编队的编号。";
		public string Lang_TroopFormationName_CHS = "名称";
		public string Lang_TroopFormationName_Desc_CHS = "编队的名称。";
		public string Lang_TroopFormationKindID_CHS = "类型";
		public string Lang_TroopFormationKindID_Desc_CHS = "编队的类型编号。";
		public string Lang_TroopFormationQuantity_CHS = "人数";
		public string Lang_TroopFormationQuantity_Desc_CHS = "编队的士兵数量。";
		public string Lang_TroopFormationMorale_CHS = "士气";
		public string Lang_TroopFormationMorale_Desc_CHS = "编队的士气值。";
		public string Lang_TroopFormationCombativity_CHS = "战意";
		public string Lang_TroopFormationCombativity_Desc_CHS = "编队的战意值。";
		public string Lang_TroopFormationExperience_CHS = "经验";
		public string Lang_TroopFormationExperience_Desc_CHS = "编队的经验值。";
		public string Lang_TroopFormationInjuryAmount_CHS = "伤兵";
		public string Lang_TroopFormationInjuryAmount_Desc_CHS = "编队的伤兵数量。";
		public string Lang_TroopFormationYearCreated_CHS = "创建年份";
		public string Lang_TroopFormationYearCreated_Desc_CHS = "编队的创建年份。";
		public string Lang_TroopFormationBelongsToCityID_CHS = "所属城池";
		public string Lang_TroopFormationBelongsToCityID_Desc_CHS = "编队的所属城池编号。";
		public string Lang_TroopFormationFollowingCaptainID_CHS = "追随将领";
		public string Lang_TroopFormationFollowingCaptainID_Desc_CHS = "编队的追随将领编号。";
		public string Lang_TroopFormationLeaderID_CHS = "主将";
		public string Lang_TroopFormationLeaderID_Desc_CHS = "编队的现在将领编号。";
		public string Lang_TroopFormationLeaderExperience_CHS = "主将经验";
		public string Lang_TroopFormationLeaderExperience_Desc_CHS = "编队的主将经验值。";
		public string Lang_TroopFormationTiredness_CHS = "疲劳度";
		public string Lang_TroopFormationTiredness_Desc_CHS = "编队的疲劳度。";
		public string Lang_TroopFormationArrivingDays_CHS = "到达时间";
		public string Lang_TroopFormationArrivingDays_Desc_CHS = "编队到达目的地的剩余天数。";
		public string Lang_TroopFormationDepartureCityID_CHS = "出发城池";
		public string Lang_TroopFormationDepartureCityID_Desc_CHS = "设定编队的出发地城池编号。";
		public string Lang_TroopFormationDestinationCityID_CHS = "目的城池";
		public string Lang_TroopFormationDestinationCityID_Desc_CHS = "设定编队的目的地城池编号。";
		public string Lang_TroopFormationDamageDealt_CHS = "总伤害";
		public string Lang_TroopFormationDamageDealt_Desc_CHS = "编队所造成的伤害总数。";
		public string Lang_TroopFormationDamageTaken_CHS = "所受伤害";
		public string Lang_TroopFormationDamageTaken_Desc_CHS = "编队所受的伤害总数。";
		public string Lang_TroopFormationDamageDealtOnCities_CHS = "城池伤害";
		public string Lang_TroopFormationDamageDealtOnCities_Desc_CHS = "编队所造成的城池伤害总数。";
		public string Lang_TroopFormationFormationsOnBoardID_CHS = "运输编队";
		public string Lang_TroopFormationFormationsOnBoardID_Desc_CHS = "指定船上的在运编队编号。";
		public string Lang_TroopFormationTroopsDefeatedCount_CHS = "击破数";
		public string Lang_TroopFormationTroopsDefeatedCount_Desc_CHS = "该编队的部队击破次数。";
		public string Lang_TroopFormationCharactersKilledCount_CHS = "击杀数";
		public string Lang_TroopFormationCharactersKilledCount_Desc_CHS = "该编队的人物击杀次数。";
		public string Lang_TroopFormationCharactersCapturedCount_CHS = "俘虏数";
		public string Lang_TroopFormationCharactersCapturedCount_Desc_CHS = "该编队的俘虏过的人物总数。";
		public string Lang_TroopFormationStrategySucceededCount_CHS = "计略成功";
		public string Lang_TroopFormationStrategySucceededCount_Desc_CHS = "该编队成功施放计略的次数。";
		public string Lang_TroopFormationStrategyFailedCount_CHS = "计略失败";
		public string Lang_TroopFormationStrategyFailedCount_Desc_CHS = "该编队施放计略失败的次数";
		public string Lang_TroopFormationTrickedByStrategyCount_CHS = "中计次数";
		public string Lang_TroopFormationTrickedByStrategyCount_Desc_CHS = "该编队抵挡计略失败的次数。";
		public string Lang_TroopFormationStrategyDefendedCount_CHS = "计略阻挡";
		public string Lang_TroopFormationStrategyDefendedCount_Desc_CHS = "该编队成功阻挡计略的次数。";
		public string Lang_TroopFormationRecruitingOfficerID_CHS = "补充担当";
		public string Lang_TroopFormationRecruitingOfficerID_Desc_CHS = "指定担当补充该编队士兵的人数。";
		
        protected override IItemList GetDataList(GameScenario scen)
        {
            return new GameObjectItemList(scen.Militaries);
        }

        protected override Dictionary<string, string> GetDefaultValues()
        {
            return new Dictionary<string, string>()
            {
                {"Morale", "100"},
                {"Combativity", "100" },
                {"Quantity", "1000"},
                {"FollowingCaptainID", "-1"},
                {"LeaderID", "-1" },
                {"TrainingPersonID", "-1" },
                {"RecruitingOfficerID", "-1" },
                {"ShelledMilitary", "-1" },
                {"DepartureCityID", "-1" },
                {"DestinationCityID", "-1" }
            };
        }

        protected override string[] GetRawItemOrder()
        {
            return new String[]
            {
                "ID",
                "Name",
                "kindID",
                "Quantity",
                "Morale",
                "Combativity",
                "Experience",
                "InjuryAmount",
				"YearCreated",
				"BelongsToCityID",
                "FollowingCaptainID",
                "LeaderID",
                "leaderExperience",
                "Tiredness",
                "ArrivingDays",
                "DepartureCityID",
                "DestinationCityID",
				"TroopDamageDealt",
				"TroopDamageTaken",
				"DamageDealtOnCities",
				"FormationsOnBoardID",
				"TroopsDefeatedCount",
				"CharactersKilledCount",
				"CharactersCapturedCount",
				"StrategySucceededCount",
				"StrategyFailedCount",
				"TrickedByStrategyCount",
				"StrategyDefendedCount",
				"RecruitingOfficerID"
            };
        }

        protected override Dictionary<String, String> GetHelpText()
        {
            return new Dictionary<string, string>()
            {
				{ Lang_TroopFormationID_CHS, Lang_TroopFormationID_Desc_CHS },
				{ Lang_TroopFormationName_CHS, Lang_TroopFormationName_Desc_CHS },
				{ Lang_TroopFormationKindID_CHS, Lang_TroopFormationKindID_Desc_CHS },
				{ Lang_TroopFormationQuantity_CHS, Lang_TroopFormationQuantity_Desc_CHS },
				{ Lang_TroopFormationMorale_CHS, Lang_TroopFormationMorale_Desc_CHS },
				{ Lang_TroopFormationCombativity_CHS, Lang_TroopFormationCombativity_Desc_CHS },
				{ Lang_TroopFormationExperience_CHS, Lang_TroopFormationExperience_Desc_CHS },
				{ Lang_TroopFormationInjuryAmount_CHS, Lang_TroopFormationInjuryAmount_Desc_CHS },
				{ Lang_TroopFormationYearCreated_CHS, Lang_TroopFormationYearCreated_Desc_CHS },
				{ Lang_TroopFormationBelongsToCityID_CHS, Lang_TroopFormationBelongsToCityID_Desc_CHS },
				{ Lang_TroopFormationFollowingCaptainID_CHS, Lang_TroopFormationFollowingCaptainID_Desc_CHS },
				{ Lang_TroopFormationLeaderID_CHS, Lang_TroopFormationLeaderID_Desc_CHS },
				{ Lang_TroopFormationLeaderExperience_CHS, Lang_TroopFormationLeaderExperience_Desc_CHS },
				{ Lang_TroopFormationTiredness_CHS, Lang_TroopFormationTiredness_Desc_CHS },
				{ Lang_TroopFormationArrivingDays_CHS, Lang_TroopFormationArrivingDays_Desc_CHS },
				{ Lang_TroopFormationDepartureCityID_CHS, Lang_TroopFormationDepartureCityID_Desc_CHS },
				{ Lang_TroopFormationDestinationCityID_CHS, Lang_TroopFormationDestinationCityID_Desc_CHS },
				{ Lang_TroopFormationDamageDealt_CHS, Lang_TroopFormationDamageDealt_Desc_CHS },
				{ Lang_TroopFormationDamageTaken_CHS, Lang_TroopFormationDamageTaken_Desc_CHS },
				{ Lang_TroopFormationDamageDealtOnCities_CHS, Lang_TroopFormationDamageDealtOnCities_Desc_CHS },
				{ Lang_TroopFormationFormationsOnBoardID_CHS, Lang_TroopFormationFormationsOnBoardID_Desc_CHS },
				{ Lang_TroopFormationTroopsDefeatedCount_CHS, Lang_TroopFormationTroopsDefeatedCount_Desc_CHS },
				{ Lang_TroopFormationCharactersKilledCount_CHS, Lang_TroopFormationCharactersKilledCount_Desc_CHS },
				{ Lang_TroopFormationCharactersCapturedCount_CHS, Lang_TroopFormationCharactersCapturedCount_Desc_CHS },
				{ Lang_TroopFormationStrategySucceededCount_CHS, Lang_TroopFormationStrategySucceededCount_Desc_CHS },
				{ Lang_TroopFormationStrategyFailedCount_CHS, Lang_TroopFormationStrategyFailedCount_Desc_CHS },
				{ Lang_TroopFormationTrickedByStrategyCount_CHS, Lang_TroopFormationTrickedByStrategyCount_Desc_CHS },
				{ Lang_TroopFormationStrategyDefendedCount_CHS, Lang_TroopFormationStrategyDefendedCount_Desc_CHS },
				{ Lang_TroopFormationRecruitingOfficerID_CHS, Lang_TroopFormationRecruitingOfficerID_Desc_CHS }
            };
        }

        public TroopFormationTab(GameScenario scen, DataGrid dg, TextBlock helpTextBlock)
        {
            init(scen, dg, helpTextBlock);
        }
    }
}
