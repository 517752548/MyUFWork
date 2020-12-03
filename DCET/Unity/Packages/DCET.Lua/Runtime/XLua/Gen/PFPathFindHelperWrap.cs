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
    public class PFPathFindHelperWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.PathFindHelper);
			Utils.BeginObjectRegister(type, L, translator, 0, 0, 0, 0);
			
            			
						
            
			
						
			
			
			
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 55, 13, 11);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "GetConfig", _m_GetConfig_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetNearest", _m_GetNearest_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetNewNodeIndex", _m_GetNewNodeIndex_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "InitializeNode", _m_InitializeNode_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "GetNextPathID", _m_GetNextPathID_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Close", _m_Close_xlua_st_);
            
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getdebugPathData", _g_get_debugPathData);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getdebugPathID", _g_get_debugPathID);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getpathProcessor", _g_get_pathProcessor);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getIsUsingMultithreading", _g_get_IsUsingMultithreading);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getgraphs", _g_get_graphs);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getheuristic", _g_get_heuristic);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getheuristicScale", _g_get_heuristicScale);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "geteuclideanEmbedding", _g_get_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getlogPathResults", _g_get_logPathResults);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getOnAwakeSettings", _g_get_OnAwakeSettings);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getOnPathPreSearch", _g_get_OnPathPreSearch);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getOnPathPostSearch", _g_get_OnPathPostSearch);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "getOn65KOverflow", _g_get_On65KOverflow);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "setdebugPathData", _s_set_debugPathData);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setdebugPathID", _s_set_debugPathID);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setpathProcessor", _s_set_pathProcessor);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setheuristic", _s_set_heuristic);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setheuristicScale", _s_set_heuristicScale);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "seteuclideanEmbedding", _s_set_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setlogPathResults", _s_set_logPathResults);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setOnAwakeSettings", _s_set_OnAwakeSettings);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setOnPathPreSearch", _s_set_OnPathPreSearch);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setOnPathPostSearch", _s_set_OnPathPostSearch);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "setOn65KOverflow", _s_set_On65KOverflow);
            
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "debugPathData", _g_get_debugPathData);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "debugPathID", _g_get_debugPathID);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "pathProcessor", _g_get_pathProcessor);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "IsUsingMultithreading", _g_get_IsUsingMultithreading);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "graphs", _g_get_graphs);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "heuristic", _g_get_heuristic);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "heuristicScale", _g_get_heuristicScale);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "euclideanEmbedding", _g_get_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "logPathResults", _g_get_logPathResults);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OnAwakeSettings", _g_get_OnAwakeSettings);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OnPathPreSearch", _g_get_OnPathPreSearch);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "OnPathPostSearch", _g_get_OnPathPostSearch);
            Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "On65KOverflow", _g_get_On65KOverflow);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "debugPathData", _s_set_debugPathData);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "debugPathID", _s_set_debugPathID);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "pathProcessor", _s_set_pathProcessor);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "heuristic", _s_set_heuristic);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "heuristicScale", _s_set_heuristicScale);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "euclideanEmbedding", _s_set_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "logPathResults", _s_set_logPathResults);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OnAwakeSettings", _s_set_OnAwakeSettings);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OnPathPreSearch", _s_set_OnPathPreSearch);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "OnPathPostSearch", _s_set_OnPathPostSearch);
            Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "On65KOverflow", _s_set_On65KOverflow);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.PathFindHelper does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetConfig_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        AstarPath gen_ret = PF.PathFindHelper.GetConfig(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearest_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.Vector3>(L, 1)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    
                        PF.NNInfo gen_ret = PF.PathFindHelper.GetNearest( 
                        _position );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<PF.NNConstraint>(L, 2)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    PF.NNConstraint _constraint = (PF.NNConstraint)translator.GetObject(L, 2, typeof(PF.NNConstraint));
                    
                        PF.NNInfo gen_ret = PF.PathFindHelper.GetNearest( 
                        _position, 
                        _constraint );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<PF.NNConstraint>(L, 2)&& translator.Assignable<PF.GraphNode>(L, 3)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 1, out _position);
                    PF.NNConstraint _constraint = (PF.NNConstraint)translator.GetObject(L, 2, typeof(PF.NNConstraint));
                    PF.GraphNode _hint = (PF.GraphNode)translator.GetObject(L, 3, typeof(PF.GraphNode));
                    
                        PF.NNInfo gen_ret = PF.PathFindHelper.GetNearest( 
                        _position, 
                        _constraint, 
                        _hint );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.PathFindHelper.GetNearest!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNewNodeIndex_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                        int gen_ret = PF.PathFindHelper.GetNewNodeIndex(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InitializeNode_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    
                    PF.PathFindHelper.InitializeNode( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNextPathID_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                        ushort gen_ret = PF.PathFindHelper.GetNextPathID(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Close_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                    PF.PathFindHelper.Close(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_debugPathData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PF.PathFindHelper.debugPathData);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_debugPathID(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.xlua_pushinteger(L, PF.PathFindHelper.debugPathID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pathProcessor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PF.PathFindHelper.pathProcessor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsUsingMultithreading(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushboolean(L, PF.PathFindHelper.IsUsingMultithreading);
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
			    translator.Push(L, PF.PathFindHelper.graphs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_heuristic(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushPFHeuristic(L, PF.PathFindHelper.heuristic);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_heuristicScale(RealStatePtr L)
        {
		    try {
            
			    LuaAPI.lua_pushnumber(L, PF.PathFindHelper.heuristicScale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_euclideanEmbedding(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PF.PathFindHelper.euclideanEmbedding);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_logPathResults(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.PushPFPathLog(L, PF.PathFindHelper.logPathResults);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnAwakeSettings(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PF.PathFindHelper.OnAwakeSettings);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnPathPreSearch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PF.PathFindHelper.OnPathPreSearch);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_OnPathPostSearch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PF.PathFindHelper.OnPathPostSearch);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_On65KOverflow(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PF.PathFindHelper.On65KOverflow);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_debugPathData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    PF.PathFindHelper.debugPathData = (PF.PathHandler)translator.GetObject(L, 1, typeof(PF.PathHandler));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_debugPathID(RealStatePtr L)
        {
		    try {
                
			    PF.PathFindHelper.debugPathID = (ushort)LuaAPI.xlua_tointeger(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pathProcessor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    PF.PathFindHelper.pathProcessor = (PF.PathProcessor)translator.GetObject(L, 1, typeof(PF.PathProcessor));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_heuristic(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			PF.Heuristic gen_value;translator.Get(L, 1, out gen_value);
				PF.PathFindHelper.heuristic = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_heuristicScale(RealStatePtr L)
        {
		    try {
                
			    PF.PathFindHelper.heuristicScale = (float)LuaAPI.lua_tonumber(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_euclideanEmbedding(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    PF.PathFindHelper.euclideanEmbedding = (PF.EuclideanEmbedding)translator.GetObject(L, 1, typeof(PF.EuclideanEmbedding));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_logPathResults(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			PF.PathLog gen_value;translator.Get(L, 1, out gen_value);
				PF.PathFindHelper.logPathResults = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnAwakeSettings(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    PF.PathFindHelper.OnAwakeSettings = translator.GetDelegate<System.Action>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnPathPreSearch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    PF.PathFindHelper.OnPathPreSearch = translator.GetDelegate<PF.OnPathDelegate>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_OnPathPostSearch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    PF.PathFindHelper.OnPathPostSearch = translator.GetDelegate<PF.OnPathDelegate>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_On65KOverflow(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    PF.PathFindHelper.On65KOverflow = translator.GetDelegate<System.Action>(L, 1);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
