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
    public class PFNavmeshTileWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.NavmeshTile);
			Utils.BeginObjectRegister(type, L, translator, 0, 28, 12, 11);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetTileCoordinates", _m_GetTileCoordinates);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertexArrayIndex", _m_GetVertexArrayIndex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertex", _m_GetVertex);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetVertexInGraphSpace", _m_GetVertexInGraphSpace);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetNodes", _m_GetNodes);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettransform", _g_get_transform);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gettris", _g_get_tris);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getverts", _g_get_verts);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getvertsInGraphSpace", _g_get_vertsInGraphSpace);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getx", _g_get_x);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getz", _g_get_z);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getw", _g_get_w);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getd", _g_get_d);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getnodes", _g_get_nodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getbbTree", _g_get_bbTree);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getflag", _g_get_flag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getgraph", _g_get_graph);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "settris", _s_set_tris);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setverts", _s_set_verts);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setvertsInGraphSpace", _s_set_vertsInGraphSpace);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setx", _s_set_x);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setz", _s_set_z);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setw", _s_set_w);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setd", _s_set_d);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setnodes", _s_set_nodes);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setbbTree", _s_set_bbTree);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setflag", _s_set_flag);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setgraph", _s_set_graph);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "transform", _g_get_transform);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "tris", _g_get_tris);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "verts", _g_get_verts);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "vertsInGraphSpace", _g_get_vertsInGraphSpace);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "x", _g_get_x);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "z", _g_get_z);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "w", _g_get_w);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "d", _g_get_d);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "nodes", _g_get_nodes);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "bbTree", _g_get_bbTree);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "flag", _g_get_flag);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "graph", _g_get_graph);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "tris", _s_set_tris);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "verts", _s_set_verts);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "vertsInGraphSpace", _s_set_vertsInGraphSpace);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "x", _s_set_x);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "z", _s_set_z);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "w", _s_set_w);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "d", _s_set_d);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "nodes", _s_set_nodes);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "bbTree", _s_set_bbTree);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "flag", _s_set_flag);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "graph", _s_set_graph);
            
			
			
			
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
					
					PF.NavmeshTile gen_ret = new PF.NavmeshTile();
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.NavmeshTile constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetTileCoordinates(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _tileIndex = LuaAPI.xlua_tointeger(L, 2);
                    int _x;
                    int _z;
                    
                    gen_to_be_invoked.GetTileCoordinates( 
                        _tileIndex, 
                        out _x, 
                        out _z );
                    LuaAPI.xlua_pushinteger(L, _x);
                        
                    LuaAPI.xlua_pushinteger(L, _z);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVertexArrayIndex(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        int gen_ret = gen_to_be_invoked.GetVertexArrayIndex( 
                        _index );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVertex(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        PF.Int3 gen_ret = gen_to_be_invoked.GetVertex( 
                        _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetVertexInGraphSpace(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    int _index = LuaAPI.xlua_tointeger(L, 2);
                    
                        PF.Int3 gen_ret = gen_to_be_invoked.GetVertexInGraphSpace( 
                        _index );
                        translator.Push(L, gen_ret);
                    
                    
                    
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
            
            
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    System.Action<PF.GraphNode> _action = translator.GetDelegate<System.Action<PF.GraphNode>>(L, 2);
                    
                    gen_to_be_invoked.GetNodes( 
                        _action );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_transform(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.transform);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_tris(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.tris);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_verts(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.verts);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_vertsInGraphSpace(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.vertsInGraphSpace);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_x(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.x);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_z(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.z);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_w(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.w);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_d(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.d);
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
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.nodes);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_bbTree(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.bbTree);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_flag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.flag);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_graph(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                translator.Push(L, gen_to_be_invoked.graph);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_tris(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.tris = (int[])translator.GetObject(L, 2, typeof(int[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_verts(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.verts = (PF.Int3[])translator.GetObject(L, 2, typeof(PF.Int3[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_vertsInGraphSpace(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.vertsInGraphSpace = (PF.Int3[])translator.GetObject(L, 2, typeof(PF.Int3[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_x(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.x = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_z(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.z = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_w(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.w = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_d(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.d = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_nodes(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.nodes = (PF.TriangleMeshNode[])translator.GetObject(L, 2, typeof(PF.TriangleMeshNode[]));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_bbTree(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.bbTree = (PF.BBTree)translator.GetObject(L, 2, typeof(PF.BBTree));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_flag(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.flag = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_graph(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.NavmeshTile gen_to_be_invoked = (PF.NavmeshTile)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.graph = (PF.NavmeshBase)translator.GetObject(L, 2, typeof(PF.NavmeshBase));
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
