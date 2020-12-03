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
    public class PFEuclideanEmbeddingWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.EuclideanEmbedding);
			Utils.BeginObjectRegister(type, L, translator, 0, 13, 5, 5);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHeuristic", _m_GetHeuristic);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RecalculatePivots", _m_RecalculatePivots);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDrawGizmos", _m_OnDrawGizmos);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmode", _g_get_mode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getseed", _g_get_seed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getspreadOutCount", _g_get_spreadOutCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdirty", _g_get_dirty);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpivots", _g_get_pivots);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmode", _s_set_mode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setseed", _s_set_seed);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setspreadOutCount", _s_set_spreadOutCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdirty", _s_set_dirty);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpivots", _s_set_pivots);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "mode", _g_get_mode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "seed", _g_get_seed);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "spreadOutCount", _g_get_spreadOutCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "dirty", _g_get_dirty);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pivots", _g_get_pivots);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "mode", _s_set_mode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "seed", _s_set_seed);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "spreadOutCount", _s_set_spreadOutCount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "dirty", _s_set_dirty);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pivots", _s_set_pivots);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PF.EuclideanEmbedding gen_ret = new PF.EuclideanEmbedding();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.EuclideanEmbedding constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHeuristic(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _nodeIndex1 = LuaAPI.xlua_tointeger(L, 2);
                    int _nodeIndex2 = LuaAPI.xlua_tointeger(L, 3);
                    
                        uint gen_ret = gen_to_be_invoked.GetHeuristic( 
                        _nodeIndex1, 
                        _nodeIndex2 );
                        LuaAPI.xlua_pushuint(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RecalculatePivots(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.RecalculatePivots(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDrawGizmos(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.EuclideanEmbedding _embedding = (PF.EuclideanEmbedding)translator.GetObject(L, 1, typeof(PF.EuclideanEmbedding));
                    
                    gen_to_be_invoked.OnDrawGizmos(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_mode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
                translator.PushPFHeuristicOptimizationMode(L, gen_to_be_invoked.mode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_seed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.seed);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_spreadOutCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.spreadOutCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_dirty(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.dirty);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pivots(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.pivots);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_mode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
                PF.HeuristicOptimizationMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.mode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_seed(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.seed = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_spreadOutCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.spreadOutCount = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_dirty(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.dirty = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pivots(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.EuclideanEmbedding gen_to_be_invoked = (PF.EuclideanEmbedding)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pivots = (PF.GraphNode[])translator.GetObject(L, 2, typeof(PF.GraphNode[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
