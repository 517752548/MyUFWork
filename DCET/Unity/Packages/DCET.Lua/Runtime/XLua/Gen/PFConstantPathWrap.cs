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
    public class PFConstantPathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.ConstantPath);
			Utils.BeginObjectRegister(type, L, translator, 0, 10, 5, 5);
			
            			
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstartNode", _g_get_startNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstartPoint", _g_get_startPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getoriginalStartPoint", _g_get_originalStartPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getallNodes", _g_get_allNodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getendingCondition", _g_get_endingCondition);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstartNode", _s_set_startNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstartPoint", _s_set_startPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setoriginalStartPoint", _s_set_originalStartPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setallNodes", _s_set_allNodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setendingCondition", _s_set_endingCondition);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "startNode", _g_get_startNode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startPoint", _g_get_startPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "originalStartPoint", _g_get_originalStartPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "allNodes", _g_get_allNodes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "endingCondition", _g_get_endingCondition);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "startNode", _s_set_startNode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startPoint", _s_set_startPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "originalStartPoint", _s_set_originalStartPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "allNodes", _s_set_allNodes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "endingCondition", _s_set_endingCondition);
            
			
			
			
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
					
					PF.ConstantPath gen_ret = new PF.ConstantPath();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.ConstantPath constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Construct_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& translator.Assignable<PF.OnPathDelegate>(L, 3)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    int _maxGScore = LuaAPI.xlua_tointeger(L, 2);
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 3);
                    
                        PF.ConstantPath gen_ret = PF.ConstantPath.Construct( 
                        _start, 
                        _maxGScore, 
                        _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    int _maxGScore = LuaAPI.xlua_tointeger(L, 2);
                    
                        PF.ConstantPath gen_ret = PF.ConstantPath.Construct( 
                        _start, 
                        _maxGScore );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.ConstantPath.Construct!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ConstantPath gen_to_be_invoked = (PF.ConstantPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.startNode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ConstantPath gen_to_be_invoked = (PF.ConstantPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.startPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_originalStartPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ConstantPath gen_to_be_invoked = (PF.ConstantPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.originalStartPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_allNodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ConstantPath gen_to_be_invoked = (PF.ConstantPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.allNodes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_endingCondition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ConstantPath gen_to_be_invoked = (PF.ConstantPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.endingCondition);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ConstantPath gen_to_be_invoked = (PF.ConstantPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.startNode = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ConstantPath gen_to_be_invoked = (PF.ConstantPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.startPoint = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_originalStartPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ConstantPath gen_to_be_invoked = (PF.ConstantPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.originalStartPoint = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_allNodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ConstantPath gen_to_be_invoked = (PF.ConstantPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.allNodes = (System.Collections.Generic.List<PF.GraphNode>)translator.GetObject(L, 2, typeof(System.Collections.Generic.List<PF.GraphNode>));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_endingCondition(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.ConstantPath gen_to_be_invoked = (PF.ConstantPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.endingCondition = (PF.PathEndingCondition)translator.GetObject(L, 2, typeof(PF.PathEndingCondition));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
