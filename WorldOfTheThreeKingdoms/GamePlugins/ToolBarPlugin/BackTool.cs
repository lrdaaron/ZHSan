﻿using GameManager;
using GameObjects;
using GamePanels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PluginInterface;
using WorldOfTheThreeKingdoms.GameScreens;

namespace WorldOfTheThreeKingdoms.GamePlugins.ToolBarPlugin
{
    public class BackTool
    {
        ButtonTexture btBack;

        public Vector2 Position
        {
            get
            {
                return btBack.Position;
            }
            set
            {
                btBack.Position = value;
            }
        }

        public bool MouseOver
        {
            get
            {
                return btBack.MouseOver;
            }
        }
        
        public BackTool()
        {
            btBack = new ButtonTexture(@"Content\Textures\Resources\Start\Back", "Back", null);
            btBack.OnButtonPress += (sender, e) =>
            {
                var architectureDetail = Session.MainGame.mainGameScreen.Plugins.ArchitectureDetailPlugin;
                var personDetail = Session.MainGame.mainGameScreen.Plugins.PersonDetailPlugin;
                var treasureDetail = Session.MainGame.mainGameScreen.Plugins.TreasureDetailPlugin;
                var factionTech = Session.MainGame.mainGameScreen.Plugins.FactionTechniquesPlugin;
                var optionDialog = Session.MainGame.mainGameScreen.Plugins.OptionDialogPlugin as OptionDialogPlugin.OptionDialogPlugin;
                var troopDetail = Session.MainGame.mainGameScreen.Plugins.TroopDetailPlugin;
                var createTroop = Session.MainGame.mainGameScreen.Plugins.CreateTroopPlugin;

                if (architectureDetail.IsShowing)
                {
                    architectureDetail.IsShowing = false;
                }
                else if (personDetail.IsShowing)
                {
                    personDetail.IsShowing = false;
                }
                else if (treasureDetail.IsShowing)
                {
                    treasureDetail.IsShowing = false;
                }
                else if (factionTech.IsShowing)
                {
                    factionTech.IsShowing = false;
                }
                else if (optionDialog.IsShowing)
                {
                    optionDialog.IsShowing = false;
                }
                else if (troopDetail.IsShowing)
                {
                    troopDetail.IsShowing = false;
                }
                else if (createTroop.IsShowing)
                {
                    createTroop.IsShowing = false;
                }
            };          
        }

        public void Update()
        {
            var architectureDetail = Session.MainGame.mainGameScreen.Plugins.ArchitectureDetailPlugin;
            var personDetail = Session.MainGame.mainGameScreen.Plugins.PersonDetailPlugin;
            var treasureDetail = Session.MainGame.mainGameScreen.Plugins.TreasureDetailPlugin;
            var factionTech = Session.MainGame.mainGameScreen.Plugins.FactionTechniquesPlugin;
            var optionDialog = Session.MainGame.mainGameScreen.Plugins.OptionDialogPlugin as OptionDialogPlugin.OptionDialogPlugin;
            var troopDetail = Session.MainGame.mainGameScreen.Plugins.TroopDetailPlugin;
            var createTroop = Session.MainGame.mainGameScreen.Plugins.CreateTroopPlugin;

            if (architectureDetail.IsShowing || personDetail.IsShowing || treasureDetail.IsShowing || troopDetail.IsShowing || createTroop.IsShowing
                || factionTech.IsShowing || optionDialog.OptionTitle != "系统选项" && optionDialog.IsShowing)
            {
                btBack.Visible = true;
            }
            else
            {
                btBack.Visible = false;
            }

            btBack.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            btBack.Draw();

        }

    }
}
