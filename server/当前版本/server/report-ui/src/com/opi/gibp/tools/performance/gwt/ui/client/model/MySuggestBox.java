/**
 * 
 */
package com.opi.gibp.tools.performance.gwt.ui.client.model;

import com.google.gwt.user.client.Window;
import com.google.gwt.user.client.ui.MouseListener;
import com.google.gwt.user.client.ui.MultiWordSuggestOracle;
import com.google.gwt.user.client.ui.SuggestBox;
import com.google.gwt.user.client.ui.Widget;

/**
 * @author Administrator
 *
 */
public class MySuggestBox extends SuggestBox implements MouseListener{

	/* (non-Javadoc)
	 * @see com.google.gwt.user.client.ui.MouseListener#onMouseDown(com.google.gwt.user.client.ui.Widget, int, int)
	 */
	@Override
	public void onMouseDown(Widget sender, int x, int y) {
		Window.alert(sender.toString());
	}

	/* (non-Javadoc)
	 * @see com.google.gwt.user.client.ui.MouseListener#onMouseEnter(com.google.gwt.user.client.ui.Widget)
	 */
	@Override
	public void onMouseEnter(Widget sender) {
		Window.alert(sender.toString());
		
	}

	/* (non-Javadoc)
	 * @see com.google.gwt.user.client.ui.MouseListener#onMouseLeave(com.google.gwt.user.client.ui.Widget)
	 */
	@Override
	public void onMouseLeave(Widget sender) {

		Window.alert(sender.toString());
	}

	/* (non-Javadoc)
	 * @see com.google.gwt.user.client.ui.MouseListener#onMouseMove(com.google.gwt.user.client.ui.Widget, int, int)
	 */
	@Override
	public void onMouseMove(Widget sender, int x, int y) {

		Window.alert(sender.toString());
	}

	/* (non-Javadoc)
	 * @see com.google.gwt.user.client.ui.MouseListener#onMouseUp(com.google.gwt.user.client.ui.Widget, int, int)
	 */
	@Override
	public void onMouseUp(Widget sender, int x, int y) {

		Window.alert(sender.toString());
	}
	
	public MySuggestBox(MultiWordSuggestOracle oracle){
		super(oracle);
	}
	
}
