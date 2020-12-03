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
    public class PFFloodPathWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.FloodPath);
			Utils.BeginObjectRegister(type, L, translator, 0, 10, 4, 4);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasPathTo", _m_HasPathTo);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetParent", _m_GetParent);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getoriginalStartPoint", _g_get_originalStartPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstartPoint", _g_get_startPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getstartNode", _g_get_startNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsaveParents", _g_get_saveParents);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setoriginalStartPoint", _s_set_originalStartPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstartPoint", _s_set_startPoint);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setstartNode", _s_set_startNode);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsaveParents", _s_set_saveParents);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "originalStartPoint", _g_get_originalStartPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startPoint", _g_get_startPoint);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "startNode", _g_get_startNode);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "saveParents", _g_get_saveParents);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "originalStartPoint", _s_set_originalStartPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startPoint", _s_set_startPoint);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "startNode", _s_set_startNode);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "saveParents", _s_set_saveParents);
            
			
			
			
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
					
					PF.FloodPath gen_ret = new PF.FloodPath();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.FloodPath constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasPathTo(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.FloodPath gen_to_be_invoked = (PF.FloodPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                        bool gen_ret = gen_to_be_invoked.HasPathTo( 
                        _node );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetParent(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.FloodPath gen_to_be_invoked = (PF.FloodPath)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                        PF.GraphNode gen_ret = gen_to_be_invoked.GetParent( 
                        _node );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Construct_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<UnityEngine.Vector3>(L, 1)&& translator.Assignable<PF.OnPathDelegate>(L, 2)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 2);
                    
                        PF.FloodPath gen_ret = PF.FloodPath.Construct( 
                        _start, 
                        _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<UnityEngine.Vector3>(L, 1)) 
                {
                    UnityEngine.Vector3 _start;translator.Get(L, 1, out _start);
                    
                        PF.FloodPath gen_ret = PF.FloodPath.Construct( 
                        _start );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.GraphNode>(L, 1)&& translator.Assignable<PF.OnPathDelegate>(L, 2)) 
                {
                    PF.GraphNode _start = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    PF.OnPathDelegate _callback = translator.GetDelegate<PF.OnPathDelegate>(L, 2);
                    
                        PF.FloodPath gen_ret = PF.FloodPath.Construct( 
                        _start, 
                        _callback );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 1&& translator.Assignable<PF.GraphNode>(L, 1)) 
                {
                    PF.GraphNode _start = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    
                        PF.FloodPath gen_ret = PF.FloodPath.Construct( 
                        _start );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.FloodPath.Construct!");
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_originalStartPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.FloodPath gen_to_be_invoked = (PF.FloodPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.originalStartPoint);
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
			
                PF.FloodPath gen_to_be_invoked = (PF.FloodPath)translator.FastGetCSObj(L, 1);
                translator.PushUnityEngineVector3(L, gen_to_be_invoked.startPoint);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_startNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.FloodPath gen_to_be_invoked = (PF.FloodPath)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.startNode);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_saveParents(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.FloodPath gen_to_be_invoked = (PF.FloodPath)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.saveParents);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_originalStartPoint(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.FloodPath gen_to_be_invoked = (PF.FloodPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.originalStartPoint = gen_value;
            
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
			
                PF.FloodPath gen_to_be_invoked = (PF.FloodPath)translator.FastGetCSObj(L, 1);
                UnityEngine.Vector3 gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.startPoint = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_startNode(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.FloodPath gen_to_be_invoked = (PF.FloodPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.startNode = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_saveParents(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.FloodPath gen_to_be_invoked = (PF.FloodPath)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.saveParents = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
