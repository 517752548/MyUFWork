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
    public class AstarPathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(AstarPath);
			Utils.BeginObjectRegister(type, L, translator, 0, 70, 34, 27);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTagNames", _m_GetTagNames);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddWorkItem", _m_AddWorkItem);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FlushGraphUpdates", _m_FlushGraphUpdates);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FlushWorkItems", _m_FlushWorkItems);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ConfigureReferencesInternal", _m_ConfigureReferencesInternal);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "FloodFill", _m_FloodFill);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PausePathfinding", _m_PausePathfinding);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Scan", _m_Scan);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ScanAsync", _m_ScanAsync);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraphs", _g_get_graphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxNearestNodeDistanceSqr", _g_get_maxNearestNodeDistanceSqr);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlastScanTime", _g_get_lastScanTime);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getisScanning", _g_get_isScanning);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getIsAnyGraphUpdateQueued", _g_get_IsAnyGraphUpdateQueued);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getIsAnyGraphUpdateInProgress", _g_get_IsAnyGraphUpdateInProgress);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getIsAnyWorkItemInProgress", _g_get_IsAnyWorkItemInProgress);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdata", _g_get_data);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowNavGraphs", _g_get_showNavGraphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowUnwalkableNodes", _g_get_showUnwalkableNodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdebugMode", _g_get_debugMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdebugFloor", _g_get_debugFloor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdebugRoof", _g_get_debugRoof);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmanualDebugFloorRoof", _g_get_manualDebugFloorRoof);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowSearchTree", _g_get_showSearchTree);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getunwalkableNodeDebugSize", _g_get_unwalkableNodeDebugSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getlogPathResults", _g_get_logPathResults);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxNearestNodeDistance", _g_get_maxNearestNodeDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getscanOnStartup", _g_get_scanOnStartup);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getfullGetNearestSearch", _g_get_fullGetNearestSearch);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getprioritizeGraphs", _g_get_prioritizeGraphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getprioritizeGraphsLimit", _g_get_prioritizeGraphsLimit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcolorSettings", _g_get_colorSettings);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheuristic", _g_get_heuristic);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheuristicScale", _g_get_heuristicScale);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getthreadCount", _g_get_threadCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmaxFrameTime", _g_get_maxFrameTime);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getbatchGraphUpdates", _g_get_batchGraphUpdates);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraphUpdateBatchingInterval", _g_get_graphUpdateBatchingInterval);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdebugPathData", _g_get_debugPathData);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdebugPathID", _g_get_debugPathID);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpathProcessor", _g_get_pathProcessor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "geteuclideanEmbedding", _g_get_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getshowGraphs", _g_get_showGraphs);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdata", _s_set_data);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowNavGraphs", _s_set_showNavGraphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowUnwalkableNodes", _s_set_showUnwalkableNodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdebugMode", _s_set_debugMode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdebugFloor", _s_set_debugFloor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdebugRoof", _s_set_debugRoof);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmanualDebugFloorRoof", _s_set_manualDebugFloorRoof);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowSearchTree", _s_set_showSearchTree);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setunwalkableNodeDebugSize", _s_set_unwalkableNodeDebugSize);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setlogPathResults", _s_set_logPathResults);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxNearestNodeDistance", _s_set_maxNearestNodeDistance);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setscanOnStartup", _s_set_scanOnStartup);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setfullGetNearestSearch", _s_set_fullGetNearestSearch);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setprioritizeGraphs", _s_set_prioritizeGraphs);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setprioritizeGraphsLimit", _s_set_prioritizeGraphsLimit);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcolorSettings", _s_set_colorSettings);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setheuristic", _s_set_heuristic);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setheuristicScale", _s_set_heuristicScale);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setthreadCount", _s_set_threadCount);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setmaxFrameTime", _s_set_maxFrameTime);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setbatchGraphUpdates", _s_set_batchGraphUpdates);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgraphUpdateBatchingInterval", _s_set_graphUpdateBatchingInterval);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdebugPathData", _s_set_debugPathData);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdebugPathID", _s_set_debugPathID);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpathProcessor", _s_set_pathProcessor);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "seteuclideanEmbedding", _s_set_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setshowGraphs", _s_set_showGraphs);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "graphs", _g_get_graphs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxNearestNodeDistanceSqr", _g_get_maxNearestNodeDistanceSqr);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "lastScanTime", _g_get_lastScanTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "isScanning", _g_get_isScanning);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsAnyGraphUpdateQueued", _g_get_IsAnyGraphUpdateQueued);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsAnyGraphUpdateInProgress", _g_get_IsAnyGraphUpdateInProgress);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "IsAnyWorkItemInProgress", _g_get_IsAnyWorkItemInProgress);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "data", _g_get_data);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showNavGraphs", _g_get_showNavGraphs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showUnwalkableNodes", _g_get_showUnwalkableNodes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "debugMode", _g_get_debugMode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "debugFloor", _g_get_debugFloor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "debugRoof", _g_get_debugRoof);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "manualDebugFloorRoof", _g_get_manualDebugFloorRoof);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showSearchTree", _g_get_showSearchTree);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "unwalkableNodeDebugSize", _g_get_unwalkableNodeDebugSize);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "logPathResults", _g_get_logPathResults);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxNearestNodeDistance", _g_get_maxNearestNodeDistance);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "scanOnStartup", _g_get_scanOnStartup);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "fullGetNearestSearch", _g_get_fullGetNearestSearch);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "prioritizeGraphs", _g_get_prioritizeGraphs);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "prioritizeGraphsLimit", _g_get_prioritizeGraphsLimit);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "colorSettings", _g_get_colorSettings);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "heuristic", _g_get_heuristic);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "heuristicScale", _g_get_heuristicScale);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "threadCount", _g_get_threadCount);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "maxFrameTime", _g_get_maxFrameTime);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "batchGraphUpdates", _g_get_batchGraphUpdates);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "graphUpdateBatchingInterval", _g_get_graphUpdateBatchingInterval);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "debugPathData", _g_get_debugPathData);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "debugPathID", _g_get_debugPathID);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathProcessor", _g_get_pathProcessor);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "euclideanEmbedding", _g_get_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "showGraphs", _g_get_showGraphs);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "data", _s_set_data);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showNavGraphs", _s_set_showNavGraphs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showUnwalkableNodes", _s_set_showUnwalkableNodes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "debugMode", _s_set_debugMode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "debugFloor", _s_set_debugFloor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "debugRoof", _s_set_debugRoof);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "manualDebugFloorRoof", _s_set_manualDebugFloorRoof);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showSearchTree", _s_set_showSearchTree);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "unwalkableNodeDebugSize", _s_set_unwalkableNodeDebugSize);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "logPathResults", _s_set_logPathResults);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxNearestNodeDistance", _s_set_maxNearestNodeDistance);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "scanOnStartup", _s_set_scanOnStartup);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "fullGetNearestSearch", _s_set_fullGetNearestSearch);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "prioritizeGraphs", _s_set_prioritizeGraphs);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "prioritizeGraphsLimit", _s_set_prioritizeGraphsLimit);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "colorSettings", _s_set_colorSettings);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "heuristic", _s_set_heuristic);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "heuristicScale", _s_set_heuristicScale);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "threadCount", _s_set_threadCount);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "maxFrameTime", _s_set_maxFrameTime);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "batchGraphUpdates", _s_set_batchGraphUpdates);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "graphUpdateBatchingInterval", _s_set_graphUpdateBatchingInterval);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "debugPathData", _s_set_debugPathData);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "debugPathID", _s_set_debugPathID);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pathProcessor", _s_set_pathProcessor);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "euclideanEmbedding", _s_set_euclideanEmbedding);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "showGraphs", _s_set_showGraphs);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 16, 1, 1);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "FindAstarPath", _m_FindAstarPath_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "FindTagNames", _m_FindTagNames_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "CalculateThreadCount", _m_CalculateThreadCount_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "BlockUntilCalculated", _m_BlockUntilCalculated_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "StartPath", _m_StartPath_xlua_st_);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getVersion", AstarPath.Version);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getDistribution", AstarPath.Distribution);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getBranch", AstarPath.Branch);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getactive", _g_get_active);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "setactive", _s_set_active);
            
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Version", AstarPath.Version);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Distribution", AstarPath.Distribution);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Branch", AstarPath.Branch);
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "active", _g_get_active);
            
			Utils.RegisterFunc(L, Utils.CLS_SETTER_IDX, "active", _s_set_active);
            
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "AstarPath does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTagNames(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        string[] gen_ret = gen_to_be_invoked.GetTagNames(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindAstarPath_xlua_st_(RealStatePtr L)
        {
		    try {
			
            
            
                
                {
                    
                    AstarPath.FindAstarPath(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FindTagNames_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    
                        string[] gen_ret = AstarPath.FindTagNames(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddWorkItem(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<System.Action>(L, 2)) 
                {
                    System.Action _callback = translator.GetDelegate<System.Action>(L, 2);
                    
                    gen_to_be_invoked.AddWorkItem( 
                        _callback );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<Pathfinding.AstarWorkItem>(L, 2)) 
                {
                    Pathfinding.AstarWorkItem _item;translator.Get(L, 2, out _item);
                    
                    gen_to_be_invoked.AddWorkItem( 
                        _item );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AstarPath.AddWorkItem!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FlushGraphUpdates(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.FlushGraphUpdates(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FlushWorkItems(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.FlushWorkItems(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CalculateThreadCount_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.ThreadCount _count;translator.Get(L, 1, out _count);
                    
                        int gen_ret = AstarPath.CalculateThreadCount( 
                        _count );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ConfigureReferencesInternal(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.ConfigureReferencesInternal(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_FloodFill(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.FloodFill(  );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.GraphNode>(L, 2)) 
                {
                    PF.GraphNode _seed = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.FloodFill( 
                        _seed );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 3&& translator.Assignable<PF.GraphNode>(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    PF.GraphNode _seed = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    uint _area = LuaAPI.xlua_touint(L, 3);
                    
                    gen_to_be_invoked.FloodFill( 
                        _seed, 
                        _area );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AstarPath.FloodFill!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PausePathfinding(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        PF.PathProcessor.GraphUpdateLock gen_ret = gen_to_be_invoked.PausePathfinding(  );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Scan(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<PF.NavGraph>(L, 2)) 
                {
                    PF.NavGraph _graphToScan = (PF.NavGraph)translator.GetObject(L, 2, typeof(PF.NavGraph));
                    
                    gen_to_be_invoked.Scan( 
                        _graphToScan );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.NavGraph[]>(L, 2)) 
                {
                    PF.NavGraph[] _graphsToScan = (PF.NavGraph[])translator.GetObject(L, 2, typeof(PF.NavGraph[]));
                    
                    gen_to_be_invoked.Scan( 
                        _graphsToScan );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1) 
                {
                    
                    gen_to_be_invoked.Scan(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AstarPath.Scan!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ScanAsync(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<PF.NavGraph>(L, 2)) 
                {
                    PF.NavGraph _graphToScan = (PF.NavGraph)translator.GetObject(L, 2, typeof(PF.NavGraph));
                    
                        System.Collections.Generic.IEnumerable<Pathfinding.Progress> gen_ret = gen_to_be_invoked.ScanAsync( 
                        _graphToScan );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.NavGraph[]>(L, 2)) 
                {
                    PF.NavGraph[] _graphsToScan = (PF.NavGraph[])translator.GetObject(L, 2, typeof(PF.NavGraph[]));
                    
                        System.Collections.Generic.IEnumerable<Pathfinding.Progress> gen_ret = gen_to_be_invoked.ScanAsync( 
                        _graphsToScan );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1) 
                {
                    
                        System.Collections.Generic.IEnumerable<Pathfinding.Progress> gen_ret = gen_to_be_invoked.ScanAsync(  );
                        translator.PushAny(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AstarPath.ScanAsync!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_BlockUntilCalculated_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 1, typeof(PF.Path));
                    
                    AstarPath.BlockUntilCalculated( 
                        _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_StartPath_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<PF.Path>(L, 1)&& LuaTypes.LUA_TBOOLEAN == LuaAPI.lua_type(L, 2)) 
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 1, typeof(PF.Path));
                    bool _pushToFront = LuaAPI.lua_toboolean(L, 2);
                    
                    AstarPath.StartPath( 
                        _path, 
                        _pushToFront );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 1&& translator.Assignable<PF.Path>(L, 1)) 
                {
                    PF.Path _path = (PF.Path)translator.GetObject(L, 1, typeof(PF.Path));
                    
                    AstarPath.StartPath( 
                        _path );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to AstarPath.StartPath!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_graphs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.graphs);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxNearestNodeDistanceSqr);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_lastScanTime(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.lastScanTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_isScanning(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.isScanning);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAnyGraphUpdateQueued(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsAnyGraphUpdateQueued);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAnyGraphUpdateInProgress(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsAnyGraphUpdateInProgress);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_IsAnyWorkItemInProgress(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.IsAnyWorkItemInProgress);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.data);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_active(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, AstarPath.active);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showNavGraphs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showNavGraphs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showUnwalkableNodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showUnwalkableNodes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_debugMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                translator.PushPFGraphDebugMode(L, gen_to_be_invoked.debugMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_debugFloor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.debugFloor);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_debugRoof(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.debugRoof);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_manualDebugFloorRoof(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.manualDebugFloorRoof);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showSearchTree(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showSearchTree);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_unwalkableNodeDebugSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.unwalkableNodeDebugSize);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                translator.PushPFPathLog(L, gen_to_be_invoked.logPathResults);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxNearestNodeDistance);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_scanOnStartup(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.scanOnStartup);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.fullGetNearestSearch);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.prioritizeGraphs);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.prioritizeGraphsLimit);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_colorSettings(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.colorSettings);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                translator.PushPFHeuristic(L, gen_to_be_invoked.heuristic);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.heuristicScale);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_threadCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                translator.PushPFThreadCount(L, gen_to_be_invoked.threadCount);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.maxFrameTime);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_batchGraphUpdates(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.batchGraphUpdates);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_graphUpdateBatchingInterval(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.graphUpdateBatchingInterval);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.debugPathData);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.debugPathID);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.pathProcessor);
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.euclideanEmbedding);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_showGraphs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.showGraphs);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_data(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.data = (Pathfinding.AstarData)translator.GetObject(L, 2, typeof(Pathfinding.AstarData));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_active(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    AstarPath.active = (AstarPath)translator.GetObject(L, 1, typeof(AstarPath));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showNavGraphs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showNavGraphs = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showUnwalkableNodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showUnwalkableNodes = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_debugMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                PF.GraphDebugMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.debugMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_debugFloor(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.debugFloor = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_debugRoof(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.debugRoof = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_manualDebugFloorRoof(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.manualDebugFloorRoof = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showSearchTree(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showSearchTree = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_unwalkableNodeDebugSize(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.unwalkableNodeDebugSize = (float)LuaAPI.lua_tonumber(L, 2);
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                PF.PathLog gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.logPathResults = gen_value;
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxNearestNodeDistance = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_scanOnStartup(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.scanOnStartup = LuaAPI.lua_toboolean(L, 2);
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.fullGetNearestSearch = LuaAPI.lua_toboolean(L, 2);
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.prioritizeGraphs = LuaAPI.lua_toboolean(L, 2);
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.prioritizeGraphsLimit = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_colorSettings(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.colorSettings = (Pathfinding.AstarColor)translator.GetObject(L, 2, typeof(Pathfinding.AstarColor));
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                PF.Heuristic gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.heuristic = gen_value;
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.heuristicScale = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_threadCount(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                PF.ThreadCount gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.threadCount = gen_value;
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.maxFrameTime = (float)LuaAPI.lua_tonumber(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_batchGraphUpdates(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.batchGraphUpdates = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_graphUpdateBatchingInterval(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.graphUpdateBatchingInterval = (float)LuaAPI.lua_tonumber(L, 2);
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.debugPathData = (PF.PathHandler)translator.GetObject(L, 2, typeof(PF.PathHandler));
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.debugPathID = (ushort)LuaAPI.xlua_tointeger(L, 2);
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pathProcessor = (PF.PathProcessor)translator.GetObject(L, 2, typeof(PF.PathProcessor));
            
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
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.euclideanEmbedding = (PF.EuclideanEmbedding)translator.GetObject(L, 2, typeof(PF.EuclideanEmbedding));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_showGraphs(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                AstarPath gen_to_be_invoked = (AstarPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.showGraphs = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
