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

namespace RoutewayEditorPlugin
{

    public class RoutewayEditorPlugin : GameObject, IRoutewayEditor, IBasePlugin, IPluginXML, IPluginGraphics, IScreenDisableRects
    {
        private string author = "clip_on";
        private const string DataPath = @"Content\Textures\GameComponents\RoutewayEditor\Data\";
        private string description = "粮道编辑器";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"Content\Textures\GameComponents\RoutewayEditor\";
        private string pluginName = "RoutewayEditorPlugin";
        private RoutewayEditor routewayEditor = new RoutewayEditor();
        private string version = "1.0.0";
        private const string XMLFilename = "RoutewayEditorData.xml";

        public void AddDisableRects()
        {
            this.routewayEditor.AddDisableRects();
        }

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.routewayEditor.IsShowing)
            {
                this.routewayEditor.Draw(spriteBatch);
            }
        }

        public void Initialize()
        {
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            Font font;
            Microsoft.Xna.Framework.Color color;
            XmlDocument document = new XmlDocument();
            string xml = Platform.Current.LoadText(filename);document.LoadXml(xml);
            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.routewayEditor.BackgroundTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.BackgroundSize = new Microsoft.Xna.Framework.Point(int.Parse(node.Attributes.GetNamedItem("Width").Value), int.Parse(node.Attributes.GetNamedItem("Height").Value));
            node = nextSibling.ChildNodes.Item(1);
            this.routewayEditor.CommentBackgroundTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.CommentClientWidth = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            node = nextSibling.ChildNodes.Item(2);
            this.routewayEditor.Comment.ClientWidth = this.routewayEditor.CommentClientWidth;
            this.routewayEditor.Comment.RowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            this.routewayEditor.Comment.TitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("TitleColor").Value);
            this.routewayEditor.Comment.SubTitleColor = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor").Value);
            this.routewayEditor.Comment.SubTitleColor2 = StaticMethods.LoadColor(node.Attributes.GetNamedItem("SubTitleColor2").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);

            this.routewayEditor.Comment.Builder = font;
            //this.routewayEditor.Comment.Builder.SetFreeTextBuilder(this.graphicsDevice, font);

            this.routewayEditor.Comment.DefaultColor = color;
            node = nextSibling.ChildNodes.Item(3);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.routewayEditor.TitleText = new FreeText(this.graphicsDevice, font, color);
            this.routewayEditor.TitleText.Position = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.TitleText.Align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            this.routewayEditor.TitleText.Text = node.Attributes["Text"].Value;
            node = nextSibling.ChildNodes.Item(4);
            this.routewayEditor.ExtendButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.ExtendButtonTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.ExtendButtonSelectedTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.routewayEditor.ExtendButtonDownTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Down").Value);
            this.routewayEditor.ExtendButtonDisabledTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(5);
            this.routewayEditor.CutButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.CutButtonTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.CutButtonSelectedTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.routewayEditor.CutButtonDownTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Down").Value);
            this.routewayEditor.CutButtonDisabledTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(6);
            this.routewayEditor.DirectionSwitchPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.DirectionSwitchTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.DirectionSwitchSelectedTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.routewayEditor.DirectionSwitchDisabledTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(7);
            this.routewayEditor.BuildButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.BuildButtonTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.BuildButtonSelectedTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.routewayEditor.BuildButtonDownTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Down").Value);
            node = nextSibling.ChildNodes.Item(8);
            this.routewayEditor.EndButtonPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.routewayEditor.EndButtonTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.EndButtonSelectedTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Selected").Value);
            this.routewayEditor.EndButtonDownTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Down").Value);
            node = nextSibling.ChildNodes.Item(9);
            this.routewayEditor.ExtendMouseArrowSize = new Microsoft.Xna.Framework.Point(int.Parse(node.Attributes.GetNamedItem("Width").Value), int.Parse(node.Attributes.GetNamedItem("Height").Value));
            this.routewayEditor.ExtendMouseArrowTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.ExtendDisabledMouseArrowTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(10);
            this.routewayEditor.CutMouseArrowSize = new Microsoft.Xna.Framework.Point(int.Parse(node.Attributes.GetNamedItem("Width").Value), int.Parse(node.Attributes.GetNamedItem("Height").Value));
            this.routewayEditor.CutMouseArrowTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.CutDisabledMouseArrowTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("Disabled").Value);
            node = nextSibling.ChildNodes.Item(11);
            this.routewayEditor.ExtendPointTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.routewayEditor.ExtendPointEndTexture = CacheManager.LoadTempTexture(@"Content\Textures\GameComponents\RoutewayEditor\Data\" + node.Attributes.GetNamedItem("End").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            TextAlign align = (TextAlign) Enum.Parse(typeof(TextAlign), node.Attributes.GetNamedItem("Align").Value);
            for (int i = 0; i < 4; i++)
            {
                FreeText item = new FreeText(this.graphicsDevice, font, color) {
                    Align = align
                };
                this.routewayEditor.ExtendPointTexts.Add(item);
            }
        }

        public void RemoveDisableRects()
        {
            this.routewayEditor.RemoveDisableRects();
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"Content\Data\Plugins\RoutewayEditorData.xml");
        }

        public void SetRouteway(object routeway)
        {
            this.routewayEditor.SetRouteway(routeway as Routeway);
        }

        public void SetScreen(object screen)
        {
            this.routewayEditor.Initialize(screen as Screen);
        }

        public void Update(GameTime gameTime)
        {
            if (this.routewayEditor.IsShowing)
            {
                this.routewayEditor.Update();
            }
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
                return this.routewayEditor.IsShowing;
            }
            set
            {
                this.routewayEditor.IsShowing = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }
    }
}

