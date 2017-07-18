﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Tools;

namespace GameManager
{
    [DataContract]
    public class Scenario
    {
        [DataMember]
        public string ID { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Path { get; set; }
        [DataMember]
        public string Time { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Create { get; set; }
        [DataMember]
        public string Info { get; set; }
        [DataMember]
        public string First { get; set; }
        [DataMember]
        public string Desc { get; set; }
        [DataMember]
        public string IDs { get; set; }
        [DataMember]
        public string Names { get; set; }
        [DataMember]
        public string Players { get; set; }
        [DataMember]
        public string Player { get; set; }
        [DataMember]
        public string PlayTime { get; set; }

        public string GameTime
        {
            get
            {
                int playTime;
                if (int.TryParse(PlayTime, out playTime))
                {
                    return (playTime / 60 / 60) + ":" + (playTime / 60 % 60);
                }
                return "";
            }
        }

        public string Summary
        {
            get
            {
                string str = "空 白 存 档";

                string exp = ID == "0" ? "(自动保存) " : "";

                if (!String.IsNullOrEmpty(Title))
                {
                    str = String.Join("  ", new string[] { Info, Title, Time.ToSeasonDate(), Create.ToSeasonShortTime(), "(" + GameTime + ")" });
                }
                return exp + str;
            }
        }
    }
}
