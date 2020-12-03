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
    public class PathfindingRelevantGraphSurfaceWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.RelevantGraphSurface);
			Utils.BeginObjectRegister(type, L, translator, 0, 8, 4, 1);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdatePosition", _m_UpdatePosition);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDrawGizmos", _m_OnDrawGizmos);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDrawGizmosSelected", _m_OnDrawGizmosSelected);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getPosition", _g_get_Position);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getNext", _g_get_Next);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getPrev", _g_get_Prev);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxRange", _g_get_maxRange);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxRange", _s_set_maxRange);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Position", _g_get_Position);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Next", _g_get_Next);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Prev", _g_get_Prev);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxRange", _g_get_maxRange);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxRange", _s_set_maxRange);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 5, 1, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "UpdateAllPositions", _m_UpdateAllPositions_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FindAllGraphSurfaces", _m_FindAllGraphSurfaces_xlua_st_);
            
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getRoot", _g_get_Root);
            
			
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Root", _g_get_Root);
            
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.RelevantGraphSurface gen_ret = new Pathfinding.RelevantGraphSurface();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.RelevantGraphSurface constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdatePosition(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RelevantGraphSurface gen_to_be_invoked = (Pathfinding.RelevantGraphSurface)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdatePosition(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateAllPositions_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                    Pathfinding.RelevantGraphSurface.UpdateAllPositions(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindAllGraphSurfaces_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                    Pathfinding.RelevantGraphSurface.FindAllGraphSurfaces(  );
                    
                    
                    
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
            
            
                Pathfinding.RelevantGraphSurface gen_to_be_invoked = (Pathfinding.RelevantGraphSurface)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDrawGizmos(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDrawGizmosSelected(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.RelevantGraphSurface gen_to_be_invoked = (Pathfinding.RelevantGraphSurface)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDrawGizmosSelected(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Position(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RelevantGraphSurface gen_to_be_invoked = (Pathfinding.RelevantGraphSurface)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.Position);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Next(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RelevantGraphSurface gen_to_be_invoked = (Pathfinding.RelevantGraphSurface)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Next);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Prev(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RelevantGraphSurface gen_to_be_invoked = (Pathfinding.RelevantGraphSurface)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Prev);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Root(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, Pathfinding.RelevantGraphSurface.Root);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxRange(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RelevantGraphSurface gen_to_be_invoked = (Pathfinding.RelevantGraphSurface)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxRange);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxRange(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.RelevantGraphSurface gen_to_be_invoked = (Pathfinding.RelevantGraphSurface)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxRange = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
