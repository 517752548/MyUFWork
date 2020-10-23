using UnityEngine;
using app.model;
using app.utils;
using app.main;
using System;
using System.Collections.Generic;

namespace app.zone
{
    
    
    public class ZoneMap
    {
        private class ZoneMapTile
        {
            public int col;
            public int row;
            public string path;
            public int status;
            public GameObject tile;
            public Texture2D tex;
        }

        //private int[,] mMapTilesStatus = null;
        private ZoneMapTile[,] mMapTiles = null;
        private int mMapTileColsCount = 0;
        private int mMapTileRowsCount = 0;
        private Vector3 mTileUnityPosFix = Vector3.zero;
        private string mMapTilesPath = null;
        private Vector3 mLastCheckedUnityPos = Vector3.zero;
        
        private int mSceneStartCol = 0;
        private int mSceneStartRow = 0;
        private int mSceneEndCol = 0;
        private int mSceneEndRow = 0;
        
        private bool mIsInBattle = false;

        private string mMapSceneName = null;

        private List<ZoneMapTile> mLoadingList = new List<ZoneMapTile>();

        private Action mMapTilesInited = null;
        private int mMapTilesInitCount = 0;
        
        public void Init(string mapSceneName)
        {
            mMapSceneName = mapSceneName;
            mMapTilesPath = PathUtil.Ins.GetZoneScenePath(mapSceneName + "_tiles");
            mMapTileColsCount = Mathf.CeilToInt((float)ZoneModel.ins.mapPixelWidth / (float)ZoneDef.MAP_TILE_PIXEL_WIDTH);
            mMapTileRowsCount = Mathf.CeilToInt((float)ZoneModel.ins.mapPixelHeight / (float)ZoneDef.MAP_TILE_PIXEL_HEIGHT);
            int mMapTilesBlankWidth = mMapTileColsCount * ZoneDef.MAP_TILE_PIXEL_WIDTH - ZoneModel.ins.mapPixelWidth;
            int mMapTilesBlankHeight = mMapTileRowsCount * ZoneDef.MAP_TILE_PIXEL_HEIGHT - ZoneModel.ins.mapPixelHeight;
            float mMapRBTileBlankWPerHalf = (float)mMapTilesBlankWidth / (float)ZoneDef.MAP_TILE_PIXEL_WIDTH * 0.5f;
            float mMapRBTileBlankHPerHalf = (float)mMapTilesBlankHeight / (float)ZoneDef.MAP_TILE_PIXEL_HEIGHT * 0.5f;
            mTileUnityPosFix.x = mMapRBTileBlankWPerHalf + 0.5f;
            mTileUnityPosFix.y = -(mMapRBTileBlankHPerHalf + 0.5f);

            //mMapTilesStatus = new int[mMapTileColsCount, mMapTileRowsCount];

            mMapTiles = new ZoneMapTile[mMapTileColsCount, mMapTileRowsCount];

            for (int i = 0; i < mMapTileColsCount; i++)
            {
                for (int j = 0; j < mMapTileRowsCount; j++)
                {
                    if (mMapTiles[i, j] == null)
                    {
                        mMapTiles[i, j] = new ZoneMapTile
                            {
                                col = i, 
                                row = j, 
                                path = null,
                                status = 0, 
                                tile = null
                            };
                    }
                }
            }
        }

        public void Update(Vector3 roleUnityPos, bool loadInQueue = true)
        {
            if (mLastCheckedUnityPos.x != roleUnityPos.x || mLastCheckedUnityPos.z != roleUnityPos.z )
            {
                UpdateCellsStatus(roleUnityPos, loadInQueue);
                mLastCheckedUnityPos = roleUnityPos;
            }
        }

        public void InitMapTiles(Vector3 roleUnityPos, Action mapTilesInited = null)
        {
            mMapTilesInited = mapTilesInited;
            UpdateCellsStatus(roleUnityPos, false);
            mLastCheckedUnityPos = roleUnityPos;
        }

        private void UpdateCellsStatus(Vector3 roleUnityPos, bool loadInQueue = true)
        {
            //int scrWidth = Screen.width;
            //int scrHeight = Screen.height;
            int zoneViewportW = UGUIConfig.ZoneViewportWidth;
            int zoneViewportH = UGUIConfig.ZoneViewportHeight;
            
            int[] rolePixelPos = ZoneUtil.ConvertUnityPos2LeftTopPixelPos(roleUnityPos);

            float dx = 0.0f;
            float dy = 0.0f;
            float rx = rolePixelPos[0] + zoneViewportW * 0.5f;
            float ry = rolePixelPos[1] + zoneViewportH * 0.5f;
            int mapW = ZoneModel.ins.mapTpl.width;
            int mapH = ZoneModel.ins.mapTpl.height;

            if (rx > mapW)
            {
                dx = mapW - rx;
            }

            if (ry > mapH)
            {
                dy = mapH - ry;
            }

            //屏幕左上角像素坐标。
            Vector2 scrLeftTopPixPos = new Vector2(
                Mathf.Max(rolePixelPos[0] - (float)zoneViewportW * 0.5f + dx, 0), 
                Mathf.Max(rolePixelPos[1] - (float)zoneViewportH * 0.5f + dy, 0));
            //屏幕右下角像素坐标。
            Vector2 scrRightBottomPixPos = new Vector2(scrLeftTopPixPos.x + zoneViewportW, scrLeftTopPixPos.y + zoneViewportH);

            if (loadInQueue)
            {
                mSceneStartCol = Mathf.FloorToInt(scrLeftTopPixPos.x / (float)ZoneDef.MAP_TILE_PIXEL_WIDTH) - 1;
                mSceneStartRow = Mathf.FloorToInt(scrLeftTopPixPos.y / (float)ZoneDef.MAP_TILE_PIXEL_HEIGHT) - 1;
            }
            else
            {
                mSceneStartCol = Mathf.FloorToInt(scrLeftTopPixPos.x / (float)ZoneDef.MAP_TILE_PIXEL_WIDTH);
                mSceneStartRow = Mathf.FloorToInt(scrLeftTopPixPos.y / (float)ZoneDef.MAP_TILE_PIXEL_HEIGHT);
            }

            mSceneEndCol = Mathf.CeilToInt(scrRightBottomPixPos.x / (float)ZoneDef.MAP_TILE_PIXEL_WIDTH);
            mSceneEndRow = Mathf.CeilToInt(scrRightBottomPixPos.y / (float)ZoneDef.MAP_TILE_PIXEL_HEIGHT);

            mSceneStartCol = Mathf.Max(0, mSceneStartCol);
            mSceneStartRow = Mathf.Max(0, mSceneStartRow);

            mSceneEndCol = Mathf.Min(mMapTileColsCount - 1, mSceneEndCol);
            mSceneEndRow = Mathf.Min(mMapTileRowsCount - 1, mSceneEndRow);

            for (int col = 0; col < mMapTileColsCount; col++)
            {
                for (int row = 0; row < mMapTileRowsCount; row++)
                {
                    ZoneMapTile tile = mMapTiles[col, row];
                    if (col >= mSceneStartCol && col <= mSceneEndCol && row >= mSceneStartRow && row <= mSceneEndRow)
                    {
                        if (tile.status == 0)
                        {
                            tile.status = 1;

                            if (tile.tex != null)
                            {
                                ShowTile(tile);
                            }
                            else
                            {
                                if (tile.path == null)
                                {
                                    tile.path = PathUtil.Ins.GetZoneSceneMapTilePath(mMapSceneName, col, row);
                                }
                                //GameClient.ins.SimpleLoad(tile.path, OnMapTileLoaded, false, false, tile, true);
                                mMapTilesInitCount++;
                                SourceLoader.Ins.load(tile.path, OnMapTileLoaded, null, tile, !loadInQueue, LoadArgs.NONE, LoadContentType.BIN);
                            }
                        }
                    }
                    else
                    {
                        if (tile.status == 1)
                        {
                            tile.status = 0;
                            SourceManager.Ins.removeReference(tile.path, tile.tile, true);
                        }
                    }
                }
            }
        }

        private void OnMapTileLoaded(RMetaEvent e)
        {
            if (e.type == SourceLoader.LOAD_COMPLETE)
            {
                LoadInfo loadInfo = (e.data as LoadInfo);
                if (mMapTiles != null)
                {
                    ZoneMapTile tile = loadInfo.param as ZoneMapTile;
                    if (tile.status == 1)
                    {
                        //loadInfo.bundleContainer.referenceCount++;
                        //mapTileUnityPos.x -= col * 0.02f;
                        //mapTileUnityPos.y += row * 0.02f;
                        //byte[] rawData = loadInfo.bundleContainer.bytes;
                        /*
                        uint num5 = x54662872262ea52a(rawData, 60, false);
                        uint num6 = x54662872262ea52a(rawData, 0x40 + (int)num5, false);
                        uint num7 = (0x40 + num5) + 4;
                        byte[] buffer = new byte[num6];
                        Buffer.BlockCopy(rawData, (int)num7, buffer, 0, (int)num6);
                        Debug.LogError(num7 + ", " + num6);
                        */
                        //byte[] buffer = new byte[32768];
                        Texture2D mapTileTex = null;
                        #if UNITY_ANDROID
                        //Buffer.BlockCopy(rawData, 68, buffer, 0, 32768);
                        mapTileTex = new Texture2D(ZoneDef.MAP_TILE_PIXEL_WIDTH, ZoneDef.MAP_TILE_PIXEL_HEIGHT, TextureFormat.ETC_RGB4, false, true);
                        #elif UNITY_IOS
                        //Buffer.BlockCopy(rawData, 52, buffer, 0, 32768);
                        mapTileTex = new Texture2D(ZoneDef.MAP_TILE_PIXEL_WIDTH, ZoneDef.MAP_TILE_PIXEL_HEIGHT, TextureFormat.PVRTC_RGB4, false, true);
                        #endif
                        mapTileTex.wrapMode = TextureWrapMode.Clamp;
                        mapTileTex.LoadRawTextureData(loadInfo.bundleContainer.bytes);
                        mapTileTex.Apply();
                        tile.tex = mapTileTex;

                        //Texture2D mapTileTex = SourceManager.Ins.GetAsset<Texture2D>(loadInfo.urlPath);
                        ShowTile(tile);
                    }
                    else
                    {
                        //SourceManager.Ins.removeReference(loadInfo.urlPath);
                        //loadInfo.bundleContainer.referenceCount--;
                    }
                }
                else
                {
                    //SourceManager.Ins.removeReference(loadInfo.urlPath);
                    //loadInfo.bundleContainer.referenceCount--;
                }

                mMapTilesInitCount--;
                if (mMapTilesInitCount == 0)
                {
                    if (mMapTilesInited != null)
                    {
                        mMapTilesInited();
                        mMapTilesInited = null;
                    }
                }
            }
            else
            {

            }
        }

        private void ShowTile(ZoneMapTile tile)
        {
            Vector3 mapTileUnityPos = new Vector3((float)tile.col - (float)mMapTileColsCount / 2.0f + mTileUnityPosFix.x, (float)(mMapTileRowsCount - tile.row) - (float)mMapTileRowsCount / 2.0f + +mTileUnityPosFix.y, mTileUnityPosFix.z);
            GameObject groundTile = SceneModel.ins.zoneMapConfig.groundTile;
            GameObject mapTile = GameObject.Instantiate(groundTile);
            mapTile.transform.SetParent(groundTile.transform.parent);
            mapTile.transform.localEulerAngles = groundTile.transform.localEulerAngles;
            mapTile.transform.localScale = groundTile.transform.localScale;
            mapTile.layer = groundTile.layer;
            mapTile.GetComponent<MeshRenderer>().material.SetTexture("_MainTexture", tile.tex);
            mapTile.transform.localPosition = mapTileUnityPos;
            mapTile.SetActive(true);
            //tile.path = loadInfo.urlPath;
            tile.tile = mapTile;
        }

        /*
        private uint x54662872262ea52a(byte[] x4a3f0a05c02f235f, int x10aaa7cdfa38f254, bool xfd487787605a7fc7)
        {
            byte[] buffer;
            uint num;
            bool flag = !xfd487787605a7fc7;
            //do
            {
                if (flag)
                {
                    return BitConverter.ToUInt32(x4a3f0a05c02f235f, x10aaa7cdfa38f254);
                }
                buffer = new byte[4];
            }
            //while ((num - x10aaa7cdfa38f254) < 0);
            Buffer.BlockCopy(x4a3f0a05c02f235f, x10aaa7cdfa38f254, buffer, 0, 4);
            Array.Reverse(buffer);
            return BitConverter.ToUInt32(buffer, 0);
        }
        */
        
        public void EnterBattle()
        {
            GameObjectUtil.SetLayer(SceneModel.ins.ground, SceneModel.ins.battleGroundContainer.layer);
            
            /*
            for (int col = mSceneStartCol; col <= mSceneEndCol; col++)
            {
                for (int row = mSceneStartRow; row <= mSceneEndRow; row++)
                {
                    if (mMapTiles[col, row] != null)
                    {
                        mMapTiles[col, row].GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0.39f, 0.39f, 0.39f, 1));
                    }
                }
            }
            */
            mIsInBattle = true;
        }

        public void ExitBattle()
        {
            GameObjectUtil.SetLayer(SceneModel.ins.ground, LayerMask.NameToLayer(GlobalConstDefine.SCENE_GROUND_LAYER_NAME));
            
            /*
            for (int col = mSceneStartCol; col <= mSceneEndCol; col++)
            {
                for (int row = mSceneStartRow; row <= mSceneEndRow; row++)
                {
                    if (mMapTiles[col, row] != null)
                    {
                        mMapTiles[col, row].GetComponent<MeshRenderer>().material.SetColor("_Color", Color.white);
                    }
                }
            }
            */
            mIsInBattle = false;
        }

        public void Destroy()
        {
            if (mMapTiles != null)
            {
                for (int col = 0; col < mMapTileColsCount; col++)
                {
                    for (int row = 0; row < mMapTileRowsCount; row++)
                    {
                        ZoneMapTile tile = mMapTiles[col, row];
                        if (tile != null)
                        {
                            if (tile.tex != null)
                            {
                                GameObject.DestroyImmediate(tile.tex, true);
                            }

                            if (tile.tile != null)
                            {
                                GameObject.DestroyImmediate(tile.tile, true);
                            }
                        }
                        
                        tile.path = null;
                        tile.status = 0;
                        tile.tex = null;
                    }
                }
            }
            //mMapTiles = null;
            mLastCheckedUnityPos = Vector3.zero;
        }
    }
}