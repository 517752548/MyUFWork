package com.imop.lj.gameserver.util;

import java.awt.Color;
import java.awt.Graphics2D;
import java.awt.Point;
import java.awt.Polygon;
import java.awt.image.BufferedImage;

public class MapUtil {
	// masks的区域
	// _______
	// |  /\  |
	// | /  \ |
	// |/    \|
	// |\    /|
	// | \  / |
	// |__\/__|
	public static final byte AREA_CENTER = 0;
	public static final byte AREA_NORTHEAST = 1;
	public static final byte AREA_SOUTHEAST = 2;
	public static final byte AREA_NORTHWEST = 3;
	public static final byte AREA_SOUTHWEST = 4;
	
	//XXX 每张地图的都是这个数
	public static final int TILE_WIDTH = 64;
	public static final int TILE_HEIGHT = 64;
	
	public static final int HALF_TILE_WIDTH = TILE_WIDTH / 2;
	public static final int HALF_TILE_HEIGHT = TILE_HEIGHT / 2;

	private static byte[][] masks;
	
	public static void initMask() {
		int width = TILE_WIDTH;
		int height = TILE_HEIGHT;
		
		Polygon poly = new Polygon();
		poly.addPoint(width/2, 0);
		poly.addPoint(width, height/2);
		poly.addPoint(width/2, height);
		poly.addPoint(0, height/2);
		
		
		BufferedImage bufimage = new BufferedImage(width, height, BufferedImage.TYPE_INT_BGR);
		Graphics2D g2d = bufimage.createGraphics();
		g2d.setColor(Color.WHITE);
		g2d.fillRect(0, 0, width, height);
		
		g2d.setColor(Color.BLACK);
		g2d.fillPolygon(poly);

		masks = new byte[height][width];
		int w2 = width/2;
		int h2 = height/2;
		for(int row=0; row<height; row++){
			for(int col=0; col<width; col++){
				int rgb = bufimage.getRGB(col, row);
				if(rgb == 0xFF000000){
					masks[row][col] = AREA_CENTER;
				}
				else if(row < h2){
					if(col < w2){
						masks[row][col] = AREA_NORTHWEST;
					}
					else{
						masks[row][col] = AREA_NORTHEAST;
					}
				}
				else{
					if(col < w2){
						masks[row][col] = AREA_SOUTHWEST;
					}
					else{
						masks[row][col] = AREA_SOUTHEAST;
					}
				}
			}
		}
		
		g2d.dispose();
		bufimage = null;
	}
	
	/**
	 * 返回tile坐标对应的网格的中点坐标
	 * @param x	tile所在列坐标
	 * @param y	tile所在行坐标
	 * @return
	 */
	public static Point tile2ImageCoord(int x, int y) {
		Point rt;
        if(y%2 == 0){
        	rt = new Point(x*TILE_WIDTH, y*HALF_TILE_HEIGHT);
        }
        else{
        	rt = new Point(x*TILE_WIDTH+HALF_TILE_WIDTH, y*HALF_TILE_HEIGHT);
        }
        return rt;
		
	}
	
	public static Point tile2ImageCoord(String str) {
		Point pt = null;
		try {
			if(str!=null){
				String[] coords = str.split(",");
				if(coords.length==2){
					pt =  tile2ImageCoord(Integer.parseInt(coords[0]), Integer.parseInt(coords[1]));
				}	
			}
		} catch (NumberFormatException e) {
			e.printStackTrace();
			return  null;
		}
		return pt;
		
	}
	
	public static Point image2TileCoord(int x, int y) {
		Point centerCellCoords = new Point(x/TILE_WIDTH, y/TILE_HEIGHT*2+1);
		
		int offx = Math.abs(x%TILE_WIDTH);
		int offy = Math.abs(y%TILE_HEIGHT);
		switch(masks[offy][offx]){
			case AREA_NORTHEAST:{
				centerCellCoords.x+=1;
				centerCellCoords.y --;
				break;
			}
			case AREA_NORTHWEST:{
				centerCellCoords.y --;
				break;
			}
			case AREA_SOUTHEAST:{
				centerCellCoords.x +=1;
				centerCellCoords.y ++;
				break;
			}
			case AREA_SOUTHWEST:{
				centerCellCoords.y ++;
				break;
			}
		}
		if(x<0){
			centerCellCoords.x = -centerCellCoords.x;
		}
		if(y<0){
			centerCellCoords.y = -centerCellCoords.y;
		}
		return centerCellCoords;
		
	}
	
	public static void main(String[] args) {
		initMask();
		// 计算各个地图的尺寸
//		System.out.println(image2TileCoord(22, 10));
		System.out.println(image2TileCoord(1318, 1227));		// 新手村，竖直方向+16  java.awt.Point[x=1376,y=1296]  1376, 1312
		System.out.println(image2TileCoord(1120, 1193));
//		System.out.println(tile2ImageCoord(74, 149));		// 未来之城，竖直方向+16  java.awt.Point[x=4768,y=2384]  4768, 2400
//		System.out.println(tile2ImageCoord(155, 391));		// 问道新手村，竖直方向+16  java.awt.Point[x=9952,y=6256]  9952, 6272
	
	}

}
