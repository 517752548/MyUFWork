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


namespace XLua.CSObjectWrap
{
    using Utils = XLua.Utils;
    public class PathfindingVoxelsVoxelizeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Voxels.Voxelize);
			Utils.BeginObjectRegister(type, L, translator, 0, 54, 16, 11);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BuildContours", _m_BuildContours);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SimplifyContour", _m_SimplifyContour);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "WalkContour", _m_WalkContour);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetCornerHeight", _m_GetCornerHeight);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveDegenerateSegments", _m_RemoveDegenerateSegments);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalcAreaOfPolygon2D", _m_CalcAreaOfPolygon2D);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BuildPolyMesh", _m_BuildPolyMesh);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CompactSpanToVector", _m_CompactSpanToVector);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "VectorToIndex", _m_VectorToIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "VoxelizeInput", _m_VoxelizeInput);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DebugDrawSpans", _m_DebugDrawSpans);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BuildCompactField", _m_BuildCompactField);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BuildVoxelConnections", _m_BuildVoxelConnections);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "VoxelToWorld", _m_VoxelToWorld);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "VoxelToWorldInt3", _m_VoxelToWorldInt3);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ErodeWalkableArea", _m_ErodeWalkableArea);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BuildDistanceField", _m_BuildDistanceField);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FilterLowHeightSpans", _m_FilterLowHeightSpans);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FilterLedges", _m_FilterLedges);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ExpandRegions", _m_ExpandRegions);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FloodRegion", _m_FloodRegion);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "MarkRectWithRegion", _m_MarkRectWithRegion);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CalculateDistanceField", _m_CalculateDistanceField);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BoxBlur", _m_BoxBlur);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "BuildRegions", _m_BuildRegions);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FilterSmallRegions", _m_FilterSmallRegions);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettransformVoxel2Graph", _g_get_transformVoxel2Graph);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getinputMeshes", _g_get_inputMeshes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvoxelWalkableClimb", _g_get_voxelWalkableClimb);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvoxelWalkableHeight", _g_get_voxelWalkableHeight);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcellSize", _g_get_cellSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcellHeight", _g_get_cellHeight);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getminRegionSize", _g_get_minRegionSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getborderSize", _g_get_borderSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxEdgeLength", _g_get_maxEdgeLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxSlope", _g_get_maxSlope);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrelevantGraphSurfaceMode", _g_get_relevantGraphSurfaceMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getforcedBounds", _g_get_forcedBounds);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvoxelArea", _g_get_voxelArea);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcountourSet", _g_get_countourSet);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getwidth", _g_get_width);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdepth", _g_get_depth);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setinputMeshes", _s_set_inputMeshes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setminRegionSize", _s_set_minRegionSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setborderSize", _s_set_borderSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxEdgeLength", _s_set_maxEdgeLength);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxSlope", _s_set_maxSlope);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setrelevantGraphSurfaceMode", _s_set_relevantGraphSurfaceMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setforcedBounds", _s_set_forcedBounds);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setvoxelArea", _s_set_voxelArea);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcountourSet", _s_set_countourSet);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setwidth", _s_set_width);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdepth", _s_set_depth);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "transformVoxel2Graph", _g_get_transformVoxel2Graph);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "inputMeshes", _g_get_inputMeshes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "voxelWalkableClimb", _g_get_voxelWalkableClimb);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "voxelWalkableHeight", _g_get_voxelWalkableHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cellSize", _g_get_cellSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cellHeight", _g_get_cellHeight);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "minRegionSize", _g_get_minRegionSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "borderSize", _g_get_borderSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxEdgeLength", _g_get_maxEdgeLength);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxSlope", _g_get_maxSlope);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "relevantGraphSurfaceMode", _g_get_relevantGraphSurfaceMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "forcedBounds", _g_get_forcedBounds);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "voxelArea", _g_get_voxelArea);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "countourSet", _g_get_countourSet);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "width", _g_get_width);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "depth", _g_get_depth);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "inputMeshes", _s_set_inputMeshes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "minRegionSize", _s_set_minRegionSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "borderSize", _s_set_borderSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxEdgeLength", _s_set_maxEdgeLength);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxSlope", _s_set_maxSlope);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "relevantGraphSurfaceMode", _s_set_relevantGraphSurfaceMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "forcedBounds", _s_set_forcedBounds);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "voxelArea", _s_set_voxelArea);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "countourSet", _s_set_countourSet);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "width", _s_set_width);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "depth", _s_set_depth);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 21, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "MergeContours", _m_MergeContours_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Ileft", _m_Ileft_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Diagonal", _m_Diagonal_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "InCone", _m_InCone_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Left", _m_Left_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "LeftOn", _m_LeftOn_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Collinear", _m_Collinear_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Area2", _m_Area2_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Xorb", _m_Xorb_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "IntersectProp", _m_IntersectProp_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Prev", _m_Prev_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Next", _m_Next_xlua_st_);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getNotConnected", Pathfinding.Voxels.Voxelize.NotConnected);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getRC_CONTOUR_TESS_WALL_EDGES", Pathfinding.Voxels.Voxelize.RC_CONTOUR_TESS_WALL_EDGES);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getRC_CONTOUR_TESS_AREA_EDGES", Pathfinding.Voxels.Voxelize.RC_CONTOUR_TESS_AREA_EDGES);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getRC_CONTOUR_TESS_TILE_EDGES", Pathfinding.Voxels.Voxelize.RC_CONTOUR_TESS_TILE_EDGES);
            
			
			
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "NotConnected", Pathfinding.Voxels.Voxelize.NotConnected);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RC_CONTOUR_TESS_WALL_EDGES", Pathfinding.Voxels.Voxelize.RC_CONTOUR_TESS_WALL_EDGES);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RC_CONTOUR_TESS_AREA_EDGES", Pathfinding.Voxels.Voxelize.RC_CONTOUR_TESS_AREA_EDGES);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "RC_CONTOUR_TESS_TILE_EDGES", Pathfinding.Voxels.Voxelize.RC_CONTOUR_TESS_TILE_EDGES);
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 7 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 6) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 7))
				{
					float _ch = (float)LuaAPI.lua_tonumber(L, 2);
					float _cs = (float)LuaAPI.lua_tonumber(L, 3);
					float _walkableClimb = (float)LuaAPI.lua_tonumber(L, 4);
					float _walkableHeight = (float)LuaAPI.lua_tonumber(L, 5);
					float _maxSlope = (float)LuaAPI.lua_tonumber(L, 6);
					float _maxEdgeLength = (float)LuaAPI.lua_tonumber(L, 7);
					
					Pathfinding.Voxels.Voxelize gen_ret = new Pathfinding.Voxels.Voxelize(_ch, _cs, _walkableClimb, _walkableHeight, _maxSlope, _maxEdgeLength);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Voxels.Voxelize constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BuildContours(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    float _maxError = (float)LuaAPI.lua_tonumber(L, 2);
                    int _maxEdgeLength = LuaAPI.xlua_tointeger(L, 3);
                    Pathfinding.Voxels.VoxelContourSet _cset = (Pathfinding.Voxels.VoxelContourSet)translator.GetObject(L, 4, typeof(Pathfinding.Voxels.VoxelContourSet));
                    int _buildFlags = LuaAPI.xlua_tointeger(L, 5);
                    
                    gen_to_be_invoked.BuildContours( 
                        _maxError, 
                        _maxEdgeLength, 
                        _cset, 
                        _buildFlags );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MergeContours_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    Pathfinding.Voxels.VoxelContour _ca;translator.Get(L, 1, out _ca);
                    Pathfinding.Voxels.VoxelContour _cb;translator.Get(L, 2, out _cb);
                    int _ia = LuaAPI.xlua_tointeger(L, 3);
                    int _ib = LuaAPI.xlua_tointeger(L, 4);
                    
                        bool gen_ret = Pathfinding.Voxels.Voxelize.MergeContours( 
                        ref _ca, 
                        ref _cb, 
                        _ia, 
                        _ib );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _ca);
                        translator.Update(L, 1, _ca);
                        
                    translator.Push(L, _cb);
                        translator.Update(L, 2, _cb);
                        
                    
                    
                    
                    return 3;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SimplifyContour(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<int> _verts = (System.Collections.Generic.List<int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<int>));
                    System.Collections.Generic.List<int> _simplified = (System.Collections.Generic.List<int>)translator.GetObject(L, 3, typeof(System.Collections.Generic.List<int>));
                    float _maxError = (float)LuaAPI.lua_tonumber(L, 4);
                    int _maxEdgeLenght = LuaAPI.xlua_tointeger(L, 5);
                    int _buildFlags = LuaAPI.xlua_tointeger(L, 6);
                    
                    gen_to_be_invoked.SimplifyContour( 
                        _verts, 
                        _simplified, 
                        _maxError, 
                        _maxEdgeLenght, 
                        _buildFlags );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_WalkContour(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    int _i = LuaAPI.xlua_tointeger(L, 4);
                    ushort[] _flags = (ushort[])translator.GetObject(L, 5, typeof(ushort[]));
                    System.Collections.Generic.List<int> _verts = (System.Collections.Generic.List<int>)translator.GetObject(L, 6, typeof(System.Collections.Generic.List<int>));
                    
                    gen_to_be_invoked.WalkContour( 
                        _x, 
                        _z, 
                        _i, 
                        _flags, 
                        _verts );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetCornerHeight(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    int _i = LuaAPI.xlua_tointeger(L, 4);
                    int _dir = LuaAPI.xlua_tointeger(L, 5);
                    bool _isBorderVertex = LuaAPI.lua_toboolean(L, 6);
                    
                        int gen_ret = gen_to_be_invoked.GetCornerHeight( 
                        _x, 
                        _z, 
                        _i, 
                        _dir, 
                        ref _isBorderVertex );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    LuaAPI.lua_pushboolean(L, _isBorderVertex);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveDegenerateSegments(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Collections.Generic.List<int> _simplified = (System.Collections.Generic.List<int>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<int>));
                    
                    gen_to_be_invoked.RemoveDegenerateSegments( 
                        _simplified );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalcAreaOfPolygon2D(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int[] _verts = (int[])translator.GetObject(L, 2, typeof(int[]));
                    int _nverts = LuaAPI.xlua_tointeger(L, 3);
                    
                        int gen_ret = gen_to_be_invoked.CalcAreaOfPolygon2D( 
                        _verts, 
                        _nverts );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Ileft_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    int _c = LuaAPI.xlua_tointeger(L, 3);
                    int[] _va = (int[])translator.GetObject(L, 4, typeof(int[]));
                    int[] _vb = (int[])translator.GetObject(L, 5, typeof(int[]));
                    int[] _vc = (int[])translator.GetObject(L, 6, typeof(int[]));
                    
                        bool gen_ret = Pathfinding.Voxels.Voxelize.Ileft( 
                        _a, 
                        _b, 
                        _c, 
                        _va, 
                        _vb, 
                        _vc );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Diagonal_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 1);
                    int _j = LuaAPI.xlua_tointeger(L, 2);
                    int _n = LuaAPI.xlua_tointeger(L, 3);
                    int[] _verts = (int[])translator.GetObject(L, 4, typeof(int[]));
                    int[] _indices = (int[])translator.GetObject(L, 5, typeof(int[]));
                    
                        bool gen_ret = Pathfinding.Voxels.Voxelize.Diagonal( 
                        _i, 
                        _j, 
                        _n, 
                        _verts, 
                        _indices );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InCone_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 1);
                    int _j = LuaAPI.xlua_tointeger(L, 2);
                    int _n = LuaAPI.xlua_tointeger(L, 3);
                    int[] _verts = (int[])translator.GetObject(L, 4, typeof(int[]));
                    int[] _indices = (int[])translator.GetObject(L, 5, typeof(int[]));
                    
                        bool gen_ret = Pathfinding.Voxels.Voxelize.InCone( 
                        _i, 
                        _j, 
                        _n, 
                        _verts, 
                        _indices );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Left_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    int _c = LuaAPI.xlua_tointeger(L, 3);
                    int[] _verts = (int[])translator.GetObject(L, 4, typeof(int[]));
                    
                        bool gen_ret = Pathfinding.Voxels.Voxelize.Left( 
                        _a, 
                        _b, 
                        _c, 
                        _verts );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LeftOn_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    int _c = LuaAPI.xlua_tointeger(L, 3);
                    int[] _verts = (int[])translator.GetObject(L, 4, typeof(int[]));
                    
                        bool gen_ret = Pathfinding.Voxels.Voxelize.LeftOn( 
                        _a, 
                        _b, 
                        _c, 
                        _verts );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Collinear_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    int _c = LuaAPI.xlua_tointeger(L, 3);
                    int[] _verts = (int[])translator.GetObject(L, 4, typeof(int[]));
                    
                        bool gen_ret = Pathfinding.Voxels.Voxelize.Collinear( 
                        _a, 
                        _b, 
                        _c, 
                        _verts );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Area2_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    int _c = LuaAPI.xlua_tointeger(L, 3);
                    int[] _verts = (int[])translator.GetObject(L, 4, typeof(int[]));
                    
                        int gen_ret = Pathfinding.Voxels.Voxelize.Area2( 
                        _a, 
                        _b, 
                        _c, 
                        _verts );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Xorb_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    bool _x = LuaAPI.lua_toboolean(L, 1);
                    bool _y = LuaAPI.lua_toboolean(L, 2);
                    
                        bool gen_ret = Pathfinding.Voxels.Voxelize.Xorb( 
                        _x, 
                        _y );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IntersectProp_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    int _a = LuaAPI.xlua_tointeger(L, 1);
                    int _b = LuaAPI.xlua_tointeger(L, 2);
                    int _c = LuaAPI.xlua_tointeger(L, 3);
                    int _d = LuaAPI.xlua_tointeger(L, 4);
                    int[] _verts = (int[])translator.GetObject(L, 5, typeof(int[]));
                    
                        bool gen_ret = Pathfinding.Voxels.Voxelize.IntersectProp( 
                        _a, 
                        _b, 
                        _c, 
                        _d, 
                        _verts );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Prev_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 1);
                    int _n = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = Pathfinding.Voxels.Voxelize.Prev( 
                        _i, 
                        _n );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Next_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    int _i = LuaAPI.xlua_tointeger(L, 1);
                    int _n = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = Pathfinding.Voxels.Voxelize.Next( 
                        _i, 
                        _n );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BuildPolyMesh(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.Voxels.VoxelContourSet _cset = (Pathfinding.Voxels.VoxelContourSet)translator.GetObject(L, 2, typeof(Pathfinding.Voxels.VoxelContourSet));
                    int _nvp = LuaAPI.xlua_tointeger(L, 3);
                    Pathfinding.Voxels.VoxelMesh _mesh;
                    
                    gen_to_be_invoked.BuildPolyMesh( 
                        _cset, 
                        _nvp, 
                        out _mesh );
                    translator.Push(L, _mesh);
                        
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CompactSpanToVector(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    int _i = LuaAPI.xlua_tointeger(L, 4);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.CompactSpanToVector( 
                        _x, 
                        _z, 
                        _i );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_VectorToIndex(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _p;translator.Get(L, 2, out _p);
                    int _x;
                    int _z;
                    
                    gen_to_be_invoked.VectorToIndex( 
                        _p, 
                        out _x, 
                        out _z );
                    LuaAPI.xlua_pushinteger(L, _x);
                        
                    LuaAPI.xlua_pushinteger(L, _z);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Init(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_VoxelizeInput(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphTransform _graphTransform = (PF.GraphTransform)translator.GetObject(L, 2, typeof(PF.GraphTransform));
                    UnityEngine.Bounds _graphSpaceBounds;translator.Get(L, 3, out _graphSpaceBounds);
                    
                    gen_to_be_invoked.VoxelizeInput( 
                        _graphTransform, 
                        _graphSpaceBounds );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DebugDrawSpans(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.DebugDrawSpans(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BuildCompactField(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.BuildCompactField(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BuildVoxelConnections(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.BuildVoxelConnections(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_VoxelToWorld(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _y = LuaAPI.xlua_tointeger(L, 3);
                    int _z = LuaAPI.xlua_tointeger(L, 4);
                    
                        UnityEngine.Vector3 gen_ret = gen_to_be_invoked.VoxelToWorld( 
                        _x, 
                        _y, 
                        _z );
                        translator.PushUnityEngineVector3(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_VoxelToWorldInt3(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Int3 _voxelPosition;translator.Get(L, 2, out _voxelPosition);
                    
                        PF.Int3 gen_ret = gen_to_be_invoked.VoxelToWorldInt3( 
                        _voxelPosition );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ErodeWalkableArea(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _radius = LuaAPI.xlua_tointeger(L, 2);
                    
                    gen_to_be_invoked.ErodeWalkableArea( 
                        _radius );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BuildDistanceField(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.BuildDistanceField(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FilterLowHeightSpans(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    uint _voxelWalkableHeight = LuaAPI.xlua_touint(L, 2);
                    float _cs = (float)LuaAPI.lua_tonumber(L, 3);
                    float _ch = (float)LuaAPI.lua_tonumber(L, 4);
                    
                    gen_to_be_invoked.FilterLowHeightSpans( 
                        _voxelWalkableHeight, 
                        _cs, 
                        _ch );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FilterLedges(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    uint _voxelWalkableHeight = LuaAPI.xlua_touint(L, 2);
                    int _voxelWalkableClimb = LuaAPI.xlua_tointeger(L, 3);
                    float _cs = (float)LuaAPI.lua_tonumber(L, 4);
                    float _ch = (float)LuaAPI.lua_tonumber(L, 5);
                    
                    gen_to_be_invoked.FilterLedges( 
                        _voxelWalkableHeight, 
                        _voxelWalkableClimb, 
                        _cs, 
                        _ch );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExpandRegions(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _maxIterations = LuaAPI.xlua_tointeger(L, 2);
                    uint _level = LuaAPI.xlua_touint(L, 3);
                    ushort[] _srcReg = (ushort[])translator.GetObject(L, 4, typeof(ushort[]));
                    ushort[] _srcDist = (ushort[])translator.GetObject(L, 5, typeof(ushort[]));
                    ushort[] _dstReg = (ushort[])translator.GetObject(L, 6, typeof(ushort[]));
                    ushort[] _dstDist = (ushort[])translator.GetObject(L, 7, typeof(ushort[]));
                    System.Collections.Generic.List<int> _stack = (System.Collections.Generic.List<int>)translator.GetObject(L, 8, typeof(System.Collections.Generic.List<int>));
                    
                        ushort[] gen_ret = gen_to_be_invoked.ExpandRegions( 
                        _maxIterations, 
                        _level, 
                        _srcReg, 
                        _srcDist, 
                        _dstReg, 
                        _dstDist, 
                        _stack );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FloodRegion(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _z = LuaAPI.xlua_tointeger(L, 3);
                    int _i = LuaAPI.xlua_tointeger(L, 4);
                    uint _level = LuaAPI.xlua_touint(L, 5);
                    ushort _r = (ushort)LuaAPI.xlua_tointeger(L, 6);
                    ushort[] _srcReg = (ushort[])translator.GetObject(L, 7, typeof(ushort[]));
                    ushort[] _srcDist = (ushort[])translator.GetObject(L, 8, typeof(ushort[]));
                    System.Collections.Generic.List<int> _stack = (System.Collections.Generic.List<int>)translator.GetObject(L, 9, typeof(System.Collections.Generic.List<int>));
                    
                        bool gen_ret = gen_to_be_invoked.FloodRegion( 
                        _x, 
                        _z, 
                        _i, 
                        _level, 
                        _r, 
                        _srcReg, 
                        _srcDist, 
                        _stack );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_MarkRectWithRegion(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _minx = LuaAPI.xlua_tointeger(L, 2);
                    int _maxx = LuaAPI.xlua_tointeger(L, 3);
                    int _minz = LuaAPI.xlua_tointeger(L, 4);
                    int _maxz = LuaAPI.xlua_tointeger(L, 5);
                    ushort _region = (ushort)LuaAPI.xlua_tointeger(L, 6);
                    ushort[] _srcReg = (ushort[])translator.GetObject(L, 7, typeof(ushort[]));
                    
                    gen_to_be_invoked.MarkRectWithRegion( 
                        _minx, 
                        _maxx, 
                        _minz, 
                        _maxz, 
                        _region, 
                        _srcReg );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateDistanceField(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    ushort[] _src = (ushort[])translator.GetObject(L, 2, typeof(ushort[]));
                    
                        ushort gen_ret = gen_to_be_invoked.CalculateDistanceField( 
                        _src );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BoxBlur(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    ushort[] _src = (ushort[])translator.GetObject(L, 2, typeof(ushort[]));
                    ushort[] _dst = (ushort[])translator.GetObject(L, 3, typeof(ushort[]));
                    
                        ushort[] gen_ret = gen_to_be_invoked.BoxBlur( 
                        _src, 
                        _dst );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BuildRegions(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.BuildRegions(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FilterSmallRegions(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    ushort[] _reg = (ushort[])translator.GetObject(L, 2, typeof(ushort[]));
                    int _minRegionSize = LuaAPI.xlua_tointeger(L, 3);
                    int _maxRegions = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.FilterSmallRegions( 
                        _reg, 
                        _minRegionSize, 
                        _maxRegions );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_transformVoxel2Graph(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.transformVoxel2Graph);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_inputMeshes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.inputMeshes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_voxelWalkableClimb(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.voxelWalkableClimb);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_voxelWalkableHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.voxelWalkableHeight);
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
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.cellSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cellHeight(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.cellHeight);
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
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.minRegionSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_borderSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.borderSize);
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
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxEdgeLength);
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
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxSlope);
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
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                translator.PushPFRecastGraphRelevantGraphSurfaceMode(L, gen_to_be_invoked.relevantGraphSurfaceMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_forcedBounds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineBounds(L, gen_to_be_invoked.forcedBounds);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_voxelArea(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.voxelArea);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_countourSet(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.countourSet);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_width(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.width);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_depth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.depth);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_inputMeshes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.inputMeshes = (System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<Pathfinding.Voxels.RasterizationMesh>));
            
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
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.minRegionSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_borderSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.borderSize = LuaAPI.xlua_tointeger(L, 2);
            
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
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxEdgeLength = (float)LuaAPI.lua_tonumber(L, 2);
            
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
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxSlope = (float)LuaAPI.lua_tonumber(L, 2);
            
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
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                PF.RecastGraph.RelevantGraphSurfaceMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.relevantGraphSurfaceMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_forcedBounds(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                UnityEngine.Bounds gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.forcedBounds = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_voxelArea(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.voxelArea = (Pathfinding.Voxels.VoxelArea)translator.GetObject(L, 2, typeof(Pathfinding.Voxels.VoxelArea));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_countourSet(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.countourSet = (Pathfinding.Voxels.VoxelContourSet)translator.GetObject(L, 2, typeof(Pathfinding.Voxels.VoxelContourSet));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_width(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.width = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_depth(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.Voxelize gen_to_be_invoked = (Pathfinding.Voxels.Voxelize)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.depth = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
