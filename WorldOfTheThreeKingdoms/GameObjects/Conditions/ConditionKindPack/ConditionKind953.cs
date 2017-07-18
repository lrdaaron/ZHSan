﻿using GameObjects;
using GameObjects.Conditions;
using System;


using System.Runtime.Serialization;namespace GameObjects.Conditions.ConditionKindPack
{

    [DataContract]public class ConditionKind953 : ConditionKind
    {
        public override bool CheckConditionKind(Person person)
        {
            return person.BelongedFactionWithPrincess != null && !person.Hates(person.BelongedFactionWithPrincess.Leader);
        }
    }
}

