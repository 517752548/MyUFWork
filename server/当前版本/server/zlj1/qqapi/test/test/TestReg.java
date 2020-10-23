package test;

import org.junit.Test;

public class TestReg {

	@Test
	public void test() {
		String text = "10.30.125.10";
		String regex = "^(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|[1-9])\\."
                + "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)\\."
                + "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)\\."
                + "(1\\d{2}|2[0-4]\\d|25[0-5]|[1-9]\\d|\\d)$";
        // 判断ip地址是否与正则表达式匹配
        if (text.matches(regex)) {
            // 返回判断信息
            System.out.println( text + "\n是一个合法的IP地址！");
        } else {
            // 返回判断信息
        	System.out.println( text + "\n不是一个合法的IP地址！");
        }
	}

}
