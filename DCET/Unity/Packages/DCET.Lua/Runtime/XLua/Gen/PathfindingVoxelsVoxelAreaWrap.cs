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
    public class PathfindingVoxelsVoxelAreaWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Voxels.VoxelArea);
			Utils.BeginObjectRegister(type, L, translator, 0, 30, 14, 12);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Reset", _m_Reset);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSpanCountAll", _m_GetSpanCountAll);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetSpanCount", _m_GetSpanCount);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddLinkedSpan", _m_AddLinkedSpan);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getwidth", _g_get_width);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdepth", _g_get_depth);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcompactSpans", _g_get_compactSpans);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcompactCells", _g_get_compactCells);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcompactSpanCount", _g_get_compactSpanCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettmpUShortArr", _g_get_tmpUShortArr);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getareaTypes", _g_get_areaTypes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdist", _g_get_dist);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxDistance", _g_get_maxDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxRegions", _g_get_maxRegions);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getDirectionX", _g_get_DirectionX);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getDirectionZ", _g_get_DirectionZ);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getVectorDirection", _g_get_VectorDirection);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlinkedSpans", _g_get_linkedSpans);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcompactSpans", _s_set_compactSpans);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcompactCells", _s_set_compactCells);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcompactSpanCount", _s_set_compactSpanCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settmpUShortArr", _s_set_tmpUShortArr);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setareaTypes", _s_set_areaTypes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdist", _s_set_dist);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxDistance", _s_set_maxDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxRegions", _s_set_maxRegions);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setDirectionX", _s_set_DirectionX);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setDirectionZ", _s_set_DirectionZ);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setVectorDirection", _s_set_VectorDirection);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlinkedSpans", _s_set_linkedSpans);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "width", _g_get_width);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "depth", _g_get_depth);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "compactSpans", _g_get_compactSpans);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "compactCells", _g_get_compactCells);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "compactSpanCount", _g_get_compactSpanCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tmpUShortArr", _g_get_tmpUShortArr);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "areaTypes", _g_get_areaTypes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dist", _g_get_dist);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxDistance", _g_get_maxDistance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxRegions", _g_get_maxRegions);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DirectionX", _g_get_DirectionX);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DirectionZ", _g_get_DirectionZ);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "VectorDirection", _g_get_VectorDirection);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "linkedSpans", _g_get_linkedSpans);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "compactSpans", _s_set_compactSpans);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "compactCells", _s_set_compactCells);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "compactSpanCount", _s_set_compactSpanCount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "tmpUShortArr", _s_set_tmpUShortArr);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "areaTypes", _s_set_areaTypes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dist", _s_set_dist);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxDistance", _s_set_maxDistance);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxRegions", _s_set_maxRegions);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "DirectionX", _s_set_DirectionX);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "DirectionZ", _s_set_DirectionZ);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "VectorDirection", _s_set_VectorDirection);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "linkedSpans", _s_set_linkedSpans);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 9, 0, 0);
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getMaxHeight", Pathfinding.Voxels.VoxelArea.MaxHeight);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getMaxHeightInt", Pathfinding.Voxels.VoxelArea.MaxHeightInt);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getInvalidSpanValue", Pathfinding.Voxels.VoxelArea.InvalidSpanValue);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getAvgSpanLayerCountEstimate", Pathfinding.Voxels.VoxelArea.AvgSpanLayerCountEstimate);
            
			
			
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MaxHeight", Pathfinding.Voxels.VoxelArea.MaxHeight);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "MaxHeightInt", Pathfinding.Voxels.VoxelArea.MaxHeightInt);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "InvalidSpanValue", Pathfinding.Voxels.VoxelArea.InvalidSpanValue);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "AvgSpanLayerCountEstimate", Pathfinding.Voxels.VoxelArea.AvgSpanLayerCountEstimate);
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3))
				{
					int _width = LuaAPI.xlua_tointeger(L, 2);
					int _depth = LuaAPI.xlua_tointeger(L, 3);
					
					Pathfinding.Voxels.VoxelArea gen_ret = new Pathfinding.Voxels.VoxelArea(_width, _depth);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Voxels.VoxelArea constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Reset(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Reset(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSpanCountAll(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetSpanCountAll(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetSpanCount(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetSpanCount(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddLinkedSpan(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    uint _bottom = LuaAPI.xlua_touint(L, 3);
                    uint _top = LuaAPI.xlua_touint(L, 4);
                    int _area = LuaAPI.xlua_tointeger(L, 5);
                    int _voxelWalkableClimb = LuaAPI.xlua_tointeger(L, 6);
                    
                    gen_to_be_invoked.AddLinkedSpan( 
                        _index, 
                        _bottom, 
                        _top, 
                        _area, 
                        _voxelWalkableClimb );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_width(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
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
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.depth);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_compactSpans(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.compactSpans);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_compactCells(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.compactCells);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_compactSpanCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.compactSpanCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tmpUShortArr(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tmpUShortArr);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_areaTypes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.areaTypes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dist(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.dist);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.maxDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxRegions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.maxRegions);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DirectionX(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.DirectionX);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DirectionZ(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.DirectionZ);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_VectorDirection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.VectorDirection);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_linkedSpans(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.linkedSpans);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_compactSpans(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.compactSpans = (Pathfinding.Voxels.CompactVoxelSpan[])translator.GetObject(L, 2, typeof(Pathfinding.Voxels.CompactVoxelSpan[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_compactCells(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.compactCells = (Pathfinding.Voxels.CompactVoxelCell[])translator.GetObject(L, 2, typeof(Pathfinding.Voxels.CompactVoxelCell[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_compactSpanCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.compactSpanCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tmpUShortArr(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tmpUShortArr = (ushort[])translator.GetObject(L, 2, typeof(ushort[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_areaTypes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.areaTypes = (int[])translator.GetObject(L, 2, typeof(int[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dist(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.dist = (ushort[])translator.GetObject(L, 2, typeof(ushort[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxDistance = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxRegions(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxRegions = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DirectionX(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.DirectionX = (int[])translator.GetObject(L, 2, typeof(int[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_DirectionZ(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.DirectionZ = (int[])translator.GetObject(L, 2, typeof(int[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_VectorDirection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.VectorDirection = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_linkedSpans(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Voxels.VoxelArea gen_to_be_invoked = (Pathfinding.Voxels.VoxelArea)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.linkedSpans = (Pathfinding.Voxels.LinkedVoxelSpan[])translator.GetObject(L, 2, typeof(Pathfinding.Voxels.LinkedVoxelSpan[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
