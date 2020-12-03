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
    public class PathfindingUtilGraphGizmoHelperWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(Pathfinding.Util.GraphGizmoHelper);
			Utils.BeginObjectRegister(type, L, translator, 0, 10, 2, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Init", _m_Init);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "OnEnterPool", _m_OnEnterPool);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DrawConnections", _m_DrawConnections);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "NodeColor", _m_NodeColor);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DrawWireTriangle", _m_DrawWireTriangle);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DrawTriangles", _m_DrawTriangles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DrawWireTriangles", _m_DrawWireTriangles);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Submit", _m_Submit);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gethasher", _g_get_hasher);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getbuilder", _g_get_builder);
            
			
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "hasher", _g_get_hasher);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "builder", _g_get_builder);
            
			
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 2, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "InSearchTree", _m_InSearchTree_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 1)
				{
					
					Pathfinding.Util.GraphGizmoHelper gen_ret = new Pathfinding.Util.GraphGizmoHelper();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to Pathfinding.Util.GraphGizmoHelper constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Init(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.GraphGizmoHelper gen_to_be_invoked = (Pathfinding.Util.GraphGizmoHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    Pathfinding.Util.RetainedGizmos.Hasher _hasher;translator.Get(L, 2, out _hasher);
                    Pathfinding.Util.RetainedGizmos _gizmos = (Pathfinding.Util.RetainedGizmos)translator.GetObject(L, 3, typeof(Pathfinding.Util.RetainedGizmos));
                    
                    gen_to_be_invoked.Init( 
                        _hasher, 
                        _gizmos );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_OnEnterPool(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.GraphGizmoHelper gen_to_be_invoked = (Pathfinding.Util.GraphGizmoHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.OnEnterPool(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawConnections(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.GraphGizmoHelper gen_to_be_invoked = (Pathfinding.Util.GraphGizmoHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                    gen_to_be_invoked.DrawConnections( 
                        _node );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_NodeColor(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.GraphGizmoHelper gen_to_be_invoked = (Pathfinding.Util.GraphGizmoHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 2, typeof(PF.GraphNode));
                    
                        UnityEngine.Color gen_ret = gen_to_be_invoked.NodeColor( 
                        _node );
                        translator.PushUnityEngineColor(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_InSearchTree_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.GraphNode _node = (PF.GraphNode)translator.GetObject(L, 1, typeof(PF.GraphNode));
                    PF.PathHandler _handler = (PF.PathHandler)translator.GetObject(L, 2, typeof(PF.PathHandler));
                    ushort _pathID = (ushort)LuaAPI.xlua_tointeger(L, 3);
                    
                        bool gen_ret = Pathfinding.Util.GraphGizmoHelper.InSearchTree( 
                        _node, 
                        _handler, 
                        _pathID );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawWireTriangle(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.GraphGizmoHelper gen_to_be_invoked = (Pathfinding.Util.GraphGizmoHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3 _a;translator.Get(L, 2, out _a);
                    UnityEngine.Vector3 _b;translator.Get(L, 3, out _b);
                    UnityEngine.Vector3 _c;translator.Get(L, 4, out _c);
                    UnityEngine.Color _color;translator.Get(L, 5, out _color);
                    
                    gen_to_be_invoked.DrawWireTriangle( 
                        _a, 
                        _b, 
                        _c, 
                        _color );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawTriangles(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.GraphGizmoHelper gen_to_be_invoked = (Pathfinding.Util.GraphGizmoHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3[] _vertices = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    UnityEngine.Color[] _colors = (UnityEngine.Color[])translator.GetObject(L, 3, typeof(UnityEngine.Color[]));
                    int _numTriangles = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.DrawTriangles( 
                        _vertices, 
                        _colors, 
                        _numTriangles );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DrawWireTriangles(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.GraphGizmoHelper gen_to_be_invoked = (Pathfinding.Util.GraphGizmoHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    UnityEngine.Vector3[] _vertices = (UnityEngine.Vector3[])translator.GetObject(L, 2, typeof(UnityEngine.Vector3[]));
                    UnityEngine.Color[] _colors = (UnityEngine.Color[])translator.GetObject(L, 3, typeof(UnityEngine.Color[]));
                    int _numTriangles = LuaAPI.xlua_tointeger(L, 4);
                    
                    gen_to_be_invoked.DrawWireTriangles( 
                        _vertices, 
                        _colors, 
                        _numTriangles );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Submit(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                Pathfinding.Util.GraphGizmoHelper gen_to_be_invoked = (Pathfinding.Util.GraphGizmoHelper)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    
                    gen_to_be_invoked.Submit(  );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_hasher(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.GraphGizmoHelper gen_to_be_invoked = (Pathfinding.Util.GraphGizmoHelper)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.hasher);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_builder(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                Pathfinding.Util.GraphGizmoHelper gen_to_be_invoked = (Pathfinding.Util.GraphGizmoHelper)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.builder);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
