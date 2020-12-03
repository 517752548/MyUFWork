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
    public class FairyGUIDynamicFontWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.DynamicFont);
			Utils.BeginObjectRegister(type, L, translator, 0, 5, 0, 0);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetFormat", _m_SetFormat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "PrepareCharacters", _m_PrepareCharacters);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGlyphSize", _m_GetGlyphSize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGlyph", _m_GetGlyph);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasCharacter", _m_HasCharacter);
						
            
			
						
			
			
			
			
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && (LuaAPI.lua_isnil(L, 2) || LuaAPI.lua_type(L, 2) == LuaTypes.LUA_TSTRING))
				{
					string _name = LuaAPI.lua_tostring(L, 2);
					
					FairyGUI.DynamicFont gen_ret = new FairyGUI.DynamicFont(_name);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.DynamicFont constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFormat(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.DynamicFont gen_to_be_invoked = (FairyGUI.DynamicFont)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    FairyGUI.TextFormat _format = (FairyGUI.TextFormat)translator.GetObject(L, 2, typeof(FairyGUI.TextFormat));
                    float _fontSizeScale = (float)LuaAPI.lua_tonumber(L, 3);
                    
                    gen_to_be_invoked.SetFormat( 
                        _format, 
                        _fontSizeScale );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_PrepareCharacters(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.DynamicFont gen_to_be_invoked = (FairyGUI.DynamicFont)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    string _text = LuaAPI.lua_tostring(L, 2);
                    
                    gen_to_be_invoked.PrepareCharacters( 
                        _text );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGlyphSize(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.DynamicFont gen_to_be_invoked = (FairyGUI.DynamicFont)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    char _ch = (char)LuaAPI.xlua_tointeger(L, 2);
                    float _width;
                    float _height;
                    
                        bool gen_ret = gen_to_be_invoked.GetGlyphSize( 
                        _ch, 
                        out _width, 
                        out _height );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    LuaAPI.lua_pushnumber(L, _width);
                        
                    LuaAPI.lua_pushnumber(L, _height);
                        
                    
                    
                    
                    return 3;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_GetGlyph(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.DynamicFont gen_to_be_invoked = (FairyGUI.DynamicFont)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    char _ch = (char)LuaAPI.xlua_tointeger(L, 2);
                    FairyGUI.GlyphInfo _glyph;translator.Get(L, 3, out _glyph);
                    
                        bool gen_ret = gen_to_be_invoked.GetGlyph( 
                        _ch, 
                        ref _glyph );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    translator.Push(L, _glyph);
                        translator.Update(L, 3, _glyph);
                        
                    
                    
                    
                    return 2;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_HasCharacter(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.DynamicFont gen_to_be_invoked = (FairyGUI.DynamicFont)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    char _ch = (char)LuaAPI.xlua_tointeger(L, 2);
                    
                        bool gen_ret = gen_to_be_invoked.HasCharacter( 
                        _ch );
                        LuaAPI.lua_pushboolean(L, gen_ret);
                    
                    
                    
                    return 1;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        
        
        
        
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
