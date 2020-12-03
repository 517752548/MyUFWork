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
    public class PFInt3Wrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(PF.Int3);
			Utils.BeginObjectRegister(type, L, translator, 6, 15, 7, 3);
			Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__eq", __EqMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__sub", __SubMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__unm", __UnmMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__add", __AddMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__mul", __MulMeta);
            Utils.RegisterFunc(L, Utils.OBJ_META_IDX, "__div", __DivMeta);
            
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "__clone__", __clone__);
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Normal2D", _m_Normal2D);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "ToString", _m_ToString);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "Equals", _m_Equals);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetHashCode", _m_GetHashCode);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getmagnitude", _g_get_magnitude);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getcostMagnitude", _g_get_costMagnitude);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsqrMagnitude", _g_get_sqrMagnitude);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsqrMagnitudeLong", _g_get_sqrMagnitudeLong);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getx", _g_get_x);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "gety", _g_get_y);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getz", _g_get_z);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setx", _s_set_x);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "sety", _s_set_y);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setz", _s_set_z);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "magnitude", _g_get_magnitude);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "costMagnitude", _g_get_costMagnitude);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sqrMagnitude", _g_get_sqrMagnitude);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "sqrMagnitudeLong", _g_get_sqrMagnitudeLong);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "x", _g_get_x);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "y", _g_get_y);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "z", _g_get_z);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "x", _s_set_x);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "y", _s_set_y);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "z", _s_set_z);
            
			
			
			
			Utils.EndObjectRegister(type, L, translator, __CSIndexer, __NewIndexer,
			    null, null, null);

		    Utils.BeginClassRegister(type, L, __CreateInstance, 21, 1, 0);
			Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Equality",__EqMeta);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Inequality", _m_op_Inequality);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Explicit", _m_op_Explicit);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Subtraction",__SubMeta);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "op_UnaryNegation",__UnmMeta);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Addition",__AddMeta);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Multiply",__MulMeta);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Division",__DivMeta);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Angle", _m_Angle_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "Dot", _m_Dot_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "DotLong", _m_DotLong_xlua_st_);
            Utils.RegisterFunc(L, Utils.CLS_IDX, "op_Implicit", _m_op_Implicit);
            
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getPrecision", PF.Int3.Precision);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getFloatPrecision", PF.Int3.FloatPrecision);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "getPrecisionFactor", PF.Int3.PrecisionFactor);
            
			Utils.RegisterFunc(L, Utils.CLS_IDX, "getzero", _g_get_zero);
            
			
			
			
			
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "Precision", PF.Int3.Precision);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "FloatPrecision", PF.Int3.FloatPrecision);
            Utils.RegisterObject(L, translator, Utils.CLS_IDX, "PrecisionFactor", PF.Int3.PrecisionFactor);
            
			Utils.RegisterFunc(L, Utils.CLS_GETTER_IDX, "zero", _g_get_zero);
            
			
			
			
			
			Utils.EndClassRegister(type, L, translator);
        }
		
		
		[MonoPInvokeCallback(typeof(LuaCSFunction))]
		public static int __clone__(RealStatePtr L)
		{
			try
			{
				ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<UnityEngine.Vector3>(L, 2))
				{
					UnityEngine.Vector3 _position;translator.Get(L, 2, out _position);
					
					PF.Int3 gen_ret = new PF.Int3(_position);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				if(LuaAPI.lua_gettop(L) == 4 && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 4))
				{
					int __x = LuaAPI.xlua_tointeger(L, 2);
					int __y = LuaAPI.xlua_tointeger(L, 3);
					int __z = LuaAPI.xlua_tointeger(L, 4);
					
					PF.Int3 gen_ret = new PF.Int3(__x, __y, __z);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
				if (LuaAPI.lua_gettop(L) == 1)
				{
				    translator.Push(L, default(PF.Int3));
			        return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to PF.Int3 constructor!");
            
        }
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __CSIndexer(RealStatePtr L)
        {
			try {
			    ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
				
				if (translator.Assignable<PF.Int3>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					
					PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
					int index = LuaAPI.xlua_tointeger(L, 2);
					LuaAPI.lua_pushboolean(L, true);
					LuaAPI.xlua_pushinteger(L, gen_to_be_invoked[index]);
					return 2;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			
            LuaAPI.lua_pushboolean(L, false);
			return 1;
        }
		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        public static int __NewIndexer(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
			try {
				
				if (translator.Assignable<PF.Int3>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 3))
				{
					
					PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
					int key = LuaAPI.xlua_tointeger(L, 2);
					gen_to_be_invoked[key] = LuaAPI.xlua_tointeger(L, 3);
					LuaAPI.lua_pushboolean(L, true);
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
			
			LuaAPI.lua_pushboolean(L, false);
            return 1;
        }
		
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __EqMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<PF.Int3>(L, 1) && translator.Assignable<PF.Int3>(L, 2))
				{
					PF.Int3 leftside;translator.Get(L, 1, out leftside);
					PF.Int3 rightside;translator.Get(L, 2, out rightside);
					
					LuaAPI.lua_pushboolean(L, leftside == rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of == operator, need PF.Int3!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __SubMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<PF.Int3>(L, 1) && translator.Assignable<PF.Int3>(L, 2))
				{
					PF.Int3 leftside;translator.Get(L, 1, out leftside);
					PF.Int3 rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside - rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of - operator, need PF.Int3!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __UnmMeta(RealStatePtr L)
        {
            
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
                PF.Int3 rightside;translator.Get(L, 1, out rightside);
                translator.Push(L, - rightside);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __AddMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<PF.Int3>(L, 1) && translator.Assignable<PF.Int3>(L, 2))
				{
					PF.Int3 leftside;translator.Get(L, 1, out leftside);
					PF.Int3 rightside;translator.Get(L, 2, out rightside);
					
					translator.Push(L, leftside + rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of + operator, need PF.Int3!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __MulMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<PF.Int3>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					PF.Int3 leftside;translator.Get(L, 1, out leftside);
					int rightside = LuaAPI.xlua_tointeger(L, 2);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<PF.Int3>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					PF.Int3 leftside;translator.Get(L, 1, out leftside);
					float rightside = (float)LuaAPI.lua_tonumber(L, 2);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			
				if (translator.Assignable<PF.Int3>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					PF.Int3 leftside;translator.Get(L, 1, out leftside);
					double rightside = LuaAPI.lua_tonumber(L, 2);
					
					translator.Push(L, leftside * rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of * operator, need PF.Int3!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int __DivMeta(RealStatePtr L)
        {
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<PF.Int3>(L, 1) && LuaTypes.LUA_TNUMBER == LuaAPI.lua_type(L, 2))
				{
					PF.Int3 leftside;translator.Get(L, 1, out leftside);
					float rightside = (float)LuaAPI.lua_tonumber(L, 2);
					
					translator.Push(L, leftside / rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of / operator, need PF.Int3!");
            
        }
        

		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_op_Inequality(RealStatePtr L)
        {					
			
            
			try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
			
				if (translator.Assignable<PF.Int3>(L, 1) && translator.Assignable<PF.Int3>(L, 2))
				{
					PF.Int3 leftside;translator.Get(L, 1, out leftside);
					PF.Int3 rightside;translator.Get(L, 2, out rightside);

					LuaAPI.lua_pushboolean(L, leftside != rightside);
					
					return 1;
				}
            
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to right hand of != operator, need PF.Int3!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_op_Explicit(RealStatePtr L)
        {					
			
            
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
                PF.Int3 rightside;translator.Get(L, 1, out rightside);
				
				translator.Push(L, (PF.Int3) rightside)
				;
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_op_Implicit(RealStatePtr L)
        {					
			
            
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            try {
                PF.Int3 rightside;translator.Get(L, 1, out rightside);
				
                LuaAPI.lua_pushstring(L,  rightside)
				;
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
            
        }
        
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Angle_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int3 _lhs;translator.Get(L, 1, out _lhs);
                    PF.Int3 _rhs;translator.Get(L, 2, out _rhs);
                    
                        float gen_ret = PF.Int3.Angle( 
                        _lhs, 
                        _rhs );
                        LuaAPI.lua_pushnumber(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Dot_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int3 _lhs;translator.Get(L, 1, out _lhs);
                    PF.Int3 _rhs;translator.Get(L, 2, out _rhs);
                    
                        int gen_ret = PF.Int3.Dot( 
                        _lhs, 
                        _rhs );
                        LuaAPI.xlua_pushinteger(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_DotLong_xlua_st_(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
            
                
                {
                    PF.Int3 _lhs;translator.Get(L, 1, out _lhs);
                    PF.Int3 _rhs;translator.Get(L, 2, out _rhs);
                    
                        long gen_ret = PF.Int3.DotLong( 
                        _lhs, 
                        _rhs );
                        LuaAPI.lua_pushint64(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_Normal2D(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
                {
                    
                        PF.Int3 gen_ret = gen_to_be_invoked.Normal2D(  );
                        translator.Push(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_ToString(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
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
        static int _m_Equals(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
			    int gen_param_count = LuaAPI.lua_gettop(L);
            
                if(gen_param_count == 2&& translator.Assignable<object>(L, 2)) 
                {
                    object _obj = translator.GetObject(L, 2, typeof(object));
                    
                        bool gen_ret = gen_to_be_invoked.Equals( 
                        _obj );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                if(gen_param_count == 2&& translator.Assignable<PF.Int3>(L, 2)) 
                {
                    PF.Int3 _other;translator.Get(L, 2, out _other);
                    
                        bool gen_ret = gen_to_be_invoked.Equals( 
                        _other );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                        translator.Update(L, 1, gen_to_be_invoked);
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
            return LuaAPI.luaL_error(L, "invalid arguments to PF.Int3.Equals!");
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetHashCode(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
            
            
                
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
        static int _g_get_zero(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			    translator.Push(L, PF.Int3.zero);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_magnitude(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.magnitude);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_costMagnitude(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.costMagnitude);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sqrMagnitude(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushnumber(L, gen_to_be_invoked.sqrMagnitude);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_sqrMagnitudeLong(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.lua_pushint64(L, gen_to_be_invoked.sqrMagnitudeLong);
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
			
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.x);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_y(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.y);
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
			
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.z);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_x(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.x = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_y(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.y = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
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
			
                PF.Int3 gen_to_be_invoked;translator.Get(L, 1, out gen_to_be_invoked);
                gen_to_be_invoked.z = LuaAPI.xlua_tointeger(L, 2);
            
                translator.Update(L, 1, gen_to_be_invoked);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
