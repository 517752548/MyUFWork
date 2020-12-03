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
    public class PFMultiTargetPathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.MultiTargetPath);
			Utils.BeginObjectRegister(type, L, translator, 0, 21, 11, 10);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getinverted", _g_get_inverted);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcallbacks", _g_get_callbacks);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettargetNodes", _g_get_targetNodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettargetsFound", _g_get_targetsFound);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettargetPoints", _g_get_targetPoints);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getoriginalTargetPoints", _g_get_originalTargetPoints);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvectorPaths", _g_get_vectorPaths);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnodePaths", _g_get_nodePaths);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getpathsForAll", _g_get_pathsForAll);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getchosenTarget", _g_get_chosenTarget);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getheuristicMode", _g_get_heuristicMode);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setcallbacks", _s_set_callbacks);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settargetNodes", _s_set_targetNodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settargetsFound", _s_set_targetsFound);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "settargetPoints", _s_set_targetPoints);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setoriginalTargetPoints", _s_set_originalTargetPoints);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setvectorPaths", _s_set_vectorPaths);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnodePaths", _s_set_nodePaths);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setpathsForAll", _s_set_pathsForAll);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setchosenTarget", _s_set_chosenTarget);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setheuristicMode", _s_set_heuristicMode);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "inverted", _g_get_inverted);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "callbacks", _g_get_callbacks);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "targetNodes", _g_get_targetNodes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "targetsFound", _g_get_targetsFound);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "targetPoints", _g_get_targetPoints);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "originalTargetPoints", _g_get_originalTargetPoints);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "vectorPaths", _g_get_vectorPaths);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nodePaths", _g_get_nodePaths);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "pathsForAll", _g_get_pathsForAll);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "chosenTarget", _g_get_chosenTarget);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "heuristicMode", _g_get_heuristicMode);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "callbacks", _s_set_callbacks);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "targetNodes", _s_set_targetNodes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "targetsFound", _s_set_targetsFound);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "targetPoints", _s_set_targetPoints);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "originalTargetPoints", _s_set_originalTargetPoints);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "vectorPaths", _s_set_vectorPaths);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "nodePaths", _s_set_nodePaths);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "pathsForAll", _s_set_pathsForAll);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "chosenTarget", _s_set_chosenTarget);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "heuristicMode", _s_set_heuristicMode);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "Construct", _m_Construct_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					PF.MultiTargetPath gen_ret = new PF.MultiTargetPath();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.MultiTargetPath constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Construct_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3[]>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<PF.OnPathDelegate[]>(L, 3)&& translator.Assignable<PF.OnPathDelegate>(L, 4)) 
                {
                    UnityEngine.Vector3[] _startPoints = (UnityEngine.Vector3[])translator.GetObject(L, 1, typeof(UnityEngine.Vector3[]));
                    UnityEngine.Vector3 _target;translator.Get(L, 2, out _target);
                    PF.OnPathDelegate[] _callbackDelegates = (PF.OnPathDelegate[])translator.GetObject(L, 3, typeof(PF.OnPathDelegate[]));
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 4);
                    
                        PF.MultiTargetPath gen_ret = PF.MultiTargetPath.Construct( 
                        _startPoints, 
                        _target, 
                        _callbackDelegates, 
                        _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3[]>(L, 1)&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<PF.OnPathDelegate[]>(L, 3)) 
                {
                    UnityEngine.Vector3[] _startPoints = (UnityEngine.Vector3[])translator.GetObject(L, 1, typeof(UnityEngine.Vector3[]));
                    UnityEngine.Vector3 _target;translator.Get(L, 2, out _target);
                    PF.OnPathDelegate[] _callbackDelegates = (PF.OnPathDelegate[])translator.GetObject(L, 3, typeof(PF.OnPathDelegate[]));
                    
                        PF.MultiTargetPath gen_ret = PF.MultiTargetPath.Construct( 
                        _startPoints, 
                        _target, 
                        _callbackDelegates );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3[]>(L, 2)&& translator.Assignable<PF.OnPathDelegate[]>(L, 3)&& translator.Assignable<PF.OnPathDelegate>(L, 4)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    UnityEngine.Vector3[] _targets = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    PF.OnPathDelegate[] _callbackDelegates = (PF.OnPathDelegate[])translator.GetObject(L, 3, typeof(PF.OnPathDelegate[]));
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 4);
                    
                        PF.MultiTargetPath gen_ret = PF.MultiTargetPath.Construct( 
                        _start, 
                        _targets, 
                        _callbackDelegates, 
                        _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<UnityEngine.Vector3[]>(L, 2)&& translator.Assignable<PF.OnPathDelegate[]>(L, 3)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    UnityEngine.Vector3[] _targets = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    PF.OnPathDelegate[] _callbackDelegates = (PF.OnPathDelegate[])translator.GetObject(L, 3, typeof(PF.OnPathDelegate[]));
                    
                        PF.MultiTargetPath gen_ret = PF.MultiTargetPath.Construct( 
                        _start, 
                        _targets, 
                        _callbackDelegates );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.MultiTargetPath.Construct!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_inverted(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.inverted);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_callbacks(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.callbacks);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_targetNodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.targetNodes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_targetsFound(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.targetsFound);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_targetPoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.targetPoints);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_originalTargetPoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.originalTargetPoints);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vectorPaths(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.vectorPaths);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_nodePaths(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.nodePaths);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_pathsForAll(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.pathsForAll);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_chosenTarget(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.chosenTarget);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_heuristicMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                translator.PushPFMultiTargetPathHeuristicMode(L, gen_to_be_invoked.heuristicMode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_callbacks(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.callbacks = (PF.OnPathDelegate[])translator.GetObject(L, 2, typeof(PF.OnPathDelegate[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_targetNodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.targetNodes = (PF.GraphNode[])translator.GetObject(L, 2, typeof(PF.GraphNode[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_targetsFound(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.targetsFound = (bool[])translator.GetObject(L, 2, typeof(bool[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_targetPoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.targetPoints = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_originalTargetPoints(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.originalTargetPoints = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_vectorPaths(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.vectorPaths = (System.Collections.Generic.List<UnityEngine.Vector3>[])translator.GetObject(L, 2, typeof(System.Collections.Generic.List<UnityEngine.Vector3>[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_nodePaths(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.nodePaths = (System.Collections.Generic.List<PF.GraphNode>[])translator.GetObject(L, 2, typeof(System.Collections.Generic.List<PF.GraphNode>[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_pathsForAll(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.pathsForAll = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_chosenTarget(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.chosenTarget = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_heuristicMode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.MultiTargetPath gen_to_be_invoked = (PF.MultiTargetPath)translator.FastGetCSObj(L, 1);
                PF.MultiTargetPath.HeuristicMode gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.heuristicMode = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
