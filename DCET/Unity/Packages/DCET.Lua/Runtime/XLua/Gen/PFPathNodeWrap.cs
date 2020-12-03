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
    public class PFPathNodeWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.PathNode);
			Utils.BeginObjectRegister(type, L, translator, 0, 20, 10, 9);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateG", _m_UpdateG);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcost", _g_get_cost);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getflag1", _g_get_flag1);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getflag2", _g_get_flag2);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getG", _g_get_G);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getH", _g_get_H);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getF", _g_get_F);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnode", _g_get_node);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getparent", _g_get_parent);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpathID", _g_get_pathID);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheapIndex", _g_get_heapIndex);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcost", _s_set_cost);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setflag1", _s_set_flag1);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setflag2", _s_set_flag2);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setG", _s_set_G);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setH", _s_set_H);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnode", _s_set_node);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setparent", _s_set_parent);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpathID", _s_set_pathID);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setheapIndex", _s_set_heapIndex);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "cost", _g_get_cost);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "flag1", _g_get_flag1);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "flag2", _g_get_flag2);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "G", _g_get_G);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "H", _g_get_H);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "F", _g_get_F);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "node", _g_get_node);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "parent", _g_get_parent);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathID", _g_get_pathID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "heapIndex", _g_get_heapIndex);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "cost", _s_set_cost);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "flag1", _s_set_flag1);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "flag2", _s_set_flag2);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "G", _s_set_G);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "H", _s_set_H);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "node", _s_set_node);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "parent", _s_set_parent);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pathID", _s_set_pathID);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "heapIndex", _s_set_heapIndex);
            
			
			
			
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
					
					PF.PathNode gen_ret = new PF.PathNode();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.PathNode constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateG(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    
                    gen_to_be_invoked.UpdateG( 
                        _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cost(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.cost);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_flag1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.flag1);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_flag2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.flag2);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_G(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.G);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_H(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.H);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_F(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.F);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_node(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.node);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_parent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.parent);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pathID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.pathID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_heapIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.heapIndex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cost(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cost = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_flag1(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.flag1 = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_flag2(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.flag2 = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_G(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.G = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_H(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.H = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_node(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_parent(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.parent = (PF.PathNode)translator.GetObject(L, 2, typeof(PF.PathNode));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pathID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pathID = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_heapIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathNode gen_to_be_invoked = (PF.PathNode)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.heapIndex = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
