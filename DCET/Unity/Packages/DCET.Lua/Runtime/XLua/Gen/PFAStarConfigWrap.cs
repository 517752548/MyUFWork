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
    public class PFAStarConfigWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.AStarConfig);
			Utils.BeginObjectRegister(type, L, translator, 0, 27, 14, 13);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxNearestNodeDistanceSqr", _g_get_maxNearestNodeDistanceSqr);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraphs", _g_get_graphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdebugPathID", _g_get_debugPathID);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getprioritizeGraphs", _g_get_prioritizeGraphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getfullGetNearestSearch", _g_get_fullGetNearestSearch);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheuristicScale", _g_get_heuristicScale);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheuristic", _g_get_heuristic);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlogPathResults", _g_get_logPathResults);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getprioritizeGraphsLimit", _g_get_prioritizeGraphsLimit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxFrameTime", _g_get_maxFrameTime);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "geteuclideanEmbedding", _g_get_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxNearestNodeDistance", _g_get_maxNearestNodeDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdebugPathData", _g_get_debugPathData);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpathProcessor", _g_get_pathProcessor);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgraphs", _s_set_graphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdebugPathID", _s_set_debugPathID);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setprioritizeGraphs", _s_set_prioritizeGraphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setfullGetNearestSearch", _s_set_fullGetNearestSearch);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setheuristicScale", _s_set_heuristicScale);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setheuristic", _s_set_heuristic);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlogPathResults", _s_set_logPathResults);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setprioritizeGraphsLimit", _s_set_prioritizeGraphsLimit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxFrameTime", _s_set_maxFrameTime);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "seteuclideanEmbedding", _s_set_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxNearestNodeDistance", _s_set_maxNearestNodeDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdebugPathData", _s_set_debugPathData);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpathProcessor", _s_set_pathProcessor);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxNearestNodeDistanceSqr", _g_get_maxNearestNodeDistanceSqr);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "graphs", _g_get_graphs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "debugPathID", _g_get_debugPathID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "prioritizeGraphs", _g_get_prioritizeGraphs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fullGetNearestSearch", _g_get_fullGetNearestSearch);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "heuristicScale", _g_get_heuristicScale);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "heuristic", _g_get_heuristic);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "logPathResults", _g_get_logPathResults);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "prioritizeGraphsLimit", _g_get_prioritizeGraphsLimit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxFrameTime", _g_get_maxFrameTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "euclideanEmbedding", _g_get_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxNearestNodeDistance", _g_get_maxNearestNodeDistance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "debugPathData", _g_get_debugPathData);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathProcessor", _g_get_pathProcessor);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "graphs", _s_set_graphs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "debugPathID", _s_set_debugPathID);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "prioritizeGraphs", _s_set_prioritizeGraphs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fullGetNearestSearch", _s_set_fullGetNearestSearch);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "heuristicScale", _s_set_heuristicScale);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "heuristic", _s_set_heuristic);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "logPathResults", _s_set_logPathResults);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "prioritizeGraphsLimit", _s_set_prioritizeGraphsLimit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxFrameTime", _s_set_maxFrameTime);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "euclideanEmbedding", _s_set_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxNearestNodeDistance", _s_set_maxNearestNodeDistance);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "debugPathData", _s_set_debugPathData);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pathProcessor", _s_set_pathProcessor);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 3, 1, 0);
			
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getInstance", _g_get_Instance);
            
			
			
			
			
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "Instance", _g_get_Instance);
            
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PF.AStarConfig gen_ret = new PF.AStarConfig();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.AStarConfig constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Instance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PF.AStarConfig.Instance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxNearestNodeDistanceSqr(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxNearestNodeDistanceSqr);
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
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.graphs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_debugPathID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.debugPathID);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_prioritizeGraphs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.prioritizeGraphs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_fullGetNearestSearch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.fullGetNearestSearch);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_heuristicScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.heuristicScale);
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
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                translator.PushPFHeuristic(L, gen_to_be_invoked.heuristic);
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
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                translator.PushPFPathLog(L, gen_to_be_invoked.logPathResults);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_prioritizeGraphsLimit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.prioritizeGraphsLimit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxFrameTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxFrameTime);
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
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.euclideanEmbedding);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_maxNearestNodeDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxNearestNodeDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_debugPathData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.debugPathData);
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
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.pathProcessor);
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
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.graphs = (PF.NavGraph[])translator.GetObject(L, 2, typeof(PF.NavGraph[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_debugPathID(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.debugPathID = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_prioritizeGraphs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.prioritizeGraphs = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_fullGetNearestSearch(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.fullGetNearestSearch = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_heuristicScale(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.heuristicScale = (float)LuaAPI.lua_tonumber(L, 2);
            
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
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                PF.Heuristic gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.heuristic = gen_value;
            
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
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                PF.PathLog gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.logPathResults = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_prioritizeGraphsLimit(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.prioritizeGraphsLimit = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxFrameTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxFrameTime = (float)LuaAPI.lua_tonumber(L, 2);
            
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
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.euclideanEmbedding = (PF.EuclideanEmbedding)translator.GetObject(L, 2, typeof(PF.EuclideanEmbedding));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_maxNearestNodeDistance(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxNearestNodeDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_debugPathData(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.debugPathData = (PF.PathHandler)translator.GetObject(L, 2, typeof(PF.PathHandler));
            
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
			
                PF.AStarConfig gen_to_be_invoked = (PF.AStarConfig)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pathProcessor = (PF.PathProcessor)translator.GetObject(L, 2, typeof(PF.PathProcessor));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
