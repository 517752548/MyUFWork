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
    public class FairyGUIBitmapFontWrap 
    {
        public static void __Register(RealStatePtr L)
        {
			ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			System.Type type = typeof(FairyGUI.BitmapFont);
			Utils.BeginObjectRegister(type, L, translator, 0, 9, 2, 2);
			
            			
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "AddChar", _m_AddChar);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "SetFormat", _m_SetFormat);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGlyphSize", _m_GetGlyphSize);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "GetGlyph", _m_GetGlyph);
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "HasCharacter", _m_HasCharacter);
						
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getsize", _g_get_size);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "getresizable", _g_get_resizable);
            
			Utils.RegisterFunc(L, Utils.METHOD_IDX, "setsize", _s_set_size);
            Utils.RegisterFunc(L, Utils.METHOD_IDX, "setresizable", _s_set_resizable);
            
						
			
			
			Utils.RegisterFunc(L, Utils.GETTER_IDX, "size", _g_get_size);
            Utils.RegisterFunc(L, Utils.GETTER_IDX, "resizable", _g_get_resizable);
            
			Utils.RegisterFunc(L, Utils.SETTER_IDX, "size", _s_set_size);
            Utils.RegisterFunc(L, Utils.SETTER_IDX, "resizable", _s_set_resizable);
            
			
			
			
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
				if(LuaAPI.lua_gettop(L) == 2 && translator.Assignable<FairyGUI.PackageItem>(L, 2))
				{
					FairyGUI.PackageItem _item = (FairyGUI.PackageItem)translator.GetObject(L, 2, typeof(FairyGUI.PackageItem));
					
					FairyGUI.BitmapFont gen_ret = new FairyGUI.BitmapFont(_item);
					translator.Push(L, gen_ret);
                    
					return 1;
				}
				
			}
			catch(System.Exception gen_e) {
				return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
			}
            return LuaAPI.luaL_error(L, "invalid arguments to FairyGUI.BitmapFont constructor!");
            
        }
        
		
        
		
        
        

		
        
		
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_AddChar(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.BitmapFont gen_to_be_invoked = (FairyGUI.BitmapFont)translator.FastGetCSObj(L, 1);
            
            
                
                {
                    char _ch = (char)LuaAPI.xlua_tointeger(L, 2);
                    FairyGUI.BitmapFont.BMGlyph _glyph = (FairyGUI.BitmapFont.BMGlyph)translator.GetObject(L, 3, typeof(FairyGUI.BitmapFont.BMGlyph));
                    
                    gen_to_be_invoked.AddChar( 
                        _ch, 
                        _glyph );
                    
                    
                    
                    return 0;
                }
                
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _m_SetFormat(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.BitmapFont gen_to_be_invoked = (FairyGUI.BitmapFont)translator.FastGetCSObj(L, 1);
            
            
                
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
        static int _m_GetGlyphSize(RealStatePtr L)
        {
		    try {
			
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
            
            
                FairyGUI.BitmapFont gen_to_be_invoked = (FairyGUI.BitmapFont)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                FairyGUI.BitmapFont gen_to_be_invoked = (FairyGUI.BitmapFont)translator.FastGetCSObj(L, 1);
            
            
                
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
            
            
                FairyGUI.BitmapFont gen_to_be_invoked = (FairyGUI.BitmapFont)translator.FastGetCSObj(L, 1);
            
            
                
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
        
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_size(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.BitmapFont gen_to_be_invoked = (FairyGUI.BitmapFont)translator.FastGetCSObj(L, 1);
                LuaAPI.xlua_pushinteger(L, gen_to_be_invoked.size);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _g_get_resizable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.BitmapFont gen_to_be_invoked = (FairyGUI.BitmapFont)translator.FastGetCSObj(L, 1);
                LuaAPI.lua_pushboolean(L, gen_to_be_invoked.resizable);
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 1;
        }
        
        
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_size(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.BitmapFont gen_to_be_invoked = (FairyGUI.BitmapFont)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.size = LuaAPI.xlua_tointeger(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
        [MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
        static int _s_set_resizable(RealStatePtr L)
        {
		    try {
                ObjectTranslator translator = ObjectTranslatorPool.Instance.Find(L);
			
                FairyGUI.BitmapFont gen_to_be_invoked = (FairyGUI.BitmapFont)translator.FastGetCSObj(L, 1);
                gen_to_be_invoked.resizable = LuaAPI.lua_toboolean(L, 2);
            
            } catch(System.Exception gen_e) {
                return LuaAPI.luaL_error(L, "c# exception:" + gen_e);
            }
            return 0;
        }
        
		
		
		
		

		
		
		
		
		
		
		
    }
}
