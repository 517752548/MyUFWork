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
    public class PFPathHandlerWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.PathHandler);
			Utils.BeginObjectRegister(type, L, translator, 0, 12, 6, 1);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InitializeForPath", _m_InitializeForPath);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DestroyNode", _m_DestroyNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "InitializeNode", _m_InitializeNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetPathNode", _m_GetPathNode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ClearPathIDs", _m_ClearPathIDs);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getPathID", _g_get_PathID);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getthreadID", _g_get_threadID);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettotalThreadCount", _g_get_totalThreadCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheap", _g_get_heap);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnodes", _g_get_nodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getDebugStringBuilder", _g_get_DebugStringBuilder);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnodes", _s_set_nodes);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "PathID", _g_get_PathID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "threadID", _g_get_threadID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "totalThreadCount", _g_get_totalThreadCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "heap", _g_get_heap);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nodes", _g_get_nodes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "DebugStringBuilder", _g_get_DebugStringBuilder);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "nodes", _s_set_nodes);
            
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 3 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3))
				{
					int _threadID = LuaAPI.xlua_tointeger(L, 2);
					int _totalThreadCount = LuaAPI.xlua_tointeger(L, 3);
					
					PF.PathHandler gen_ret = new PF.PathHandler(_threadID, _totalThreadCount);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.PathHandler constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitializeForPath(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.Path _p = (PF.Path)translator.GetObject(L, 2, typeof(PF.Path));
                    
                    gen_to_be_invoked.InitializeForPath( 
                        _p );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DestroyNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.DestroyNode( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitializeNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.InitializeNode( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetPathNode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    int _nodeIndex = LuaAPI.xlua_tointeger(L, 2);
                    
                        PF.PathNode gen_ret = gen_to_be_invoked.GetPathNode( 
                        _nodeIndex );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.GraphNode>(L, 2)) 
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                        PF.PathNode gen_ret = gen_to_be_invoked.GetPathNode( 
                        _node );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.PathHandler.GetPathNode!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ClearPathIDs(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ClearPathIDs(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_PathID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.PathID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_threadID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.threadID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_totalThreadCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.totalThreadCount);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_heap(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.heap);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.nodes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_DebugStringBuilder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.DebugStringBuilder);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.PathHandler gen_to_be_invoked = (PF.PathHandler)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.nodes = (PF.PathNode[])translator.GetObject(L, 2, typeof(PF.PathNode[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
