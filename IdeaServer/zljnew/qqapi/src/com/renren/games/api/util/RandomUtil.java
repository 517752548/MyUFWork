package com.renren.games.api.util;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;

/**
 * Created by wyn on 16/3/10.
 */
public class RandomUtil {

    private static Random random = new Random();

    /**
     * 获取一个范围内的随机值
     *
     * @param randomMin
     *            区间起始值
     * @param randomMax
     *            区间结束值
     * @return 返回左开右闭区间的一个随机值
     */
    public static int nextInt(int randomMin, int randomMax) {
        int randomBase = randomMax - randomMin;
        if (randomBase < 0) {
            throw new IllegalArgumentException(
                    "randomMax must be bigger than randomMin");
        } else if (randomBase == 0) {
            return randomMin;
        } else {
            return (random.nextInt(randomBase) + randomMin);
        }
    }

    /**
     * 获取一个范围内的随机值结果为闭区间
     *
     * @param randomMin
     *            区间起始值
     * @param randomMax
     *            区间结束值
     * @return 返回全闭区间的一个随机值
     */
    public static int nextEntireInt(int randomMin, int randomMax) {
        int randomBase = randomMax - randomMin +1;
        if (randomBase < 0) {
            throw new IllegalArgumentException(
                    "randomMax must be bigger than randomMin");
        } else if (randomBase == 0) {
            return randomMin;
        } else {
            return (random.nextInt(randomBase) + randomMin);
        }
    }

    /**
     * 返回命中对象，按照随机基数取出命中对象
     *
     * @param <T>
     * @param randomList
     *            命中对象随机概率，要求按顺序概率从小到大，随机列表是累加的，假设a概率为1000，b概率为1000，传入列表是[1000,
     *            2000]
     * @param list
     *            命中对象 注：命中对象与随机概率对象长度一致，如果没有对象命中返回为空
     * @param baseRandom
     *            随机基数
     * @return
     */
    public static <T> T hitObject(List<Integer> randomList, List<T> objectList, int baseRandom) {
        // 如果随机基数小于等于0
        if (baseRandom <= 0) {
            return null;
        }

        // 如果随机列表长度为0
        if (randomList == null || randomList.size() <= 0) {
            return null;
        }

        // 如果随机对列表长度为0
        if (objectList == null || objectList.size() <= 0) {
            return null;
        }

        // 如果随机对象列表长度不等于随机列表长度
        if (randomList.size() != objectList.size()) {
            return null;
        }

        // 生成随机数
        int hitNum = betweenInt(1, baseRandom, true);

        // 索引下标
        int index = 0;
        for (int random : randomList) {
            // 如果命中
            if (hitNum <= random) {
                return objectList.get(index);
            }
            index++;
        }

        // 如果没有命中，返回空对象
        return null;
    }

    /**
     * 返回命中对象，从集合中抽取随机概率相等的数量为num的对象集合
     *
     * @param <T>
     * @param objectList
     *            集合对象
     * @param baseRandom
     * @param num
     * @return
     */
    public static <T> List<T> hitObjects(List<T> objectList, int num) {
        List<T> result = new ArrayList<T>();

        // 如果抽取对象数量小于等于0
        if (num <= 0) {
            return null;
        }

        // 如果随机对列表长度为0
        if (objectList == null || objectList.size() <= 0) {
            return null;
        }

        // 当num数量大于列表中数量，修正num，num为列表长度
        int getNum = num;
        if (num > objectList.size()) {
            getNum = objectList.size();
        }

        // 克隆参数列表
        List<T> cloneObjectList = new ArrayList<T>();
        for (T t : objectList) {
            cloneObjectList.add(t);
        }

        //如果全部取出
        if(getNum == objectList.size()){
            return cloneObjectList;
        }

        // 抽取getNum次
        for (int i = 0; i < getNum; i++) {
            // 随机一个数，取下标0到列表数量-1的数，即列表下标
            int getIndex = betweenInt(0, cloneObjectList.size() - 1, true);
            // 获得对象
            T t = cloneObjectList.get(getIndex);
            // 存入结果
            result.add(t);
            // 删除克隆列表中对象
            cloneObjectList.remove(getIndex);
        }

        return result;
    }

    /**
     * 随机中间值
     *
     * @param min
     *            最大值
     * @param max
     *            最小值
     * @param include
     *            是否是闭区间如返回[1,100]值为true， 如(1,100)值为false，目前不支持左开右闭和左闭右开，
     *            当true时，返回min到max之间的数包括 1 和 100，，当false时，返回min到max之间的数不包括 1 和
     *            100，
     * @return
     */
    public static int betweenInt(int min, int max, boolean include) {
        if (min > max)
            throw new IllegalArgumentException("最小值[" + min + "]不能大于最大值[" + max + "]");
        if ((!include) && (min == max)) {
            throw new IllegalArgumentException("不包括边界值时最小值[" + min + "]不能等于最大值[" + max + "]");
        }

        if (include)
            max++;
        else {
            min++;
        }
        return (int) (min + Math.random() * (max - min));
    }

    public static void main(String[] args) {
        for (int i = 0; i < 1000; i++) {

            String pwd = nextEntireInt(1, 9) + "" + nextEntireInt(0, 9) + "" + nextEntireInt(0, 9) + "" +
                    + nextEntireInt(0, 9) + "" + nextEntireInt(0, 9) + "" + + nextEntireInt(0, 9) + "";

            System.out.println(pwd);
        }
    }
}
