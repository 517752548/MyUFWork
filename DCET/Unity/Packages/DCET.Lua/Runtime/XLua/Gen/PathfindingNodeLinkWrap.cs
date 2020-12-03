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
    public class PathfindingNodeLinkWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.NodeLink);
			Utils.BeginObjectRegister(type, L, translator, 0, 15, 6, 4);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnPostScan", _m_OnPostScan);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InternalOnPostScan", _m_InternalOnPostScan);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnGraphsPostUpdate", _m_OnGraphsPostUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Apply", _m_Apply);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDrawGizmos", _m_OnDrawGizmos);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getStart", _g_get_Start);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getEnd", _g_get_End);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getend", _g_get_end);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcostFactor", _g_get_costFactor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getoneWay", _g_get_oneWay);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdeleteConnection", _g_get_deleteConnection);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setend", _s_set_end);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcostFactor", _s_set_costFactor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setoneWay", _s_set_oneWay);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdeleteConnection", _s_set_deleteConnection);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Start", _g_get_Start);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "End", _g_get_End);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "end", _g_get_end);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "costFactor", _g_get_costFactor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "oneWay", _g_get_oneWay);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "deleteConnection", _g_get_deleteConnection);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "end", _s_set_end);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "costFactor", _s_set_costFactor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "oneWay", _s_set_oneWay);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "deleteConnection", _s_set_deleteConnection);
            
			
			
			
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
					
					Pathfinding.NodeLink gen_ret = new Pathfinding.NodeLink();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.NodeLink constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnPostScan(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnPostScan(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InternalOnPostScan(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.InternalOnPostScan(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnGraphsPostUpdate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnGraphsPostUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Apply(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Apply(  );
                    
                    
                    
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
            
            
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDrawGizmos(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Start(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.Start);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_End(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.End);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_end(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.end);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_costFactor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.costFactor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_oneWay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.oneWay);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_deleteConnection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.deleteConnection);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_end(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.end = (UnityEngine.Transform)translator.GetObject(L, 2, typeof(UnityEngine.Transform));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_costFactor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.costFactor = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_oneWay(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.oneWay = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_deleteConnection(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.NodeLink gen_to_be_invoked = (Pathfinding.NodeLink)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.deleteConnection = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
