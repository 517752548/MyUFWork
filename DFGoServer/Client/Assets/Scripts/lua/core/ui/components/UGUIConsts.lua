---@type table<string, number> @ScrollList的布局类型
_G.ListLayoutType = {
	NONE       = 0, --无
	HORIZONTAL = 1, --横向紧密排列
	VERTICAL   = 2, --纵向紧密排列
	GRID       = 3, --等宽等高的格子
}

--动画list Item进入方向
_G.ItemEnterDirection = {
	rightToLeft = 1, --左侧到右侧
	leftToRight = 2, --右侧到左侧
	bottomToTop = 3, --下部到上部
	topToBottom = 3, --上部到上下
}