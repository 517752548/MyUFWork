package com.renren.games.api.util;

import java.util.Set;
import java.util.concurrent.ConcurrentHashMap;

/**
 * 同步LRUMap
 * 
 * @author yuanbo.gao
 *
 * @param <K>
 * @param <V>
 */
public class LRUMap<K, V> {

	/**
	 * 最大空间
	 */
	private int maxSize;

	/**
	 * 缓存用到了ConcurrentHashMap这样可以避免自己去同步cache的put和delete
	 */
	private ConcurrentHashMap<K, Node> cache;

	/**
	 * 这个数据结构就是缓存中entry的wraper类，因为他还要记录上一个元素和下一个元素来区分到底他是否是该LRU中最老的那个元素
	 */
	private class Node {
		Node prev, next;
		K key;
		V item;
		// int size;
	}

	/**
	 * 最新元素和最老元素
	 */
	private Node head, tail;

	public LRUMap(int maxSize) {
		this.maxSize = maxSize;
		clear();
	}

	public int getSize() {
		return cache.size();
	}

	/**
	 * 
	 * 
	 * @return 得到缓存的大小
	 */
	public int getMaxSize() {
		return maxSize;
	}

	/**
	 * 用于遍历
	 * 
	 * @return
	 */
	public Set<K> keySet() {
		return cache.keySet();
	}

	/**
	 * 增加一个缓存entry，默认大小为1 如果map满了的话，最老的那个缓存entry将会被删除
	 * 本entry将会成为最年轻的entry，当前最后被删除
	 */
	public void put(K key, V item) {
		put(key, item, 1);
	}

	/**
	 * 增加一个实体到缓存中 假如缓存满了，将会从最老的缓存实体（或者最不经常用的）那个开始删除 这个新的实体将会成为最新的那个缓存
	 * 
	 * @param key
	 *            The key used to refer to the object when calling
	 *            <CODE>get()</CODE>.
	 * @param item
	 *            The item to add to the cache.
	 * @param size
	 */
	private void put(K key, V item, int size) {
		// 假如已经有这个key的缓存，删除原先的那个
		if (cache.containsKey(key))
			remove(key);
		// 从最老的entry开始删除,直到有空余空间位置
		while (cache.size() + size > maxSize) {
			if (!deleteLRU())
				break;
		}
		if (cache.size() + size > maxSize)
			// 如果此时正好被别的线程又保存新的entry进来，那么空间还是不够，那么就缓存失败
			return;
		// 创建一个新的实体保存到LRUMap中，并保存实体之间的联系为一个链表
		Node node = new Node();
		node.key = key;
		node.item = item;
		// node.size = size;
		cache.put(key, node);
		insertNode(node);
	}

	/**
	 * 从缓存中查找实体，返回null假如没有找到 因为经常被查找的缓存要延迟被清空的时间，所以要把被查找的缓存从列表中删除更新为最新的entry
	 * 
	 * @param key
	 *            The key used to refer to the object when <CODE>add()</CODE>
	 *            was called.
	 * @return The item, or null if not found.
	 */
	public V get(K key) {
		Node node = cache.get(key);
		if (node == null)
			return null;
		deleteNode(node);
		insertNode(node); // 移动到链表的最前面(更新为最新的实体).
		return node.item;
	}

	/**
	 * 从缓存中删除
	 * 
	 * @param key
	 *            The key used to refer to the object when <CODE>add()</CODE>
	 *            was called.
	 * @return The item that was removed, or null if not found.
	 */
	public V remove(K key) {
		Node node = cache.remove(key);
		if (node == null)
			return null;
		deleteNode(node);
		return node.item;
	}

	public boolean containsKey(K key) {
		return cache.containsKey(key);
	}

	/**
	 * 清空所有缓存，慎用
	 */
	public void clear() {
		cache = new ConcurrentHashMap<K, Node>();
		head = tail = null;
	}

	/**
	 * 把实体插入到链表的第一个位置
	 */
	private void insertNode(Node node) {
		node.next = head;
		node.prev = null;
		if (head != null)
			head.prev = node;
		head = node;
		if (tail == null)
			tail = node;
	}

	/**
	 * 从链表中删除这个实体 This only does linked list management.
	 */
	private void deleteNode(Node node) {
		if (node.prev != null)
			node.prev.next = node.next;
		else
			head = node.next;
		if (node.next != null)
			node.next.prev = node.prev;
		else
			tail = node.prev;
	}

	/**
	 * 删除列表最后一个缓存 如果删除成功返回正确，如果缓存为空则返回失败
	 */
	private boolean deleteLRU() {
		if (tail == null)
			return false;
		cache.remove(tail.key);
		deleteNode(tail);
		return true;
	}

	/**
	 * 得到这个缓存的描述字串，以key连接
	 */
	public String toString() {
		StringBuffer buf = new StringBuffer();
		buf.append("LRU ");
		buf.append("/");
		buf.append(maxSize);
		buf.append(" Order: ");
		Node n = head;
		while (n != null) {
			buf.append(n.key);
			if (n.next != null)
				buf.append(", ");
			n = n.next;
		}
		return buf.toString();
	}
}
