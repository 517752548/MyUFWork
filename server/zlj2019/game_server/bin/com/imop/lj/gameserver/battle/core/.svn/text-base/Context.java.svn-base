package com.imop.lj.gameserver.battle.core;

import java.util.Collection;
import java.util.HashMap;
import java.util.Map;
import java.util.Set;

/**
 * 战斗上下文对象，保存数值，战斗阶段对其修改
 * @author yuanbo.gao
 *
 */
public class Context implements Map<String, Object> {
	private HashMap<String, Object> contents = new HashMap<String, Object>();

	private HashMap<String, HashMap<String, Object>> units = new HashMap<String, HashMap<String, Object>>();

	public Object put(FightUnit unit, String key, Object value) {
		HashMap<String, Object> contents = loadUnitResult(unit);
		return contents.put(key, value);
	}

	public void put(FightUnit unit, Map<String, Object> map) {
		HashMap<String, Object> contents = loadUnitResult(unit);
		for (Entry<String, Object> entry : map.entrySet())
			contents.put(entry.getKey(), entry.getValue());
	}

	public void increaseValue(FightUnit unit, String key, int value) {
		int current = ((Integer) getWithDefault(unit, key, Integer.valueOf(0), Integer.class)).intValue();
		current += value;
		put(unit, key, Integer.valueOf(current));
	}

	public void decreaseValue(FightUnit unit, String key, int value) {
		int current = ((Integer) getWithDefault(unit, key, Integer.valueOf(0), Integer.class)).intValue();
		current -= value;
		put(unit, key, Integer.valueOf(current));
	}

	public Object get(FightUnit unit, String key) {
		String id = unit.getIdentifier();
		Map<String, Object> result = getUnitResult(id);
		return result == null ? null : result.get(key);
	}

	private Map<String, Object> getUnitResult(String id) {
		return this.units.get(id);
	}

	@SuppressWarnings("unchecked")
	public <E> E getWithDefault(String key, E defaultValue, Class<E> clz) {
		Object result = get(key);
		if (result == null) {
			return defaultValue;
		}
		return (E) result;
	}

	@SuppressWarnings("unchecked")
	public <E> E getWithDefault(FightUnit unit, String key, E defaultValue, Class<E> clz) {
		Object result = get(unit, key);
		if (result == null) {
			return defaultValue;
		}
		return (E) result;
	}

	public void remove(FightUnit unit, String key) {
		String id = unit.getIdentifier();
		Map<String, Object> result = getUnitResult(id);
		if (result == null) {
			return;
		}
		result.remove(key);
	}

	private HashMap<String, Object> loadUnitResult(FightUnit unit) {
		String id = unit.getIdentifier();
		if (this.units.containsKey(id)) {
			return this.units.get(id);
		}

		HashMap<String, Object> result = new HashMap<String, Object>();
		this.units.put(id, result);
		return result;
	}

	public void clear() {
		this.contents.clear();
	}

	public boolean containsKey(Object key) {
		return this.contents.containsKey(key);
	}

	public boolean containsValue(Object value) {
		return this.contents.containsValue(value);
	}

	public Set<Map.Entry<String, Object>> entrySet() {
		return this.contents.entrySet();
	}

	public boolean equals(Object o) {
		return this.contents.equals(o);
	}

	public Object get(Object key) {
		return this.contents.get(key);
	}

	public int hashCode() {
		return this.contents.hashCode();
	}

	public boolean isEmpty() {
		return this.contents.isEmpty();
	}

	public Set<String> keySet() {
		return this.contents.keySet();
	}

	public Object put(String key, Object value) {
		return this.contents.put(key, value);
	}

	public void putAll(Map<? extends String, ? extends Object> m) {
		this.contents.putAll(m);
	}

	public Object remove(Object key) {
		return this.contents.remove(key);
	}

	public int size() {
		return this.contents.size();
	}

	public Collection<Object> values() {
		return this.contents.values();
	}
}