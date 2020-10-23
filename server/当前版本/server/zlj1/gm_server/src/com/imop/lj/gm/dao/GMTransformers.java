/**
 *
 */
package com.imop.lj.gm.dao;

import org.hibernate.transform.ResultTransformer;




/**
 * @author linfan
 *
 */
public class GMTransformers {

	@SuppressWarnings("unchecked")
	public static ResultTransformer aliasToBean(Class target) {
		return (ResultTransformer) new GMAliasToBeanResultTransformer(target);
	}

}
