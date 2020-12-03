#if USE_UNI_LUA
using LuaAPI = UniLua.Lua;
using RealStatePtr = UniLua.ILuaState;
using LuaCSFunction = UniLua.CSharpFunctionDelegate;
#else
using LuaAPI = XLua.LuaDLL.Lua;
using RealStatePtr = System.IntPtr;
using LuaCSFunction = XLua.LuaDLL.lua_CSFunction;
#endif

using XLua;
using System.Collections.Generic;
using Pathfinding;

namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class PFRecastGraphWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.RecastGraph);
			Utils.BeginObjectRegister(type, L, translator, 0, 63, 30, 24);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateTransform", _m_CalculateTransform);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InitializeTileInfo", _m_InitializeTileInfo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ScanAllTiles", _m_ScanAllTiles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PutMeshesIntoTileBuckets", _m_PutMeshesIntoTileBuckets);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CollectMeshes", _m_CollectMeshes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateTileBoundsWithBorder", _m_CalculateTileBoundsWithBorder);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BuildTileMesh", _m_BuildTileMesh);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CreateTile", _m_CreateTile);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SnapForceBoundsToScene", _m_SnapForceBoundsToScene);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getTileWorldSizeX", _g_get_TileWorldSizeX);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getTileWorldSizeZ", _g_get_TileWorldSizeZ);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCellHeight", _g_get_CellHeight);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getCharacterRadiusInVoxels", _g_get_CharacterRadiusInVoxels);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getTileBorderSizeInVoxels", _g_get_TileBorderSizeInVoxels);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getTileBorderSizeInWorldUnits", _g_get_TileBorderSizeInWorldUnits);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcharacterRadius", _g_get_characterRadius);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcontourMaxError", _g_get_contourMaxError);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcellSize", _g_get_cellSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getwalkableHeight", _g_get_walkableHeight);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getwalkableClimb", _g_get_walkableClimb);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxSlope", _g_get_maxSlope);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxEdgeLength", _g_get_maxEdgeLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getminRegionSize", _g_get_minRegionSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "geteditorTileSize", _g_get_editorTileSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettileSizeX", _g_get_tileSizeX);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettileSizeZ", _g_get_tileSizeZ);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getuseTiles", _g_get_useTiles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getscanEmptyGraph", _g_get_scanEmptyGraph);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrelevantGraphSurfaceMode", _g_get_relevantGraphSurfaceMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrasterizeColliders", _g_get_rasterizeColliders);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrasterizeMeshes", _g_get_rasterizeMeshes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrasterizeTerrain", _g_get_rasterizeTerrain);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrasterizeTrees", _g_get_rasterizeTrees);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcolliderRasterizeDetail", _g_get_colliderRasterizeDetail);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmask", _g_get_mask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettagMask", _g_get_tagMask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getterrainSampleSize", _g_get_terrainSampleSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrotation", _g_get_rotation);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getforcedBoundsCenter", _g_get_forcedBoundsCenter);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcharacterRadius", _s_set_characterRadius);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcontourMaxError", _s_set_contourMaxError);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcellSize", _s_set_cellSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setwalkableHeight", _s_set_walkableHeight);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setwalkableClimb", _s_set_walkableClimb);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxSlope", _s_set_maxSlope);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxEdgeLength", _s_set_maxEdgeLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setminRegionSize", _s_set_minRegionSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "seteditorTileSize", _s_set_editorTileSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settileSizeX", _s_set_tileSizeX);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settileSizeZ", _s_set_tileSizeZ);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setuseTiles", _s_set_useTiles);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setscanEmptyGraph", _s_set_scanEmptyGraph);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrelevantGraphSurfaceMode", _s_set_relevantGraphSurfaceMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrasterizeColliders", _s_set_rasterizeColliders);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrasterizeMeshes", _s_set_rasterizeMeshes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrasterizeTerrain", _s_set_rasterizeTerrain);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrasterizeTrees", _s_set_rasterizeTrees);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcolliderRasterizeDetail", _s_set_colliderRasterizeDetail);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmask", _s_set_mask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settagMask", _s_set_tagMask);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setterrainSampleSize", _s_set_terrainSampleSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrotation", _s_set_rotation);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setforcedBoundsCenter", _s_set_forcedBoundsCenter);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "TileWorldSizeX", _g_get_TileWorldSizeX);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TileWorldSizeZ", _g_get_TileWorldSizeZ);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CellHeight", _g_get_CellHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "CharacterRadiusInVoxels", _g_get_CharacterRadiusInVoxels);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TileBorderSizeInVoxels", _g_get_TileBorderSizeInVoxels);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "TileBorderSizeInWorldUnits", _g_get_TileBorderSizeInWorldUnits);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "characterRadius", _g_get_characterRadius);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "contourMaxError", _g_get_contourMaxError);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cellSize", _g_get_cellSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "walkableHeight", _g_get_walkableHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "walkableClimb", _g_get_walkableClimb);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxSlope", _g_get_maxSlope);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxEdgeLength", _g_get_maxEdgeLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "minRegionSize", _g_get_minRegionSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "editorTileSize", _g_get_editorTileSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tileSizeX", _g_get_tileSizeX);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tileSizeZ", _g_get_tileSizeZ);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "useTiles", _g_get_useTiles);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "scanEmptyGraph", _g_get_scanEmptyGraph);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "relevantGraphSurfaceMode", _g_get_relevantGraphSurfaceMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rasterizeColliders", _g_get_rasterizeColliders);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rasterizeMeshes", _g_get_rasterizeMeshes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rasterizeTerrain", _g_get_rasterizeTerrain);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rasterizeTrees", _g_get_rasterizeTrees);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "colliderRasterizeDetail", _g_get_colliderRasterizeDetail);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "mask", _g_get_mask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tagMask", _g_get_tagMask);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "terrainSampleSize", _g_get_terrainSampleSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "rotation", _g_get_rotation);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "forcedBoundsCenter", _g_get_forcedBoundsCenter);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "characterRadius", _s_set_characterRadius);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "contourMaxError", _s_set_contourMaxError);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cellSize", _s_set_cellSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "walkableHeight", _s_set_walkableHeight);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "walkableClimb", _s_set_walkableClimb);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxSlope", _s_set_maxSlope);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxEdgeLength", _s_set_maxEdgeLength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "minRegionSize", _s_set_minRegionSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "editorTileSize", _s_set_editorTileSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tileSizeX", _s_set_tileSizeX);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tileSizeZ", _s_set_tileSizeZ);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "useTiles", _s_set_useTiles);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "scanEmptyGraph", _s_set_scanEmptyGraph);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "relevantGraphSurfaceMode", _s_set_relevantGraphSurfaceMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rasterizeColliders", _s_set_rasterizeColliders);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rasterizeMeshes", _s_set_rasterizeMeshes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rasterizeTerrain", _s_set_rasterizeTerrain);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rasterizeTrees", _s_set_rasterizeTrees);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "colliderRasterizeDetail", _s_set_colliderRasterizeDetail);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "mask", _s_set_mask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tagMask", _s_set_tagMask);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "terrainSampleSize", _s_set_terrainSampleSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "rotation", _s_set_rotation);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "forcedBoundsCenter", _s_set_forcedBoundsCenter);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 0, 0);
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getBorderVertexMask", PF.RecastGraph.BorderVertexMask);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getBorderVertexOffset", PF.RecastGraph.BorderVertexOffset);
            
			
			
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BorderVertexMask", PF.RecastGraph.BorderVertexMask);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "BorderVertexOffset", PF.RecastGraph.BorderVertexOffset);
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PF.RecastGraph gen_ret = new PF.RecastGraph();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.RecastGraph constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateTransform(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        PF.GraphTransform gen_ret = gen_to_be_invoked.CalculateTransform(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitializeTileInfo(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.InitializeTileInfo(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScanAllTiles(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    
                        System.Collections.Generic.IEnumerable<Pathfinding.Progress> gen_ret = gen_to_be_invoked.ScanAllTiles(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PutMeshesIntoTileBuckets(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh> _meshes = (System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh>));
                    
                        System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh>[] gen_ret = gen_to_be_invoked.PutMeshesIntoTileBuckets( 
                        _meshes );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CollectMeshes(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    UnityEngine.Bounds _bounds;translator.Get(L, 2, out _bounds);
                    
                        System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh> gen_ret = gen_to_be_invoked.CollectMeshes( 
                        _bounds );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateTileBoundsWithBorder(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    
                        UnityEngine.Bounds gen_ret = gen_to_be_invoked.CalculateTileBoundsWithBorder( 
                        _x,  
                        _z );
                        translator.PushUnityEngineBounds(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BuildTileMesh(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 5&& translator.Assignable<PF.RecastGraph>(L, 1)&& translator.Assignable<Pathfinding.Voxels.Voxelize>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5)) 
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    Pathfinding.Voxels.Voxelize _vox = (Pathfinding.Voxels.Voxelize)translator.GetObject(L, 2, typeof(Pathfinding.Voxels.Voxelize));
                    int _x = LuaAPI.xlua_tointeger(L, 3);
                    int _z = LuaAPI.xlua_tointeger(L, 4);
                    int _threadIndex = LuaAPI.xlua_tointeger(L, 5);
                    
                        PF.NavmeshTile gen_ret = gen_to_be_invoked.BuildTileMesh( 
                        _vox,  
                        _x,  
                        _z,  
                        _threadIndex );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<PF.RecastGraph>(L, 1)&& translator.Assignable<Pathfinding.Voxels.Voxelize>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4)) 
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    Pathfinding.Voxels.Voxelize _vox = (Pathfinding.Voxels.Voxelize)translator.GetObject(L, 2, typeof(Pathfinding.Voxels.Voxelize));
                    int _x = LuaAPI.xlua_tointeger(L, 3);
                    int _z = LuaAPI.xlua_tointeger(L, 4);
                    
                        PF.NavmeshTile gen_ret = gen_to_be_invoked.BuildTileMesh( 
                        _vox,  
                        _x,  
                        _z );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.RecastGraph.BuildTileMesh!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CreateTile(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    Pathfinding.Voxels.Voxelize _vox = (Pathfinding.Voxels.Voxelize)translator.GetObject(L, 2, typeof(Pathfinding.Voxels.Voxelize));
                    Pathfinding.Voxels.VoxelMesh _mesh;translator.Get(L, 3, out _mesh);
                    int _x = LuaAPI.xlua_tointeger(L, 4);
                    int _z = LuaAPI.xlua_tointeger(L, 5);
                    int _threadIndex = LuaAPI.xlua_tointeger(L, 6);
                    
                        PF.NavmeshTile gen_ret = gen_to_be_invoked.CreateTile( 
                        _vox,  
                        _mesh,  
                        _x,  
                        _z,  
                        _threadIndex );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SnapForceBoundsToScene(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.RecastGraph _self = (PF.RecastGraph)translator.GetObject(L, 1, typeof(PF.RecastGraph));
                    
                    gen_to_be_invoked.SnapForceBoundsToScene(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TileWorldSizeX(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.TileWorldSizeX);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TileWorldSizeZ(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.TileWorldSizeZ);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CellHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.CellHeight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_CharacterRadiusInVoxels(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.CharacterRadiusInVoxels);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TileBorderSizeInVoxels(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.TileBorderSizeInVoxels);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_TileBorderSizeInWorldUnits(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.TileBorderSizeInWorldUnits);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_characterRadius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.characterRadius);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_contourMaxError(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.contourMaxError);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cellSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.cellSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_walkableHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.walkableHeight);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_walkableClimb(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.walkableClimb);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxSlope(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxSlope);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxEdgeLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxEdgeLength);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_minRegionSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.minRegionSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_editorTileSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.editorTileSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tileSizeX(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.tileSizeX);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tileSizeZ(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.tileSizeZ);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_useTiles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.useTiles);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scanEmptyGraph(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.scanEmptyGraph);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_relevantGraphSurfaceMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                translator.PushPFRecastGraphRelevantGraphSurfaceMode(L, gen_to_be_invoked.relevantGraphSurfaceMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rasterizeColliders(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.rasterizeColliders);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rasterizeMeshes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.rasterizeMeshes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rasterizeTerrain(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.rasterizeTerrain);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rasterizeTrees(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.rasterizeTrees);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_colliderRasterizeDetail(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.colliderRasterizeDetail);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.mask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tagMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tagMask);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_terrainSampleSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.terrainSampleSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_rotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.rotation);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_forcedBoundsCenter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.forcedBoundsCenter);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_characterRadius(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.characterRadius = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_contourMaxError(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.contourMaxError = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cellSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cellSize = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_walkableHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.walkableHeight = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_walkableClimb(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.walkableClimb = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxSlope(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxSlope = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxEdgeLength(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxEdgeLength = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_minRegionSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.minRegionSize = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_editorTileSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.editorTileSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tileSizeX(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tileSizeX = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tileSizeZ(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tileSizeZ = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_useTiles(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.useTiles = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scanEmptyGraph(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.scanEmptyGraph = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_relevantGraphSurfaceMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                PF.RecastGraph.RelevantGraphSurfaceMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.relevantGraphSurfaceMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rasterizeColliders(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rasterizeColliders = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rasterizeMeshes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rasterizeMeshes = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rasterizeTerrain(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rasterizeTerrain = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rasterizeTrees(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.rasterizeTrees = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_colliderRasterizeDetail(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.colliderRasterizeDetail = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.mask = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tagMask(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tagMask = (System.Collections.Generic.List<string>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<string>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_terrainSampleSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.terrainSampleSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_rotation(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.rotation = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_forcedBoundsCenter(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.RecastGraph gen_to_be_invoked = (PF.RecastGraph)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.forcedBoundsCenter = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
