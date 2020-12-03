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
    public class PathfindingAstarDataWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.AstarData);
			Utils.BeginObjectRegister(type, L, translator, 0, 27, 6, 4);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetData", _m_GetData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetData", _m_SetData);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Awake", _m_Awake);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "UpdateShortcuts", _m_UpdateShortcuts);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "LoadFromCache", _m_LoadFromCache);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SerializeGraphs", _m_SerializeGraphs);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeGraphs", _m_DeserializeGraphs);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnDestroy", _m_OnDestroy);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DeserializeGraphsAdditive", _m_DeserializeGraphsAdditive);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FindGraphTypes", _m_FindGraphTypes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddGraph", _m_AddGraph);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "RemoveGraph", _m_RemoveGraph);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FindGraph", _m_FindGraph);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FindGraphOfType", _m_FindGraphOfType);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FindGraphWhichInheritsFrom", _m_FindGraphWhichInheritsFrom);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FindGraphsOfType", _m_FindGraphsOfType);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGraphIndex", _m_GetGraphIndex);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getrecastGraph", _g_get_recastGraph);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraphTypes", _g_get_graphTypes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraphs", _g_get_graphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getfile_cachedStartup", _g_get_file_cachedStartup);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdata_cachedStartup", _g_get_data_cachedStartup);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcacheStartup", _g_get_cacheStartup);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgraphs", _s_set_graphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setfile_cachedStartup", _s_set_file_cachedStartup);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdata_cachedStartup", _s_set_data_cachedStartup);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcacheStartup", _s_set_cacheStartup);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "recastGraph", _g_get_recastGraph);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "graphTypes", _g_get_graphTypes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "graphs", _g_get_graphs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "file_cachedStartup", _g_get_file_cachedStartup);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "data_cachedStartup", _g_get_data_cachedStartup);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "cacheStartup", _g_get_cacheStartup);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "graphs", _s_set_graphs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "file_cachedStartup", _s_set_file_cachedStartup);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "data_cachedStartup", _s_set_data_cachedStartup);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "cacheStartup", _s_set_cacheStartup);
            
			
			
			
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
					
					Pathfinding.AstarData gen_ret = new Pathfinding.AstarData();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AstarData constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetData(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        byte[] gen_ret = gen_to_be_invoked.GetData(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetData(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] _data = LuaAPI.lua_tobytes(L, 2);
                    
                    gen_to_be_invoked.SetData( 
                        _data );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Awake(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Awake(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_UpdateShortcuts(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.UpdateShortcuts(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_LoadFromCache(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.LoadFromCache(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SerializeGraphs(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                        byte[] gen_ret = gen_to_be_invoked.SerializeGraphs(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.SerializeSettings>(L, 2)) 
                {
                    PF.SerializeSettings _settings = (PF.SerializeSettings)translator.GetObject(L, 2, typeof(PF.SerializeSettings));
                    
                        byte[] gen_ret = gen_to_be_invoked.SerializeGraphs( 
                        _settings );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.SerializeSettings>(L, 2)) 
                {
                    PF.SerializeSettings _settings = (PF.SerializeSettings)translator.GetObject(L, 2, typeof(PF.SerializeSettings));
                    uint _checksum;
                    
                        byte[] gen_ret = gen_to_be_invoked.SerializeGraphs( 
                        _settings, 
                        out _checksum );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    LuaAPI.xlua_pushuint(L, _checksum);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AstarData.SerializeGraphs!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeGraphs(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.DeserializeGraphs(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING)) 
                {
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 2);
                    
                    gen_to_be_invoked.DeserializeGraphs( 
                        _bytes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.AstarData.DeserializeGraphs!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnDestroy(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnDestroy(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DeserializeGraphsAdditive(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    byte[] _bytes = LuaAPI.lua_tobytes(L, 2);
                    
                    gen_to_be_invoked.DeserializeGraphsAdditive( 
                        _bytes );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindGraphTypes(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.FindGraphTypes(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddGraph(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        PF.NavGraph gen_ret = gen_to_be_invoked.AddGraph( 
                        _type );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_RemoveGraph(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.NavGraph _graph = (PF.NavGraph)translator.GetObject(L, 2, typeof(PF.NavGraph));
                    
                        bool gen_ret = gen_to_be_invoked.RemoveGraph( 
                        _graph );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindGraph(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Func<PF.NavGraph, bool> _predicate = translator.GetDelegate<System.Func<PF.NavGraph, bool>>(L, 2);
                    
                        PF.NavGraph gen_ret = gen_to_be_invoked.FindGraph( 
                        _predicate );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindGraphOfType(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        PF.NavGraph gen_ret = gen_to_be_invoked.FindGraphOfType( 
                        _type );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindGraphWhichInheritsFrom(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        PF.NavGraph gen_ret = gen_to_be_invoked.FindGraphWhichInheritsFrom( 
                        _type );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindGraphsOfType(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Type _type = (System.Type)translator.GetObject(L, 2, typeof(System.Type));
                    
                        System.Collections.IEnumerable gen_ret = gen_to_be_invoked.FindGraphsOfType( 
                        _type );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGraphIndex(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.NavGraph _graph = (PF.NavGraph)translator.GetObject(L, 2, typeof(PF.NavGraph));
                    
                        int gen_ret = gen_to_be_invoked.GetGraphIndex( 
                        _graph );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_recastGraph(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.recastGraph);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_graphTypes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.graphTypes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_graphs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.graphs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_file_cachedStartup(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.file_cachedStartup);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_data_cachedStartup(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.data_cachedStartup);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_cacheStartup(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.cacheStartup);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_graphs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.graphs = (PF.NavGraph[])translator.GetObject(L, 2, typeof(PF.NavGraph[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_file_cachedStartup(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.file_cachedStartup = (UnityEngine.TextAsset)translator.GetObject(L, 2, typeof(UnityEngine.TextAsset));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_data_cachedStartup(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.data_cachedStartup = LuaAPI.lua_tobytes(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_cacheStartup(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.AstarData gen_to_be_invoked = (Pathfinding.AstarData)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.cacheStartup = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
