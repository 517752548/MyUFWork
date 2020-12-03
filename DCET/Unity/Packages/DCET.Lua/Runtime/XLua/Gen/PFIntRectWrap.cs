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
    public class PFIntRectWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.IntRect);
			Utils.BeginObjectRegister(type, L, translator, 1, 21, 6, 4);
			Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__eq", __EqMeta);
            
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "__clone__", __clone__);
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Contains", _m_Contains);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "IsValid", _m_IsValid);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Equals", _m_Equals);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ExpandToContain", _m_ExpandToContain);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Expand", _m_Expand);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Rotate", _m_Rotate);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Offset", _m_Offset);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToString", _m_ToString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "DebugDraw", _m_DebugDraw);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getWidth", _g_get_Width);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getHeight", _g_get_Height);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getxmin", _g_get_xmin);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getymin", _g_get_ymin);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getxmax", _g_get_xmax);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getymax", _g_get_ymax);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setxmin", _s_set_xmin);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setymin", _s_set_ymin);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setxmax", _s_set_xmax);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setymax", _s_set_ymax);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "Width", _g_get_Width);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "Height", _g_get_Height);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "xmin", _g_get_xmin);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ymin", _g_get_ymin);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "xmax", _g_get_xmax);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "ymax", _g_get_ymax);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "xmin", _s_set_xmin);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ymin", _s_set_ymin);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "xmax", _s_set_xmax);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "ymax", _s_set_ymax);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, null, null,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 6, 0, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Equality",__EqMeta);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Inequality", _m_op_Inequality);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Intersection", _m_Intersection_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Intersects", _m_Intersects_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Union", _m_Union_xlua_st_);
            
            
			
			
			
			
			
            
			
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int __clone__(RealStatePtr L)
		{
			try
			{
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
				translator.Push(L, gen_to_be_invoked);
				return 1;
			}
			catch (System.Exception e)
			{
				return LuaAPI.luaL_error(L, "c# exception in StructClone:" + e);
			}
		}
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __CreateInstance(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				if(LuaAPI.lua_gettop(L) == 5 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 5))
				{
					int _xmin = LuaAPI.xlua_tointeger(L, 2);
					int _ymin = LuaAPI.xlua_tointeger(L, 3);
					int _xmax = LuaAPI.xlua_tointeger(L, 4);
					int _ymax = LuaAPI.xlua_tointeger(L, 5);
					
					PF.IntRect gen_ret = new PF.IntRect(_xmin, _ymin, _xmax, _ymax);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(PF.IntRect));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.IntRect constructor!");
            
        }
        
		
        
		
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __EqMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<PF.IntRect>(L, 1) && translator.Assignable<PF.IntRect>(L, 2))
				{
					PF.IntRect leftside;translator.Get(L, 1, out leftside);
					PF.IntRect rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of == operator, need PF.IntRect!");
            
        }
        

		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_op_Inequality(RealStatePtr L)
        {					
			
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<PF.IntRect>(L, 1) && translator.Assignable<PF.IntRect>(L, 2))
				{
					PF.IntRect leftside;translator.Get(L, 1, out leftside);
					PF.IntRect rightside;translator.Get(L, 2, out rightside);

					LuaAPI.lua_pushboolean(L, leftside != rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of != operator, need PF.IntRect!");
            
        }
        
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Contains(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _y = LuaAPI.xlua_tointeger(L, 3);
                    
                        bool gen_ret = gen_to_be_invoked.Contains( 
                        _x, 
                        _y );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_IsValid(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        bool gen_ret = gen_to_be_invoked.IsValid(  );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Equals(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    object _obj = translator.GetObject(L, 2, typeof(object));
                    
                        bool gen_ret = gen_to_be_invoked.Equals( 
                        _obj );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        int gen_ret = gen_to_be_invoked.GetHashCode(  );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Intersection_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.IntRect _a;translator.Get(L, 1, out _a);
                    PF.IntRect _b;translator.Get(L, 2, out _b);
                    
                        PF.IntRect gen_ret = PF.IntRect.Intersection( 
                        _a, 
                        _b );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Intersects_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.IntRect _a;translator.Get(L, 1, out _a);
                    PF.IntRect _b;translator.Get(L, 2, out _b);
                    
                        bool gen_ret = PF.IntRect.Intersects( 
                        _a, 
                        _b );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Union_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.IntRect _a;translator.Get(L, 1, out _a);
                    PF.IntRect _b;translator.Get(L, 2, out _b);
                    
                        PF.IntRect gen_ret = PF.IntRect.Union( 
                        _a, 
                        _b );
                        translator.Push(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ExpandToContain(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _y = LuaAPI.xlua_tointeger(L, 3);
                    
                        PF.IntRect gen_ret = gen_to_be_invoked.ExpandToContain( 
                        _x, 
                        _y );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Expand(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    int _range = LuaAPI.xlua_tointeger(L, 2);
                    
                        PF.IntRect gen_ret = gen_to_be_invoked.Expand( 
                        _range );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Rotate(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    int _r = LuaAPI.xlua_tointeger(L, 2);
                    
                        PF.IntRect gen_ret = gen_to_be_invoked.Rotate( 
                        _r );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Offset(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 3&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2)&& LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3)) 
                {
                    int _x = LuaAPI.xlua_tointeger(L, 2);
                    int _y = LuaAPI.xlua_tointeger(L, 3);
                    
                        PF.IntRect gen_ret = gen_to_be_invoked.Offset( 
                        _x, 
                        _y );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.Int2>(L, 2)) 
                {
                    PF.Int2 _offset;translator.Get(L, 2, out _offset);
                    
                        PF.IntRect gen_ret = gen_to_be_invoked.Offset( 
                        _offset );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.IntRect.Offset!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        string gen_ret = gen_to_be_invoked.ToString(  );
                        LuaAPI.lua_pushstring(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DebugDraw(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    PF.GraphTransform _transform = (PF.GraphTransform)translator.GetObject(L, 2, typeof(PF.GraphTransform));
                    UnityEngine.Color _color;translator.Get(L, 3, out _color);
                    
                    gen_to_be_invoked.DebugDraw( 
                        _transform, 
                        _color );
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Width(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Width);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_Height(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.Height);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_xmin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.xmin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ymin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ymin);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_xmax(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.xmax);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_ymax(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.ymax);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_xmin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.xmin = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ymin(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.ymin = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_xmax(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.xmax = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_ymax(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.IntRect gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.ymax = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
