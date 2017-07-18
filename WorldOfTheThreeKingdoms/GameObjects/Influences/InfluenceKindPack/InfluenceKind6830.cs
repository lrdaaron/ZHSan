﻿using GameObjects;
using GameObjects.Influences;
using System;


using System.Runtime.Serialization;namespace GameObjects.Influences.InfluenceKindPack
{

    [DataContract]public class InfluenceKind6830 : InfluenceKind
    {
        private int rate;

        public override void ApplyInfluenceKind(Person person)
        {
            person.CommandExperienceIncrease += this.rate;
        }

        public override void PurifyInfluenceKind(Person person)
        {
            person.CommandExperienceIncrease -= this.rate;
        }

        public override void InitializeParameter(string parameter)
        {
            try
            {
                this.rate = int.Parse(parameter);
            }
            catch
            {
            }
        }
    }
}

