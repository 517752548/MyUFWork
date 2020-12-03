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
    public class PathfindingAstarDebuggerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AstarDebugger);
			Utils.BeginObjectRegister(type, L, translator, 0, 23, 10, 10);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Start", _m_Start);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LateUpdate", _m_LateUpdate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnGUI", _m_OnGUI);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getyOffset", _g_get_yOffset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshow", _g_get_show);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowInEditor", _g_get_showInEditor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowFPS", _g_get_showFPS);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowPathProfile", _g_get_showPathProfile);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowMemProfile", _g_get_showMemProfile);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowGraph", _g_get_showGraph);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraphBufferSize", _g_get_graphBufferSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getfont", _g_get_font);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getfontSize", _g_get_fontSize);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setyOffset", _s_set_yOffset);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshow", _s_set_show);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowInEditor", _s_set_showInEditor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowFPS", _s_set_showFPS);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowPathProfile", _s_set_showPathProfile);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowMemProfile", _s_set_showMemProfile);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowGraph", _s_set_showGraph);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgraphBufferSize", _s_set_graphBufferSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setfont", _s_set_font);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setfontSize", _s_set_fontSize);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "yOffset", _g_get_yOffset);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "show", _g_get_show);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showInEditor", _g_get_showInEditor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showFPS", _g_get_showFPS);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showPathProfile", _g_get_showPathProfile);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showMemProfile", _g_get_showMemProfile);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showGraph", _g_get_showGraph);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "graphBufferSize", _g_get_graphBufferSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "font", _g_get_font);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fontSize", _g_get_fontSize);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "yOffset", _s_set_yOffset);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "show", _s_set_show);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showInEditor", _s_set_showInEditor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showFPS", _s_set_showFPS);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showPathProfile", _s_set_showPathProfile);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showMemProfile", _s_set_showMemProfile);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showGraph", _s_set_showGraph);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "graphBufferSize", _s_set_graphBufferSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "font", _s_set_font);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fontSize", _s_set_fontSize);
            
			
			
			
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
					
					Pathfinding.AstarDebugger gen_ret = new Pathfinding.AstarDebugger();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AstarDebugger constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Start(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Start(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LateUpdate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.LateUpdate(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnGUI(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnGUI(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_yOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.yOffset);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_show(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.show);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showInEditor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showInEditor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showFPS(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showFPS);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showPathProfile(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showPathProfile);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showMemProfile(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showMemProfile);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showGraph(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showGraph);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_graphBufferSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.graphBufferSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_font(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.font);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fontSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.fontSize);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_yOffset(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.yOffset = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_show(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.show = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showInEditor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showInEditor = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showFPS(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showFPS = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showPathProfile(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showPathProfile = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showMemProfile(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showMemProfile = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showGraph(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showGraph = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_graphBufferSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.graphBufferSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_font(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.font = (UnityEngine.Font)translator.GetObject(L, 2, typeof(UnityEngine.Font));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fontSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarDebugger gen_to_be_invoked = (Pathfinding.AstarDebugger)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.fontSize = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
