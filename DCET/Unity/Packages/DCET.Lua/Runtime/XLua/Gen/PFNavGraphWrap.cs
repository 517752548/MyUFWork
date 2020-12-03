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
    public class PFNavGraphWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.NavGraph);
			Utils.BeginObjectRegister(type, L, translator, 0, 18, 7, 7);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "CountNodes", _m_CountNodes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNodes", _m_GetNodes);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearest", _m_GetNearest);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNearestForce", _m_GetNearestForce);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getguid", _g_get_guid);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getinitialPenalty", _g_get_initialPenalty);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getopen", _g_get_open);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraphIndex", _g_get_graphIndex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getname", _g_get_name);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getdrawGizmos", _g_get_drawGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getinfoScreenOpen", _g_get_infoScreenOpen);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setguid", _s_set_guid);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setinitialPenalty", _s_set_initialPenalty);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setopen", _s_set_open);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgraphIndex", _s_set_graphIndex);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setname", _s_set_name);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setdrawGizmos", _s_set_drawGizmos);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setinfoScreenOpen", _s_set_infoScreenOpen);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "guid", _g_get_guid);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "initialPenalty", _g_get_initialPenalty);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "open", _g_get_open);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "graphIndex", _g_get_graphIndex);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "name", _g_get_name);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "drawGizmos", _g_get_drawGizmos);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "infoScreenOpen", _g_get_infoScreenOpen);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "guid", _s_set_guid);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "initialPenalty", _s_set_initialPenalty);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "open", _s_set_open);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "graphIndex", _s_set_graphIndex);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "name", _s_set_name);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "drawGizmos", _s_set_drawGizmos);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "infoScreenOpen", _s_set_infoScreenOpen);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 1, 0, 0);
			
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            return LuaAPI.luaL_error(L, "PF.NavGraph does not have a constructor!");
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_CountNodes(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.CountNodes(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNodes(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<System.Func<PF.GraphNode, bool>>(L, 2)) 
                {
                    System.Func<PF.GraphNode, bool> _action = translator.GetDelegate<System.Func<PF.GraphNode, bool>>(L, 2);
                    
                    gen_to_be_invoked.GetNodes( 
                        _action );
                    
                    
                    
                    return 0;
                }
                if(gen_param_count == 2&& translator.Assignable<System.Action<PF.GraphNode>>(L, 2)) 
                {
                    System.Action<PF.GraphNode> _action = translator.GetDelegate<System.Action<PF.GraphNode>>(L, 2);
                    
                    gen_to_be_invoked.GetNodes( 
                        _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.NavGraph.GetNodes!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearest(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<PF.NNConstraint>(L, 3)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    PF.NNConstraint _constraint = (PF.NNConstraint)translator.GetObject(L, 3, typeof(PF.NNConstraint));
                    
                        PF.NNInfoInternal gen_ret = gen_to_be_invoked.GetNearest( 
                        _position, 
                        _constraint );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                if(gen_param_count == 4&& translator.Assignable<UnityEngine.Vector3>(L, 2)&& translator.Assignable<PF.NNConstraint>(L, 3)&& translator.Assignable<PF.GraphNode>(L, 4)) 
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    PF.NNConstraint _constraint = (PF.NNConstraint)translator.GetObject(L, 3, typeof(PF.NNConstraint));
                    PF.GraphNode _hint = (PF.GraphNode)translator.GetObject(L, 4, typeof(PF.GraphNode));
                    
                        PF.NNInfoInternal gen_ret = gen_to_be_invoked.GetNearest( 
                        _position, 
                        _constraint, 
                        _hint );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.NavGraph.GetNearest!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetNearestForce(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
                    PF.NNConstraint _constraint = (PF.NNConstraint)translator.GetObject(L, 3, typeof(PF.NNConstraint));
                    
                        PF.NNInfoInternal gen_ret = gen_to_be_invoked.GetNearestForce( 
                        _position, 
                        _constraint );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_guid(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.guid);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_initialPenalty(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.initialPenalty);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_open(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.open);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_graphIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushuint(L, gen_to_be_invoked.graphIndex);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_name(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushstring(L, gen_to_be_invoked.name);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_drawGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.drawGizmos);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_infoScreenOpen(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.infoScreenOpen);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_guid(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                PF.Guid gen_value;translator.Get(L, 2, out gen_value);
				gen_to_be_invoked.guid = gen_value;
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_initialPenalty(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.initialPenalty = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_open(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.open = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_graphIndex(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.graphIndex = LuaAPI.xlua_touint(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_name(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.name = LuaAPI.lua_tostring(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_drawGizmos(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.drawGizmos = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_infoScreenOpen(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavGraph gen_to_be_invoked = (PF.NavGraph)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.infoScreenOpen = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
