﻿using System;
using System.Runtime.InteropServices;
using BrutileArcGIS.lib;
using BrutileArcGIS.Lib;
using ESRI.ArcGIS.ADF.BaseClasses;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Framework;
using BruTile.Web;
using ESRI.ArcGIS.Carto;

namespace BrutileArcGIS.commands
{
    [ProgId("AboutBruTileCommand")]
    public sealed class AboutBruTileCommand : BaseCommand
    {
        private IApplication _application;

        public AboutBruTileCommand()
        {
            m_category = "BruTile";
            m_caption = "&About ArcBruTile...";
            m_message = "About BruTile...";
            m_toolTip = m_caption;
            m_name = "AboutBruTileCommand";
        }

        public override void OnCreate(object hook)
        {
            if (hook == null)
                return;

            _application = hook as IApplication;

            //Disable if it is not ArcMap
            if (hook is IMxApplication)
                m_enabled = true;
            else
                m_enabled = false;
        }

        public override void OnClick()
        {
            // var url = "http://i{s}.maps.daum-img.net/map/image/G03/i/1.20/L{z}/{y}/{x}.png";
            var url1 = "http://h{s}.maps.daum-img.net/map/image/G03/h/1.20/L{z}/{y}/{x}.png";
            var url = "http://s{s}.maps.daum-img.net/L{z}/{y}/{x}.jpg";

            var daumConfig = new DaumConfig("Daum Streets", url);

            var layerType = EnumBruTileLayer.InvertedTMS;
            var mxdoc = (IMxDocument)_application.Document;
            var map = mxdoc.FocusMap;

            var brutileLayer = new BruTileLayer(_application, daumConfig, layerType)
            {
                Name = "Daum Streets",
                Visible = true
            };
            ((IMapLayers)map).InsertLayer(brutileLayer, true, 0);

            //var bruTileAboutBox = new BruTileAboutBox();
            //bruTileAboutBox.ShowDialog(new ArcMapWindow(_application));
        }
    }
}


