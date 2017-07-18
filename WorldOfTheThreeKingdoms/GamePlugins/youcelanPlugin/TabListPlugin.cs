﻿using GameFreeText;
using GameGlobal;
using GameManager;
using GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Platforms;
using PluginInterface;
using PluginInterface.BaseInterface;
using System;
//using System.Drawing;
using System.Xml;
using WorldOfTheThreeKingdoms;

namespace youcelanPlugin
{

    public class TabListPlugin : GameObject, Iyoucelan, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"Content\Textures\GameComponents\youcelan\Data\";
        private string description = "可选择类别的详细列表";
        private const string Path = @"Content\Textures\GameComponents\youcelan\";
        private string pluginName = "youcelanPlugin";
        private TabListInFrame tabList = new TabListInFrame();
        private string version = "1.0.1";
        private const string XMLFilename = "youcelanData.xml";


        public FrameFunction Function
        {
            get
            {
                return this.tabList.Function;
            }
            set
            {
                this.tabList.Function = value;
            }
        }

        public FrameKind Kind
        {
            get;
            set;
            /*
            get
            {
                return this.tabList.Kind;
            }
            set
            {
                this.tabList.Kind = value;
            }*/
        }

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            this.tabList.Draw(spriteBatch);
        }

        public void Initialize()
        {
        }

        public void InitialValues(object gameObjectList, object selectedObjectList, int scrollValue, string title)
        {
            this.tabList.InitialValues(gameObjectList as GameObjectList, selectedObjectList as GameObjectList, scrollValue, title);
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            Font font;
            Microsoft.Xna.Framework.Color color;
            XmlDocument document = new XmlDocument();
            string xml = Platform.Current.LoadText(filename);document.LoadXml(xml);
            XmlNode nextSibling = document.FirstChild.NextSibling;

            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.tabList.leftedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.leftedgeTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(1);
            this.tabList.rightedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.rightedgeTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(2);
            this.tabList.topedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.topedgeTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(3);
            this.tabList.bottomedgeWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.bottomedgeTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(4);
            this.tabList.backgroundTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            





            node = nextSibling.ChildNodes.Item(5);
            this.tabList.ToolTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.tabList.ToolSelectedTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.tabList.ToolDisplayTexture = this.tabList.ToolSelectedTexture;
            this.tabList.ToolPosition = StaticMethods.LoadRectangleFromXMLNode(node);


            node = nextSibling.ChildNodes.Item(6);
            this.tabList.tabbuttonWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.tabbuttonHeight = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.tabList.tabbuttonTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.tabList.tabbuttonselectedTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("SelectedFileName").Value);
            node = nextSibling.ChildNodes.Item(7);
            this.tabList.columnheaderHeight = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.tabList.columnheaderTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(8);
            this.tabList.columnspliterWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.columnspliterHeight = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.tabList.columnspliterTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(9);
            this.tabList.scrollbuttonWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.scrollbuttonTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(10);
            this.tabList.scrolltrackWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.scrolltrackTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(11);
            this.tabList.leftArrowTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("LeftFileName").Value);
            this.tabList.rightArrowTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("RightFileName").Value);
            node = nextSibling.ChildNodes.Item(12);
            this.tabList.focusTrackTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(13);
            this.tabList.checkboxName = node.Attributes.GetNamedItem("Name").Value;
            this.tabList.checkboxDisplayName = node.Attributes.GetNamedItem("DisplayName").Value;
            this.tabList.checkboxWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.checkboxTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.tabList.checkboxSelectedTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("SelectedFileName").Value);
            this.tabList.roundcheckboxTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("RoundFileName").Value);
            this.tabList.roundcheckboxSelectedTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("RoundSelectedFileName").Value);
            node = nextSibling.ChildNodes.Item(14);
            this.tabList.PortraitWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.PortraitHeight = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            node = nextSibling.ChildNodes.Item(15);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.tabList.TabTextBuilder.SetFreeTextBuilder(this.tabList.graphicsDevice, font);
            this.tabList.TabTextColor = color;
            this.tabList.TabTextAlign = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(16);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.tabList.ColumnTextBuilder.SetFreeTextBuilder(this.tabList.graphicsDevice, font);
            this.tabList.ColumnTextColor = color;
            this.tabList.ColumnTextAlign = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            node = nextSibling.ChildNodes.Item(17);
            this.tabList.SelectSoundFile = @"Content\Sound\" + node.Attributes.GetNamedItem("Select").Value;
            node = nextSibling.ChildNodes.Item(18);
            this.tabList.TopLeftPosition.X  = int.Parse(node.Attributes.GetNamedItem("X").Value);
            this.tabList.TopLeftPosition.Y = int.Parse(node.Attributes.GetNamedItem("Y").Value);

            node = nextSibling.ChildNodes.Item(19);
            //this.gameFrame.TopLeftWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.TopLeftTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(20);
            //this.gameFrame.TopRightWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.TopRightTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(21);
            //this.gameFrame.BottomLeftWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.BottomLeftTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            node = nextSibling.ChildNodes.Item(22);
            //this.gameFrame.BottomRightWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.tabList.BottomRightTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\youcelan\Data\" + node.Attributes.GetNamedItem("FileName").Value);




            this.tabList.LoadFromXMLNode(nextSibling.ChildNodes.Item(23));
        }

        public void RefreshEditable()
        {
            this.tabList.RefreshEditable();
        }

        public void SetArchitectureDetailDialog(IArchitectureDetail iArchitectureDetail)
        {
            this.tabList.iArchitectureDetail = iArchitectureDetail;
        }

        public void SetFactionTechniquesDialog(IFactionTechniques iFactionTechniques)
        {
            this.tabList.iFactionTechniques = iFactionTechniques;
        }

        public void SetGameFrame(IGameFrame iGameFrame)
        {
            this.tabList.iGameFrame = iGameFrame;
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.tabList.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"Content\Data\Plugins\youcelanData.xml");
        }

        public void SetListKindByName(string Name, bool ShowCheckBox, bool MultiSelecting)
        {
            this.tabList.SetListKindByName(Name, ShowCheckBox, MultiSelecting);
        }

        public void SetMapViewSelector(IMapViewSelector iMapViewSelector)
        {
            this.tabList.iMapViewSelector = iMapViewSelector;
            //iMapViewSelector.SetTabList(this);
        }

        public void SetPersonDetailDialog(IPersonDetail iPersonDetail)
        {
            this.tabList.iPersonDetail = iPersonDetail;
        }

        public void SetScreen(object screen)
        {
            this.tabList.Initialize(screen as Screen);
        }

        public void SetSelectedItemMaxCount(int max)
        {
            this.tabList.SelectedItemMaxCount = max;
        }

        public void SetSelectedTab(string tabName)
        {
            this.tabList.SetSelectedTab(tabName);
        }

        public void SetTreasureDetailDialog(ITreasureDetail iTreasureDetail)
        {
            this.tabList.iTreasureDetail = iTreasureDetail;
        }

        public void SetTroopDetailDialog(ITroopDetail iTroopDetail)
        {
            this.tabList.iTroopDetail = iTroopDetail;
        }

        public void Update(GameTime gameTime)
        {
            this.tabList.ReCalculate();
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public object Instance
        {
            get
            {
                return this;
            }
        }

        public bool IsShowing
        {
            get
            {
                return this.tabList.IsShowing;
            }
            set
            {
                this.tabList.IsShowing = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public object SelectedItem
        {
            get
            {
                return this.tabList.SelectedItem;
            }
        }

        public object SelectedItemList
        {
            get
            {
                return this.tabList.SelectedItemList;
            }
        }

        public object TabList
        {
            get
            {
                return this.tabList;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }

        public Microsoft.Xna.Framework.Rectangle FrameRectangle
        {
            get
            {
                if (this.tabList.xianshiyoucelan)
                {
                    return new Microsoft.Xna.Framework.Rectangle(this.tabList.FramePosition.X - 18, this.tabList.FramePosition.Y - 28, this.tabList.FramePosition.Width + 32, this.tabList.FramePosition.Height + 54);
                }
                else
                {
                    return this.tabList.ToolDisplayPosition;
                }
            }
        }

        public void SetyoucelanContent(Microsoft.Xna.Framework.Point viewportSize)
        {
            //if (content is FrameContent)
            //{
            this.tabList.SetyoucelanContent(viewportSize);
            //}
        }
    }
}

