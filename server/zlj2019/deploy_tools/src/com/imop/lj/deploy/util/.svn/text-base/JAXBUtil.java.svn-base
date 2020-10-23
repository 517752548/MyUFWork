package com.imop.lj.deploy.util;

import java.io.IOException;
import java.io.Reader;
import java.io.Writer;

import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import javax.xml.bind.Unmarshaller;

/**
 *
 * @see com.mop.tr.core.util.JAXBUtil
 *
 * 为了使deploy_tools不依赖core包而将其 单独拷贝到此
 *
 */
public class JAXBUtil {
	public static void write(Object xmlObject, Writer writer) {
		JAXBContext _context = null;
		try {
			_context = JAXBContext.newInstance(xmlObject.getClass());
			Marshaller _marshaller = _context.createMarshaller();
			_marshaller.setProperty(Marshaller.JAXB_ENCODING, "UTF-8");
			_marshaller.setProperty(Marshaller.JAXB_FORMATTED_OUTPUT, Boolean.TRUE);
			_marshaller.marshal(xmlObject, writer);
		} catch (JAXBException e) {
			throw new RuntimeException(e);
		} finally {
			try {
				writer.close();
			} catch (IOException e) {
			}
		}
	}

	@SuppressWarnings("unchecked")
	public static <T> T read(Class<T> xmlObjectClass, Reader reader) {
		JAXBContext _context = null;
		try {
			_context = JAXBContext.newInstance(xmlObjectClass);
			Unmarshaller _unmarshaller = _context.createUnmarshaller();
			return (T) _unmarshaller.unmarshal(reader);
		} catch (JAXBException e) {
			throw new RuntimeException(e);
		} finally {
			try {
				reader.close();
			} catch (IOException e) {
			}
		}
	}
}
